using Raymark.PassWordPolicy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordPolicy.TestTool
{
    public partial class PasswordPolicyTestTool : Form
    {
        public PasswordPolicyTestTool()
        {
            InitializeComponent();
        }

        private void hashBtn_Click(object sender, EventArgs e)
        {
            string password = plainPasswordTBox.Text.Trim();
            string hashSalt;

            if (saltKeyCBox.Checked)
            {
                if (string.IsNullOrWhiteSpace(passwordSaltKeyTBox.Text))
                {
                    MessageBox.Show("Salt key cannot be empty!", "Warning", MessageBoxButtons.OK);
                    return;
                }

                hashSalt = passwordSaltKeyTBox.Text.Trim();
                hashedPasswordTBox.Text = EncryptUtil.GetHashBySalt(password, hashSalt);
            }
            else
            {
                hashedPasswordTBox.Text = EncryptUtil.GetHashWithGeneratedSalt(password, out hashSalt);
                passwordSaltKeyTBox.Text = hashSalt;                
            }

        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            string password = plainPasswordTBox.Text.Trim();
            string hash = hashedPasswordTBox.Text.Trim();
            string hashSalt = passwordSaltKeyTBox.Text.Trim();
            
            bool isValid = EncryptUtil.IsPasswordEquivalentToHashedValue(password, hashSalt, hash);

            MessageBox.Show(isValid? "Password is Valid." : "Password is invalid.", "Password Verification result");

        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            string password = plainPasswordEnTBox.Text.Trim();
            string enSalt;
            encryptedPasswordTBox.Text = EncryptUtil.Encrypt(password, out enSalt);
            passwordSaltKeyEnTBox.Text = enSalt;
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            string encryption = encryptedPasswordTBox.Text.Trim();
            string enSalt = passwordSaltKeyEnTBox.Text.Trim();

            plainPasswordEnTBox.Text = EncryptUtil.Decrypt(encryption, enSalt);
        }
    }
}
