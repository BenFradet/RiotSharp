using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotSharp
{
    public class BeforeSendRequestEventArgs : EventArgs
    {
        public BeforeSendRequestEventArgs()
        {
        }
        public BeforeSendRequestEventArgs(Uri requestUri, Guid requestId)
        {
            RequestUri = requestUri;
            RequestId = requestId;
        }

        /// <summary>
        ///  Request Uri used in the api request
        /// </summary>
        public Uri RequestUri { get; private set; }

        /// <summary>
        /// Request identifier used to match request and response calls 
        /// </summary>
        public Guid RequestId { get; private set; }
    }
}
