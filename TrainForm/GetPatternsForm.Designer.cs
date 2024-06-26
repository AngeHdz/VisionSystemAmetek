﻿namespace VisionSystemAmetek.TrainForm
{
    partial class GetPatternsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            labelNameCat = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            buttonDone = new Button();
            buttonCancel = new Button();
            pictureBoxPattern = new PictureBox();
            panel2 = new Panel();
            pictureBoxMain = new PictureBox();
            labelLog = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPattern).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.Controls.Add(labelNameCat, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(529, 363);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelNameCat
            // 
            labelNameCat.Dock = DockStyle.Left;
            labelNameCat.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNameCat.Location = new Point(20, 0);
            labelNameCat.Margin = new Padding(20, 0, 3, 0);
            labelNameCat.Name = "labelNameCat";
            labelNameCat.Size = new Size(284, 50);
            labelNameCat.TabIndex = 0;
            labelNameCat.Text = "label1";
            labelNameCat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 1);
            tableLayoutPanel2.Controls.Add(pictureBoxPattern, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(332, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(194, 307);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelLog);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 203);
            panel1.Name = "panel1";
            panel1.Size = new Size(188, 101);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonDone);
            panel3.Controls.Add(buttonCancel);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 64);
            panel3.Name = "panel3";
            panel3.Size = new Size(188, 37);
            panel3.TabIndex = 2;
            // 
            // buttonDone
            // 
            buttonDone.Dock = DockStyle.Right;
            buttonDone.Location = new Point(113, 0);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(75, 37);
            buttonDone.TabIndex = 2;
            buttonDone.Text = "Done";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += ButtonDone_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Dock = DockStyle.Left;
            buttonCancel.Location = new Point(0, 0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 37);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // pictureBoxPattern
            // 
            pictureBoxPattern.Dock = DockStyle.Fill;
            pictureBoxPattern.Location = new Point(3, 3);
            pictureBoxPattern.Name = "pictureBoxPattern";
            pictureBoxPattern.Size = new Size(188, 194);
            pictureBoxPattern.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPattern.TabIndex = 1;
            pictureBoxPattern.TabStop = false;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(pictureBoxMain);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(323, 307);
            panel2.TabIndex = 2;
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Location = new Point(3, 3);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(100, 50);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            pictureBoxMain.Paint += PictureBoxMain_Paint;
            pictureBoxMain.MouseDown += PictureBoxMain_MouseDown;
            pictureBoxMain.MouseMove += PictureBoxMain_MouseMove;
            pictureBoxMain.MouseUp += PictureBoxMain_MouseUp;
            // 
            // labelLog
            // 
            labelLog.Dock = DockStyle.Fill;
            labelLog.Location = new Point(0, 0);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(188, 64);
            labelLog.TabIndex = 3;
            // 
            // GetPatternsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 363);
            Controls.Add(tableLayoutPanel1);
            Name = "GetPatternsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GetPatternsForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPattern).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelNameCat;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel3;
        private Button buttonDone;
        private Button buttonCancel;
        private PictureBox pictureBoxPattern;
        private Panel panel2;
        private PictureBox pictureBoxMain;
        private Label labelLog;
    }
}