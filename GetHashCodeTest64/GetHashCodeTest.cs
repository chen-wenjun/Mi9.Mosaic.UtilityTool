using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetHashCodeTest64
{
    public partial class GetHashCodeTestForm : Form
    {
        public GetHashCodeTestForm()
        {
            InitializeComponent();
        }

        private void getHashCodeBtn_Click(object sender, EventArgs e)
        {
            hashCodeTBox.Text = stringTBox.Text.Trim().GetHashCode().ToString();
        }
    }
}
