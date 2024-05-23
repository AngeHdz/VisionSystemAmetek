namespace VisionSystemAmetek.ProcessWindows
{
    partial class FiltersForm
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
            panel1 = new Panel();
            panel90 = new Panel();
            panelTool = new Panel();
            panel5 = new Panel();
            buttonAccept = new Button();
            buttonCancel = new Button();
            panel4 = new Panel();
            label2 = new Label();
            textBoxName = new TextBox();
            label1 = new Label();
            comboBoxFilters = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelOriginal = new Panel();
            pictureBoxOriginal = new PictureBox();
            panelProcessed = new Panel();
            pictureBoxProcessed = new PictureBox();
            panel1.SuspendLayout();
            panel90.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelOriginal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            panelProcessed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel90);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 423);
            panel1.TabIndex = 0;
            // 
            // panel90
            // 
            panel90.Controls.Add(panelTool);
            panel90.Controls.Add(panel5);
            panel90.Dock = DockStyle.Fill;
            panel90.Location = new Point(0, 71);
            panel90.Name = "panel90";
            panel90.Size = new Size(200, 352);
            panel90.TabIndex = 1;
            // 
            // panelTool
            // 
            panelTool.Dock = DockStyle.Fill;
            panelTool.Location = new Point(0, 0);
            panelTool.Name = "panelTool";
            panelTool.Size = new Size(200, 303);
            panelTool.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(buttonAccept);
            panel5.Controls.Add(buttonCancel);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 303);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 49);
            panel5.TabIndex = 0;
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(125, 12);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(69, 27);
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Done";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += ButtonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(12, 14);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBoxName);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(comboBoxFilters);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 71);
            panel4.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Name:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(60, 41);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(134, 23);
            textBoxName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Filter:";
            // 
            // comboBoxFilters
            // 
            comboBoxFilters.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilters.FlatStyle = FlatStyle.Flat;
            comboBoxFilters.FormattingEnabled = true;
            comboBoxFilters.Location = new Point(60, 12);
            comboBoxFilters.Name = "comboBoxFilters";
            comboBoxFilters.Size = new Size(134, 23);
            comboBoxFilters.TabIndex = 0;
            comboBoxFilters.SelectedIndexChanged += ComboBoxFilters_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panelOriginal, 0, 0);
            tableLayoutPanel1.Controls.Add(panelProcessed, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(200, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(516, 423);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panelOriginal
            // 
            panelOriginal.AutoScroll = true;
            panelOriginal.Controls.Add(pictureBoxOriginal);
            panelOriginal.Dock = DockStyle.Fill;
            panelOriginal.Location = new Point(3, 3);
            panelOriginal.Name = "panelOriginal";
            panelOriginal.Size = new Size(252, 417);
            panelOriginal.TabIndex = 0;
            panelOriginal.Scroll += PanelOriginal_Scroll;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(3, 3);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(100, 50);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxOriginal.TabIndex = 0;
            pictureBoxOriginal.TabStop = false;
            // 
            // panelProcessed
            // 
            panelProcessed.AutoScroll = true;
            panelProcessed.Controls.Add(pictureBoxProcessed);
            panelProcessed.Dock = DockStyle.Fill;
            panelProcessed.Location = new Point(261, 3);
            panelProcessed.Name = "panelProcessed";
            panelProcessed.Size = new Size(252, 417);
            panelProcessed.TabIndex = 1;
            panelProcessed.Scroll += PanelProcessed_Scroll;
            // 
            // pictureBoxProcessed
            // 
            pictureBoxProcessed.Location = new Point(3, 3);
            pictureBoxProcessed.Name = "pictureBoxProcessed";
            pictureBoxProcessed.Size = new Size(100, 50);
            pictureBoxProcessed.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxProcessed.TabIndex = 1;
            pictureBoxProcessed.TabStop = false;
            // 
            // FiltersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 423);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "FiltersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FiltersForm";
            panel1.ResumeLayout(false);
            panel90.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panelOriginal.ResumeLayout(false);
            panelOriginal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            panelProcessed.ResumeLayout(false);
            panelProcessed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelOriginal;
        private PictureBox pictureBoxOriginal;
        private Panel panelProcessed;
        private PictureBox pictureBoxProcessed;
        private Panel panel4;
        private Label label1;
        private ComboBox comboBoxFilters;
        private Label label2;
        private TextBox textBoxName;
        private Panel panel90;
        private Panel panel5;
        private Button buttonAccept;
        private Button buttonCancel;
        private Panel panelTool;
    }
}