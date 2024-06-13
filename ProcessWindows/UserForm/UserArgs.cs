using EmguClass.Resources.Setting;

namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public class UserArgs : EventArgs
    {
        public Settings Settings { get; set; }

        public UserArgs(Settings settings)
        {
            Settings = settings;
        }
    }
}
