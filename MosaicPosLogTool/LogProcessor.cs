using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MosaicPosLogTool
{
    public class LogProcessor : ILogProcessor
    {
        private string _currentLine;
        private List<string> _logFiles;
        private Dictionary<string, SessionData> _sessionDic;
        private Dictionary<int, string> _threadDic;
        private int? _lastThreadId;
        private string _outputPath;
        private IProgress<ProgressReportModel> _progress;
        private CancellationToken _cancellationToken;


        public LogProcessor(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            _logFiles = new List<string>();
            _sessionDic = new Dictionary<string, SessionData>();
            _threadDic = new Dictionary<int, string>();
            _progress = progress;
            _cancellationToken = cancellationToken;
        }

        public async Task StartProcess()
        {
            LoadFiles();
            CreateOutputFolder();
            await ProcessFiles();
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

            ProgressReportModel report = new ProgressReportModel();
            report.ReportType = ProgressReportTypeEnum.FileList;
            report.LogFiles = _logFiles;
            _progress.Report(report);

        }

        private async Task ProcessFiles()
        {
            await Task.Run(() =>
            {
                ProgressReportModel report = new ProgressReportModel();

                Stopwatch watchTotal = Stopwatch.StartNew();

                try
                {
                    foreach(var logFile in _logFiles)
                    {
                        if(File.Exists(logFile))
                        {
                            report.ReportType = ProgressReportTypeEnum.CurrentFile;
                            report.CurrentProcessingFile = logFile;
                            _progress.Report(report);

                            Stopwatch watch = Stopwatch.StartNew();

                            using ( var reader = new StreamReader(logFile))
                            {
                                _currentLine = reader.ReadLine();
                                int lineNumber = 1;
                       
                                while(_currentLine != null)
                                {
                                    _cancellationToken.ThrowIfCancellationRequested();

                                    if(lineNumber % 1000 == 0)
                                    {
                                        report.ReportType = ProgressReportTypeEnum.CurrentLineNumber;
                                        report.CurrentProcessingFileLineNumber = lineNumber;
                                        _progress.Report(report);
                                    }

                                    string sessionId = ProcessLine();
                                    WriteLine(sessionId);

                                    _currentLine = reader.ReadLine();
                                    lineNumber++;
                                }
                            }

                            watch.Stop();

                            report.ReportType = ProgressReportTypeEnum.CurrentFileProcessTime;
                            report.CurrentFileProcessTime = watch.Elapsed.ToString();
                            _progress.Report(report);
                        }
                    }
                }
                finally
                {
                    foreach(var sessionPair in _sessionDic)
                    {
                        var sessionId = sessionPair.Key;
                        var session = sessionPair.Value;
                        if(session.Writer != null)
                        {
                            session.Writer.Close();
                            string newFileName = $@"{_outputPath}\[{session.StartTime}]-[{session.EndTime}][ERROR({session.ErrorCount})][FATAL({session.FatalCount})]{sessionId}.txt";
                            if(File.Exists(newFileName))
                            {
                                File.Delete(newFileName);
                            }

                            File.Move(session.FileName, newFileName);
                        }
                    }

                    watchTotal.Stop();

                    report.ReportType = ProgressReportTypeEnum.TotalProcessTime;
                    report.TotalProcessTime = watchTotal.Elapsed.ToString();
                    _progress.Report(report);
                }

            });

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
                //if (_currentLine.Contains(@"2052539ms [             62] 2018-11-21 09:51:21,533 [ERROR] Raymark.EpaymentModule.Epayment => GetMainData - string responseStr"))
                //{
                //    ;
                //}

                int? threadId = null;
                bool foundSessionId = false;
                string timeStamp = string.Empty;
                string operation = null;
                bool isError = false;
                bool isFatal = false;
                int operationInsertIndex = 60;

                Match match = Regex.Match(_currentLine, @"\[SessionId\]=([^;]+);", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    sessionId = match.Groups[1].Value;
                    foundSessionId = true;
                }
                else
                {
                    match = Regex.Match(_currentLine, @"<SessionId>=([^;]+);", RegexOptions.IgnoreCase);
                    if(match.Success)
                    {
                        sessionId = match.Groups[1].Value;
                        foundSessionId = true;
                    }
                }

                match = Regex.Match(_currentLine, @"\[\s*(\d+)\]", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    threadId = Convert.ToInt32(match.Groups[1].Value);
                }

                match = Regex.Match(_currentLine, @"\[\s*\d+\] (.+) \[(INFO |ERROR|DEBUG|WARN |FATAL)\]", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    timeStamp = match.Groups[1].Value.Replace(':', '.');

                    if(match.Groups[2].Value == "ERROR")
                    {
                        isError = true;
                    }
                    else if(match.Groups[2].Value == "FATAL")
                    {
                        isFatal = true;
                    }

                    operationInsertIndex = _currentLine.IndexOf(match.Groups[0].Value) + match.Groups[0].Value.Length + 1;
                }

                match = Regex.Match(_currentLine, @"\[Operation\]=([^;]+);", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    operation = match.Groups[1].Value;
                }
                else
                {
                    match = Regex.Match(_currentLine, @"<Operation>=([^;]+);", RegexOptions.IgnoreCase);
                    if(match.Success)
                    {
                        operation = match.Groups[1].Value;
                    }
                    else
                    {
                        match = Regex.Match(_currentLine, @"\[Operation\]([^,]+),", RegexOptions.IgnoreCase);
                        if(match.Success)
                        {
                            operation = match.Groups[1].Value;
                        }
                        else
                        {
                            match = Regex.Match(_currentLine, @"Operation=([^,]+),", RegexOptions.IgnoreCase);
                            if(match.Success)
                            {
                                operation = match.Groups[1].Value;
                            }
                        }
                    }
                }

                // Update line inserting Operaton column
                if(operation != null && timeStamp != string.Empty)
                {
                    // Max operation length is 46
                    _currentLine = _currentLine.Substring(0, operationInsertIndex) + $"[  {operation.PadRight(30)} ] " + _currentLine.Substring(operationInsertIndex);
                }

                // Update sessionId Dictionary
                if(sessionId != null) // sessionId not null (threadId must be not null as well)
                {
                    if(!_sessionDic.ContainsKey(sessionId))
                    {
                         _sessionDic.Add(sessionId, new SessionData());
                    }

                    if(threadId.HasValue)
                    {
                        _sessionDic[sessionId].LastThreadId = threadId.Value;
                    }

                    if(timeStamp != null)
                    {
                        if(_sessionDic[sessionId].StartTime == null)
                        {
                            _sessionDic[sessionId].StartTime = timeStamp;
                        }

                        _sessionDic[sessionId].EndTime = timeStamp;
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
                        if(_lastThreadId.HasValue && _threadDic.ContainsKey(_lastThreadId.Value))
                        {
                            sessionId = _threadDic[_lastThreadId.Value];
                        }
                    }

                }


                // Update threadId Dictionary
                if(threadId.HasValue)
                {
                    _lastThreadId = threadId.Value;

                    if(foundSessionId)
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

                if(sessionId == null)
                {
                    sessionId = "void";
                    if(!_sessionDic.ContainsKey(sessionId))
                    {
                        _sessionDic.Add(sessionId, new SessionData());
                    }
                }

                // Update ERROR, FATAL count
                if (isError)
                {
                    _sessionDic[sessionId].ErrorCount++;
                }
                else if(isFatal)
                {
                    _sessionDic[sessionId].FatalCount++;
                }
            }

            return sessionId;
        }

        public void WriteLine(string sessionId)
        {
            var session = _sessionDic[sessionId];
            if(session.Writer == null)
            {
                session.FileName = $@"{_outputPath}\{sessionId}";
                session.Writer = new StreamWriter(session.FileName, true);
            }

            session.Writer.WriteLine(_currentLine);
        }
    }
}
