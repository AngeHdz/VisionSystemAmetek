namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    partial class SmoothBlurSet
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
            numericUpDownWidth = new NumericUpDown();
            numericUpDownHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownWidth
            // 
            numericUpDownWidth.Location = new Point(84, 3);
            numericUpDownWidth.Name = "numericUpDownWidth";
            numericUpDownWidth.Size = new Size(65, 23);
            numericUpDownWidth.TabIndex = 0;
            numericUpDownWidth.ValueChanged += NumericUpDownWidth_ValueChanged;
            // 
            // numericUpDownHeight
            // 
            numericUpDownHeight.Location = new Point(84, 50);
            numericUpDownHeight.Name = "numericUpDownHeight";
            numericUpDownHeight.Size = new Size(65, 23);
            numericUpDownHeight.TabIndex = 1;
            numericUpDownHeight.ValueChanged += NumericUpDownHeight_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 2;
            label1.Text = "Width:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 55);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 3;
            label2.Text = "Height:";
            // 
            // SmoothBlurSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownHeight);
            Controls.Add(numericUpDownWidth);
            Name = "SmoothBlurSet";
            Size = new Size(200, 145);
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownWidth;
        private NumericUpDown numericUpDownHeight;
        private Label label1;
        private Label label2;
    }
}
