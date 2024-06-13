using Emgu.CV;
using Emgu.CV.Structure;
using EmguClass;
using MLClass;
using System.Data;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.TrainForm
{
    internal enum logType
    {
        Error,
        Status,
        Log
    }
    public partial class StepTestWindow : Form
    {
        ProjectConfig ProjectConfig { get; set; }
        public bool _success = false;
        private bool loading = false;
        private Bitmap Original;
        private Bitmap RoiImage;
        private Bitmap Template;
        private Bitmap ImageProcessed;
        private RoiClass _RoiClass;
        private string TemplatePath = string.Empty;
        MLModel model;
        public TestStep Step = new TestStep();
        TestStepType type;

        public StepTestWindow(ProjectConfig project, Bitmap Image)
        {
            ProjectConfig = project;
            Original = Image;
            InitializeComponent();
            buttonSave.Enabled = false;
            pictureBoxMain.Image = Original;
            LoadModel();
            LodaSettings();
        }

        private void LoadModel()
        {
            model = new MLModel();
            model.OnReport += Model_OnReport;
            model.PathTraining = ProjectConfig.TraiPath;
            model.PathModel = ProjectConfig.ModelPath;
            model.mlContext.Log += MlContext_Log;
        }

        private void Model_OnReport(object? sender, EventMLStatus e)
        {
            PrintStatus(logType.Log, $"{e.Log}");
            if (e.Log == "Finish Training Model Process")
            {
                Invoke(delegate
                {
                    buttonTrain.Enabled = true;
                });
            }
        }

        private void MlContext_Log(object? sender, Microsoft.ML.LoggingEventArgs e)
        {

            PrintStatus(logType.Log, $"{e.RawMessage}");
        }

        private void LodaSettings()
        {
            loading = true;

            List<string> rois = new List<string>();
            rois.Add(string.Empty);
            rois.AddRange(ProjectConfig.RoiClasses.Select(x => x.Name).ToList());
            comboBoxRoi.DataSource = rois;
            comboBoxRoi.Text = string.Empty;

            List<string> Cat = new List<string>();
            Cat.Add(string.Empty);
            Cat.AddRange(ProjectConfig.Categories);
            comboBoxcat.DataSource = Cat;
            comboBoxcat.Text = string.Empty;

            List<string> type = new List<string>();
            type.Add(string.Empty);
            type.AddRange(Enum.GetNames(typeof(TestStepType)));
            comboBoxType.Text = string.Empty;
            comboBoxType.DataSource = type;

            loading = false;
        }



        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Step.Category = comboBoxcat.Text;
            Step.TemplateFile = TemplatePath;
            Step.ROI = comboBoxRoi.Text;
            Step.StepType = type;
            Step.TestStepName = textBoxName.Text;
            _success = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextboxName();
            if (loading)
            {
                return;
            }

            Drawroi();
            execute();
        }

        private void ComboBoxcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextboxName();
            UpdateTemplate(string.Empty);
            if (loading)
            {
                return;
            }
            execute();
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxType.Text))
            {
                type = (TestStepType)Enum.Parse(typeof(TestStepType), comboBoxType.Text);
            }

            if (loading)
            {
                return;
            }

            execute();
        }

        private bool IsComplete()
        {
            if (comboBoxRoi.Text == string.Empty) return false;
            if (comboBoxcat.Text == string.Empty) return false;
            if (comboBoxType.Text == string.Empty) return false;
            if (string.IsNullOrEmpty(TemplatePath)) return false;
            if (!File.Exists(ProjectConfig.ModelPath))
            {
                PrintStatus(logType.Error, $"Model is not trained");
                return false;
            }

            buttonSave.Enabled = true;
            return true;
        }

        private void UpdateTextboxName()
        {
            textBoxName.Text = string.Empty;
            string Roi = string.Empty;
            if (!string.IsNullOrEmpty(comboBoxcat.Text)) Roi = $"{comboBoxRoi.Text}_";
            else Roi = comboBoxRoi.Text;
            string name = $"{Roi}{comboBoxcat.Text}";
            textBoxName.Text = name;
        }

        private void Drawroi()
        {
            if (string.IsNullOrEmpty(comboBoxRoi.Text)) return;
            _RoiClass = ProjectConfig.RoiClasses.Where(x => x.Name == comboBoxRoi.Text).First();
            RoiImage = VisionClass.DrawRoi(Original, _RoiClass.Rectangle, _RoiClass.Name);
            pictureBoxMain.Image = RoiImage;
        }

        private void execute()
        {
            if (!IsComplete())
            {
                buttonSave.Enabled = false;
                return;
            }
            int resultScore = 0;
            Bitmap train = Template;

            ImageProcessed = VisionClass.PatternMatch(RoiImage, Template, 80, _RoiClass.Rectangle, comboBoxcat.Text, false, out resultScore, ref train);
            string key = string.Empty;
            float acc = 0;
            List<string> log = new List<string>();
            model.Test(VisionClass.ImageToByteArray(train.ToImage<Bgr, byte>()), ref key, ref acc, ref log, ProjectConfig.ModelPath);
            pictureBoxMain.Image = ImageProcessed;
            PrintStatus(logType.Status, $"Roi: {_RoiClass.Name},Find: {key}, ACC: {acc}");
            foreach (string d in log)
            {
                PrintStatus(logType.Status, d);
            }
        }

        private void PrintStatus(logType Type, string log)
        {
            string msg = string.Empty;
            switch (Type)
            {
                case logType.Error:
                    msg = $"Error: {log}";
                    break;
                case logType.Status:
                    msg = $"Status: {log}";
                    break;
                case logType.Log:
                    msg = $"{log} \n";
                    break;
            }
            Invoke(delegate
            {
                listBoxLog.Items.Add(msg);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            });
        }

        private void ButtonTrain_Click(object sender, EventArgs e)
        {
            buttonTrain.Enabled = false;
            model.Training();
            LoadModel();
        }

        #region Template
        private void ButtonFindFile_Click(object sender, EventArgs e)
        {
            string comboCategory = comboBoxcat.Text;
            using (PatternValidation Pattern = new PatternValidation(
                ref model,
                ProjectConfig,
                RoiImage,
                _RoiClass.Rectangle,
                $"{ProjectConfig.TraiPath}{comboCategory}",
                comboCategory))
            {
                Pattern.ShowDialog();

                if (Pattern._Success)
                {
                    Template = new Bitmap(Pattern._theBest.Path);
                    textBoxTemplate.Text = Pattern._theBest.Path;
                    TemplatePath = Pattern._theBest.Path;
                    execute();
                }
            }
        }

        private void UpdateTemplate(string path)
        {
            TemplatePath = path;
            textBoxTemplate.Text = TemplatePath;
        }
        #endregion


        private void StepTestWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
