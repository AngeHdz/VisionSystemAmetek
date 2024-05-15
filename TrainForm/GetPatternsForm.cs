using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemConfigFile;
using EmguClass;
using Emgu.CV;
using Emgu.CV.Structure;
using MLClass;
using Microsoft.VisualBasic.Logging;

namespace VisionSystemAmetek.TrainForm
{
    public partial class GetPatternsForm : Form
    {
        Bitmap Image;
        Bitmap Pattern;
        Rectangle rect;
        Point StartROI, EndROI;
        bool selecting, MouseDown;
        string nameCat;
        string pathtosave;
        public bool Success;
        public RoiClass NewRoi = null;
        ProjectConfig _project;
        MLModel model;
        public GetPatternsForm(ProjectConfig project,Bitmap image, string NameCat, string PathToSave)
        {
            InitializeComponent();
            labelNameCat.Text = NameCat;
            Image = image;
            pictureBoxMain.Image = Image;
            buttonDone.Hide();
            rect = Rectangle.Empty;
            nameCat = NameCat;
            pathtosave = PathToSave;
            _project = project;

            if (File.Exists(_project.ModelPath)) 
            {
                model = new MLModel();
                model.PathModel = _project.ModelPath;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            string pathDir = $"{pathtosave}\\{nameCat}";
            try 
            {
                if (!Directory.Exists(pathDir))
                {
                    Directory.CreateDirectory(pathDir);
                }
                VisionClass.saveRoi(Pattern.ToImage<Bgr, byte>(), nameCat, pathDir);
                Success = true;
            }
            catch(Exception ex) 
            {
                return;
            }
            this.Close();
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
            buttonDone.Hide();
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown)
            {
                int with = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
                int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
                rect = new Rectangle(Math.Min(StartROI.X, e.X),
                    Math.Min(StartROI.Y, e.Y),
                    with,
                    height);

                Refresh();
            }
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            labelLog.Text = string.Empty;
            if (MouseDown)
            {
                MouseDown = false;
                Pattern = VisionClass.GetRoi(rect, Image);
                pictureBoxPattern.Image = Pattern;

                string key = string.Empty;
                float acc = 0;
                model.Test(VisionClass.ImageToByteArray(Pattern.ToImage<Bgr, byte>()), ref key, ref acc, _project.ModelPath);
               
                labelLog.Text = $"Size - W:{Pattern.Width}p x H:{Pattern.Height}p\nCategory: {key}\n Acc: {acc}";
                if (acc >= .9 && nameCat == key)
                {
                    labelNameCat.ForeColor = Color.Black;
                    buttonDone.Show();
                    return;
                }

                if (model.Categories.Contains(key) && acc >= .8) 
                {
                    labelNameCat.ForeColor = Color.Red;
                    return;
                }

                if (!model.Categories.Contains(nameCat))
                {
                    buttonDone.Show();
                    return;
                }
                labelNameCat.ForeColor = Color.Red;
            }


        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Green, 3))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
