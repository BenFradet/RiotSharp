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
        public int RateLimitPer10S { get; set; }
        public int RateLimitPer10M { get; set; }

        public RateLimitedRequester(string apiKey, int rateLimitPer10s, int rateLimitPer10m) : base(apiKey)
        {
            RateLimitPer10S = rateLimitPer10s;
            RateLimitPer10M = rateLimitPer10m;
        }

        private readonly Dictionary<Region, RateLimiter> rateLimiters = new Dictionary<Region, RateLimiter>();

        #region Public Methods

        public string CreateGetRequest(string relativeUrl, Region region, List<string> addedArguments = null,
            bool useHttps = true, bool usePlatforms = false)
        {
            if (usePlatforms)
                rootDomain = GetPlatformDomain(region);
            else
                rootDomain = region + ".api.pvp.net";

            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);

            GetRateLimiter(region).HandleRateLimit();

            using (var response = Get(request))
            {
                return GetResponseContent(response);
            }              
        }

        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region, List<string> addedArguments = null, 
            bool useHttps = true, bool usePlatforms = false)
        {
            if (usePlatforms)
                rootDomain = GetPlatformDomain(region);
            else
                rootDomain = region + ".api.pvp.net";

            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            
            await GetRateLimiter(region).HandleRateLimitAsync();

            using (var response = await GetAsync(request))
            {
                return await GetResponseContentAsync(response);
            }
        }

        public string CreatePostRequest(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            GetRateLimiter(region).HandleRateLimit();

            using (var response = Post(request))
            {
                return GetResponseContent(response);
            }     
        }

        public async Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter(region).HandleRateLimitAsync();

            using (var response = await PostAsync(request))
            {
                return await GetResponseContentAsync(response);
            }
        }

        public bool CreatePutRequest(string relativeUrl, Region region, string body, List<string> addedArguments = null,
            bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            GetRateLimiter(region).HandleRateLimit();

            using (var response = Put(request))
            {
                return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
            }              
        }

        public async Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter(region).HandleRateLimitAsync();

            using (var response = await PutAsync(request))
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
                rateLimiters[region] = new RateLimiter(RateLimitPer10S, RateLimitPer10M);
            return rateLimiters[region]; 
        }
    }
}
