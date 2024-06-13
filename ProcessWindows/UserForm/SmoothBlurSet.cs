
using EmguClass.Resources.Setting;

namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public partial class SmoothBlurSet : IUserProcess
    {
        public SmoothBlurSet()
        {
            InitializeComponent();
            numericUpDownHeight.Value = 1;
            numericUpDownWidth.Value = 1;
            numericUpDownHeight.Minimum = 1;
            numericUpDownHeight.Maximum = 20;

            numericUpDownHeight.Minimum = 1;
            numericUpDownHeight.Maximum = 20;
        }

        private protected void Report()
        {
            OnReportReached(new UserArgs(new Settings()
            {
                Width = (int)numericUpDownHeight.Value,
                Height = (int)numericUpDownHeight.Value,
                Type = EmguClass.TypeProcess.SmoothBlur
            }));
        }

        private void NumericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            Report();
        }

        private void NumericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            Report();
        }
    }
}
