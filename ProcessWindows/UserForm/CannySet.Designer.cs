namespace VisionSystemAmetek.ProcessWindows.UserForm
{
    partial class CannySet
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
            numericUpDownTresh = new NumericUpDown();
            numericUpDownTreshLinking = new NumericUpDown();
            numericUpDownApertureSize = new NumericUpDown();
            checkBoxGradient = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTreshLinking).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownApertureSize).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownTresh
            // 
            numericUpDownTresh.Location = new Point(99, 20);
            numericUpDownTresh.Name = "numericUpDownTresh";
            numericUpDownTresh.Size = new Size(89, 23);
            numericUpDownTresh.TabIndex = 0;
            numericUpDownTresh.ValueChanged += Update;
            // 
            // numericUpDownTreshLinking
            // 
            numericUpDownTreshLinking.Location = new Point(99, 63);
            numericUpDownTreshLinking.Name = "numericUpDownTreshLinking";
            numericUpDownTreshLinking.Size = new Size(89, 23);
            numericUpDownTreshLinking.TabIndex = 1;
            numericUpDownTreshLinking.ValueChanged += Update;
            // 
            // numericUpDownApertureSize
            // 
            numericUpDownApertureSize.Location = new Point(99, 102);
            numericUpDownApertureSize.Name = "numericUpDownApertureSize";
            numericUpDownApertureSize.Size = new Size(89, 23);
            numericUpDownApertureSize.TabIndex = 2;
            numericUpDownApertureSize.ValueChanged += Update;
            // 
            // checkBoxGradient
            // 
            checkBoxGradient.AutoSize = true;
            checkBoxGradient.Location = new Point(103, 145);
            checkBoxGradient.Name = "checkBoxGradient";
            checkBoxGradient.Size = new Size(80, 19);
            checkBoxGradient.TabIndex = 3;
            checkBoxGradient.Text = "I2Gradient";
            checkBoxGradient.UseVisualStyleBackColor = true;
            checkBoxGradient.CheckedChanged += Update;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 22);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 4;
            label1.Text = "Tresh:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 65);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 5;
            label2.Text = "TreshLinking:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 104);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 6;
            label3.Text = "ApertureSize:";
            // 
            // CannySet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBoxGradient);
            Controls.Add(numericUpDownApertureSize);
            Controls.Add(numericUpDownTreshLinking);
            Controls.Add(numericUpDownTresh);
            Name = "CannySet";
            Size = new Size(200, 177);
            ((System.ComponentModel.ISupportInitialize)numericUpDownTresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTreshLinking).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownApertureSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownTresh;
        private NumericUpDown numericUpDownTreshLinking;
        private NumericUpDown numericUpDownApertureSize;
        private CheckBox checkBoxGradient;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
