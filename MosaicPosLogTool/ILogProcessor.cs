using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public interface ILogProcessor
    {
        string CurrentLine { get; }
        IList<FileInfo> LogFiles { get; }

        Task StartProcess();
    }
}
