using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace App.Logger
{
	public interface ILogDetails
	{

		EventId EventID { get; set; }
		//what
		string Layer { get; }
		string Product { get; }
		string Location { get;}
		string HostName { get;}

		//who
		string UserName { get; set; }

		//log message
		
		string Message { get; set; }
		Exception Exception { get; set; }

		DateTime Time { get; }
		Dictionary<string, object> AdditionalInfo { get; set; }
	}
}
