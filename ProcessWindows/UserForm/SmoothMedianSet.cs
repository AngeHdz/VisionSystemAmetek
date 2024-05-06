using EmguClass.Args;
using EmguClass.Resources.Setting.Interface;
using EmguClass.Resources.Setting.SettingsClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public partial class SmoothMedianSet : UserControl
    {
        public event EventHandler<UserArgs> UpdaData;
        //public ISettings data;
        public SmoothMedianSet()
        {
            InitializeComponent();

        }

        protected virtual void OnReportReached(UserArgs e)
        {
            UpdaData.Invoke(this, e);
        }

        private void numericUpDownSize_KeyUp(object sender, KeyEventArgs e)
        {
            OnReportReached(new UserArgs(new SmothMedianSetting((int)numericUpDownSize.Value)));

        }

        private void numericUpDownSize_Click(object sender, EventArgs e)
        {
            OnReportReached(new UserArgs(new SmothMedianSetting((int)numericUpDownSize.Value)));
        }
    }
}
