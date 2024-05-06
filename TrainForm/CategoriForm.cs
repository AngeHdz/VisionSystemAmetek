using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionSystemAmetek.TrainForm
{
    public partial class CategoriForm : Form
    {
        public string CategoryName = string.Empty;
        List<string> categorise = null;
        public bool succes = false;
        public CategoriForm(List<string> cat)
        {
            InitializeComponent();
            categorise = cat;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Categorize name cannot be empty", "Create Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!categorise.Contains(textBoxName.Text))
            {
                CategoryName = textBoxName.Text;
                textBoxName.Enabled = false;
                succes = true;
                this.Close();
            }
            else MessageBox.Show("Type another name", "Create Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
