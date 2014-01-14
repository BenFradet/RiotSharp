using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public interface IRequester
    {
        JObject CreateRequestJObject(string relativeUrl, string addedArgument = null);
        Task<JObject> CreateRequestJObjectAsync(string relativeUrl, string addedArgument = null);
        string CreateRequest(string relativeUrl, string addedArgument = null);
        Task<string> CreateRequestAsync(string relativeUrl, string addedArgument = null);
    }
}
