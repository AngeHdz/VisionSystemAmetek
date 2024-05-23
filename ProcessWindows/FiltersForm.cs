
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
        public bool Success;
        private bool isSyncing;
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

            panelOriginal.MouseWheel += PanelOriginal_MouseWheel;
            panelProcessed.MouseWheel += PanelProcessed_MouseWheel;
        }


        private void SmoothMedianSet_UpdaData(object? sender, UserArgs e)
        {
            Data = e._Data;
            SmoothMedian sm = new("", Data);
            Imageprocessed = sm.execute(Image);
            pictureBoxProcessed.Image = Imageprocessed;
            SynchronizeScroll(panelOriginal, panelProcessed);
        }

        private void ComboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = (ProcessImageTypes)Enum.Parse(typeof(ProcessImageTypes), comboBoxFilters.Text);
            switch (type)
            {
                case ProcessImageTypes.SmootMedian:
                    SmootMedian();
                    break;
                case ProcessImageTypes.Canny:
                    Canny();
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

        private void Canny()
        {
            smoothMedianSet.Hide();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PanelOriginal_Scroll(object sender, ScrollEventArgs e)
        {
            if (!isSyncing)
            {
                isSyncing = true;
                SynchronizeScroll(panelOriginal, panelProcessed);
                isSyncing = false;
            }
        }

        private void PanelProcessed_Scroll(object sender, ScrollEventArgs e)
        {
            if (!isSyncing)
            {
                isSyncing = true;
                SynchronizeScroll(panelProcessed, panelOriginal);
                isSyncing = false;
            }
        }


        private void PanelProcessed_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (!isSyncing)
            {
                isSyncing = true;
                SynchronizeScroll(panelProcessed, panelOriginal);
                isSyncing = false;
            }
        }

        private void PanelOriginal_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (!isSyncing)
            {
                isSyncing = true;
                SynchronizeScroll(panelOriginal, panelProcessed);
                isSyncing = false;
            }
        }

        private static void SynchronizeScroll(Panel source, Panel target)
        {
            // Calcular las posiciones correctas, teniendo en cuenta que AutoScrollPosition devuelve valores negativos
            int newX = -source.AutoScrollPosition.X;
            int newY = -source.AutoScrollPosition.Y;

            // Ajustar la posición de desplazamiento del panel de destino
            target.AutoScrollPosition = new Point(newX, newY);
        }
    }
}
