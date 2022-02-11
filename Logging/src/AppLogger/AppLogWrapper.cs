using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logger
{
    public enum  LogSink
    {
        Console,
        SQLServer,
        File,
    }

    public class AppLogWrapper
    {
        public static IAppLogger GetConsoleLogger()
        {
            if (logger == null)
            {
                logger = new AppConsoleLogger();
            }
            return logger;
        }

        public static IAppLogger GetFileLogger(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("A filepath cannot be empty or null");

            //if (logger == null)
            //{
                logger = new AppFileLogger(filePath);
            //}
            return logger;
        }

        public static IAppLogger GetSqlServerLogger(string dbConnectionString, string tableName, IConfiguration configuration = null,
            IConfigurationSection columnOptions = null)
        {
            if (string.IsNullOrEmpty(dbConnectionString))
                throw new ArgumentException("A connection cannot be empty or null");

            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("A table name cannot be empty or null");

            
            //if (logger == null)
            //{
                logger = new AppSqlServerLogger(dbConnectionString,tableName,configuration,columnOptions);
            //}
            return logger;

        }

        public static IAppLogger GetLogger(LogSink sink, string filePath = null)
        {
            if(sink == LogSink.Console)
            {
                if(logger == null)
                {
                    logger = new AppConsoleLogger();
                }
            }
            else if (sink == LogSink.File)
            {
                if (logger == null)
                {
                    if (string.IsNullOrEmpty(filePath))
                        throw new ArgumentException("A filepath cannot be empty or null");

                    logger = new AppFileLogger(filePath);
                }
            }
            else if (sink == LogSink.SQLServer)
            {
                if (logger == null)
                {
                    if (string.IsNullOrEmpty(filePath))
                        throw new ArgumentException("A filepath cannot be empty or null");

                    logger = new AppFileLogger(filePath);
                }
            }
            return logger;
        }

        private static IAppLogger logger = null;
    }
}
