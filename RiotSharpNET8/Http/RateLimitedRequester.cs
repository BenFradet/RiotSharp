using System.Collections.Concurrent;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http
{
    /// <summary>
    /// A requester with a rate limiter
    /// </summary>
    /// <seealso cref="RequesterBase" />
    /// <seealso cref="IRiotRateLimitedRequester" />
    public class RateLimitedRequester : RequesterBase, IRateLimitedRequester
    {
		#region fields
	    protected override string platformDomain => ".api.riotgames.com";

	    private readonly IRateLimiter _rateLimiter;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor for RateLimitedRequester.
		/// </summary>
		/// <param name="apiKey"></param>
		/// <param name="httpRequester"></param>
		/// <param name="rateLimiter"></param>
		public RateLimitedRequester(string apiKey, IHttpRequester httpRequester, IRateLimiter rateLimiter) : base(apiKey, httpRequester)
        {
			_rateLimiter = rateLimiter;
		}

        /// <summary>
        /// Turned private to prevent usage without an API key.
        /// </summary>
        /// <param name="httpRequester"></param>
        private RateLimitedRequester(IHttpRequester httpRequester) : base(httpRequester)
        {
		}

		#endregion

		#region Methods
		/// <summary>
		/// Builds a GET request with the given parameters.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="relativeUrl"></param>
		/// <param name="queryParameters"></param>
		/// <param name="useHttps"></param>
		/// <returns></returns>
		/// <exception cref="RiotSharpRateLimitException"></exception>
		public HttpRequestMessage CreateGetRequestAsync(Region region, string relativeUrl, List<string>? queryParameters = null, bool useHttps = true)
        {
	        var host = CreateHostString(region);
	        var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
	        return request;
		}

		/// <summary>
		/// Send a Http message to the given region.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="region"></param>
		/// <returns></returns>
		/// <exception cref="RiotSharpRateLimitException"></exception>
		public async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request, Region region)
		{
			var lease = await _rateLimiter.GetLeaseForRegion(region).ConfigureAwait(false);
			if(lease.IsAcquired)
			{
				var response = await base.SendMessageAsync(request).ConfigureAwait(false);
				
				return response;
			}
			else
			{
				throw new RiotSharpRateLimitException("Rate limiter has blocked the request", HttpStatusCode.TooManyRequests, (TimeSpan)lease.RetryAfter!, "X-App-Rate-Limit");
			}
		}

		/// <inheritdoc />
        public Task<string> CreatePostRequestAsync(Region region, string relativeUrl, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
			/*
            var host = GetPlatformHost(region);
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return GetRateLimitedResponseContentAsync(request, region);
			*/ 
			throw new NotImplementedException();
		}

        /// <inheritdoc />
        public async Task<bool> CreatePutRequestAsync(Region region, string relativeUrl, string body,
            List<string> queryParameters = null, bool useHttps = true)
        {
			/*
            var host = GetPlatformHost(region);

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
			*/
			throw new NotImplementedException();
		}
		
		/// <inheritdoc/>
		public override void HandleRequestFailure(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == (HttpStatusCode)429)
                {
                    var retryAfter = TimeSpan.Zero;
                    if (response.Headers.TryGetValues("Retry-After", out var retryAfterHeaderValues))
                    {
                        if (int.TryParse(retryAfterHeaderValues.FirstOrDefault(), out var seconds))
                        {
                            retryAfter = TimeSpan.FromSeconds(seconds);
                        }
                    }

                    string? rateLimitType = null;
                    if (response.Headers.TryGetValues("X-Rate-Limit-Type", out var rateLimitTypeHeaderValues))
                    {
                        rateLimitType = rateLimitTypeHeaderValues.FirstOrDefault();
                    }
                    throw new RiotSharpRateLimitException("429, Rate Limit Exceeded", response.StatusCode, retryAfter, rateLimitType ?? "No rateLimitType specified in response");
                }
                // Here we handle all other HTTP status codes that are not 200 OK
                else if (riotHttpStatusCodeBadResponse.Contains(response.StatusCode))
                {
	                string? message;
	                var json = response.Content.ToString();
					// Parse JSON using System.Text.Json
					if (json != null)
					{
						using var doc = JsonDocument.Parse(json);
						var root = doc.RootElement;
						// Safely navigate JSON structure to find the message
						if (root.TryGetProperty("status", out var statusElement) &&
						    statusElement.TryGetProperty("message", out var messageElement))
						{
							message = messageElement.GetString();
						}
						else
						{
							message = response.StatusCode.ToString();
						}
					}
					else
					{
						message = response.StatusCode.ToString();
					}
	                throw new RiotSharpException(message ?? "There was no message in the response", response.StatusCode);
                }
                // No idea what StatusCode was returned, but it isn't supported
                else
                {
	                throw new RiotSharpException("Unexpected failure", response.StatusCode);
                }
            }
            finally
            {
                response.Dispose(); //Dispose Response On Error
            }
        }
		
		/// <summary>
		/// Create the host string for the given region.
		/// </summary>
		/// <param name="region"></param>
		/// <returns></returns>
		private string CreateHostString(Region region)
        {
	        return GetRegionHostUrlString(region) + platformDomain;
        }

		/// <summary>
		/// Return the string to be used in the host URL for the given region.
		/// </summary>
		/// <param name="region"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private string GetRegionHostUrlString(Region region)
        {
	        switch (region)
	        {
		        case Region.Br:
			        return "br1";
		        case Region.Eune:
			        return "eun1";
		        case Region.Euw:
			        return "euw1";
		        case Region.Jp:
			        return "jp1";
		        case Region.Kr:
			        return "kr";
		        case Region.Lan:
			        return "la1";
		        case Region.Las:
			        return "la2";
		        case Region.Me:
			        return "me1";
		        case Region.Na:
			        return "na1";
		        case Region.Oce:
			        return "oc1";
		        case Region.Ph:
			        return "ph2";
		        case Region.Ru:
			        return "ru";
		        case Region.Sg:
			        return "sg2";
		        case Region.Th:
			        return "th2";
		        case Region.Tr:
			        return "tr1";
		        case Region.Tw: 
			        return "tw2";
		        case Region.Vn:
			        return "vn2";
		        case Region.Americas:
			        return "americas";
		        case Region.Asia:
			        return "asia";
		        case Region.Europe:
			        return "europe";
		        case Region.Esports:
			        return "esports";
		        case Region.Sea:
			        return "sea";
		        case Region.Global:
			        return "global";
		        default:
			        throw new NotImplementedException();
	        }
        }
        #endregion

    }
}
