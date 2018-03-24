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
    public class RateLimitedRequester : RequesterBase, IRateLimitedRequester
    {
        public readonly IDictionary<TimeSpan, int> RateLimits;

        public RateLimitedRequester(string apiKey, IDictionary<TimeSpan, int> rateLimits) : base(apiKey)
        {
            RateLimits = rateLimits;
        }

        private readonly Dictionary<Region, RateLimiter> rateLimiters = new Dictionary<Region, RateLimiter>();

        #region Public Methods

        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region, List<string> queryParameters = null, 
            bool useHttps = true)
        {
            rootDomain = GetPlatformDomain(region);

            var request = PrepareRequest(relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            
            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await GetAsync(request).ConfigureAwait(false))
            {
                return await GetResponseContentAsync(response).ConfigureAwait(false);
            }
        }
        
        public async Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
            rootDomain = GetPlatformDomain(region);

            var request = PrepareRequest(relativeUrl, queryParameters, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await PostAsync(request).ConfigureAwait(false))
            {
                return await GetResponseContentAsync(response).ConfigureAwait(false);
            }
        }

        public async Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
            rootDomain = GetPlatformDomain(region);

            var request = PrepareRequest(relativeUrl, queryParameters, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await PutAsync(request).ConfigureAwait(false))
            {
                return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
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
            if (!rateLimiters.ContainsKey(region))
                rateLimiters[region] = new RateLimiter(RateLimits);
            return rateLimiters[region]; 
        }
    }
}
