using RiotSharp.Http.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Misc;
using System;

namespace RiotSharp.Http
{
    /// <summary>
    /// A requester with a rate limiter
    /// </summary>
    /// <seealso cref="RiotSharp.Http.RequesterBase" />
    /// <seealso cref="RiotSharp.Http.Interfaces.IRateLimitedRequester" />
    public class RateLimitedRequester : RequesterBase, IRateLimitedRequester
    {
        public readonly IDictionary<TimeSpan, int> RateLimits;

        private readonly bool _throwOnDelay;
        private readonly Dictionary<Region, RateLimiter> _rateLimiters = new Dictionary<Region, RateLimiter>();

        /// <inheritdoc />
        public RateLimitedRequester(string apiKey, IDictionary<TimeSpan, int> rateLimits, bool throwOnDelay = false) : base(apiKey)
        {
            RateLimits = rateLimits;
            _throwOnDelay = throwOnDelay;
        }

        #region Public Methods

        /// <inheritdoc />
        public Task<string> CreateGetRequestAsync(string relativeUrl, Region region, List<string> queryParameters = null, 
            bool useHttps = true)
        {
            var host = GetPlatformHost(region);
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);

            return GetRateLimitedResponseContentAsync(request, region);
        }

        /// <inheritdoc />
        public Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
            var host = GetPlatformHost(region);
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return GetRateLimitedResponseContentAsync(request, region);
        }

        /// <inheritdoc />
        public async Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
            var host = GetPlatformHost(region);

            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);
            try
            {
                var response = await SendAsync(request).ConfigureAwait(false);
                response.Dispose();
                return true;
                
            }
            catch (RiotSharpException)
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Returns the respective region's RateLimiter, creating it if needed.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private RateLimiter GetRateLimiter(Region region)
        {
            if (!_rateLimiters.ContainsKey(region))
                _rateLimiters[region] = new RateLimiter(RateLimits, _throwOnDelay);
            return _rateLimiters[region]; 
        }

        /// <summary>
        /// Sends a configured <see cref="HttpRequestMessage"/> possibly Rate-Limited for the specific <paramref name="region"/>
        /// </summary>
        /// <param name="request">Pre-Configured <see cref="HttpRequestMessage"/></param>
        /// <param name="region">The region which's requests should be rate limited</param>
        private async Task<string> GetRateLimitedResponseContentAsync(HttpRequestMessage request, Region region)
        {
            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await SendAsync(request).ConfigureAwait(false))
            {
                return await GetResponseContentAsync(response).ConfigureAwait(false);
            }
        }
    }
}
