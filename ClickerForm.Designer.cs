namespace Clicker
{
    partial class ClickerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nsClickInterval = new System.Windows.Forms.NumericUpDown();
            this.cbKeySelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsIsRunning = new System.Windows.Forms.ToolStripStatusLabel();
            this.nsIntDeviation = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nsClickInterval)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nsIntDeviation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hot Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interval (MS)";
            // 
            // nsClickInterval
            // 
            this.nsClickInterval.Location = new System.Drawing.Point(106, 33);
            this.nsClickInterval.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nsClickInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nsClickInterval.Name = "nsClickInterval";
            this.nsClickInterval.Size = new System.Drawing.Size(120, 20);
            this.nsClickInterval.TabIndex = 3;
            this.nsClickInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nsClickInterval.ValueChanged += new System.EventHandler(this.nsClickInterval_ValueChanged);
            // 
            // cbKeySelection
            // 
            this.cbKeySelection.AccessibleDescription = "";
            this.cbKeySelection.AccessibleName = "";
            this.cbKeySelection.FormattingEnabled = true;
            this.cbKeySelection.Location = new System.Drawing.Point(143, 6);
            this.cbKeySelection.Name = "cbKeySelection";
            this.cbKeySelection.Size = new System.Drawing.Size(83, 21);
            this.cbKeySelection.TabIndex = 4;
            this.cbKeySelection.SelectedValueChanged += new System.EventHandler(this.cbKeySelection_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CTL +";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsIsRunning});
            this.statusStrip1.Location = new System.Drawing.Point(0, 95);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(235, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsIsRunning
            // 
            this.tsIsRunning.Name = "tsIsRunning";
            this.tsIsRunning.Size = new System.Drawing.Size(75, 17);
            this.tsIsRunning.Text = "Not Running";
            // 
            // nsIntDeviation
            // 
            this.nsIntDeviation.Location = new System.Drawing.Point(106, 59);
            this.nsIntDeviation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nsIntDeviation.Name = "nsIntDeviation";
            this.nsIntDeviation.Size = new System.Drawing.Size(120, 20);
            this.nsIntDeviation.TabIndex = 8;
            this.nsIntDeviation.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nsIntDeviation.ValueChanged += new System.EventHandler(this.nsIntDeviation_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interval Deviation";
            // 
            // ClickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 117);
            this.Controls.Add(this.nsIntDeviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbKeySelection);
            this.Controls.Add(this.nsClickInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClickerForm";
            this.Text = "Clickin clicker";
            ((System.ComponentModel.ISupportInitialize)(this.nsClickInterval)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nsIntDeviation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nsClickInterval;
        private System.Windows.Forms.ComboBox cbKeySelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsIsRunning;
        private System.Windows.Forms.NumericUpDown nsIntDeviation;
        private System.Windows.Forms.Label label4;
    }
}

