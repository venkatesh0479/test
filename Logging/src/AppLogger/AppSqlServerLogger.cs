
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace App.Logger
{
    public class AppSqlServerLogger : IAppLogger
    {
		public AppSqlServerLogger(string dbConnectionString, string tableName, IConfiguration configuration = null, 
			IConfigurationSection columnOptions = null)
        {
			var sinkOPtions = new MSSqlServerSinkOptions { TableName = tableName, AutoCreateSqlTable=true };
			appLogger = new LoggerConfiguration().WriteTo.MSSqlServer(connectionString: dbConnectionString, sinkOPtions, 
				columnOptions, configuration).CreateLogger();
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
