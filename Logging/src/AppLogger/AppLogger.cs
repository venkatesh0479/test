using System;
using System.Collections.Generic;

namespace AppLogger
{
    public class AppLogger
    {
        public AppLogger()
        {
            LogDateTime = DateTime.Now;
        }

        public DateTime LogDateTime { get; private set; }

        public string Message { get; set; }

        //Where
        public string Product { get; set; }

        public string Layer { get; set; }

        public string Location { get; set; }

        public string Hostname { get; set; }

        //who
        public string UserID { get; set; }

        public string UserName { get; set; }

        //other
        public long? ElaspsedMilliSeconds { get; set; }

        public Exception Exception { get; set; }

        public string CorrelationID { get; set; }

        public Dictionary<string, object> AdditionalInfo { get; set; }
    }
}
