using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class ProgressReportModel
    {
        public string CurrentProcessingFile { get; set; }
        public int CurrentProcessingFileIndex { get; set; }
        public int CurrentProcessingFileLineCount { get; set; }
        public int CurrentProcessingFileLineNumber { get; set; }
        public List<string> LogFiles { get; set; }
        public string CurrentFileProcessTime { get; set; }
        public string TotalProcessTime { get; set; }
        public ProgressReportTypeEnum ReportType { get; set; }
    }

    public enum ProgressReportTypeEnum
    {
        FileList,
        CurrentFile,
        CurrentLineNumber,
        CurrentFileProcessTime,
        TotalProcessTime
    }
}
