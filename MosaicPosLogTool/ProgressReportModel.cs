using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class ProgressReportModel
    {
        public FileInfo CurrentProcessingFile { get; set; }
        //public int CurrentProcessingFileIndex { get; set; }
        //public int CurrentProcessingFileLineCount { get; set; }
        public int CurrentProcessingFileRunningLineNumber { get; set; }
        public long CurrentProcessingFileRuningBytes { get; set; }
        public long CurrentProcessingFileTotalRuningBytes { get; set; }
        public List<FileInfo> LogFiles { get; set; }
        public string CurrentFileProcessTime { get; set; }
        public string TotalProcessTime { get; set; }
        public ProgressReportTypeEnum ReportType { get; set; }
        public int[] ClosingFilesProgress { get; set; }
    }

    public enum ProgressReportTypeEnum
    {
        FileList,
        CurrentFile,
        CurrentLine,
        CurrentFileProcessTime,
        TotalProcessTime,
        ClosingFiles,
        ClosingCurrentFile
    }
}
