using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MosaicPosLogTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void processLogFilesBtn_Click(object sender, EventArgs e)
        {
            var logProcessor = new LogProcessor();
            logProcessor.StartProcess();

            MessageBox.Show("Log files processed successfully!");
        }
    }
}
