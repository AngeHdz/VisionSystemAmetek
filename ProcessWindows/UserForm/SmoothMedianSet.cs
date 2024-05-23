
using EmguClass.Resources.Setting.SettingsClasses;


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

        private void NumericUpDownSize_KeyUp(object sender, KeyEventArgs e)
        {
            OnReportReached(new UserArgs(new SmothMedianSetting((int)numericUpDownSize.Value)));

        }

        private void NumericUpDownSize_Click(object sender, EventArgs e)
        {
            OnReportReached(new UserArgs(new SmothMedianSetting((int)numericUpDownSize.Value)));
        }
    }
}
