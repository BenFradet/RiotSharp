using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotSharp.Http
{
    /// <summary>
    /// A requester without a rate limiter.
    /// </summary>
    public class Requester : RequesterBase, IRequester
    {
        public Requester(string apiKey) : base(apiKey)
        {
        }

        #region Public Methods

        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = GetPlatformDomain(region);
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            var response = await GetAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }
        #endregion
    }
}
