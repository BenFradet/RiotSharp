using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp
{
    public interface IRateLimitedRequester: IRequester
    {
        int RateLimitPer10S { get; set; }
        int RateLimitPer10M { get; set; }

        string CreateGetRequest(string relativeUrl, Region region, List<string> addedArguments = null,
            bool useHttps = true);

        Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null, bool useHttps = true);

        string CreatePostRequest(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true);

        Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true);

        bool CreatePutRequest(string relativeUrl, Region region, string body, List<string> addedArguments = null,
           bool useHttps = true);

        Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true);

    }
}
