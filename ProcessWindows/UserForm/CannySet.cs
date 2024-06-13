
using EmguClass.Resources.Setting;

namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public partial class CannySet : IUserProcess
    {
        public CannySet()
        {
            InitializeComponent();
            numericUpDownTresh.Value = 1;
            numericUpDownTresh.Maximum = 255;
            numericUpDownTreshLinking.Value = 3;
            numericUpDownApertureSize.Value = 3;

            numericUpDownTreshLinking.Minimum = 3;
            numericUpDownTreshLinking.Maximum = 7;

            numericUpDownApertureSize.Minimum = 3;
            numericUpDownApertureSize.Maximum = 7;
        }

        private protected void Report()
        {
            OnReportReached(new UserArgs(new Settings()
            {
                tresh = (double)numericUpDownTresh.Value,
                treshLinking = (double)numericUpDownTreshLinking.Value,
                apertureSize = (int)numericUpDownApertureSize.Value,
                I2Gradient = checkBoxGradient.Checked,
                Type = EmguClass.TypeProcess.Canny
            }));
        }
        private void Update(object sender, EventArgs e)
        {
            Report();
        }
    }
}
