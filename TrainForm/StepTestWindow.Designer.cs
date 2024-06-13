namespace VisionSystemAmetek.TrainForm
{
    partial class StepTestWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxName = new TextBox();
            labelStepName = new Label();
            buttonSave = new Button();
            comboBoxRoi = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxcat = new ComboBox();
            panel1 = new Panel();
            panel5 = new Panel();
            groupBox1 = new GroupBox();
            buttonFindFile = new Button();
            textBoxTemplate = new TextBox();
            labelFileName = new Label();
            panel4 = new Panel();
            buttonTrain = new Button();
            buttonCancel = new Button();
            panel3 = new Panel();
            label3 = new Label();
            comboBoxType = new ComboBox();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxMain = new PictureBox();
            listBoxLog = new ListBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(88, 9);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(265, 23);
            textBoxName.TabIndex = 0;
            // 
            // labelStepName
            // 
            labelStepName.AutoSize = true;
            labelStepName.Location = new Point(11, 17);
            labelStepName.Name = "labelStepName";
            labelStepName.Size = new Size(68, 15);
            labelStepName.TabIndex = 1;
            labelStepName.Text = "Step Name:";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Right;
            buttonSave.BackColor = Color.ForestGreen;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(20, 93);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(79, 32);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // comboBoxRoi
            // 
            comboBoxRoi.FormattingEnabled = true;
            comboBoxRoi.Location = new Point(88, 38);
            comboBoxRoi.Name = "comboBoxRoi";
            comboBoxRoi.Size = new Size(265, 23);
            comboBoxRoi.TabIndex = 3;
            comboBoxRoi.SelectedIndexChanged += ComboBoxRoi_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 46);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 4;
            label1.Text = "Roi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 75);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Category:";
            // 
            // comboBoxcat
            // 
            comboBoxcat.FormattingEnabled = true;
            comboBoxcat.Location = new Point(88, 67);
            comboBoxcat.Name = "comboBoxcat";
            comboBoxcat.Size = new Size(265, 23);
            comboBoxcat.TabIndex = 6;
            comboBoxcat.SelectedIndexChanged += ComboBoxcat_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 131);
            panel1.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(groupBox1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(368, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(455, 131);
            panel5.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonFindFile);
            groupBox1.Controls.Add(textBoxTemplate);
            groupBox1.Controls.Add(labelFileName);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 131);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Template";
            // 
            // buttonFindFile
            // 
            buttonFindFile.Location = new Point(58, 49);
            buttonFindFile.Name = "buttonFindFile";
            buttonFindFile.Size = new Size(76, 23);
            buttonFindFile.TabIndex = 2;
            buttonFindFile.Text = "Find";
            buttonFindFile.UseVisualStyleBackColor = true;
            buttonFindFile.Click += ButtonFindFile_Click;
            // 
            // textBoxTemplate
            // 
            textBoxTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTemplate.Location = new Point(58, 17);
            textBoxTemplate.Name = "textBoxTemplate";
            textBoxTemplate.Size = new Size(271, 23);
            textBoxTemplate.TabIndex = 1;
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Location = new Point(14, 20);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(28, 15);
            labelFileName.TabIndex = 0;
            labelFileName.Text = "File:";
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonTrain);
            panel4.Controls.Add(buttonSave);
            panel4.Controls.Add(buttonCancel);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(823, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(111, 131);
            panel4.TabIndex = 12;
            // 
            // buttonTrain
            // 
            buttonTrain.Anchor = AnchorStyles.Right;
            buttonTrain.BackColor = Color.Orange;
            buttonTrain.FlatAppearance.BorderSize = 0;
            buttonTrain.FlatStyle = FlatStyle.Flat;
            buttonTrain.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTrain.ForeColor = Color.White;
            buttonTrain.Location = new Point(20, 9);
            buttonTrain.Name = "buttonTrain";
            buttonTrain.Size = new Size(79, 32);
            buttonTrain.TabIndex = 10;
            buttonTrain.Text = "Train";
            buttonTrain.UseVisualStyleBackColor = false;
            buttonTrain.Click += ButtonTrain_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Right;
            buttonCancel.BackColor = Color.Red;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(20, 49);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(79, 32);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBoxName);
            panel3.Controls.Add(comboBoxRoi);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(comboBoxType);
            panel3.Controls.Add(labelStepName);
            panel3.Controls.Add(comboBoxcat);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(368, 131);
            panel3.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 104);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 8;
            label3.Text = "Test Type";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(88, 96);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(265, 23);
            comboBoxType.TabIndex = 7;
            comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 131);
            panel2.Name = "panel2";
            panel2.Size = new Size(934, 480);
            panel2.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.64354F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.35646F));
            tableLayoutPanel1.Controls.Add(pictureBoxMain, 0, 0);
            tableLayoutPanel1.Controls.Add(listBoxLog, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(934, 480);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Dock = DockStyle.Fill;
            pictureBoxMain.Location = new Point(3, 3);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(700, 474);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            // 
            // listBoxLog
            // 
            listBoxLog.Dock = DockStyle.Fill;
            listBoxLog.FormattingEnabled = true;
            listBoxLog.ItemHeight = 15;
            listBoxLog.Location = new Point(709, 3);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(222, 474);
            listBoxLog.TabIndex = 1;
            // 
            // StepTestWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 611);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(950, 650);
            Name = "StepTestWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StepTestWindow";
            FormClosing += StepTestWindow_FormClosing;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxName;
        private Label labelStepName;
        private Button buttonSave;
        private ComboBox comboBoxRoi;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxcat;
        private Panel panel1;
        private Label label3;
        private ComboBox comboBoxType;
        private Button buttonCancel;
        private Panel panel2;
        private PictureBox pictureBoxMain;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonTrain;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private GroupBox groupBox1;
        private Label labelFileName;
        private TextBox textBoxTemplate;
        private Button buttonFindFile;
        private ListBox listBoxLog;
    }
}