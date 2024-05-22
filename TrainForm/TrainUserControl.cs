using EmguClass;
using System.Data;
using VisionSystemConfigFile;
using VisionSystemAmetek.ProcessWindows;
using EmguClass.Resources;
using EmguClass.Camera;
using Emgu.CV;

namespace VisionSystemAmetek.TrainForm
{
    public partial class TrainUserControl : UserControl
    {
        #region Main

        private Bitmap? ProcessImage;
        private Bitmap JustProcess;
        private Bitmap? OriginalImage;
        private ProjectConfig Project;
        private string _CurrentModel = string.Empty;
        private WebCapture? _WCap;

        public TrainUserControl()
        {
            InitializeComponent();
            string[] captype = ["Webcam", "IndustrialCam", "File"];
            comboBoxCaptureType.DataSource = captype;
            buttonLoadCapture.Enabled = false;
            buttonReload.Hide();
            comboBoxModels.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDownCam.Hide();
            buttonSnap.Hide();
        }
        #endregion

        #region UpdateWindow

        public void SetProject(ProjectConfig project)
        {
            Project = project;
            comboBoxCaptureType.Text = Project.captureType.ToString();
            Reload();
        }

        public ProjectConfig GetProject()
        {
            return Project;
        }

        private void ComboBoxCaptureType_SelectedValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            if (Project == null)
            {
                return;
            }
            Project.captureType = SetCaptureType(comboBoxCaptureType.Text);
            SetImageLoadMethod(Project.captureType);
            ReloadListRoi();
            ReloadListCat();
            ReloadListProcess();
            ReloadListSteps();
            ReloadModels();
        }

        protected void ReloadModels()
        {
            if (Project.Models.Count > 0)
            {
                comboBoxModels.DataSource = Project.Models.Select(x => x.ModelName).ToList();
            }
        }

        protected void ReloadListProcess()
        {
            if (Project.ProcessImages.Count > 0 && Project.ProcessImages != null)
            {
                listBoxProcessImage.DataSource = Project.ProcessImages.Select(x => x.Name).ToList();
            }
        }

        protected void ReloadListRoi()
        {
            if (Project.RoiClasses.Count > 0)
            {
                listBoxRois.DataSource = Project.RoiClasses.Select(x => x.Name).ToList();
            }
        }

        protected void ReloadListSteps()
        {
            int i = 0;
            foreach (Models d in Project.Models)
            {
                if (Project.Models[i].ModelName == _CurrentModel)
                {
                    listBoxTestSteps.DataSource = Project.Models[i].TestSteps.Select(x => x.TestStepName).ToList();
                    return;
                }
                i++;
            }
        }

        protected void ReloadListCat()
        {
            listBoxCat.DataSource = Project.Categories.ToArray();
        }

        protected void SetImageLoadMethod(CaptureType type)
        {
            switch (type)
            {
                case CaptureType.Webcam:
                    SetWebCam();
                    break;
                case CaptureType.File:
                    SetFile();
                    break;
                case CaptureType.IndustrialCam:
                    SetIndustrialCam();
                    break;
                default:
                    break;
            }
        }

        protected void SetWebCam()
        {
            buttonLoadCapture.Text = "Capture";
            buttonLoadCapture.Enabled = true;
            buttonReload.Hide();
            numericUpDownCam.Show();
            numericUpDownCam.Value = Project.CamNum;
        }
        protected void SetFile()
        {
            _WCap?.Dispose();
            buttonLoadCapture.Text = "Load";
            buttonLoadCapture.Enabled = true;
            LoadFile(Project.FileCapturePath);
            buttonReload.Show();
            buttonSnap.Hide();
            numericUpDownCam.Hide();

        }
        protected void SetIndustrialCam()
        {
            _WCap?.Dispose();
            buttonLoadCapture.Text = "Capture";
            buttonLoadCapture.Enabled = true;
            buttonReload.Hide();
            buttonSnap.Hide();
            numericUpDownCam.Hide();
        }

        public static CaptureType SetCaptureType(string text)
        {
            try
            {
                return (CaptureType)Enum.Parse(typeof(CaptureType), text, true);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("El texto proporcionado no corresponde al tipo captura");
            }
        }


