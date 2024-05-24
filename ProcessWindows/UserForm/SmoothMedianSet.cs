
using EmguClass.Resources.Setting;


namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public partial class SmoothMedianSet : IUserProcess
    {
        private decimal lastSize = 1;
        public SmoothMedianSet()
        {
            InitializeComponent();
            numericUpDownSize.Minimum = 1;
            numericUpDownSize.Maximum = 15;
        }

        private void NumericUpDownSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDownSize.Value % 2 == 0)
            {
                if (lastSize > numericUpDownSize.Value)
                {
                    numericUpDownSize.Value -= 1;
                }
                if (lastSize < numericUpDownSize.Value)
                {
                    numericUpDownSize.Value += 1;
                }
                lastSize = numericUpDownSize.Value;
            }
            size = (int)numericUpDownSize.Value;
            Report();
        }

        private void NumericUpDownSize_Click(object sender, EventArgs e)
        {
            if (numericUpDownSize.Value % 2 == 0)
            {
                if (lastSize > numericUpDownSize.Value)
                {
                    numericUpDownSize.Value -= 1;
                }
                if (lastSize < numericUpDownSize.Value)
                {
                    numericUpDownSize.Value += 1;
                }
                lastSize = numericUpDownSize.Value;
            }
            size = (int)numericUpDownSize.Value;
            Report();
        }

        private protected void Report()
        {
            OnReportReached(new UserArgs(new Settings() { Size = size, Type = EmguClass.TypeProcess.SmoothMedian }));
        }
    }
}
