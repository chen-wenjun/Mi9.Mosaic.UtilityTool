using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class Operation
    {
        public string SessionId { get; set; }
        public int ThreadId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Successful { get; set; }
        public double Duration { get; set; }
    }
}
