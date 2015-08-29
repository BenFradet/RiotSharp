using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    interface IInterceptable
    {
        event BeforeSendRequestEventHandler BeforeSendRequest;

        event AfterReceiveReplyEventHandler AfterReceiveReply;
    }
}
