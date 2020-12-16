namespace Assembly_Information
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.labelAssemblyTitle = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAssemblyTitle
            // 
            this.labelAssemblyTitle.AutoSize = true;
            this.labelAssemblyTitle.Location = new System.Drawing.Point(24, 33);
            this.labelAssemblyTitle.Name = "labelAssemblyTitle";
            this.labelAssemblyTitle.Size = new System.Drawing.Size(0, 16);
            this.labelAssemblyTitle.TabIndex = 0;
            this.labelAssemblyTitle.UseCompatibleTextRendering = true;
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DateToolStripStatusLabel,
            this.TimeToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 251);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(292, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DateToolStripStatusLabel
            // 
            this.DateToolStripStatusLabel.Name = "DateToolStripStatusLabel";
            this.DateToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // TimeToolStripStatusLabel
            // 
            this.TimeToolStripStatusLabel.Name = "TimeToolStripStatusLabel";
            this.TimeToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelAssemblyTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAssemblyTitle;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DateToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel TimeToolStripStatusLabel;
    }
}

