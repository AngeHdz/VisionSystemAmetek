using MLClass;
using VisionSystemConfigFile;
using VisionSystemAmetek.Train.Forms;
using VisionSystemAmetek.Runtime;

namespace VisionSystemAmetek
{

    public partial class VIsionSystem : Form
    {
        #region Variables
        private MLModel model;
        private readonly ImageList imagelist;
        private readonly List<Bitmap> images = [];
        private ProjectConfig? Project;
        private ProjectConfig _CurrentTestProject;
        private string _CurrentModel = string.Empty;
        private bool PanelButton;
        private Engine _engine;


        #endregion

        #region Constructor
        public VIsionSystem()
        {
            InitializeComponent();
            SetReportColumns();
            imagelist = new ImageList
            {
                ImageSize = new Size(100, 100)
            };
            listViewImage.LargeImageList = imagelist;
            model = new MLModel();
            model.mlContext.Log += MlContext_Log;
            dataGridViewReport.CellFormatting += DataGridViewReport_CellFormatting;
            buttonCancel.Hide();
            buttonSave.Hide();
            panelbutton.Show();
            PanelButton = true;
            trainUserControl1.Hide();
            buttonTest.Enabled = false;
            comboBoxModels.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Telltale_OnReportTime(object? sender, EmguClass.Args.TimerEventArgs e)
        {
            Invoke(delegate
            {
                labelTime.Text = e.time;
            });
        }

        public void ReloadEngine()
        {
            _engine = new(_CurrentTestProject, _CurrentModel);
            _engine.OnFinish += Engine_OnFinish;
            _engine.OnReport += Engine_OnReport;
            _engine.OnReportImage += Engine_OnReportImage;
            _engine.OnReportTime += Engine_OnReportTime;
        }

        private void Engine_OnReportTime(object? sender, EmguClass.Args.TimerEventArgs e)
        {
            Invoke(delegate
            {
                labelTime.Text = e.time;
            });
        }

        private void Engine_OnReportImage(object? sender, EmguClass.Args.ImageEventArgs e)
        {
            Invoke(delegate
            {
                AddImage(e.label, e.Image);
            });
        }

        private void Engine_OnReport(object? sender, EmguClass.Args.ProcessEventArgs e)
        {
            if (dataGridViewReport.InvokeRequired)
            {
                Invoke(delegate
                {
                    dataGridViewReport.SuspendLayout();
                    dataGridViewReport.Rows.Add(e._result.ResultInfo());
                    dataGridViewReport.Rows[^1].Selected = true;
                    dataGridViewReport.FirstDisplayedScrollingRowIndex = dataGridViewReport.Rows.Count - 1;
                    dataGridViewReport.ResumeLayout();
                });
            }
            else
            {
                dataGridViewReport.Rows.Add(e._result.ResultInfo());
                dataGridViewReport.Rows[^1].Selected = true;
                dataGridViewReport.FirstDisplayedScrollingRowIndex = dataGridViewReport.Rows.Count - 1;
            }
        }

        private void Engine_OnFinish(object? sender, EmguClass.Args.ProcessOnFinishEventArgs e)
        {
            Invoke(delegate
            {
                switch (e.ResultType)
                {
                    case EmguClass.Results.ResultType.Pass:
                        Pass();
                        break;
                    case EmguClass.Results.ResultType.Fail:
                        Fail();
                        break;
                    default:
                        break;
                }
                Onfinish();
            });
        }

        #endregion

        #region Report
        private void Telltale_OnReportImage(object? sender, EmguClass.Args.ImageEventArgs e)
        {
            Invoke(delegate
            {
                AddImage(e.label, e.Image);
            });
        }
        private void Telltale_OnFinish(object? sender, EmguClass.Args.ProcessOnFinishEventArgs e)
        {
            Invoke(delegate
            {
                switch (e.ResultType)
                {
                    case EmguClass.Results.ResultType.Pass:
                        Pass();
                        break;
                    case EmguClass.Results.ResultType.Fail:
                        Fail();
                        break;
                    default:
                        break;
                }
                Onfinish();
            });
        }

        private void Clear()
        {
            pictureBoxMain.Image?.Dispose();
            listViewImage.Items.Clear();
            dataGridViewReport.Rows.Clear();
            labelStatus.Text = string.Empty;
            labelStatus.ForeColor = Color.Black;
            labelStatus.BackColor = Color.Transparent;
        }
        private void OnStart()
        {
            buttonTest.Enabled = false;
            buttonTest.BackColor = Color.Transparent;
        }

        private void Onfinish()
        {
            buttonTest.Enabled = true;

            buttonTest.BackColor = Color.PaleGreen;
        }

        private void Pass()
        {
            labelStatus.Text = "Passed";
            labelStatus.ForeColor = Color.White;
            labelStatus.BackColor = Color.Green;
        }
        private void Fail()
        {
            labelStatus.Text = "Failed";
            labelStatus.ForeColor = Color.White;
            labelStatus.BackColor = Color.Red;
        }
        private void DataGridViewReport_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString() == "Pass")
            {
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.ForeColor = Color.White;
            }
            if (e.Value.ToString() == "Fail")
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
        }
        private void SetReportColumns()
        {
            dataGridViewReport.Columns.Add("ColumnaTexto", "ID");
            dataGridViewReport.Columns.Add("ColumnaTexto", "TestName");
            dataGridViewReport.Columns.Add("ColumnaTexto", "LowLimit");
            dataGridViewReport.Columns.Add("ColumnaTexto", "Meas");
            dataGridViewReport.Columns.Add("ColumnaTexto", "HighLimit");
            dataGridViewReport.Columns.Add("ColumnaTexto", "Status");
            dataGridViewReport.Columns.Add("ColumnaTexto", "TestType");
            dataGridViewReport.Refresh();

            dataGridViewReport.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dataGridViewReport.GridColor = Color.White;
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AllowUserToDeleteRows = false;
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewReport.BackgroundColor = Color.White;
            dataGridViewReport.ReadOnly = true;
            dataGridViewReport.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridViewReport.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewReport.DefaultCellStyle.BackColor = Color.White;
            dataGridViewReport.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewReport.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewReport.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReport.RowTemplate.Height = 40;
            dataGridViewReport.Columns[0].Width = 50;
            dataGridViewReport.Columns[1].Width = 150;
            dataGridViewReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewReport.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void Telltale_OnReport(object? sender, EmguClass.Args.ProcessEventArgs e)
        {
            Invoke(delegate
            {
                dataGridViewReport.Rows.Add(e._result.ResultInfo());
            });
        }

        #endregion

        #region Test
        private void ButtonTest_Click(object sender, EventArgs e)
        {
            Clear();
            _engine.RunAsyncProcess();
            OnStart();
        }


        #endregion

        #region ML
        private void MlContext_Log(object? sender, Microsoft.ML.LoggingEventArgs e)
        {
            Invoke(delegate
            {
                listBoxLog.Items.Add($"{e.RawMessage}");
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            });
        }
        private void ButtonTrain_Click(object sender, EventArgs e)
        {
            model.Training();
            model = new MLModel();
        }
        #endregion

        #region ListView
        private void AddImage(string title, Bitmap image)
        {
            if (image == null)
            {
                return;
            }
            int index = imagelist.Images.Count;
            imagelist.Images.Add(image);
            ListViewItem item = new(title, index);
            listViewImage.Items.Add(item);
            images.Add(image);
            pictureBoxMain.Image = image;
        }

        private void ListViewImage_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;

            ListViewItem clickedItem = listView.GetItemAt(e.X, e.Y);
            pictureBoxMain.Image = null;

            if (clickedItem != null)
            {
                // Obtener el índice de la imagen en el ImageList
                int imageIndex = clickedItem.ImageIndex;

                // Obtener la imagen del ImageList
                Image clickedImage = images[imageIndex];

                // Hacer algo con la imagen, por ejemplo, mostrarla en un PictureBox
                pictureBoxMain.Image = clickedImage;
                //labelDesc.Text = $"Width: {clickedImage.Width}, Height: {clickedImage.Height}";
            }
        }

