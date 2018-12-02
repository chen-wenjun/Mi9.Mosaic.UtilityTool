using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class ErrorData
    {
        public string FileName { get; set; }
        public StreamWriter Writer { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ErrorCount { get; set; }
        public IEnumerable<string> SearchKeys { get; set; }
    }

    public enum ErrorOperationEnum
    {
        Redundant,
        Others,
        AddPaymentX,
        GetCurrentTransaction,
        GetPasswordPolicy,
        LogoutOperator,
        SaveTransaction,
        ScanItem,
        StartTransaction
    }
}
