using EmguClass.Resources;
using EmguClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.Runtime
{
    public static class ProcessImageClass
    {

        public static Bitmap Process(ProjectConfig Project, Bitmap OriginalImage) 
        {
            Bitmap NewImage = OriginalImage;

            foreach (var d in Project.ProcessImages)
            {
                ProcessImageTypes type = (ProcessImageTypes)Enum.Parse(typeof(ProcessImageTypes), d.Type);
                switch (type)
                {
                    case ProcessImageTypes.Led_Ambar:
                        NewImage = VisionClass.Ambar_DarkBackground(NewImage);
                        break;
                }
            }
            return NewImage;
        }

    }
}
