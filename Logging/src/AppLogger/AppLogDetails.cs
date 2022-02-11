using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace App.Logger
{
    public class AppLogDetails : ILogDetails
    {
        public AppLogDetails(string layer, string location, string userName, string product)
        {
            dateTime = DateTime.Now;
            this.layer = layer;
            this.location = location;
            this.product = product;
        }

        public AppLogDetails(string layer, string location, string userName, string product, string message) :
                                                                this(layer, location, userName, product)
        {
            this.message = message;
        }

        //This constructor is only for backward compatibility only. will be removed later
        public AppLogDetails(string layer, string location, string userName)
        {
            dateTime = DateTime.Now;
            this.layer = layer;
            this.location = location;
            this.product = "DCR Service";
        }


        public string Layer
        {
            get
            {
                return layer;
            }
        }
                
        public string Product
        {
            get
            {
                return product;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
        }

        public string HostName
        {
            get
            {
                try
                {
                    hostName = Dns.GetHostName();
                }
                catch(SocketException se)
                {
                    hostName = se.Message;
                }
                return hostName;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        
        public EventId EventID { get => eventId; set => eventId = value; }
        public string Message { get => message; set => message = value; }
        public Exception Exception { get => exception; set => exception = value; }
        public DateTime Time { get =>  dateTime; }
        public Dictionary<string, object> AdditionalInfo { get => additionalInfo; set => additionalInfo = value; }

        string layer;
        string product;
        string location;
        string hostName;
        string userName;
        EventId eventId;
        string message;
        Exception exception;
        DateTime dateTime;
        Dictionary<string, object> additionalInfo;
    }
}
