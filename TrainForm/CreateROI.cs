using VisionSystemConfigFile;

namespace VisionSystemAmetek.TrainForm
{
    public partial class CreateROI : Form
    {
        private Rectangle rect;
        private Point StartROI, EndROI;
        //private bool selecting;
        private bool MouseDown;
        public bool Success;
        private List<string> CurrentRoiNames = new List<string>();
        public RoiClass NewRoi = null;

        public CreateROI(Bitmap image, string[] currentRoiNames)
        {
            InitializeComponent();
            rect = Rectangle.Empty;
            pictureBox.Image = image;
            panelMain.Hide();
            CurrentRoiNames = [.. currentRoiNames];
            buttonSave.Hide();
        }

        private void ButtonValid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("ROI name cannot be empty", "Create ROI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CurrentRoiNames.Contains(textBoxName.Text))
            {
                textBoxName.Enabled = false;
                panelMain.Show();
            }
            else
            {
                MessageBox.Show("Type another name", "Create ROI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
            buttonSave.Hide();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
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

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                e.Graphics.DrawRectangle(new(Color.Green, 3), rect);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseDown)
            {
                MouseDown = false;
                buttonSave.Show();
            }
        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            NewRoi = new RoiClass(textBoxName.Text, rect);
            Success = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
