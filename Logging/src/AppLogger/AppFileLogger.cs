using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logger
{
    class AppFileLogger : IAppLogger
    {
        private Serilog.Core.Logger appLogger;

        public AppFileLogger(string absolutePathLogFile, bool dailyLogRollOver = true )
        {
           appLogger = new LoggerConfiguration().WriteTo.File(absolutePathLogFile).CreateLogger();
        }

        public void LogError(ILogDetails logDetails)
        {
            appLogger.Write(Serilog.Events.LogEventLevel.Error, "{@logDetails}", logDetails);
        }

        public void LogInformation(ILogDetails logDetails)
        {
            appLogger.Write(Serilog.Events.LogEventLevel.Information, "{@logDetails}", logDetails);
        }

        public void LogTrace(ILogDetails logDetails)
        {
            appLogger.Write(Serilog.Events.LogEventLevel.Verbose, "{@logDetails}", logDetails);
        }

        public void LogWarning(ILogDetails logDetails)
        {
            appLogger.Write(Serilog.Events.LogEventLevel.Warning, "{@logDetails}", logDetails);

        }
    }
}
