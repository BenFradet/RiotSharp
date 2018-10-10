using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotSharp.Http
{
    /// <summary>
    /// A requester without a rate limiter.
    /// </summary>
    /// <seealso cref="RiotSharp.Http.RequesterBase" />
    /// <seealso cref="RiotSharp.Http.Interfaces.IRequester" />
    public class Requester : RequesterBase, IRequester
    {
        /// <inheritdoc />
        public Requester(string apiKey) : base(apiKey) { }

        /// <inheritdoc />
        public Requester()
        { }

        #region Public Methods

        /// <inheritdoc />
        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string> queryParameters = null, bool useHttps = true)
        {
            var host = GetPlatformHost(region);
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            var response = await GetAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<string> CreateGetRequestAsync(string host, string relativeUrl, 
            List<string> queryParameters = null, bool useHttps = true)
        {
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            var response = await GetAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }
        #endregion
    }
}
