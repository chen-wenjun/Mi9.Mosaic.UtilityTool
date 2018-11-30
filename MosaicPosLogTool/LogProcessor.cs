using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class LogProcessor : ILogProcessor
    {
        private string _currentLine;
        private List<string> _logFiles;
        private Dictionary<string, int> _sessionDic;
        private Dictionary<int, string> _threadDic;
        private int? _lastThread;
        private string _outputPath;


        public LogProcessor()
        {
            _logFiles = new List<string>();
            _sessionDic = new Dictionary<string, int>();
            _threadDic = new Dictionary<int, string>();
        }

        public void StartProcess()
        {
            LoadFiles();
            CreateOutputFolder();
            ProcessFiles();
        }

        private void CreateOutputFolder()
        {
            _outputPath = Environment.CurrentDirectory + @"\Logs";
            if(!Directory.Exists(_outputPath))
            {
                Directory.CreateDirectory(_outputPath);
            }
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

        private void ProcessFiles()
        {
            foreach(var logFile in _logFiles)
            {
                if(File.Exists(logFile))
                {
                    using ( var reader = new StreamReader(logFile))
                    {
                        _currentLine = reader.ReadLine();
                        
                        while(_currentLine != null)
                        {
                            string sessionId = ProcessLine();
                            WriteLine(sessionId);

                            _currentLine = reader.ReadLine();
                        }
                    }
                }
            }
        }

        public string CurrentLine
        {
            get { return _currentLine; }
        }

        public IList<string> LogFiles
        {
            get { return _logFiles; }
        }

        public string ProcessLine()
        {
            string sessionId = null;
            if(_currentLine != null)
            {
                //if(_currentLine.Contains(@"1664  ms [             13] 2018-11-26 13:30:18,348 [ERROR] Raymark.Web.POSService.ExceptionManager => ThrowPosFaultException"))
                //{
                //    ;
                //}

                int? threadId = null;
                bool hasSessionId = false;
                string timeStamp = "";

                Match match = Regex.Match(_currentLine, @"\[SessionId\]=([^;]+);", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    sessionId = match.Groups[1].Value;
                    hasSessionId = true;
                }
                else
                {
                    match = Regex.Match(_currentLine, @"<SessionId>=([^;]+);", RegexOptions.IgnoreCase);
                    if(match.Success)
                    {
                        sessionId = match.Groups[1].Value;
                        hasSessionId = true;
                    }
                }

                match = Regex.Match(_currentLine, @"\[\s*(\d+)\]", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    threadId = Convert.ToInt32(match.Groups[1].Value);
                }

                //match = Regex.Match(_currentLine, @"\[\s*\d+\] (.+) \[(INFO |ERROR|DEBUG|WARN |FATAL)\]", RegexOptions.IgnoreCase);
                //if(match.Success)
                //{
                //    timeStamp = match.Groups[1].Value;
                //}

                // Update sessionId Dictionary
                if(sessionId != null) // sessionId not null (threadId must be not null as well)
                {
                    if(_sessionDic.ContainsKey(sessionId))
                    {
                        _sessionDic[sessionId] = threadId.Value;
                    }
                    else
                    {
                        _sessionDic.Add(sessionId, threadId.Value);
                    }
                }



                // Get sessionId linked to the current line
                if(sessionId == null)
                {
                    if(threadId.HasValue)
                    {
                        if(_threadDic.ContainsKey(threadId.Value))
                        {
                            sessionId = _threadDic[threadId.Value];
                        }
                    }
                    else
                    {
                        if(_lastThread.HasValue && _threadDic.ContainsKey(_lastThread.Value))
                        {
                            sessionId = _threadDic[_lastThread.Value];
                        }
                    }

                }


                // Update threadId Dictionary
                if(threadId.HasValue)
                {
                    _lastThread = threadId.Value;

                    if(hasSessionId)
                    {
                        if(_threadDic.ContainsKey(threadId.Value))
                        {
                            _threadDic[threadId.Value] = sessionId;
                        }
                        else
                        {
                            _threadDic.Add(threadId.Value, sessionId);
                        }
                    }

                }


            }

            return sessionId;
        }

        public bool WriteLine(string sessionId)
        {
            if(sessionId == null)
                sessionId = "void";

            var filePath = $@"{_outputPath}\{sessionId}.txt";
            using(var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(_currentLine);
            }

            return true;
        }
    }
}