        #endregion

        #region CreateAModel
        private void ButtonNewproject_Click(object sender, EventArgs e)
        {
            using NewModel d = new();
            d.ShowDialog();
            if (d.success)
            {
                Project = d.NewConfig;

                if (Project != null)
                {
                    buttonLoad.Hide();
                    buttonNewproject.Hide();
                    buttonCancel.Show();
                    buttonSave.Show();
                    trainUserControl1.Show();
                    trainUserControl1.SetProject(Project);
                    return;
                }
            }

        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "C:\\MLProyects";
            openFileDialog.Filter = "json files (*.json)|*.json";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                Project = ConfigFile.LoadConfig(openFileDialog.FileName);

                if (Project != null)
                {
                    buttonLoad.Hide();
                    buttonNewproject.Hide();
                    buttonCancel.Show();
                    buttonSave.Show();
                    trainUserControl1.Show();
                    trainUserControl1.SetProject(Project);
                    return;
                }
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            buttonLoad.Show();
            buttonNewproject.Show();
            buttonCancel.Hide();
            buttonSave.Hide();
            trainUserControl1.Hide();
            Project = null;
            trainUserControl1.Cancel();
        }

        #endregion

        #region ButtonSide

        private void ButtonHide_Click(object sender, EventArgs e)
        {
            if (PanelButton)
            {
                panelbutton.Hide();
                panelButtonHide.Width = panelButtonHide.Width - panelbutton.Width;
                PanelButton = false;
            }
            else
            {
                panelbutton.Show();
                PanelButton = true;
                panelButtonHide.Width = panelButtonHide.Width + panelbutton.Width;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            ConfigFile.SaveConfig(trainUserControl1.GetProject());
        }
        #endregion

        #region Tester


        private void ButtonOpenProject_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "C:\\MLProyects";
            openFileDialog.Filter = "json files (*.json)|*.json";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _CurrentTestProject = ConfigFile.LoadConfig(openFileDialog.FileName);

                if (_CurrentTestProject != null)
                {
                    LoadModels();
                }
            }
        }

        private void LoadModels()
        {
            comboBoxModels.DataSource = _CurrentTestProject.Models.Select(x => x.ModelName).ToList();
        }


        private void ComboBoxModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentModel = comboBoxModels.Text;
            if (!string.IsNullOrEmpty(_CurrentModel))
            {
                buttonTest.Enabled = true;
                ReloadEngine();
            }
            else
            {
                buttonTest.Enabled = false;
            }
        }
        #endregion

    }
}
