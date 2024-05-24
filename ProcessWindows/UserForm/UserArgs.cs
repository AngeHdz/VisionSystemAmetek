using EmguClass.Resources.Setting;
using EmguClass.Resources.Setting.Interface;


namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public class UserArgs : EventArgs
    {
        //public ISettings _Data;
        public Settings Settings { get; set; }

        //public UserArgs(ISettings Data)
        //{
        //    _Data = Data;
        //}
        public UserArgs(Settings settings)
        {
            Settings = settings;
        }
    }
}
