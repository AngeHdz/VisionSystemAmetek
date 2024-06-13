using Emgu.CV;
using Emgu.CV.Structure;
using EmguClass;
using EmguClass.Dictionary;
using EmguClass.Resources.Setting;
using VisionSystemAmetek.Dictionary;
using VisionSystemAmetek.ProcessWindows.UserForm;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.ProcessWindows
{
    public partial class FiltersForm : Form
    {
        private Bitmap Image;
        private Bitmap Imageprocessed;
        private TypeProcess type;
        private IUserProcess Tool;
        private Settings Data;
        public ProcessClass processImage;
        public bool Success;
        private bool isSyncing;
        private readonly Settings settings;
        public FiltersForm(Bitmap image)
        {
            InitializeComponent();

            comboBoxFilters.DataSource = new List<string>(Enum.GetNames(typeof(TypeProcess)));
            Image = image;
            pictureBoxOriginal.Image = Image;
            pictureBoxProcessed.Image = Image;

            panelOriginal.MouseWheel += PanelOriginal_MouseWheel;
            panelProcessed.MouseWheel += PanelProcessed_MouseWheel;
        }


        private void ExecuteProcess(object? sender, UserArgs e)
        {
            Data = e.Settings;
            Imageprocessed = EmguFunctions.GetProcess(Image.ToImage<Bgr, byte>(), Data).ToBitmap();
            pictureBoxProcessed.Image = Imageprocessed;
            SynchronizeScroll(panelOriginal, panelProcessed);
        }

        private void ComboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tool != null)
            {
                Tool.UpdaData -= ExecuteProcess;
                Tool.Dispose();
                panelTool.Controls.Remove(Tool);
            }
            type = (TypeProcess)Enum.Parse(typeof(TypeProcess), comboBoxFilters.Text);
            Tool = DictionaryClass.GetPanel(type);
            if (Tool == null)
            {
                return;
            }
            Tool.UpdaData += ExecuteProcess;
            Tool.Hide();
            Tool.Dock = DockStyle.Fill;
            panelTool.Controls.Add(Tool);
            Tool.Show();
        }


        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            processImage = new ProcessClass(textBoxName.Text, comboBoxFilters.Text, settings);
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
