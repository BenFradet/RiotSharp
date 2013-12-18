using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public interface IRequester
    {
        HttpWebRequest CreateRequest(string relativeUrl, string addedArgument = null);
        string GetResponseString(Stream stream);
    }
}
