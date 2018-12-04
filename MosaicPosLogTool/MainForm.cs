using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MosaicPosLogTool
{
    public partial class MainForm : Form
    {
        CancellationTokenSource _cancellationTokenSource;
        long _currentProcessingFileTotalBytes = 0L;
        long _allProcessingFilesTotalBytes = 0L;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void processLogFilesBtn_Click(object sender, EventArgs e)
        {
            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;

            _cancellationTokenSource = new CancellationTokenSource();
            
            var logProcessor = new LogProcessor(progress, _cancellationTokenSource.Token, 
                enableErrorCheckCBox.Checked, enableAnalysisCBox.Checked,
                startDateTimePicker.Checked ? startDateTimePicker.Value : DateTime.MinValue, 
                endDateTimePicker.Checked ? endDateTimePicker.Value : DateTime.MaxValue);

            processLogFilesBtn.Enabled = false;
            clearBoxBtn.Enabled = false;
            
            try
            {
                cancelProcessBtn.Enabled = true;
                await logProcessor.StartProcess();
                MessageBox.Show("Log files processed successfully!");
            }
            catch(OperationCanceledException)
            {
                detailLBox.Items.Add("The process was cancelled!");
            }
            finally
            {
                processLogFilesBtn.Enabled = true;
                clearBoxBtn.Enabled = true;
                cancelProcessBtn.Enabled = false;
                currentProgressBar.Value = 0;
                totalProgressBar.Value = 0;
                currentProgressLabel.Text = "";
                totalProgressLabel.Text = "";
                _currentProcessingFileTotalBytes = 0L;
                _allProcessingFilesTotalBytes = 0L;
            }

        }

        private void Progress_ProgressChanged(object sender, ProgressReportModel e)
        {
            if(e.ReportType == ProgressReportTypeEnum.FileList)
            {
                filesLBox.Items.Clear();
                filesLBox.Items.AddRange(e.LogFiles.Select(f => $"{f.Name} ( {f.Length.ToString("n0")} Bytes )").ToArray());

                foreach(var file in e.LogFiles)
                {
                    _allProcessingFilesTotalBytes += file.Length;
                }

                totalProgressBar.Value = 1;
                totalProgressLabel.Text = "Loaded files";
            }
            else if(e.ReportType == ProgressReportTypeEnum.CurrentFile)
            {
                detailLBox.Items.Add($"Processing File: {e.CurrentProcessingFile.Name} ( {e.CurrentProcessingFile.Length.ToString("n0")} Bytes )");
                detailLBox.Items.Add($"Processing Line: {e.CurrentProcessingFileRunningLineNumber}");
                totalProgressLabel.Text = $"Processing File: {e.CurrentProcessingFile.Name} ( {e.CurrentProcessingFile.Length.ToString("n0")} Bytes )";

                _currentProcessingFileTotalBytes = e.CurrentProcessingFile.Length;
                currentProgressBar.Value = 1;
            }
            else if(e.ReportType == ProgressReportTypeEnum.CurrentLine)
            {
                detailLBox.Items[detailLBox.Items.Count- 1] = $"Processing Line: {e.CurrentProcessingFileRunningLineNumber.ToString("n0")}";
                currentProgressLabel.Text = $"Processing Line: {e.CurrentProcessingFileRunningLineNumber.ToString("n0")}";

                int value = e.CurrentProcessingFileRuningBytes <= _currentProcessingFileTotalBytes ?
                                (int)(e.CurrentProcessingFileRuningBytes * 100L / _currentProcessingFileTotalBytes) : 100;
                currentProgressBar.Value = value;

                int totalValue = e.CurrentProcessingFileTotalRuningBytes <= _allProcessingFilesTotalBytes ?
                                (int)(e.CurrentProcessingFileTotalRuningBytes * 100L / _allProcessingFilesTotalBytes) : 100;
                totalProgressBar.Value = totalValue;

            }
            else if(e.ReportType == ProgressReportTypeEnum.CurrentFileProcessTime)
            {
                detailLBox.Items.Add($"Process Time: {e.CurrentFileProcessTime}");
                detailLBox.Items.Add("---------------------------");
            }
            else if(e.ReportType == ProgressReportTypeEnum.TotalProcessTime)
            {
                detailLBox.Items.Add("===========================");
                detailLBox.Items.Add($"Total Process Time: {e.TotalProcessTime}");
                detailLBox.Items.Add("===========================");
            }
            else if(e.ReportType == ProgressReportTypeEnum.ClosingFiles)
            {
                totalProgressLabel.Text = "Closing All session Files...";
            }
            else if(e.ReportType == ProgressReportTypeEnum.ClosingCurrentFile)
            {
                currentProgressBar.Value = e.ClosingFilesProgress[0] * 100 / e.ClosingFilesProgress[1];
                currentProgressLabel.Text = $"Closing session file: {e.ClosingFilesProgress[0]} / {e.ClosingFilesProgress[1]}";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            folderTBox.Text = Environment.CurrentDirectory;
            cancelProcessBtn.Enabled = false;
            startDateTimePicker.Value = DateTime.Today.AddMonths(-1);
            endDateTimePicker.Value = DateTime.Today.AddDays(1);
            startDateTimePicker.Checked = false;
            endDateTimePicker.Checked = false;
            currentProgressLabel.Text = "";
            totalProgressLabel.Text = "";
        }

        private void selectFolderBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderTBox.Text = folderBrowserDialog1.SelectedPath;
                Environment.CurrentDirectory = folderBrowserDialog1.SelectedPath;
            }

        }

        private void cancelProcessBtn_Click(object sender, EventArgs e)
        {
            if(_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private void clearBoxBtn_Click(object sender, EventArgs e)
        {
            detailLBox.Items.Clear();
            filesLBox.Items.Clear();
        }
    }
}
