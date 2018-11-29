namespace MosaicPosLogTool
{
    partial class MainForm
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
            this.processLogFilesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processLogFilesBtn
            // 
            this.processLogFilesBtn.Location = new System.Drawing.Point(320, 207);
            this.processLogFilesBtn.Name = "processLogFilesBtn";
            this.processLogFilesBtn.Size = new System.Drawing.Size(162, 32);
            this.processLogFilesBtn.TabIndex = 0;
            this.processLogFilesBtn.Text = "Process log files";
            this.processLogFilesBtn.UseVisualStyleBackColor = true;
            this.processLogFilesBtn.Click += new System.EventHandler(this.processLogFilesBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 251);
            this.Controls.Add(this.processLogFilesBtn);
            this.Name = "MainForm";
            this.Text = "Mosaic POS Log Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button processLogFilesBtn;
    }
}

