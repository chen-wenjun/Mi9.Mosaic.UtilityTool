﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public interface ILogProcessor
    {
        string CurrentLine { get; }
        IList<string> LogFiles { get; }

        bool ReadNextLine();
        void ProcessLine();
        bool WriteLine(string sessionId);
    }
}