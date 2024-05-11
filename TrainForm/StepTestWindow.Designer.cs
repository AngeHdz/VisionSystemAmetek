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
            buttonTrain = new Button();
            buttonCancel = new Button();
            label3 = new Label();
            comboBoxType = new ComboBox();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxMain = new PictureBox();
            textBoxLog = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(85, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(265, 23);
            textBoxName.TabIndex = 0;
            // 
            // labelStepName
            // 
            labelStepName.AutoSize = true;
            labelStepName.Location = new Point(8, 20);
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
            buttonSave.Location = new Point(843, 93);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(79, 32);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // comboBoxRoi
            // 
            comboBoxRoi.FormattingEnabled = true;
            comboBoxRoi.Location = new Point(85, 41);
            comboBoxRoi.Name = "comboBoxRoi";
            comboBoxRoi.Size = new Size(265, 23);
            comboBoxRoi.TabIndex = 3;
            comboBoxRoi.SelectedIndexChanged += comboBoxRoi_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 49);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 4;
            label1.Text = "Roi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 78);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Category:";
            // 
            // comboBoxcat
            // 
            comboBoxcat.FormattingEnabled = true;
            comboBoxcat.Location = new Point(85, 70);
            comboBoxcat.Name = "comboBoxcat";
            comboBoxcat.Size = new Size(265, 23);
            comboBoxcat.TabIndex = 6;
            comboBoxcat.SelectedIndexChanged += comboBoxcat_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonTrain);
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBoxType);
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(comboBoxcat);
            panel1.Controls.Add(labelStepName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonSave);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBoxRoi);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 131);
            panel1.TabIndex = 7;
            // 
            // buttonTrain
            // 
            buttonTrain.Anchor = AnchorStyles.Right;
            buttonTrain.BackColor = Color.Orange;
            buttonTrain.FlatAppearance.BorderSize = 0;
            buttonTrain.FlatStyle = FlatStyle.Flat;
            buttonTrain.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTrain.ForeColor = Color.White;
            buttonTrain.Location = new Point(843, 9);
            buttonTrain.Name = "buttonTrain";
            buttonTrain.Size = new Size(79, 32);
            buttonTrain.TabIndex = 10;
            buttonTrain.Text = "Train";
            buttonTrain.UseVisualStyleBackColor = false;
            buttonTrain.Click += buttonTrain_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Right;
            buttonCancel.BackColor = Color.Red;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(843, 49);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(79, 32);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 107);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 8;
            label3.Text = "Test Type";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(85, 99);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(265, 23);
            comboBoxType.TabIndex = 7;
            comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
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
            tableLayoutPanel1.Controls.Add(textBoxLog, 1, 0);
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
            // textBoxLog
            // 
            textBoxLog.Dock = DockStyle.Fill;
            textBoxLog.Location = new Point(709, 3);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(222, 474);
            textBoxLog.TabIndex = 1;
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private TextBox textBoxLog;
        private Button buttonTrain;
    }
}