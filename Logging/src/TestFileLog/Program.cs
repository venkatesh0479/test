using App.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TestFileLog
{
    class Program   
    {
        static void Main(string[] args)
        {
            //Test logs to file sink
            WriteLogsToFileSink();

            //Test logs to SQL Servre DB sink
            WriteLogsToSqlServerSink();
            Thread.Sleep(1000 * 10);//wait for 10 seconds for DB to get populated

            //Test Logs to console sink
            WriteLogsToConsoleSink();
        }

        static void WriteLogsToConsoleSink()
        {
            var appLogger = AppLogWrapper.GetConsoleLogger();
            LogErrorMessage(appLogger);
            LogErrorMessageWithAdditionalInfo(appLogger);
            LogErrorMessageException(appLogger);
            LogTrace(appLogger);
            LogInfo(appLogger);
            LogWarning(appLogger);
        }

        static void WriteLogsToSqlServerSink()
        {
            var appLogger = AppLogWrapper.GetSqlServerLogger("Server= Localhost\\SQLEXPRESS; Database= LogDB; Integrated Security=SSPI;", "LogEvents");
            LogErrorMessage(appLogger);
            LogErrorMessageWithAdditionalInfo(appLogger);
            LogErrorMessageException(appLogger);
            LogTrace(appLogger);
            LogInfo(appLogger);
            LogWarning(appLogger);
        }

        static void WriteLogsToFileSink()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "logfile.txt");
            var appLogger = AppLogWrapper.GetFileLogger(filePath);

            LogErrorMessage(appLogger);
            LogErrorMessageWithAdditionalInfo(appLogger);
            LogErrorMessageException(appLogger);
            LogTrace(appLogger);
            LogInfo(appLogger);
            LogWarning(appLogger);
        }

        static void LogWarning(IAppLogger appLogger)
        {
            EventId warningEventID = new EventId(4000, "WarningEventID");
            var warningInfo = new AppLogDetails("testLayer", "Program", "Test User", "Test App");
            warningInfo.EventID = warningEventID;
            warningInfo.Message = "This is trace message";
            appLogger.LogInformation(warningInfo);
        }

        static void LogInfo(IAppLogger appLogger)
        {
            EventId infoEventID = new EventId(3000, "InfoEventID");
            var info = new AppLogDetails("testLayer", "Program", "Test User", "Test App");
            info.EventID = infoEventID;
            info.Message = "This is trace message";
            appLogger.LogInformation(info);
        }

        static void LogTrace(IAppLogger appLogger)
        {
            EventId traceEventID = new EventId(2000, "TraceEventID");
            var traceLog = new AppLogDetails("testLayer", "Program", "Test User", "Test App");
            traceLog.EventID = traceEventID;
            traceLog.Message = "This is trace message";
            appLogger.LogTrace(traceLog);
        }

        static void LogErrorMessage(IAppLogger appLogger)
        {
            EventId errorEventID = new EventId(1000, "ErrorEventID");
            var errorLog = new AppLogDetails("testLayer", "Program", "Test User", "Test App");
            errorLog.EventID = errorEventID;
            errorLog.Message = "This is Test Error message";
            appLogger.LogError(errorLog);
        }

        static void LogErrorMessageWithAdditionalInfo(IAppLogger appLogger)
        {
            Dictionary<string, object> additionalInfo = new Dictionary<string, object>();
            additionalInfo.Add("Context", "Test");
            additionalInfo.Add("Database", "Data Source= .\\SQLEXPRESS; Initial Catalog= test; Integrated Security=SSPI;");

            EventId errorEventID = new EventId(1000, "ErrorEventID");
            var errorLog = new AppLogDetails("testLayer", "Program", "Test User", "Test App");
            errorLog.EventID = errorEventID;
            errorLog.Message = "This is Test Error message with additional info";
            errorLog.AdditionalInfo = additionalInfo;
            appLogger.LogError(errorLog);
        }

        static void LogErrorMessageException(IAppLogger appLogger)
        {
            Dictionary<string, object> additionalInfo = new Dictionary<string, object>();
            additionalInfo.Add("Context", "Test");
            additionalInfo.Add("Database", "Data Source= .\\SQLEXPRESS; Initial Catalog= test; Integrated Security=SSPI;");

            EventId errorEventID = new EventId(1000, "ErrorEventID");
            var errorLog = new AppLogDetails("testLayer", "Program", "Test User", "Test App");
            errorLog.EventID = errorEventID;
            errorLog.Message = "This is Test Error message with additional info and exception";
            errorLog.AdditionalInfo = additionalInfo;
            var exception = new ArgumentException("Invalid Argument Exception");
            errorLog.Exception = exception;
            appLogger.LogError(errorLog);
        }
    }
}
