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
        private List<FileInfo> _logFiles;
        private Dictionary<string, SessionData> _sessionDic;
        private Dictionary<int, string> _threadDic;
        private int? _lastThreadId;
        private string _outputPathLogs;
        private IProgress<ProgressReportModel> _progress;
        private CancellationToken _cancellationToken;
        private bool _enableErrorCheck;
        private bool _enableAnalysis;
        private string _outputPathErrors;
        private Dictionary<ErrorOperationEnum, ErrorData> _errorDic;
        private DateTime _startTime;
        private DateTime _endTime;
        private Dictionary<string, int> _errorCountDic;
        private long _runningFileBytes;
        private List<Operation> _saveTransactionOperations;


        public LogProcessor(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken, bool enableErrorCheck, bool enableAnalysis, DateTime startTime, DateTime endTime)
        {
            _logFiles = new List<FileInfo>();
            _sessionDic = new Dictionary<string, SessionData>();
            _threadDic = new Dictionary<int, string>();
            _errorDic = new Dictionary<ErrorOperationEnum, ErrorData>();
            _errorCountDic = new Dictionary<string, int>();
            _saveTransactionOperations = new List<Operation>();
            _outputPathLogs = Environment.CurrentDirectory + @"\Logs";
            _outputPathErrors = Environment.CurrentDirectory + @"\Analysis";
            _progress = progress;
            _cancellationToken = cancellationToken;
            _enableErrorCheck = enableErrorCheck;
            _enableAnalysis = enableAnalysis;
            _startTime = startTime;
            _endTime = endTime;
            _runningFileBytes = 0L;

            Init();
        }

        public string CurrentLine
        {
            get { return _currentLine; }
        }

        public IList<FileInfo> LogFiles
        {
            get { return _logFiles; }
        }

        private void Init()
        {
            if(_enableErrorCheck)
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

            if(_enableErrorCheck)
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
                Stopwatch watchTotal = Stopwatch.StartNew();

                try
                {
                    FileInfo previousFile = null;
                    foreach (var logFile in _logFiles)
                    {
                        if (File.Exists(logFile.FullName))
                        {
                            if(previousFile != null)
                            {
                                _runningFileBytes += previousFile.Length;
                            }

                            previousFile = logFile;

                            ProgressReportModel fileStartReport = new ProgressReportModel();
                            fileStartReport.ReportType = ProgressReportTypeEnum.CurrentFile;
                            fileStartReport.CurrentProcessingFile = logFile;
                            _progress.Report(fileStartReport);

                            Stopwatch watch = Stopwatch.StartNew();

                            ProgressReportModel lineReport = new ProgressReportModel();
                            using (var reader = new StreamReader(logFile.FullName))
                            {
                                _currentLine = reader.ReadLine();
                                int lineRunningNumber = 1;
                                long lineRunningBytes = _currentLine != null ? _currentLine.Length : 0L;

                                while (_currentLine != null)
                                {
                                    _cancellationToken.ThrowIfCancellationRequested();

                                    if (lineRunningNumber % 1000 == 0)
                                    {
                                        lineReport.ReportType = ProgressReportTypeEnum.CurrentLine;
                                        lineReport.CurrentProcessingFileRunningLineNumber = lineRunningNumber;
                                        lineReport.CurrentProcessingFileRuningBytes = lineRunningBytes;
                                        lineReport.CurrentProcessingFileTotalRuningBytes = _runningFileBytes + lineRunningBytes;
                                        _progress.Report(lineReport);
                                    }

                                    Tuple<string, ErrorOperationEnum?> result = ProcessLine();
                                    if (result.Item1 != null)
                                    {
                                        WriteLine(result.Item1, result.Item2);
                                    }

                                    _currentLine = reader.ReadLine();
                                    lineRunningNumber++;
                                    lineRunningBytes += _currentLine != null ? _currentLine.Length : 0L;
                                }
                            }

                            watch.Stop();

                            ProgressReportModel fileEndReport = new ProgressReportModel();
                            fileEndReport.ReportType = ProgressReportTypeEnum.CurrentFileProcessTime;
                            fileEndReport.CurrentFileProcessTime = watch.Elapsed.ToString();
                            _progress.Report(fileEndReport);
                        }
                    }
                }
                finally
                {
                    ProgressReportModel closingFilesReport = new ProgressReportModel();
                    closingFilesReport.ReportType = ProgressReportTypeEnum.ClosingFiles;
                    _progress.Report(closingFilesReport);

                    var machineSessionDic = new Dictionary<string, List<string>>();

                    var currentClosingFileCount = 0;
                    foreach (var sessionPair in _sessionDic)
                    {
                        var sessionId = sessionPair.Key;
                        var session = sessionPair.Value;
                        if (session.Writer != null)
                        {
                            session.Writer.Close();
                            string newFileName = $@"{_outputPathLogs}\[{session.StartTime}]-[{session.EndTime}][ERROR({session.ErrorCount})][FATAL({session.FatalCount})][{sessionId}][{session.StoreCode}][{session.RegisterNumber}][{session.MachineName}].txt";
                            if (File.Exists(newFileName))
                            {
                                File.Delete(newFileName);
                            }

                            File.Move(session.FileName, newFileName);
                        }

                        // Save session ids for each machine
                        if(session.MachineName != null)
                        {
                            string key = $"[{session.MachineName}],[{session.StoreCode}],[{session.RegisterNumber}]";
                            if(!machineSessionDic.ContainsKey(key))
                            {
                                machineSessionDic.Add(key, new List<string> { sessionId });
                            }
                            else
                            {
                                machineSessionDic[key].Add(sessionId);
                            }
                        }

                        currentClosingFileCount++;
                        ProgressReportModel closingCurrentFileReport = new ProgressReportModel();
                        closingCurrentFileReport.ReportType = ProgressReportTypeEnum.ClosingCurrentFile;
                        closingCurrentFileReport.ClosingFilesProgress = new int[] { currentClosingFileCount, _sessionDic.Count };
                        _progress.Report(closingCurrentFileReport);

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

                    if(_saveTransactionOperations.Count > 0)
                    {
                        string fileName = $@"{_outputPathErrors}\Analysis(SaveTransaction).txt";
                        if(File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        var minCountDic = new Dictionary<string, int>();
                        var secCountDic = new Dictionary<string, int>();
                        int totalFailed = 0;

                        using (var writer = new StreamWriter(fileName, true))
                        {
                            foreach(var operation in _saveTransactionOperations)
                            {
                                if(!operation.Successful)
                                {
                                    totalFailed++;
                                }

                                string min = operation.StartTime.Substring(0, 16);
                                string sec = operation.StartTime.Substring(0, 19);
                                if(minCountDic.ContainsKey(min))
                                {
                                    minCountDic[min]++;
                                }
                                else
                                {
                                    minCountDic.Add(min, 1);
                                }

                                if(secCountDic.ContainsKey(sec))
                                {
                                    secCountDic[sec]++;
                                }
                                else
                                {
                                    secCountDic.Add(sec, 1);
                                }

                                string status = operation.Successful ? "Succ" : "Fail";
                                if(operation.EndTime == null)
                                {
                                    operation.EndTime = "null";
                                }
                                writer.WriteLine($"{operation.StartTime} - {operation.EndTime.PadLeft(23)} [{operation.Duration.ToString("n3").PadLeft(7)}] [{status}] {operation.SessionId}");
                            }

                            writer.WriteLine("==============================================");
                            writer.WriteLine($"Total: {_saveTransactionOperations.Count.ToString("n0")} , Failed: {totalFailed.ToString("n0")}");
                            writer.WriteLine("==Count per minute============================================");

                            foreach(var pair in minCountDic.OrderByDescending(e => e.Value))
                            {
                                writer.WriteLine($"{pair.Key}: {pair.Value}");
                            }

                            writer.WriteLine("==Count per second============================================");

                            foreach(var pair in secCountDic.OrderByDescending(e => e.Value))
                            {
                                writer.WriteLine($"{pair.Key}: {pair.Value}");
                            }
                        }

                    }

                    if (machineSessionDic.Count > 0)
                    {
                        string fileName = $@"{_outputPathErrors}\MachineSessions.txt";
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        using (var writer = new StreamWriter(fileName, true))
                        {
                            foreach (var pair in machineSessionDic)
                            {
                                foreach(var sid in pair.Value)
                                {
                                    writer.WriteLine($"{pair.Key},[{sid}]");
                                }
                            }
                        }
                    }

                    watchTotal.Stop();

                    ProgressReportModel totalTimeReport = new ProgressReportModel();
                    totalTimeReport.ReportType = ProgressReportTypeEnum.TotalProcessTime;
                    totalTimeReport.TotalProcessTime = watchTotal.Elapsed.ToString();
                    _progress.Report(totalTimeReport);
                }

            });

        }

        private Tuple<string, ErrorOperationEnum?> ProcessLine()
        {
            string sessionId = null;
            ErrorOperationEnum? errorOperation = null;

            if (_currentLine != null)
            {
                //if (_currentLine.Contains(@"1248942ms [             87] 2018-12-17 10:20:45,089 [INFO ] LMI => AfterReceiveRequest - [Operation]=get-current-transaction-totals;[SessionId]=39c7ffd0-7c94-43a7-834a-68d"))
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

                string storeCode = null;
                string registerNumer = null;
                string machineName = null;

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
                    else
                    {
                        match = Regex.Match(_currentLine, @"Operation=OpenSession, SessionId=([^,]+), StoreCode=([^,]+), RegisterNumber=([^,]+), ComputerName=(.+)", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            sessionId = match.Groups[1].Value;
                            foundSessionId = true;

                            storeCode = match.Groups[2].Value;
                            registerNumer = match.Groups[3].Value;
                            machineName = match.Groups[4].Value;
                        }
                    }
                }

                match = Regex.Match(_currentLine, @"^\d+\s*ms \[\s*(\d+)\]", RegexOptions.IgnoreCase);
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

                if (_enableErrorCheck && (isError || isFatal))
                {
                    errorOperation = ProcessError(operationName, timeStamp);
                }

                if(_enableAnalysis && !isError && !isFatal && sessionId != null && threadId != null && operationName != null && timeStamp != null)
                {
                    ProcessAnalysis(sessionId, threadId, operationName, timeStamp);
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

                    if (storeCode != null && registerNumer != null && machineName != null)
                    {
                        _sessionDic[sessionId].StoreCode = storeCode;
                        _sessionDic[sessionId].RegisterNumber = registerNumer;
                        _sessionDic[sessionId].MachineName = machineName;
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

        private double CalculateDuration(string startTime, string endTime)
        {
            double duration = -1;

            DateTime sTime;
            DateTime eTime;
            if(DateTime.TryParseExact(startTime, "yyyy-MM-dd hh.mm.ss,fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out sTime) &&
                DateTime.TryParseExact(endTime, "yyyy-MM-dd hh.mm.ss,fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out eTime))
            {
                duration = (eTime - sTime).TotalSeconds;
            }

            return duration;
        }

        private void ProcessAnalysis(string sessionId, int? threadId, string operationName, string timeStamp)
        {
            // save-transaction
            if (operationName.Equals("save-transaction", StringComparison.OrdinalIgnoreCase))
            {
                if(_currentLine.Contains("AfterReceiveRequest - [Operation]=save-transaction;"))
                {
                    _saveTransactionOperations.Add(new Operation
                    {
                        SessionId = sessionId,
                        ThreadId = threadId.Value,
                        StartTime = timeStamp
                    });

                }
                else if(_currentLine.Contains("BeforeSendReply - <Operation>=save-transaction;"))
                {
                    var operations = _saveTransactionOperations.Where(
                                            e => e.SessionId == sessionId 
                                            && e.ThreadId == threadId.Value 
                                            && e.EndTime == null).ToList();

                    for(int i = 0; i < operations.Count; i++)
                    {
                        if(i == 0)
                        {
                            operations[i].EndTime = timeStamp;
                            operations[i].Duration = CalculateDuration(operations[i].StartTime, operations[i].EndTime);
                            operations[i].Successful = _currentLine.Contains("<StatusCode>=200 OK");
                        }
                        else
                        {
                            operations[i].EndTime = "void";
                        }
                    }
                }

            }
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
