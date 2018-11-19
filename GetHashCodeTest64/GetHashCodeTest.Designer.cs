namespace GetHashCodeTest64
{
    partial class GetHashCodeTestForm
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
            this.hashCodeTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.getHashCodeBtn = new System.Windows.Forms.Button();
            this.stringTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hashCodeTBox
            // 
            this.hashCodeTBox.Location = new System.Drawing.Point(97, 40);
            this.hashCodeTBox.Name = "hashCodeTBox";
            this.hashCodeTBox.Size = new System.Drawing.Size(372, 22);
            this.hashCodeTBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "HashCode:";
            // 
            // getHashCodeBtn
            // 
            this.getHashCodeBtn.Location = new System.Drawing.Point(97, 68);
            this.getHashCodeBtn.Name = "getHashCodeBtn";
            this.getHashCodeBtn.Size = new System.Drawing.Size(372, 23);
            this.getHashCodeBtn.TabIndex = 9;
            this.getHashCodeBtn.Text = "GetHashCode";
            this.getHashCodeBtn.UseVisualStyleBackColor = true;
            this.getHashCodeBtn.Click += new System.EventHandler(this.getHashCodeBtn_Click);
            // 
            // stringTBox
            // 
            this.stringTBox.Location = new System.Drawing.Point(97, 12);
            this.stringTBox.Name = "stringTBox";
            this.stringTBox.Size = new System.Drawing.Size(372, 22);
            this.stringTBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "String:";
            // 
            // GetHashCodeTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 105);
            this.Controls.Add(this.hashCodeTBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.getHashCodeBtn);
            this.Controls.Add(this.stringTBox);
            this.Controls.Add(this.label1);
            this.Name = "GetHashCodeTestForm";
            this.Text = "GetHashCodeTest64";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hashCodeTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button getHashCodeBtn;
        private System.Windows.Forms.TextBox stringTBox;
        private System.Windows.Forms.Label label1;
    }
}

