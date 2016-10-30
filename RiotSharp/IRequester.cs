using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp
{
    public interface IRequester
    {
        string ApiKey { get; set; }

        string CreateGetRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null,
            bool useHttps = true);

        Task<string> CreateGetRequestAsync(string relativeUrl, string rootDomain,
            List<string> addedArguments = null, bool useHttps = true);
    }
}
