using Emgu.CV.Dnn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.Train.Forms
{
    public partial class NewModel : Form
    {
        public ProjectConfig NewConfig = new ProjectConfig();
        public bool success  = false;
        public NewModel()
        {
            InitializeComponent();
        }

        private void textBoxModelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                
            }

        }

        private bool ProjectNameValidation(ref ProjectConfig Config)
        {
            DirectoryInfo dir = new DirectoryInfo($"C:\\MLProyects\\{textBoxModelName.Text}\\");
            if (dir.Exists)
            {
                MessageBox.Show($"Already exist a project with name{textBoxModelName.Text}", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Config.ProjectPath = dir.FullName;
            Config.ProjectName = textBoxModelName.Text;
            Config.Path = $"{dir.FullName}{textBoxModelName.Text}.json";
            Config.ModelPath = $"{dir.FullName}{textBoxModelName.Text}.mlnet";
            Config.ProjectSnaps = $"{dir.FullName}Snaps\\";
            Config.TemplatePath = $"{dir.FullName}Template\\";
            Config.TraiPath = $"{dir.FullName}Train\\";


            Dir(Config.ProjectPath);
            Dir(Config.ProjectSnaps);
            Dir(Config.TemplatePath);

            Dir(Config.TraiPath);
            ConfigFile.SaveConfig(Config);

            this.Close();
            return true;
        }

        private bool Dir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                try
                {
                    dir.Create();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            success = ProjectNameValidation(ref NewConfig);
        }
    }
}
