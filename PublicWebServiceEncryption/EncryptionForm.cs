using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublicWebServiceEncryption
{
    public partial class EncryptionForm : Form
    {
        public EncryptionForm()
        {
            InitializeComponent();
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            encryptedValueTBox.Text = Encrypt(valueTBox.Text.Trim(), passkeyTBox.Text.Trim());
        }


        private void decryptBtn_Click(object sender, EventArgs e)
        {
            decryptedValueTBox.Text = Decrypt(encryptedValueTBox.Text, passkeyTBox.Text.Trim());
        }


        private string Encrypt(string text, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(ivTBox.Text.Trim());

            int keysize = 256;

            byte[] keyBytes = Encoding.UTF8.GetBytes(passPhrase);
            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.Zeros;
                using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(cryptoStream))
                            {
                                writer.Write(text);
                            }

                            return Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }
        }

        private string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(ivTBox.Text.Trim());

            int keysize = 256;

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            byte[] keyBytes = Encoding.UTF8.GetBytes(passPhrase);
            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.Zeros;
                using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).Replace("\0", string.Empty);
                        }
                    }
                }
            }
        }

    }
}
