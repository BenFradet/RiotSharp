using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotSharp
{
    public class AfterReceiveReplyEventArgs : EventArgs
    {
        public AfterReceiveReplyEventArgs()
        {
        }

        public AfterReceiveReplyEventArgs(string responseRawData, Guid requestId)
        {
            ResponseRawData = responseRawData;
            RequestId = requestId;
        }

        /// <summary>
        /// Response raw data in JSON format
        /// </summary>
        public string ResponseRawData { get; private set; }

        /// <summary>
        /// Request identifier used to match request and response calls 
        /// </summary>
        public Guid RequestId { get; private set; }
    }
}
