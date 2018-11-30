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

        private async void processLogFilesBtn_Click(object sender, EventArgs e)
        {
            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;


            var logProcessor = new LogProcessor(progress);

            processLogFilesBtn.Enabled = false;
            
            try
            {
                await logProcessor.StartProcess();
                MessageBox.Show("Log files processed successfully!");
            }
            finally
            {
                processLogFilesBtn.Enabled = true;
            }

        }

        private void Progress_ProgressChanged(object sender, ProgressReportModel e)
        {
            if(e.ReportType == ProgressReportTypeEnum.FileList)
            {
                filesLBox.Items.AddRange(e.LogFiles.ToArray());
            }
            else if(e.ReportType == ProgressReportTypeEnum.CurrentFile)
            {
                detailLBox.Items.Add($"Processing File: {e.CurrentProcessingFile}");
                detailLBox.Items.Add($"Processing Line: {e.CurrentProcessingFileLineNumber}");
            }
            else if(e.ReportType == ProgressReportTypeEnum.CurrentLineNumber)
            {
                detailLBox.Items[detailLBox.Items.Count- 1] = $"Processing Line: {e.CurrentProcessingFileLineNumber}";
            }
            else if(e.ReportType == ProgressReportTypeEnum.CurrentFileProcessTime)
            {
                detailLBox.Items.Add($"Process Time for the file: {e.CurrentFileProcessTime}");
            }
            else if(e.ReportType == ProgressReportTypeEnum.TotalProcessTime)
            {
                detailLBox.Items.Add($"Total Process Time for all the files: {e.TotalProcessTime}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            folderTBox.Text = Environment.CurrentDirectory;
        }

        private void selectFolderBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderTBox.Text = folderBrowserDialog1.SelectedPath;
                Environment.CurrentDirectory = folderBrowserDialog1.SelectedPath;
            }

        }
    }
}
