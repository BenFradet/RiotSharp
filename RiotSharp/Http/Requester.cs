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
        public Requester(string apiKey) : base(apiKey) { }

        public Requester() : base() { }

        #region Public Methods
        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string> queryParameters = null, bool useHttps = true)
        {
            host = GetPlatformDomain(region);
            var request = PrepareRequest(relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            var response = await GetAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        public async Task<string> CreateGetRequestAsync(string host, string relativeUrl, bool useHttps = true)
        {
            var response = await GetAsync(new HttpRequestMessage(HttpMethod.Get, "http://" + host + relativeUrl)).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }
        #endregion
    }
}
