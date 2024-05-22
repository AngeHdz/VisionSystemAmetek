namespace VisionSystemAmetek.TrainForm
{
    partial class CreateROI
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
            pictureBox = new PictureBox();
            panel2 = new Panel();
            buttonValid = new Button();
            panel3 = new Panel();
            textBoxName = new TextBox();
            label1 = new Label();
            panelbuttons = new Panel();
            buttonCancel = new Button();
            buttonSave = new Button();
            panelMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panelbuttons.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(3, 6);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(276, 137);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonValid);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(444, 35);
            panel2.TabIndex = 1;
            // 
            // buttonValid
            // 
            buttonValid.Location = new Point(332, 9);
            buttonValid.Name = "buttonValid";
            buttonValid.Size = new Size(101, 23);
            buttonValid.TabIndex = 2;
            buttonValid.Text = "Validate";
            buttonValid.UseVisualStyleBackColor = true;
            buttonValid.Click += ButtonValid_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBoxName);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(77, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 35);
            panel3.TabIndex = 1;
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Bottom;
            textBoxName.Location = new Point(0, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(240, 23);
            textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.BottomLeft;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 35);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            label1.TextAlign = ContentAlignment.BottomRight;
            // 
            // panelbuttons
            // 
            panelbuttons.Controls.Add(buttonCancel);
            panelbuttons.Controls.Add(buttonSave);
            panelbuttons.Dock = DockStyle.Bottom;
            panelbuttons.Location = new Point(0, 251);
            panelbuttons.Name = "panelbuttons";
            panelbuttons.Size = new Size(444, 50);
            panelbuttons.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(357, 6);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 32);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(276, 6);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 32);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.Controls.Add(pictureBox);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 35);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(444, 216);
            panelMain.TabIndex = 3;
            // 
            // CreateROI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 301);
            Controls.Add(panelMain);
            Controls.Add(panelbuttons);
            Controls.Add(panel2);
            MinimumSize = new Size(460, 340);
            Name = "CreateROI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateROI";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelbuttons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox;
        private Panel panel2;
        private TextBox textBoxName;
        private Label label1;
        private Button buttonValid;
        private Panel panel3;
        private Panel panelbuttons;
        private Button buttonCancel;
        private Button buttonSave;
        private Panel panelMain;
    }
}