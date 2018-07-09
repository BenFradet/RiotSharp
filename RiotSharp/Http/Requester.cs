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
            List<string> queryParameters = null, bool useHttps = true)
        {
            rootDomain = GetPlatformDomain(region);
            var request = PrepareRequest(relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            var response = await GetAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        public async Task<string> CreateGetRequestAsync(string absoluteUrl)
        {
            var response = await GetAsync(new HttpRequestMessage(HttpMethod.Get, absoluteUrl)).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }
        #endregion
    }
}
