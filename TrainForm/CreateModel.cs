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
    public partial class CreateModel : Form
    {
        private List<Models> _models = new List<Models>();
        public Models NewModel { get; set; }
        public bool success = false;
        public CreateModel(List<Models> models)
        {
            InitializeComponent();
            _models = models;
            buttonDone.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            success = true;
            NewModel = new Models { ModelName = textBoxName.Text };
            this.Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonDone.Enabled = false;
            if (string.IsNullOrEmpty(textBoxName.Text)) return;
            if(_models.Where(x=>x.ModelName == textBoxName.Text).Count() > 0) return;

            buttonDone.Enabled = true;
            
        }
    }
}
