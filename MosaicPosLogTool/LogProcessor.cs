using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class LogProcessor : ILogProcessor
    {
        private string _currentLine;
        private List<string> _logFiles;
        private Dictionary<string, int> _sessionDic;
        private Dictionary<int, string> _threadDic;
        private int _lastThread;


        public LogProcessor()
        {
            _logFiles = new List<string>();
            _sessionDic = new Dictionary<string, int>();
            _threadDic = new Dictionary<int, string>();

            LoadFiles();
        }

        private void LoadFiles()
        {
            var path = Environment.CurrentDirectory;
            var dirInfo = new DirectoryInfo(path);
            _logFiles = dirInfo.EnumerateFiles("*.txt.*")
                                .OrderBy(f => f.LastWriteTime)
                                .Select(f => f.FullName)
                                .ToList();

        }

        public string CurrentLine
        {
            get { return _currentLine; }
        }

        public IList<string> LogFiles
        {
            get { return _logFiles; }
        }

        public void ProcessLine()
        {
            throw new NotImplementedException();
        }

        public bool ReadNextLine()
        {
            throw new NotImplementedException();
        }

        public bool WriteLine(string sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
