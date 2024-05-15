using EmguClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemConfigFile;
using EmguClass;
using VisionSystemAmetek.ProcessWindows;
using EmguClass.Resources;

namespace VisionSystemAmetek.TrainForm
{
    public partial class TrainUserControl : UserControl
    {
        #region Main

        Bitmap ProcessImage;
        Bitmap JustProcess;
        Bitmap OriginalImage;
        private ProjectConfig Project;
        private string _CurrentModel = string.Empty;

        public TrainUserControl()
        {
            InitializeComponent();
            string[] captype = new string[] { "Webcam", "IndustrialCam", "File" };
            comboBoxCaptureType.DataSource = captype;
            buttonLoadCapture.Enabled = false;
            buttonReload.Hide();
            comboBoxModels.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region UpdateWindow

        public void SetProject(ProjectConfig _Project)
        {
            Project = _Project;
            comboBoxCaptureType.Text = Project.captureType.ToString();
            reload();
        }

        public ProjectConfig GetProject()
        {
            return Project;
        }

        private void comboBoxCaptureType_SelectedValueChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            reload();
        }

        protected void reload()
        {
            if (Project == null) return;
            Project.captureType = SetCaptureType(comboBoxCaptureType.Text);
            SetImageLoadMethod(Project.captureType);
            reloadListRoi();
            reloadListCat();
            reloadListProcess();
            reloadListSteps();
            reloadModels();
            
        }

        protected void reloadModels()
        {
            comboBoxModels.DataSource = Project.Models.Select(x => x.ModelName).ToList();
        }

        protected void reloadListProcess()
        {
            listBoxProcessImage.DataSource = Project.ProcessImages.Select(x => x.Name).ToList();
        }

        protected void reloadListRoi()
        {
            listBoxRois.DataSource = Project.RoiClasses.Select(x => x.Name).ToList();
        }

        protected void reloadListSteps()
        {
            //listBoxTestSteps.DataSource = Project.TestSteps.Select(x => x.TestStepName).ToList();

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

        protected void reloadListCat()
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
            }
        }

