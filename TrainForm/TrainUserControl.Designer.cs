namespace VisionSystemAmetek.TrainForm
{
    partial class TrainUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxProcessImage = new GroupBox();
            panel3 = new Panel();
            buttonProcess = new Button();
            buttonDeleteProcessImage = new Button();
            buttonAddProcessImage = new Button();
            listBoxProcessImage = new ListBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            buttonRoiDelete = new Button();
            buttonRoiAdd = new Button();
            listBoxRois = new ListBox();
            tabPage2 = new TabPage();
            panel5 = new Panel();
            buttonDeleteCategori = new Button();
            buttonAddCategori = new Button();
            listBoxCat = new ListBox();
            groupBoxTest = new GroupBox();
            listBoxTestSteps = new ListBox();
            groupBoxCapture = new GroupBox();
            buttonReload = new Button();
            buttonLoadCapture = new Button();
            label1 = new Label();
            comboBoxCaptureType = new ComboBox();
            pictureBoxMain = new PictureBox();
            buttonAddTestSteps = new Button();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBoxProcessImage.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            tabPage2.SuspendLayout();
            panel5.SuspendLayout();
            groupBoxTest.SuspendLayout();
            groupBoxCapture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(groupBoxCapture);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 489);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBoxProcessImage, 0, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBoxTest, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 92);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(211, 397);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBoxProcessImage
            // 
            groupBoxProcessImage.Controls.Add(panel3);
            groupBoxProcessImage.Controls.Add(listBoxProcessImage);
            groupBoxProcessImage.Dock = DockStyle.Fill;
            groupBoxProcessImage.Location = new Point(3, 3);
            groupBoxProcessImage.Name = "groupBoxProcessImage";
            groupBoxProcessImage.Size = new Size(205, 126);
            groupBoxProcessImage.TabIndex = 3;
            groupBoxProcessImage.TabStop = false;
            groupBoxProcessImage.Text = "Process Image";
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonProcess);
            panel3.Controls.Add(buttonDeleteProcessImage);
            panel3.Controls.Add(buttonAddProcessImage);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(138, 19);
            panel3.Name = "panel3";
            panel3.Size = new Size(64, 104);
            panel3.TabIndex = 1;
            // 
            // buttonProcess
            // 
            buttonProcess.Dock = DockStyle.Bottom;
            buttonProcess.Location = new Point(0, 81);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(64, 23);
            buttonProcess.TabIndex = 6;
            buttonProcess.Text = "Process";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // buttonDeleteProcessImage
            // 
            buttonDeleteProcessImage.Dock = DockStyle.Top;
            buttonDeleteProcessImage.Location = new Point(0, 23);
            buttonDeleteProcessImage.Name = "buttonDeleteProcessImage";
            buttonDeleteProcessImage.Size = new Size(64, 23);
            buttonDeleteProcessImage.TabIndex = 5;
            buttonDeleteProcessImage.Text = "Delete";
            buttonDeleteProcessImage.UseVisualStyleBackColor = true;
            buttonDeleteProcessImage.Click += buttonDeleteProcessImage_Click;
            // 
            // buttonAddProcessImage
            // 
            buttonAddProcessImage.Dock = DockStyle.Top;
            buttonAddProcessImage.Location = new Point(0, 0);
            buttonAddProcessImage.Name = "buttonAddProcessImage";
            buttonAddProcessImage.Size = new Size(64, 23);
            buttonAddProcessImage.TabIndex = 4;
            buttonAddProcessImage.Text = "Add";
            buttonAddProcessImage.UseVisualStyleBackColor = true;
            buttonAddProcessImage.Click += buttonAddProcessImage_Click;
            // 
            // listBoxProcessImage
            // 
            listBoxProcessImage.Dock = DockStyle.Left;
            listBoxProcessImage.FormattingEnabled = true;
            listBoxProcessImage.ItemHeight = 15;
            listBoxProcessImage.Location = new Point(3, 19);
            listBoxProcessImage.Name = "listBoxProcessImage";
            listBoxProcessImage.Size = new Size(135, 104);
            listBoxProcessImage.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 135);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(205, 126);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel4);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(197, 98);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "ROI";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonRoiDelete);
            panel4.Controls.Add(buttonRoiAdd);
            panel4.Controls.Add(listBoxRois);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(191, 92);
            panel4.TabIndex = 0;
            // 
            // buttonRoiDelete
            // 
            buttonRoiDelete.Dock = DockStyle.Top;
            buttonRoiDelete.Location = new Point(128, 23);
            buttonRoiDelete.Name = "buttonRoiDelete";
            buttonRoiDelete.Size = new Size(63, 23);
            buttonRoiDelete.TabIndex = 4;
            buttonRoiDelete.Text = "Delete";
            buttonRoiDelete.UseVisualStyleBackColor = true;
            buttonRoiDelete.Click += buttonRoiDelete_Click;
            // 
            // buttonRoiAdd
            // 
            buttonRoiAdd.Dock = DockStyle.Top;
            buttonRoiAdd.Location = new Point(128, 0);
            buttonRoiAdd.Name = "buttonRoiAdd";
            buttonRoiAdd.Size = new Size(63, 23);
            buttonRoiAdd.TabIndex = 3;
            buttonRoiAdd.Text = "Add";
            buttonRoiAdd.UseVisualStyleBackColor = true;
            buttonRoiAdd.Click += buttonRoiAdd_Click;
            // 
            // listBoxRois
            // 
            listBoxRois.Dock = DockStyle.Left;
            listBoxRois.FormattingEnabled = true;
            listBoxRois.ItemHeight = 15;
            listBoxRois.Location = new Point(0, 0);
            listBoxRois.Name = "listBoxRois";
            listBoxRois.Size = new Size(128, 92);
            listBoxRois.TabIndex = 2;
            listBoxRois.MouseDoubleClick += listBoxRois_MouseDoubleClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel5);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(197, 98);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Categories";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(buttonDeleteCategori);
            panel5.Controls.Add(buttonAddCategori);
            panel5.Controls.Add(listBoxCat);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(191, 92);
            panel5.TabIndex = 0;
            // 
            // buttonDeleteCategori
            // 
            buttonDeleteCategori.Dock = DockStyle.Top;
            buttonDeleteCategori.Location = new Point(128, 25);
            buttonDeleteCategori.Name = "buttonDeleteCategori";
            buttonDeleteCategori.Size = new Size(63, 25);
            buttonDeleteCategori.TabIndex = 3;
            buttonDeleteCategori.Text = "Delete";
            buttonDeleteCategori.UseVisualStyleBackColor = true;
            buttonDeleteCategori.Click += buttonDeleteCategori_Click;
            // 
            // buttonAddCategori
            // 
            buttonAddCategori.Dock = DockStyle.Top;
            buttonAddCategori.Location = new Point(128, 0);
            buttonAddCategori.Name = "buttonAddCategori";
            buttonAddCategori.Size = new Size(63, 25);
            buttonAddCategori.TabIndex = 2;
            buttonAddCategori.Text = "Add";
            buttonAddCategori.UseVisualStyleBackColor = true;
            buttonAddCategori.Click += buttonAddCategori_Click;
            // 
            // listBoxCat
            // 
            listBoxCat.Dock = DockStyle.Left;
            listBoxCat.FormattingEnabled = true;
            listBoxCat.ItemHeight = 15;
            listBoxCat.Location = new Point(0, 0);
            listBoxCat.Name = "listBoxCat";
            listBoxCat.Size = new Size(128, 92);
            listBoxCat.TabIndex = 1;
            listBoxCat.MouseDoubleClick += listBoxCat_DoubleClick;
            // 
            // groupBoxTest
            // 
            groupBoxTest.Controls.Add(buttonAddTestSteps);
            groupBoxTest.Controls.Add(listBoxTestSteps);
            groupBoxTest.Dock = DockStyle.Fill;
            groupBoxTest.Location = new Point(3, 267);
            groupBoxTest.Name = "groupBoxTest";
            groupBoxTest.Size = new Size(205, 127);
            groupBoxTest.TabIndex = 5;
            groupBoxTest.TabStop = false;
            groupBoxTest.Text = "TestSteps";
            // 
            // listBoxTestSteps
            // 
            listBoxTestSteps.Dock = DockStyle.Left;
            listBoxTestSteps.FormattingEnabled = true;
            listBoxTestSteps.ItemHeight = 15;
            listBoxTestSteps.Location = new Point(3, 19);
            listBoxTestSteps.Name = "listBoxTestSteps";
            listBoxTestSteps.Size = new Size(132, 105);
            listBoxTestSteps.TabIndex = 0;
            // 
            // groupBoxCapture
            // 
            groupBoxCapture.Controls.Add(buttonReload);
            groupBoxCapture.Controls.Add(buttonLoadCapture);
            groupBoxCapture.Controls.Add(label1);
            groupBoxCapture.Controls.Add(comboBoxCaptureType);
            groupBoxCapture.Dock = DockStyle.Top;
            groupBoxCapture.Location = new Point(0, 0);
            groupBoxCapture.Name = "groupBoxCapture";
            groupBoxCapture.Size = new Size(211, 92);
            groupBoxCapture.TabIndex = 0;
            groupBoxCapture.TabStop = false;
            groupBoxCapture.Text = "Captura";
            // 
            // buttonReload
            // 
            buttonReload.Location = new Point(119, 62);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(75, 23);
            buttonReload.TabIndex = 3;
            buttonReload.Text = "Reload";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click += buttonReload_Click;
            // 
            // buttonLoadCapture
            // 
            buttonLoadCapture.Location = new Point(6, 62);
            buttonLoadCapture.Name = "buttonLoadCapture";
            buttonLoadCapture.Size = new Size(75, 23);
            buttonLoadCapture.TabIndex = 2;
            buttonLoadCapture.Text = "button1";
            buttonLoadCapture.UseVisualStyleBackColor = true;
            buttonLoadCapture.Click += buttonLoadCapture_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "CameraType:";
            // 
            // comboBoxCaptureType
            // 
            comboBoxCaptureType.FormattingEnabled = true;
            comboBoxCaptureType.Location = new Point(90, 22);
            comboBoxCaptureType.Name = "comboBoxCaptureType";
            comboBoxCaptureType.Size = new Size(121, 23);
            comboBoxCaptureType.TabIndex = 0;
            comboBoxCaptureType.SelectedValueChanged += comboBoxCaptureType_SelectedValueChanged;
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Dock = DockStyle.Fill;
            pictureBoxMain.Location = new Point(211, 0);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(746, 489);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMain.TabIndex = 2;
            pictureBoxMain.TabStop = false;
            // 
            // buttonAddTestSteps
            // 
            buttonAddTestSteps.Dock = DockStyle.Top;
            buttonAddTestSteps.Location = new Point(135, 19);
            buttonAddTestSteps.Name = "buttonAddTestSteps";
            buttonAddTestSteps.Size = new Size(67, 23);
            buttonAddTestSteps.TabIndex = 4;
            buttonAddTestSteps.Text = "Add";
            buttonAddTestSteps.UseVisualStyleBackColor = true;
            buttonAddTestSteps.Click += buttonAddTestSteps_Click;
            // 
            // TrainUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBoxMain);
            Controls.Add(panel2);
            Name = "TrainUserControl";
            Size = new Size(957, 489);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxProcessImage.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            groupBoxTest.ResumeLayout(false);
            groupBoxCapture.ResumeLayout(false);
            groupBoxCapture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private GroupBox groupBoxCapture;
        private Label label1;
        private ComboBox comboBoxCaptureType;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonLoadCapture;
        private PictureBox pictureBoxMain;
        private Button buttonReload;
        private GroupBox groupBoxProcessImage;
        private ListBox listBoxProcessImage;
        private Panel panel3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel4;
        private Button buttonRoiDelete;
        private Button buttonRoiAdd;
        private ListBox listBoxRois;
        private Panel panel5;
        private Button buttonDeleteCategori;
        private Button buttonAddCategori;
        private ListBox listBoxCat;
        private GroupBox groupBoxTest;
        private ListBox listBoxTestSteps;
        private Button buttonAddProcessImage;
        private Button buttonDeleteProcessImage;
        private Button buttonProcess;
        private Button buttonAddTestSteps;
    }
}
