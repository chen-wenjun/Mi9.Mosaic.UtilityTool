using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class SessionData
    {
        public string FileName { get; set; }
        public bool FileExists { get; set; }
        public int LastThreadId { get; set; }
        public StreamWriter Writer { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ErrorCount { get; set; }
        public int FatalCount { get; set; }
    }
}
