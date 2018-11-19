namespace WindowsHardwareInfo
{
    partial class WindowsHardwareInfoFrm
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
            this.InfoTBox = new System.Windows.Forms.TextBox();
            this.loadInfoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoTBox
            // 
            this.InfoTBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoTBox.Location = new System.Drawing.Point(12, 12);
            this.InfoTBox.Multiline = true;
            this.InfoTBox.Name = "InfoTBox";
            this.InfoTBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InfoTBox.Size = new System.Drawing.Size(588, 416);
            this.InfoTBox.TabIndex = 0;
            // 
            // loadInfoBtn
            // 
            this.loadInfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadInfoBtn.Location = new System.Drawing.Point(436, 436);
            this.loadInfoBtn.Name = "loadInfoBtn";
            this.loadInfoBtn.Size = new System.Drawing.Size(162, 31);
            this.loadInfoBtn.TabIndex = 1;
            this.loadInfoBtn.Text = "Load Hardware Info";
            this.loadInfoBtn.UseVisualStyleBackColor = true;
            this.loadInfoBtn.Click += new System.EventHandler(this.loadInfoBtn_Click);
            // 
            // WindowsHardwareInfoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 474);
            this.Controls.Add(this.loadInfoBtn);
            this.Controls.Add(this.InfoTBox);
            this.Name = "WindowsHardwareInfoFrm";
            this.Text = "Windows Hardware Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InfoTBox;
        private System.Windows.Forms.Button loadInfoBtn;
    }
}

