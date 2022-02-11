using Serilog;
using System;

namespace App.Logger
{
    public class AppConsoleLogger: IAppLogger
    {
		public AppConsoleLogger()
		{
			appLogger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
		}

		public void LogTrace(ILogDetails logDetails)
		{
			appLogger.Write(Serilog.Events.LogEventLevel.Verbose, "{@logDetails}", logDetails);
		}

		public void LogInformation(ILogDetails logDetails)
		{
			appLogger.Write(Serilog.Events.LogEventLevel.Information, "{@logDetails}", logDetails);
		}

		public void LogWarning(ILogDetails logDetails)
		{
			appLogger.Write(Serilog.Events.LogEventLevel.Warning, "{@logDetails}", logDetails);
		}

		public void LogError(ILogDetails logDetails)
		{
			appLogger.Write(Serilog.Events.LogEventLevel.Error, "{@logDetails}", logDetails);
		}


		private readonly ILogger appLogger;
	}

	
}
