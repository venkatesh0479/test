using System;
using System.Collections.Generic;
using System.Text;

namespace App.Logger
{
    public interface IAppLogger
    {
		void LogTrace(ILogDetails logDetails);
		void LogInformation(ILogDetails logDetails);
		void LogWarning(ILogDetails logDetails);
		void LogError(ILogDetails logDetails);
	}
}
