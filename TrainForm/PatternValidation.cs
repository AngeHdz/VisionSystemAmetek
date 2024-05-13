using Emgu.CV;
using Emgu.CV.Structure;
using EmguClass;
using Microsoft.ML;
using MLClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.TrainForm
{
    public partial class PatternValidation : Form
    {
        FileInfo[] Files;
        MLModel mLModel;
        ProjectConfig Project;
        ImageList imagelist = new ImageList();
        Bitmap CurrentTemplate;
        Bitmap _Image;
        Bitmap _train;
        string _clase;
        Rectangle _roi;
        public ReportTrain _theBest;
        List<ReportTrain> reportTrains = new List<ReportTrain>();
        public bool _Success = false;
        public PatternValidation(ref MLModel model, ProjectConfig project, Bitmap image, Rectangle Roi, string Path, string Clase)
        {
            InitializeComponent();
            DirectoryInfo d = new DirectoryInfo(Path);
            Files = d.GetFiles("*.jpg");
            mLModel = model;
            Project = project;
            _Image = image;
            _clase = Clase;
            _roi = Roi;
            listViewImage.View = View.LargeIcon;
            imagelist.ImageSize = new Size(100, 100);
            listViewImage.LargeImageList = imagelist;
            labelClase.Text = Clase;
            buttonDone.Hide();
        }

        private void buttonGetBest_Click(object sender, EventArgs e)
        {
            buttonGetBest.Enabled = false;
            reportTrains.Clear();
            pictureBoxCurrentsnap.Image = null;
            pictureBoxBest.Image = null;
            listViewImage.Items.Clear();
            Task.Run(() =>
            {
                foreach (FileInfo file in Files)
                {
                    Test(file.FullName);
                }
                ShowTheBest();
                ProcessTheBest();
            });
        }
        public void ProcessTheBest()
        {
            int resultScore = 0;
            VisionClass.PatternMatch(_Image, CurrentTemplate, 800, _roi, _clase, false, out resultScore, ref _train);
            this.Invoke((Action)delegate
            {
                pictureBoxCurrentsnap.Image = _train;
            });
            if (resultScore <= 800)
            {
                UpdateTitle($"{_clase} -  Acc: {resultScore}", false);
                return;
            }
            Thread.Sleep(100);
            Report result = new Report();
            mLModel.Test(VisionClass.ImageToByteArray(_train.ToImage<Bgr, byte>()), ref result.key, ref result.acc, Project.ModelPath);

            if (_clase == result.key && result.acc >= .8)
            {
                UpdateTitle($"{_clase} - Key:{result.key}, Acc: {result.acc}", true);
            }
            else
            {
                UpdateTitle($"{_clase} - Key:{result.key}, Acc: {result.acc}", false);
            }
        }

        public void UpdateTitle(string Text, bool Pass)
        {
            this.Invoke((Action)delegate
            {
                if (Pass)
                {
                    buttonDone.Show();
                    labelClase.ForeColor = Color.Black;
                }
                else
                {
                    buttonDone.Hide();
                    labelClase.ForeColor = Color.Red;
                }
                labelClase.Text = Text;

                buttonGetBest.Enabled = true;
            });
        }

        public void ShowTheBest()
        {
            var d = reportTrains.Max(x => x.Acc);
            _theBest = reportTrains.First(x => x.Acc == d);
            this.Invoke((Action)delegate
            {
                CurrentTemplate = _theBest.Image;
                pictureBoxBest.Image = _theBest.Image;
            });
            Thread.Sleep(100);
        }


        public void Test(string currentPath)
        {
            Image<Bgr, byte> train = new Image<Bgr, byte>(currentPath);
            Report report = new Report();
            mLModel.Test(VisionClass.ImageToByteArray(train), ref report.key, ref report.acc, Project.ModelPath);

            this.Invoke((Action)delegate
            {
                reportTrains.Add(new ReportTrain(report.key, report.acc, train.ToBitmap(), currentPath));
                AddImage($"{report.key}-{report.acc}", train.ToBitmap());
            });
        }

        private void AddImage(string title, Bitmap image)
        {
            int index = imagelist.Images.Count;
            imagelist.Images.Add(image);
            ListViewItem item = new ListViewItem(title, index);
            listViewImage.Items.Add(item);
        }

        private class Report()
        {
            public string key = string.Empty;
            public float acc = 0.0f;
        }

        public class ReportTrain
        {
            public float Acc { get; set; } = 0.0f;
            public Bitmap? Image { get; set; }
            public string Key { get; set; }
            public string Path { get; set; }

            public ReportTrain(string key, float acc, Bitmap image, string path)
            {
                Key = key;
                Acc = acc;
                Image = image;
                Path = path;
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            _Success = true;
            this.Close();
        }
    }



}