        private void ButtonLoadCapture_Click(object sender, EventArgs e)
        {
            ExecuteCapture(Project.captureType);
        }

        protected void ExecuteCapture(CaptureType type)
        {
            OriginalImage = null;
            switch (type)
            {
                case CaptureType.Webcam:
                    WebcamCapture();
                    break;
                case CaptureType.File:
                    OriginalImage = LoadFile();
                    ProcessImage = OriginalImage;
                    break;
                case CaptureType.IndustrialCam:
                    break;
                default:
                    break;
            }
            if (OriginalImage == null)
            {
                buttonRoiAdd.Hide();
            }
            else
            {
                buttonRoiAdd.Show();
                pictureBoxMain.Image = OriginalImage;
            }
        }

        protected void WebcamCapture()
        {
            if (buttonLoadCapture.Text == "Stop")
            {
                WcapStop();
                return;
            }
            buttonSnap.Show();
            if (_WCap == null)
            {
                _WCap = new WebCapture(Project.CamNum);
                _WCap.OnCapture += WCap_OnCapture;
            }
            buttonLoadCapture.Text = "Stop";
            _WCap.StartCapture();
            numericUpDownCam.Enabled = false;
            comboBoxCaptureType.Enabled = false;
        }

        private void WcapStop()
        {
            if (_WCap != null)
            {
                _WCap.Dispose();
                _WCap = null;
            }
            buttonLoadCapture.Text = "Connect";
            buttonSnap.Hide();
            numericUpDownCam.Enabled = true;
            comboBoxCaptureType.Enabled = true;
        }

        private void WCap_OnCapture(object? sender, CaptureArgs e)
        {

            if (pictureBoxMain.InvokeRequired)
            {
                pictureBoxMain.Invoke(new Action(() =>
                {
                    pictureBoxMain.Image = e.Image.ToBitmap();
                }));
            }
            else
            {
                pictureBoxMain.Image = e.Image.ToBitmap();
            }
        }

