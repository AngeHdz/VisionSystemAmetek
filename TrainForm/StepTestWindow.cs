using EmguClass;
using MLClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.TrainForm
{
    enum logType
    {
        Error,
        Status,
        Log
    }
    public partial class StepTestWindow : Form
    {
        ProjectConfig ProjectConfig { get; set; }
        public bool success = true;
        private bool loading = false;
        private Bitmap Original;
        private Bitmap RoiImage;
        MLModel model;

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
            model.PathTraining = ProjectConfig.TraiPath;
            model.PathModel = ProjectConfig.ModelPath;
            model.mlContext.Log += MlContext_Log;
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



        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            Drawroi();
            execute();
        }

        private void comboBoxcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            execute();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            execute();
        }

        private bool IsComplete()
        {
            if (comboBoxRoi.Text == string.Empty) return false;
            if (comboBoxcat.Text == string.Empty) return false;
            if (comboBoxType.Text == string.Empty) return false;
            if (!File.Exists(ProjectConfig.ModelPath))
            {
                PrintStatus(logType.Error, $"Model is not trained");
                return false;
            }

            buttonSave.Enabled = true;
            return true;
        }

        private void Drawroi()
        {
            RoiClass d = ProjectConfig.RoiClasses.Where(x => x.Name == comboBoxRoi.Text).First();
            RoiImage = VisionClass.DrawRoi(Original, d.Rectangle, d.Name);
            pictureBoxMain.Image = RoiImage;
        }

        private void execute()
        {
            if (!IsComplete())
            {
                buttonSave.Enabled = false;
                return;
            }

            //VisionClass.PatternMatch(RoiImage, d.Template, MinScore, item.Rectangle, d.Name, false, out resultScore, ref train);
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
            this.Invoke((Action)delegate
            {
                textBoxLog.Text += msg;
            });
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            model.Training();
            LoadModel();
        }
    }
}
