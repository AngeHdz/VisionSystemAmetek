using Emgu.CV;
using Emgu.CV.Structure;
using EmguClass;
using EmguClass.Args;
using EmguClass.Resources;
using EmguClass.Results;
using EmguClass.Results.Types;
using EmguClass.Tester;
using MLClass;
using VisionSystemConfigFile;

namespace VisionSystemAmetek.Runtime
{
    public class Engine : TesterProcess
    {
        public LinkedList<ResultClass> TestResults = new();
        private ProjectConfig _project;
        private string _currentModel;
        public event EventHandler<ProcessEventArgs> OnReport;
        public event EventHandler<ProcessOnFinishEventArgs> OnFinish;
        public event EventHandler<ImageEventArgs> OnReportImage;
        public event EventHandler<TimerEventArgs> OnReportTime;
        private MLModel _model;


        public Engine(ProjectConfig project, string model)
        {
            _project = project;
            _currentModel = model;
            _model = new MLModel();
        }

        protected void Finish()
        {
            ProcessOnFinishEventArgs result = new(ResultType.Fail);
            int NoPass = TestResults.ToList().Where(x => x.ResultType != ResultType.Pass).Count();
            if (NoPass == 0)
            {
                result.ResultType = ResultType.Pass;
            }
            OnFinishReached(result);
            GC.Collect();
        }

        protected virtual void OnReportReached(ProcessEventArgs e)
        {
            OnReport.Invoke(this, e);
        }

        protected virtual void OnFinishReached(ProcessOnFinishEventArgs e)
        {
            OnFinish.Invoke(this, e);
        }
        protected virtual void OnImageReached(ImageEventArgs e)
        {
            try
            {
                OnReportImage.Invoke(this, e);
            }
            catch (Exception)
            {

            }
        }
        protected virtual void OnReportTimeReached(TimerEventArgs e)
        {
            OnReportTime.Invoke(this, e);
        }


        public void RunAsyncProcess()
        {
            TestResults.Clear();
            Capture(_project);
            Task.Run(Run);
        }

        private void Run()
        {
            ProcessImage();
            ProcessSteps();
            Finish();
        }

        private void ProcessImage()
        {
            _imageProcessed = _imageOriginal.Copy();

            foreach (ProcessClass d in _project.ProcessImages)
            {
                ProcessImageTypes type = (ProcessImageTypes)Enum.Parse(typeof(ProcessImageTypes), d.Type);
                switch (type)
                {
                    case ProcessImageTypes.Led_Ambar:
                        _imageProcessed = VisionClass.Ambar_DarkBackground(_imageProcessed);
                        OnImageReached(new ImageEventArgs(type.ToString(), _imageProcessed.ToBitmap()));
                        break;
                    case ProcessImageTypes.SmootMedian:
                        break;
                    case ProcessImageTypes.Canny:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ProcessSteps()
        {
            _imageTested = _imageProcessed.Copy();
            Models model = _project.Models.First(x => x.ModelName == _currentModel);
            foreach (TestStep step in model.TestSteps)
            {
                ExecuteSteps(step);
            }

            OnImageReached(new ImageEventArgs("Tested", _imageTested.ToBitmap()));
        }

        private void ExecuteSteps(TestStep _step)
        {
            switch (_step.StepType)
            {
                case TestStepType.PatternMatch_ML:
                    PatternMatch_ML(_step);
                    break;
                case TestStepType.PatternMatch:
                    break;
                case TestStepType.IA:
                    break;
                default:
                    break;
            }
        }

        private void PatternMatch_ML(TestStep Step)
        {
            int MinScore = 800;
            RoiClass roi = _project.RoiClasses.First(x => x.Name == Step.ROI);
            Image<Bgr, byte> _train = new(0, 0);
            string key = string.Empty;
            float acc = 0;
            VisionClass.PatternMatch(_imageTested, Step.TemplateFile, MinScore, roi.Rectangle, Step.ROI, false, _project.ModelPath, out int resultScore, ref _train, ref _model, ref key, ref acc);
            TestResults.AddLast(new NumericResult(TestResults.Count, $"{Step.ROI} - Pattern Match", MinScore, 1000, resultScore, "Pattern Score"));
            OnReportReached(new ProcessEventArgs(TestResults.Last.Value));
            TestResults.AddLast(new StringResult(TestResults.Count, $"{Step.TestStepName} - ML Category", Step.Category, key, "ML result"));
            OnReportReached(new ProcessEventArgs(TestResults.Last.Value));
            TestResults.AddLast(new NumericResult(TestResults.Count, $"{Step.TestStepName} - ML %", 80, 100, acc * 100, "Pattern Score"));
            OnReportReached(new ProcessEventArgs(TestResults.Last.Value));
        }

        #region Capture

        public void Capture(ProjectConfig Project)
        {
            switch (Project.captureType)
            {
                case CaptureType.File:
                    GetFile(Project);
                    break;
                case CaptureType.IndustrialCam:
                    break;
                case CaptureType.Webcam:
                    break;
                default:
                    break;
            }
        }

        private void GetFile(ProjectConfig Project)
        {
            OpenFileDialog of = new();
            if (Project.LastDirFile != string.Empty)
            {
                of.InitialDirectory = Project.LastDirFile;
            }
            of.FilterIndex = 1;
            of.RestoreDirectory = false;
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Project.LastDirFile = new FileInfo(of.FileName).Directory.FullName;
                Project.FileCapturePath = of.FileName;
                _imageOriginal = gettingFile(Project.FileCapturePath);
                OnImageReached(new ImageEventArgs("Processed Image", _imageOriginal.ToBitmap()));
            }
        }

        #endregion

    }
}
