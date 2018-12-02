using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        private string _outputPathLogs;
        private IProgress<ProgressReportModel> _progress;
        private CancellationToken _cancellationToken;
        private bool _enableAnalysis;
        private string _outputPathErrors;
        private Dictionary<ErrorOperationEnum, ErrorData> _errorDic;
        private DateTime _startTime;
        private DateTime _endTime;
        private Dictionary<string, int> _errorCountDic;


        public LogProcessor(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken, bool enableAnalysis, DateTime startTime, DateTime endTime)
        {
            _logFiles = new List<string>();
            _sessionDic = new Dictionary<string, SessionData>();
            _threadDic = new Dictionary<int, string>();
            _errorDic = new Dictionary<ErrorOperationEnum, ErrorData>();
            _errorCountDic = new Dictionary<string, int>();
            _outputPathLogs = Environment.CurrentDirectory + @"\Logs";
            _outputPathErrors = Environment.CurrentDirectory + @"\Errors";
            _progress = progress;
            _cancellationToken = cancellationToken;
            _enableAnalysis = enableAnalysis;
            _startTime = startTime;
            _endTime = endTime;

            Init();
        }

        public string CurrentLine
        {
            get { return _currentLine; }
        }

        public IList<string> LogFiles
        {
            get { return _logFiles; }
        }

        private void Init()
        {
            if(_enableAnalysis)
            {
                _errorDic.Add(ErrorOperationEnum.Redundant, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                    }
                });
                _errorDic.Add(ErrorOperationEnum.Others, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                    }
                });
                _errorDic.Add(ErrorOperationEnum.CommunicationException, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"System.ServiceModel.CommunicationException"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.AddPaymentX, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowPosFaultException - [PosFaultType]PaymentFault, [Operation]AddPayment"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.GetCurrentTransaction, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowPosFaultException - [PosFaultType]TransactionFault, [Operation]GetCurrentTransaction,"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.GetCustomerList, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowFaultException - [Operation]GetCustomerList,"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.GetPasswordPolicy, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowFaultException - [Operation]GetPasswordPolicy,"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.LogoutOperator, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowPosFaultException - [PosFaultType]SessionFault, [Operation]LogoutOperator,",
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowFaultException - [Operation]LogoutOperator,"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.SaveTransaction, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[FATAL] Raymark.Entities.Transaction => SaveFinal - [Operation]Transaction->SaveFinal(),",
                        @"[FATAL] Raymark.Entities.Transaction => Void - [Operation]Transaction->Void(),",
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowPosFaultException - [PosFaultType]TransactionFault, [Operation]SaveTransaction, [Code]NotCompleteTransactionForGenerateBarcode,"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.ScanItem, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowFaultException - [Operation]ScanItem,"
                    }
                });
                _errorDic.Add(ErrorOperationEnum.StartTransaction, new ErrorData
                {
                    SearchKeys = new List<string>
                    {
                        @"[ERROR] Raymark.Web.POSService.ExceptionManager => ThrowFaultException - [Operation]StartTransaction,"
                    }
                });
            }
        }

        public async Task StartProcess()
        {
            LoadFiles();
            CreateOutputFolder();
            await ProcessFiles();
        }

        private void CreateOutputFolder()
        {
            if(!Directory.Exists(_outputPathLogs))
            {
                Directory.CreateDirectory(_outputPathLogs);
            }

            if(_enableAnalysis)
            {
                if (!Directory.Exists(_outputPathErrors))
                {
                    Directory.CreateDirectory(_outputPathErrors);
                }
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
                    foreach (var logFile in _logFiles)
                    {
                        if (File.Exists(logFile))
                        {
                            report.ReportType = ProgressReportTypeEnum.CurrentFile;
                            report.CurrentProcessingFile = logFile;
                            _progress.Report(report);

                            Stopwatch watch = Stopwatch.StartNew();

                            using (var reader = new StreamReader(logFile))
                            {
                                _currentLine = reader.ReadLine();
                                int lineNumber = 1;

                                while (_currentLine != null)
                                {
                                    _cancellationToken.ThrowIfCancellationRequested();

                                    if (lineNumber % 1000 == 0)
                                    {
                                        report.ReportType = ProgressReportTypeEnum.CurrentLineNumber;
                                        report.CurrentProcessingFileLineNumber = lineNumber;
                                        _progress.Report(report);
                                    }

                                    Tuple<string, ErrorOperationEnum?> result = ProcessLine();
                                    if (result.Item1 != null)
                                    {
                                        WriteLine(result.Item1, result.Item2);
                                    }

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
                    foreach (var sessionPair in _sessionDic)
                    {
                        var sessionId = sessionPair.Key;
                        var session = sessionPair.Value;
                        if (session.Writer != null)
                        {
                            session.Writer.Close();
                            string newFileName = $@"{_outputPathLogs}\[{session.StartTime}]-[{session.EndTime}][ERROR({session.ErrorCount})][FATAL({session.FatalCount})] {sessionId}.txt";
                            if (File.Exists(newFileName))
                            {
                                File.Delete(newFileName);
                            }

                            File.Move(session.FileName, newFileName);
                        }
                    }

                    foreach (var errorPair in _errorDic)
                    {
                        var errOperation = errorPair.Key;
                        var error = errorPair.Value;
                        if (error.Writer != null)
                        {
                            error.Writer.Close();
                            string newFileName = $@"{_outputPathErrors}\[{errOperation}] [{error.StartTime}]-[{error.EndTime}][ERROR({error.ErrorCount})].txt";
                            if (File.Exists(newFileName))
                            {
                                File.Delete(newFileName);
                            }

                            File.Move(error.FileName, newFileName);
                        }
                    }

                    if (_errorCountDic.Count > 0)
                    {
                        string fileName = $@"{_outputPathErrors}\ErrorCount.txt";
                        if(File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        using (var writer = new StreamWriter(fileName, true))
                        {
                            foreach(var pair in _errorCountDic.OrderByDescending(e => e.Value))
                            {
                                writer.WriteLine($"{pair.Key}: {pair.Value}");
                            }
                        }
                    }

                    watchTotal.Stop();

                    report.ReportType = ProgressReportTypeEnum.TotalProcessTime;
                    report.TotalProcessTime = watchTotal.Elapsed.ToString();
                    _progress.Report(report);
                }

            });

        }

        private Tuple<string, ErrorOperationEnum?> ProcessLine()
        {
            string sessionId = null;
            ErrorOperationEnum? errorOperation = null;

            if (_currentLine != null)
            {
                //if (_currentLine.Contains(@"2052539ms [             62] 2018-11-21 09:51:21,533 [ERROR] Raymark.EpaymentModule.Epayment => GetMainData - string responseStr"))
                //{
                //    ;
                //}

                int? threadId = null;
                bool foundSessionId = false;
                string timeStamp = string.Empty;
                string operationName = null;
                bool isError = false;
                bool isFatal = false;
                int operationInsertIndex = 60;

                Match match = Regex.Match(_currentLine, @"\[\s*\d+\] (.+) \[(INFO |ERROR|DEBUG|WARN |FATAL)\]", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    timeStamp = match.Groups[1].Value.Replace(':', '.');

                    if(!ValidateTime(timeStamp))
                    {
                        return new Tuple<string, ErrorOperationEnum?>(null, null);
                    }


                    if (match.Groups[2].Value == "ERROR")
                    {
                        isError = true;
                    }
                    else if (match.Groups[2].Value == "FATAL")
                    {
                        isFatal = true;
                    }

                    operationInsertIndex = _currentLine.IndexOf(match.Groups[0].Value) + match.Groups[0].Value.Length + 1;
                }

                match = Regex.Match(_currentLine, @"\[SessionId\]=([^;]+);", RegexOptions.IgnoreCase);
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

                match = Regex.Match(_currentLine, @"\[Operation\]=([^;]+);", RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    operationName = match.Groups[1].Value;
                }
                else
                {
                    match = Regex.Match(_currentLine, @"<Operation>=([^;]+);", RegexOptions.IgnoreCase);
                    if(match.Success)
                    {
                        operationName = match.Groups[1].Value;
                    }
                    else
                    {
                        match = Regex.Match(_currentLine, @"\[Operation\]([^,]+),", RegexOptions.IgnoreCase);
                        if(match.Success)
                        {
                            operationName = match.Groups[1].Value;
                        }
                        else
                        {
                            match = Regex.Match(_currentLine, @"Operation=([^,]+),", RegexOptions.IgnoreCase);
                            if(match.Success)
                            {
                                operationName = match.Groups[1].Value;
                            }
                        }
                    }
                }

                if (_enableAnalysis && (isError || isFatal))
                {
                    errorOperation = ProcessError(operationName, timeStamp);
                }

                // Update line inserting Operaton column
                if(operationName != null && timeStamp != string.Empty)
                {
                    // Max operation length is 46
                    _currentLine = _currentLine.Substring(0, operationInsertIndex) + $"[  {operationName.PadRight(30)} ] " + _currentLine.Substring(operationInsertIndex);
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

            return new Tuple<string, ErrorOperationEnum?>(sessionId, errorOperation);
        }

        private bool ValidateTime(string timeStamp)
        {
            bool isTimeValid = true;

            DateTime time;
            if(DateTime.TryParseExact(timeStamp, "yyyy-MM-dd hh.mm.ss,fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
                if(time < _startTime || time > _endTime)
                {
                    isTimeValid = false;
                }
            }

            return isTimeValid;
        }

        private ErrorOperationEnum? ProcessError(string operationName, string timeStamp)
        {
            ErrorOperationEnum? errorOperation = null;
            foreach (KeyValuePair<ErrorOperationEnum, ErrorData> errorPair in _errorDic)
            {
                if (errorOperation == null)
                {
                    foreach (string searchKey in errorPair.Value.SearchKeys)
                    {
                        if (_currentLine.Contains(searchKey))
                        {
                            errorOperation = errorPair.Key;
                            break;
                        }
                    }
                }
            }

            if (errorOperation == null)
            {
                foreach (ErrorOperationEnum errOperation in Enum.GetValues(typeof(ErrorOperationEnum)))
                {
                    if (operationName != null &&
                        (operationName.Equals(errOperation.ToString(), StringComparison.OrdinalIgnoreCase)
                        || operationName.StartsWith("AddPayment")))
                    {
                        errorOperation = ErrorOperationEnum.Redundant;
                        break;
                    }
                }
            }

            if(errorOperation == null)
            {
                errorOperation = ErrorOperationEnum.Others;
            }

            var error = _errorDic[errorOperation.Value];

            error.ErrorCount++;
            if (error.StartTime == null)
            {
                error.StartTime = timeStamp;
            }
            error.EndTime = timeStamp;

            // Add error count
            var keys = new List<string>();

            var searchStrings = new List<string>
            {
                @"System.ServiceModel.CommunicationException",
                @"System.Data.SqlClient.SqlException (0x80131904): Execution Timeout Expired",
                @"System.Data.SqlClient.SqlException",
                @"Exception from 24 hours fitness"
            };

            foreach(string str in searchStrings)
            {
                if(_currentLine.Contains(str))
                {
                    keys.Add(str);
                }
            }

            if (operationName != null)
            {
                keys.Add(operationName);
            }

            foreach (string key in keys)
            {
                if(_errorCountDic.ContainsKey(key))
                {
                    _errorCountDic[key]++;
                }
                else
                {
                    _errorCountDic.Add(key, 1);
                }
            }



            return errorOperation;
        }

        private void WriteLine(string sessionId, ErrorOperationEnum? errorOperation = null)
        {
            var session = _sessionDic[sessionId];
            if(session.Writer == null)
            {
                session.FileName = $@"{_outputPathLogs}\{sessionId}";
                session.Writer = new StreamWriter(session.FileName, true);
            }

            session.Writer.WriteLine(_currentLine);

            if(errorOperation != null)
            {
                var error = _errorDic[errorOperation.Value];
                if(error.Writer == null)
                {
                    error.FileName = $@"{_outputPathErrors}\{errorOperation.Value.ToString()}";
                    error.Writer = new StreamWriter(error.FileName, true);
                }

                error.Writer.WriteLine($"{_currentLine} [{sessionId}]");
            }
        }
    }
}
