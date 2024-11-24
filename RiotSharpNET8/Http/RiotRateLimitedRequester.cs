using System.Collections.Concurrent;
using System.Text;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http
{
    /// <summary>
    /// A requester with a rate limiter
    /// </summary>
    /// <seealso cref="RequesterBase" />
    /// <seealso cref="IRiotRateLimitedRequester" />
    public class RiotRiotRateLimitedRequester : RequesterBase, IRiotRateLimitedRequester
    {
        public readonly IDictionary<TimeSpan, int> RateLimits;

        private readonly bool _throwExceptionOnDelay;
        private readonly ConcurrentDictionary<Region, RiotRateLimiter> _rateLimiters = new ConcurrentDictionary<Region, RiotRateLimiter>();

        /// <inheritdoc />
        public RiotRiotRateLimitedRequester(string apiKey, IDictionary<TimeSpan, int> rateLimits, bool throwExceptionOnDelay = false) : base(apiKey, new HttpRequester(new HttpClient()))
        {
            RateLimits = rateLimits;
            _throwExceptionOnDelay = throwExceptionOnDelay;
        }

        #region Public Methods

        /// <inheritdoc />
        public Task<string> CreateGetRequestAsync(string relativeUrl, Region region, List<string> queryParameters = null, 
            bool useHttps = true)
        {
	        var host = "GetPlatformHost(region);";
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);

            return GetRateLimitedResponseContentAsync(request, region);
        }

        public Task<HttpRequestMessage> CreateGetRequestAsync(string host, string relativeUrl, List<string>? queryParameters = null, bool useHttps = true)
        {
	        throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
	        var host = "GetPlatformHost(region);";
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return GetRateLimitedResponseContentAsync(request, region);
        }

        /// <inheritdoc />
        public async Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
	        var host = "GetPlatformHost(region);";

            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);
            try
            {
                var response = await SendMessageAsync(request).ConfigureAwait(false);
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
        /// Returns the respective region's RiotRateLimiter, creating it if needed.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private RiotRateLimiter GetRateLimiter(Region region)
        {
            return _rateLimiters.GetOrAdd(region, _ => new RiotRateLimiter(RateLimits, _throwExceptionOnDelay));
        }

        /// <summary>
        /// Sends a configured <see cref="HttpRequestMessage"/> possibly Rate-Limited for the specific <paramref name="region"/>
        /// </summary>
        /// <param name="request">Pre-Configured <see cref="HttpRequestMessage"/></param>
        /// <param name="region">The region which's requests should be rate limited</param>
        private async Task<string> GetRateLimitedResponseContentAsync(HttpRequestMessage request, Region region)
        {
            await GetRateLimiter(region).HandleRateLimitAsync().ConfigureAwait(false);

            using (var response = await SendMessageAsync(request).ConfigureAwait(false))
            {
                return await GetResponseContentAsync(response).ConfigureAwait(false);
            }
        }

        protected override string platformDomain => "riotgames.com";
		public override void HandleRequestFailure(HttpResponseMessage response)
        {
	        throw new NotImplementedException();
        }
    }
}
