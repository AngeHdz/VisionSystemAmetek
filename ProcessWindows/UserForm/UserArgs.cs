using EmguClass.Resources.Setting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