        protected Bitmap? LoadFile()
        {

            OpenFileDialog of = new();
            if (Project.LastDirFile != string.Empty)
            {
                of.InitialDirectory = Project.LastDirFile;
            }

            of.FilterIndex = 1;
            of.RestoreDirectory = false;
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Project.LastDirFile = new FileInfo(of.FileName).Directory.FullName;
                Project.FileCapturePath = of.FileName;
                return (Bitmap)Image.FromFile(of.FileName);
            }
            return null;
        }

        protected void LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            try
            {
                OriginalImage = (Bitmap)Image.FromFile(path);
                ProcessImage = OriginalImage;
                pictureBoxMain.Image = OriginalImage;
                return;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return;
            }
        }
        #endregion

        #region Cancel

        public void Cancel()
        {
            pictureBoxMain.Image = null;
            ProcessImage = null;
            OriginalImage = null;
        }

        #endregion

        #region category

        private void ButtonAddCategori_Click(object sender, EventArgs e)
        {
            using CategoriForm cat = new(Project.Categories);
            cat.ShowDialog();
            if (cat.succes)
            {
                Project.Categories ??= [];
                Project.Categories.Add(cat.CategoryName);
                ReloadListCat();
            }
        }

        private void ButtonDeleteCategori_Click(object sender, EventArgs e)
        {
            if (listBoxCat.Text != string.Empty)
            {
                Project.Categories.Remove(listBoxCat.SelectedItem.ToString());
                ReloadListCat();
            }

        }

        private void ListBoxCat_DoubleClick(object sender, MouseEventArgs e)
        {

            ListBox data = (ListBox)sender;
            using GetPatternsForm p = new(Project, ProcessImage, data.SelectedItem.ToString(), Project.TraiPath);
            p.ShowDialog();

            if (p.Success)
            {

            }
        }
        #endregion

        #region RoiRegion

        private void ButtonRoiDelete_Click(object sender, EventArgs e)
        {
            Project.RoiClasses.RemoveAll(x => x.Name == listBoxRois.Text);
            ReloadListRoi();
        }

        private void ButtonRoiAdd_Click(object sender, EventArgs e)
        {
            using CreateROI roiwindow = new((Bitmap)pictureBoxMain.Image, listBoxRois.Items.OfType<string>().ToArray());
            roiwindow.ShowDialog();
            if (roiwindow.Success)
            {
                if (Project.RoiClasses == null) Project.RoiClasses = [];
                Project.RoiClasses.Add(roiwindow.NewRoi);
                ReloadListRoi();
            }
        }
        #endregion

        #region ProcessImage
        //private Bitmap GetLastImage()
        //{
        //    return image;
        //}

        private void ButtonAddProcessImage_Click(object sender, EventArgs e)
        {
            using FiltersForm filters = new(OriginalImage);
            filters.ShowDialog();
            if (filters.Success)
            {
                Project.ProcessImages.Add(filters.processImage);
                ReloadListProcess();
            }
        }

        private void ButtonDeleteProcessImage_Click(object sender, EventArgs e)
        {
            if (listBoxProcessImage.Text != string.Empty)
            {
                Project.ProcessImages.RemoveAll(x => x.Name == listBoxProcessImage.Text);
                ReloadListProcess();
            }
        }



        #endregion

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            ProcessImage = OriginalImage;
            foreach (ProcessClass d in Project.ProcessImages)
            {
                ProcessImageTypes type = (ProcessImageTypes)Enum.Parse(typeof(ProcessImageTypes), d.Type);
                switch (type)
                {
                    case ProcessImageTypes.Led_Ambar:
                        ProcessImage = VisionClass.Ambar_DarkBackground(ProcessImage);
                        JustProcess = ProcessImage;
                        pictureBoxMain.Image = ProcessImage;
                        break;
                    case ProcessImageTypes.SmootMedian:
                        break;
                    case ProcessImageTypes.Canny:
                        break;
                    default:
                        break;
                }
            }
        }

        private void ListBoxRois_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RoiClass d = Project.RoiClasses.First(x => x.Name == listBoxRois.Text);
            if (d != null)
            {
                ProcessImage = VisionClass.DrawRoi(ProcessImage, d.Rectangle, d.Name);
                pictureBoxMain.Image = ProcessImage;
            }
        }

        #region TestSteps
        private void ButtonAddTestSteps_Click(object sender, EventArgs e)
        {
            using (StepTestWindow stepwidnows = new(Project, JustProcess))
            {
                stepwidnows.ShowDialog();
                if (stepwidnows._success)
                {
                    //Project.TestSteps.Add(stepwidnows.Step);
                    int i = 0;
                    foreach (Models d in Project.Models)
                    {
                        if (Project.Models[i].ModelName == _CurrentModel)
                        {
                            Project.Models[i].TestSteps.Add(stepwidnows.Step);
                        }
                        i++;
                    }
                }
            }
            ReloadListSteps();
        }

        #endregion

        #region Models

        private void ButtonModelsAdd_Click(object sender, EventArgs e)
        {
            using (CreateModel modelWindow = new(Project.Models))
            {
                modelWindow.ShowDialog();
                if (modelWindow.success)
                {
                    Project.Models.Add(modelWindow.NewModel);
                }
            }
            ReloadModels();
        }

        private void ButtonModelsDelete_Click(object sender, EventArgs e)
        {
            Project.Models.RemoveAll(x => x.ModelName == comboBoxModels.Text);
            ReloadModels();
        }

        private void ComboBoxModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentModel = comboBoxModels.Text;
            ReloadListSteps();
        }

        #endregion

        #region Update TestSteps



        #endregion


        private void NumericUpDownCam_ValueChanged(object sender, EventArgs e)
        {
            Project.CamNum = (int)numericUpDownCam.Value;
        }

        private void ButtonSnap_Click(object sender, EventArgs e)
        {
            if (_WCap == null)
            {
                return;
            }
            OriginalImage = _WCap.Snap();
            _WCap.StopCapture();
            buttonLoadCapture.Text = "Live";
            buttonRoiAdd.Show();
            buttonSnap.Hide();
        }
    }
}