        protected void SetWebCam()
        {
            buttonLoadCapture.Text = "Capture";
            buttonLoadCapture.Enabled = true;
            buttonReload.Hide();
        }
        protected void SetFile()
        {
            buttonLoadCapture.Text = "Load";
            buttonLoadCapture.Enabled = true;
            LoadFile(Project.FileCapturePath);
            buttonReload.Show();


        }
        protected void SetIndustrialCam()
        {
            buttonLoadCapture.Text = "Capture";
            buttonLoadCapture.Enabled = true;
            buttonReload.Hide();
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


        private void buttonLoadCapture_Click(object sender, EventArgs e)
        {
            ExecuteCapture(Project.captureType);
        }

        protected void ExecuteCapture(CaptureType type)
        {
            OriginalImage = null;
            switch (type)
            {
                case CaptureType.Webcam:
                    OriginalImage = WebcamCapture(0);
                    ProcessImage = OriginalImage;
                    break;
                case CaptureType.File:
                    OriginalImage = LoadFile();
                    ProcessImage = OriginalImage;
                    break;
                case CaptureType.IndustrialCam:
                    break;
            }
            if (OriginalImage == null) buttonRoiAdd.Hide();
            else
            {
                buttonRoiAdd.Show();
                pictureBoxMain.Image = OriginalImage;
            }
        }

        protected Bitmap WebcamCapture(int CamNum)
        {
            return VisionClass.capture(CamNum);
        }

        protected Bitmap LoadFile()
        {

            OpenFileDialog of = new OpenFileDialog();
            if (Project.LastDirFile != string.Empty) of.InitialDirectory = Project.LastDirFile;
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

        private void buttonAddCategori_Click(object sender, EventArgs e)
        {
            using (CategoriForm cat = new CategoriForm(Project.Categories))
            {
                cat.ShowDialog();
                if (cat.succes)
                {
                    if (Project.Categories == null) Project.Categories = new List<string>();
                    Project.Categories.Add(cat.CategoryName);
                    reloadListCat();
                }
            }
        }

        private void buttonDeleteCategori_Click(object sender, EventArgs e)
        {
            if (listBoxCat.Text != string.Empty)
            {
                Project.Categories.Remove(listBoxCat.SelectedItem.ToString());
                reloadListCat();
            }

        }

        private void listBoxCat_DoubleClick(object sender, MouseEventArgs e)
        {

            var data = (ListBox)sender;
            using (GetPatternsForm p = new GetPatternsForm(Project, ProcessImage, data.SelectedItem.ToString(), Project.TraiPath))
            {
                p.ShowDialog();

                if (p.Success)
                {

                }
            }
        }
        #endregion

        #region RoiRegion

        private void buttonRoiDelete_Click(object sender, EventArgs e)
        {
            Project.RoiClasses.RemoveAll(x => x.Name == listBoxRois.Text);
            reloadListRoi();
        }

        private void buttonRoiAdd_Click(object sender, EventArgs e)
        {
            using (CreateROI roiwindow = new CreateROI((Bitmap)pictureBoxMain.Image, listBoxRois.Items.OfType<string>().ToArray()))
            {
                roiwindow.ShowDialog();
                if (roiwindow.Success)
                {
                    if (Project.RoiClasses == null) Project.RoiClasses = new List<RoiClass>();
                    Project.RoiClasses.Add(roiwindow.NewRoi);
                    reloadListRoi();
                }
            }
        }
        #endregion

        #region ProcessImage
        //private Bitmap GetLastImage()
        //{
        //    return image;
        //}

        private void buttonAddProcessImage_Click(object sender, EventArgs e)
        {
            using (FiltersForm filters = new FiltersForm(OriginalImage))
            {
                filters.ShowDialog();
                Project.ProcessImages.Add(filters.processImage);
                reloadListProcess();
            }
        }

        private void buttonDeleteProcessImage_Click(object sender, EventArgs e)
        {
            if (listBoxProcessImage.Text != string.Empty)
            {
                Project.ProcessImages.RemoveAll(x => x.Name == listBoxProcessImage.Text);
                reloadListProcess();
            }
        }



        #endregion

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            ProcessImage = OriginalImage;
            foreach (var d in Project.ProcessImages)
            {
                ProcessImageTypes type = (ProcessImageTypes)Enum.Parse(typeof(ProcessImageTypes), d.Type);
                switch (type)
                {
                    case ProcessImageTypes.Led_Ambar:
                        ProcessImage = VisionClass.Ambar_DarkBackground(ProcessImage);
                        JustProcess = ProcessImage;
                        pictureBoxMain.Image = ProcessImage;
                        break;
                }
            }
        }

        private void listBoxRois_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var d = Project.RoiClasses.Where(x => x.Name == listBoxRois.Text).First();
            if (d != null)
            {
                ProcessImage = VisionClass.DrawRoi(ProcessImage, d.Rectangle, d.Name);
                pictureBoxMain.Image = ProcessImage;
            }
        }

        #region TestSteps
        private void buttonAddTestSteps_Click(object sender, EventArgs e)
        {
            using (StepTestWindow stepwidnows = new StepTestWindow(Project, JustProcess))
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
            reloadListSteps();
        }

        #endregion

        #region Models

        private void buttonModelsAdd_Click(object sender, EventArgs e)
        {
            using (CreateModel modelWindow = new CreateModel(Project.Models))
            {
                modelWindow.ShowDialog();
                if (modelWindow.success)
                {
                    Project.Models.Add(modelWindow.NewModel);
                }
            }
            reloadModels();
        }

        private void buttonModelsDelete_Click(object sender, EventArgs e)
        {
            Project.Models.RemoveAll(x => x.ModelName == comboBoxModels.Text);
            reloadModels();
        }

        private void comboBoxModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentModel = comboBoxModels.Text;
            reloadListSteps();
        }

        #endregion

        #region Update TestSteps



        #endregion


    }
}
