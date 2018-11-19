namespace PasswordPolicy.TestTool64
{
    partial class PasswordPolicyTestTool
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
            this.hashBtn = new System.Windows.Forms.Button();
            this.plainPasswordTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.verifyBtn = new System.Windows.Forms.Button();
            this.hashedPasswordTBox = new System.Windows.Forms.TextBox();
            this.passwordSaltKeyTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.plainPasswordEnTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.encryptedPasswordTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.passwordSaltKeyEnTBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hashBtn
            // 
            this.hashBtn.Location = new System.Drawing.Point(147, 42);
            this.hashBtn.Name = "hashBtn";
            this.hashBtn.Size = new System.Drawing.Size(412, 27);
            this.hashBtn.TabIndex = 0;
            this.hashBtn.Text = "Hash Password";
            this.hashBtn.UseVisualStyleBackColor = true;
            this.hashBtn.Click += new System.EventHandler(this.hashBtn_Click);
            // 
            // plainPasswordTBox
            // 
            this.plainPasswordTBox.Location = new System.Drawing.Point(147, 14);
            this.plainPasswordTBox.Name = "plainPasswordTBox";
            this.plainPasswordTBox.Size = new System.Drawing.Size(412, 22);
            this.plainPasswordTBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plain Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hashed Password:";
            // 
            // verifyBtn
            // 
            this.verifyBtn.Location = new System.Drawing.Point(147, 156);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(412, 27);
            this.verifyBtn.TabIndex = 0;
            this.verifyBtn.Text = "Verify Password";
            this.verifyBtn.UseVisualStyleBackColor = true;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // hashedPasswordTBox
            // 
            this.hashedPasswordTBox.Location = new System.Drawing.Point(147, 100);
            this.hashedPasswordTBox.Name = "hashedPasswordTBox";
            this.hashedPasswordTBox.Size = new System.Drawing.Size(412, 22);
            this.hashedPasswordTBox.TabIndex = 1;
            // 
            // passwordSaltKeyTBox
            // 
            this.passwordSaltKeyTBox.Location = new System.Drawing.Point(147, 128);
            this.passwordSaltKeyTBox.Name = "passwordSaltKeyTBox";
            this.passwordSaltKeyTBox.Size = new System.Drawing.Size(412, 22);
            this.passwordSaltKeyTBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password Salt Key:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.hashBtn);
            this.panel1.Controls.Add(this.plainPasswordTBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.hashedPasswordTBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.verifyBtn);
            this.panel1.Controls.Add(this.passwordSaltKeyTBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 199);
            this.panel1.TabIndex = 5;
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(159, 42);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(400, 27);
            this.encryptBtn.TabIndex = 0;
            this.encryptBtn.Text = "Encrypt Password";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // plainPasswordEnTBox
            // 
            this.plainPasswordEnTBox.Location = new System.Drawing.Point(159, 14);
            this.plainPasswordEnTBox.Name = "plainPasswordEnTBox";
            this.plainPasswordEnTBox.Size = new System.Drawing.Size(400, 22);
            this.plainPasswordEnTBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password Salt Key:";
            // 
            // encryptedPasswordTBox
            // 
            this.encryptedPasswordTBox.Location = new System.Drawing.Point(159, 100);
            this.encryptedPasswordTBox.Name = "encryptedPasswordTBox";
            this.encryptedPasswordTBox.Size = new System.Drawing.Size(400, 22);
            this.encryptedPasswordTBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Plain Password:";
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(159, 156);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(400, 27);
            this.decryptBtn.TabIndex = 0;
            this.decryptBtn.Text = "Decrypt Password";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // passwordSaltKeyEnTBox
            // 
            this.passwordSaltKeyEnTBox.Location = new System.Drawing.Point(159, 128);
            this.passwordSaltKeyEnTBox.Name = "passwordSaltKeyEnTBox";
            this.passwordSaltKeyEnTBox.Size = new System.Drawing.Size(400, 22);
            this.passwordSaltKeyEnTBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Encrypted Password:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.encryptBtn);
            this.panel2.Controls.Add(this.plainPasswordEnTBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.encryptedPasswordTBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.decryptBtn);
            this.panel2.Controls.Add(this.passwordSaltKeyEnTBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 199);
            this.panel2.TabIndex = 6;
            // 
            // PasswordPolicyTestTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 451);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PasswordPolicyTestTool";
            this.Text = "Password Policy Test (64bit)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hashBtn;
        private System.Windows.Forms.TextBox plainPasswordTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button verifyBtn;
        private System.Windows.Forms.TextBox hashedPasswordTBox;
        private System.Windows.Forms.TextBox passwordSaltKeyTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.TextBox plainPasswordEnTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox encryptedPasswordTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.TextBox passwordSaltKeyEnTBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
    }
}

