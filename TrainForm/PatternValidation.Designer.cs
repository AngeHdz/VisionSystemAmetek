namespace VisionSystemAmetek.TrainForm
{
    partial class PatternValidation
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
            listViewImage = new ListView();
            buttonGetBest = new Button();
            panel1 = new Panel();
            buttonDone = new Button();
            labelClase = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            pictureBoxCurrentsnap = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            pictureBoxBest = new PictureBox();
            label2 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCurrentsnap).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBest).BeginInit();
            SuspendLayout();
            // 
            // listViewImage
            // 
            listViewImage.Dock = DockStyle.Left;
            listViewImage.Location = new Point(0, 0);
            listViewImage.Name = "listViewImage";
            listViewImage.Size = new Size(199, 443);
            listViewImage.TabIndex = 0;
            listViewImage.UseCompatibleStateImageBehavior = false;
            // 
            // buttonGetBest
            // 
            buttonGetBest.Location = new Point(6, 57);
            buttonGetBest.Name = "buttonGetBest";
            buttonGetBest.Size = new Size(127, 37);
            buttonGetBest.TabIndex = 1;
            buttonGetBest.Text = "Get Best Pattern";
            buttonGetBest.UseVisualStyleBackColor = true;
            buttonGetBest.Click += buttonGetBest_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonDone);
            panel1.Controls.Add(labelClase);
            panel1.Controls.Add(buttonGetBest);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(199, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(396, 100);
            panel1.TabIndex = 2;
            // 
            // buttonDone
            // 
            buttonDone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDone.Location = new Point(257, 57);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(127, 37);
            buttonDone.TabIndex = 3;
            buttonDone.Text = "Done";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += buttonDone_Click;
            // 
            // labelClase
            // 
            labelClase.Dock = DockStyle.Top;
            labelClase.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClase.Location = new Point(0, 0);
            labelClase.Name = "labelClase";
            labelClase.Size = new Size(396, 40);
            labelClase.TabIndex = 2;
            labelClase.Text = "label3";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(199, 100);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(396, 343);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBoxCurrentsnap);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(201, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(192, 337);
            panel3.TabIndex = 3;
            // 
            // pictureBoxCurrentsnap
            // 
            pictureBoxCurrentsnap.Dock = DockStyle.Fill;
            pictureBoxCurrentsnap.Location = new Point(0, 23);
            pictureBoxCurrentsnap.Name = "pictureBoxCurrentsnap";
            pictureBoxCurrentsnap.Size = new Size(192, 314);
            pictureBoxCurrentsnap.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCurrentsnap.TabIndex = 5;
            pictureBoxCurrentsnap.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(192, 23);
            label1.TabIndex = 4;
            label1.Text = "Current Snap";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBoxBest);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(192, 337);
            panel2.TabIndex = 2;
            // 
            // pictureBoxBest
            // 
            pictureBoxBest.Dock = DockStyle.Fill;
            pictureBoxBest.Location = new Point(0, 23);
            pictureBoxBest.Name = "pictureBoxBest";
            pictureBoxBest.Size = new Size(192, 314);
            pictureBoxBest.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBest.TabIndex = 3;
            pictureBoxBest.TabStop = false;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(192, 23);
            label2.TabIndex = 2;
            label2.Text = "Best Pattern";
            // 
            // PatternValidation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 443);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(listViewImage);
            Name = "PatternValidation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatternValidation";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCurrentsnap).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxBest).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewImage;
        private Button buttonGetBest;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBoxBest;
        private Label label2;
        private PictureBox pictureBoxCurrentsnap;
        private Label label1;
        private Button buttonDone;
        private Label labelClase;
    }
}