using EmguClass;
using System.Drawing.Text;
using System.Windows.Forms;
using EmguClass.Tools;
using MLClass;
using EmguClass.Results.Types;
using NumSharp.Extensions;

namespace VisionSystemAmetek
{

    public partial class VIsionSystem : Form
    {
        #region Variables
        MLModel model;
        EmguClass.TellTale? telltale = null;
        private static string SnapPath = @"C:\Ametek_Resources\VisionSystemML\Snap\Capture.bmp";
        private static string TellTaleModelPath = @"C:\Image\Model\TellTaleModel.mlnet";
        private static string LastImage = @"C:\Ametek_Resources\VisionSystemML\LastImage\LastImage.bmp";
        private static string PatternPath = @"C:\Image\Template\";
        private ImageList imagelist;
        private List<Bitmap> images = new List<Bitmap>();
        #endregion

        #region Constructor
        public VIsionSystem()
        {
            InitializeComponent();
            setReportColumns();
            telltale = new EmguClass.TellTale();
            telltale.OnReport += Telltale_OnReport;
            telltale.OnFinish += Telltale_OnFinish;
            telltale.OnReportImage += Telltale_OnReportImage;
            imagelist = new ImageList();
            imagelist.ImageSize = new Size(100, 100);
            listViewImage.LargeImageList = imagelist;
            labelDesc.Text = string.Empty;
            model = new MLModel();
            model.mlContext.Log += MlContext_Log;
            dataGridViewReport.CellFormatting += DataGridViewReport_CellFormatting;
            telltale.OnReportTime += Telltale_OnReportTime;
        }

        private void Telltale_OnReportTime(object? sender, EmguClass.Args.TimerEventArgs e)
        {
            this.Invoke((Action)delegate
            {
                labelTime.Text = e.time;
            });
        }



        #endregion

        #region Report
        private void Telltale_OnReportImage(object? sender, EmguClass.Args.ImageEventArgs e)
        {
            this.Invoke((Action)delegate
            {
                AddImage(e.label, e.Image);
            });
        }
        private void Telltale_OnFinish(object? sender, EmguClass.Args.ProcessOnFinishEventArgs e)
        {
            this.Invoke((Action)delegate
            {
                switch (e.ResultType)
                {
                    case EmguClass.Results.ResultType.Pass:
                        Pass();
                        break;
                    case EmguClass.Results.ResultType.Fail:
                        Fail();
                        break;
                }
                Onfinish();
            });
        }

        private void Clear()
        {
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
        private void setReportColumns()
        {
            dataGridViewReport.Columns.Add("ColumnaTexto", "ID");
            dataGridViewReport.Columns.Add("ColumnaTexto", "TestName");
            dataGridViewReport.Columns.Add("ColumnaTexto", "LowLimit");
            dataGridViewReport.Columns.Add("ColumnaTexto", "Meas");
            dataGridViewReport.Columns.Add("ColumnaTexto", "HighLimit");
            dataGridViewReport.Columns.Add("ColumnaTexto", "Status");
            dataGridViewReport.Columns.Add("ColumnaTexto", "TestType");
            dataGridViewReport.Refresh();

            this.dataGridViewReport.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dataGridViewReport.GridColor = Color.White;
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AllowUserToDeleteRows = false;
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewReport.BackgroundColor = Color.White;
            dataGridViewReport.ReadOnly = true;
            dataGridViewReport.DefaultCellStyle.SelectionBackColor = Color.Gray;

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
            this.Invoke((Action)delegate
            {
                dataGridViewReport.Rows.Add(e._result.ResultInfo());
            });
        }

        #endregion

        #region Test
        private void buttonTest_Click(object sender, EventArgs e)
        {
            Clear();
            telltale.AsyncProcess(SnapPath, ColorType.ambar, TestType.Hvac_Buttons, PatternPath);
            listViewImage.Items.Clear();
            OnStart();
            //foreach (ImageResult r in telltale.imageResults)
            //{
            //    AddImage(r.Name, r.Bitmap);
            //}

            //telltale.imageResults[telltale.imageResults.Count - 1].Bitmap.Save(LastImage);

            //DateTime horaActual = DateTime.Now;

            //labelData.Text = horaActual.ToString("HH:mm:ss");
        }


        #endregion

        #region ML
        private void MlContext_Log(object? sender, Microsoft.ML.LoggingEventArgs e)
        {
            this.Invoke((Action)delegate
            {
                listBoxLog.Items.Add($"{e.RawMessage}");
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            });
        }
        private void buttonTrain_Click(object sender, EventArgs e)
        {
            model.Training();
            model = new MLModel();
        }
        #endregion

        #region ListView
        private void AddImage(string title, Bitmap image)
        {
            int index = imagelist.Images.Count;
            imagelist.Images.Add(image);
            ListViewItem item = new ListViewItem(title, index);
            listViewImage.Items.Add(item);
            images.Add(image);
            pictureBoxMain.Image = image;
        }

        private void listViewImage_MouseClick(object sender, MouseEventArgs e)
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
                labelDesc.Text = $"Width: {clickedImage.Width}, Height: {clickedImage.Height}";
            }
        }

#endregion
    }
}
