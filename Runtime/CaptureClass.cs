using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.Runtime
{
    public static class CaptureClass
    {
        public static Bitmap Capture(ProjectConfig Project)
        {
            Bitmap NewCapture = null;
            switch (Project.captureType) 
            {
                case CaptureType.File:
                    NewCapture = GetFile(Project);
                    break;
                case CaptureType.IndustrialCam:
                    break;  
                case CaptureType.Webcam:
                    break;
                default:
                    break;
            }

            return NewCapture;
        }

        private static Bitmap GetFile(ProjectConfig Project) 
        {
            OpenFileDialog of = new OpenFileDialog();
            if (Project.LastDirFile != string.Empty) of.InitialDirectory = Project.LastDirFile;
            of.FilterIndex = 1;
            of.RestoreDirectory = false;
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Project.LastDirFile = new FileInfo(of.FileName).Directory.FullName;
                Project.FileCapturePath = of.FileName;
                return (Bitmap)Image.FromFile(of.FileName);
            }
            return null;
        }
    }
}
