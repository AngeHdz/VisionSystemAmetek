using EmguClass.Resources.Setting.Interface;


namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public class UserArgs : EventArgs
    {
        public ISettings _Data;

        public UserArgs(ISettings Data)
        {
            _Data = Data;
        }
    }
}
