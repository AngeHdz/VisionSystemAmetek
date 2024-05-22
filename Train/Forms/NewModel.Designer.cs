namespace VisionSystemAmetek.Train.Forms
{
    partial class NewModel
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
            label1 = new Label();
            textBoxModelName = new TextBox();
            buttonCreate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Project Name:";
            // 
            // textBoxModelName
            // 
            textBoxModelName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxModelName.Location = new Point(124, 16);
            textBoxModelName.Name = "textBoxModelName";
            textBoxModelName.Size = new Size(475, 47);
            textBoxModelName.TabIndex = 1;
            textBoxModelName.KeyPress += TextBoxModelName_KeyPress;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(458, 100);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(147, 56);
            buttonCreate.TabIndex = 2;
            buttonCreate.Text = "Done";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // NewModel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 164);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxModelName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewModel";
            Text = "Create";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxModelName;
        private Button buttonCreate;
    }
}