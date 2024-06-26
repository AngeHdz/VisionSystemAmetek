﻿
using EmguClass;

namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    public class IUserProcess : UserControl
    {
        public event EventHandler<UserArgs> UpdaData;
        protected int size;
        protected TypeProcess type = TypeProcess.None;

        protected virtual void OnReportReached(UserArgs e)
        {
            if (UpdaData == null)
            {
                return;
            }
            UpdaData.Invoke(this, e);
        }
    }
}
