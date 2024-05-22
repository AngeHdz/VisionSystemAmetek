
using EmguClass.Resources;
using EmguClass.Resources.Setting.Interface;
using VisionSystemAmetek.ProcessWindows.UserForm;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.ProcessWindows
{
    public partial class FiltersForm : Form
    {
        private Bitmap Image;
        private Bitmap Imageprocessed;
        ProcessImageTypes type;
        SmoothMedianSet smoothMedianSet;
        ISettings Data;
        public ProcessClass processImage;
        public bool Success = false;
        public FiltersForm(Bitmap image)
        {
            InitializeComponent();

            comboBoxFilters.DataSource = new List<string>(Enum.GetNames(typeof(ProcessImageTypes)));
            Image = image;
            pictureBoxOriginal.Image = Image;
            pictureBoxProcessed.Image = Image;
            smoothMedianSet = new SmoothMedianSet();
            smoothMedianSet.UpdaData += SmoothMedianSet_UpdaData;
            smoothMedianSet.Hide();
            smoothMedianSet.Dock = DockStyle.Fill;
            panelTool.Controls.Add(smoothMedianSet);
        }

        private void SmoothMedianSet_UpdaData(object? sender, UserArgs e)
        {
            Data = e._Data;
            SmoothMedian sm = new("", Data);
            Imageprocessed = sm.execute(Image);
            pictureBoxProcessed.Image = Imageprocessed;
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = (ProcessImageTypes)Enum.Parse(typeof(ProcessImageTypes), comboBoxFilters.Text);
            switch (type)
            {
                case ProcessImageTypes.SmootMedian:
                    SmootMedian();
                    break;
                case ProcessImageTypes.Canny:
                    SmootMedian();
                    break;
                case ProcessImageTypes.Led_Ambar:
                    break;
                default:
                    break;
            }


        }

        private void SmootMedian()
        {
            smoothMedianSet?.Show();
        }

        private void canny()
        {
            smoothMedianSet.Hide();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            processImage = new ProcessClass(textBoxName.Text, comboBoxFilters.Text);
            Success = true;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
