namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    partial class SmoothMedianSet
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
            label1 = new Label();
            numericUpDownSize = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Size:";
            // 
            // numericUpDownSize
            // 
            numericUpDownSize.Location = new Point(39, 10);
            numericUpDownSize.Name = "numericUpDownSize";
            numericUpDownSize.Size = new Size(53, 23);
            numericUpDownSize.TabIndex = 1;
            numericUpDownSize.Click += NumericUpDownSize_Click;
            numericUpDownSize.KeyUp += NumericUpDownSize_KeyUp;
            // 
            // SmoothMedian
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDownSize);
            Controls.Add(label1);
            Name = "SmoothMedian";
            Size = new Size(120, 145);
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericUpDownSize;
    }
}
