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

namespace VisionSystemAmetek.TrainForm
{
    public partial class CreateROI : Form
    {
        Rectangle rect;
        Point StartROI, EndROI;
        bool selecting, MouseDown;
        public bool Success;
        List<string> CurrentRoiNames = new List<string>();
        public RoiClass NewRoi =  null;

        public CreateROI(Bitmap image, string[] currentRoiNames)
        {
            InitializeComponent();
            rect = Rectangle.Empty;
            pictureBox.Image = image;
            panelMain.Hide();
            CurrentRoiNames = currentRoiNames.ToList<string>();
            buttonSave.Hide();
        }

        private void buttonValid_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxName.Text)) 
            {
                MessageBox.Show( "ROI name cannot be empty", "Create ROI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CurrentRoiNames.Contains(textBoxName.Text))
            {
                textBoxName.Enabled = false;
                panelMain.Show();
            }
            else MessageBox.Show("Type another name", "Create ROI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
            buttonSave.Hide();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Green, 3))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseDown)
            {
                MouseDown = false;
                buttonSave.Show();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            NewRoi = new RoiClass(textBoxName.Text, rect);
            Success = true;
            
            this.Close();
        }
    }
}
