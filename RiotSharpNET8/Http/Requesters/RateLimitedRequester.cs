using System.Net;
using System.Text.Json;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Http.RateLimiting;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http.Requesters
{
	/// <summary>
	/// A requester that handles both application and method rate limiting.
	/// </summary>
	/// <seealso cref="RequesterBase" />
	/// <seealso cref="IRiotRateLimitedRequester" />
	public class RateLimitedRequester : RequesterBase, IRateLimitedRequester
    {
		#region fields
	    protected override string PlatformDomain => ".api.riotgames.com";

	    private readonly IRateLimiter _appRateLimiter;
		private readonly IRateLimiter _methodRateLimiter;
		#endregion

		#region Constructors

		/// <summary>
		/// Constructor for RateLimitedRequester.
		/// </summary>
		/// <param name="apiKey"></param>
		/// <param name="httpRequester"></param>
		/// <param name="appRateLimiter"></param>
		public RateLimitedRequester(string apiKey, IHttpRequester httpRequester, IRateLimiter appRateLimiter, IRateLimiter methodRateLimiter) : base(apiKey, httpRequester)
        {
			_appRateLimiter = appRateLimiter;
			_methodRateLimiter = methodRateLimiter;
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
		public HttpRequestMessage CreateGetRequest(Region region, string relativeUrl, List<string>? queryParameters = null, bool useHttps = true)
        {
	        var host = CreateHostString(region);
	        var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
	        return request;
		}

		/// <summary>
		/// Send a Http message to the given region. This method acquires the necessary leases for the request.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="region"></param>
		/// <returns></returns>
		/// <exception cref="RiotSharpRateLimitException"></exception>
		public async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request, Region region)
		{
			var lease = await GetLeasesAsync(region).ConfigureAwait(false);
			if (lease.IsAcquired)
			{
				var response = await base.SendMessageAsync(request).ConfigureAwait(false);
				
				return response;
			}
			else
			{
				throw new RiotSharpRateLimitException("Failed to acquire a lease for the request.", null, lease.RetryAfter, lease.RateLimitType);
			}
		}

		/// <inheritdoc />
        public Task<string> CreatePostRequestAsync(Region region, string relativeUrl, string body,
            List<string>? queryParameters = null, bool useHttps = true)
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
        public Task<bool> CreatePutRequestAsync(Region region, string relativeUrl, string body,
            List<string>? queryParameters = null, bool useHttps = true)
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

		/// <summary>
		/// Get the leases for the given region.
		/// Starting with the method rate limiter, so we don't interfere with the app rate limiter unless necessary
		/// </summary>
		/// <param name="region"></param>
		/// <returns>The given lease. May not be granted.</returns>
		public async Task<IRequestLease> GetLeasesAsync(Region region)
        {
			// Note that no matter what we return the lease. It is up to the caller to check if it is acquired or not.
			// Get the method rate limiter first. If we don't get the lease we just return the unacquired lease.
			var methodLease = await _methodRateLimiter.GetLeaseForRegion(region);
			if (!methodLease.IsAcquired) 
				return methodLease;
			// Get the app rate limiter.
			var appLease = await _appRateLimiter.GetLeaseForRegion(region);
			return appLease;
        }

		/// <inheritdoc/>
		/// <remarks>We don't really "handle" the failure, just format an error message with information.</remarks>
		public override void HandleRequestFailure(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.TooManyRequests)
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
					} // TODO: Fix the thrown exception to include the rate limit type. Possibly even a decoding of the header to the enum.

                    throw new RiotSharpRateLimitException("429, Rate Limit Exceeded", response.StatusCode, retryAfter,
	                    RateLimitType.App); //rateLimitType ?? "No rateLimitType specified in response");
                }
                // Here we handle all other HTTP status codes that are not 200 OK
                else if (RiotHttpStatusCodeBadResponse.Contains(response.StatusCode))
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
	        return GetRegionHostUrlString(region) + PlatformDomain;
        }

		/// <summary>
		/// Return the string to be used in the host URL for the given region.
		/// </summary>
		/// <param name="region"></param>
		/// <returns>The corresponding string used in the Riot API.</returns>
		/// <exception cref="NotImplementedException"></exception>
		private string GetRegionHostUrlString(Region region)
		{
			return region switch
			{
				Region.Br => "br1",
				Region.Eune => "eun1",
				Region.Euw => "euw1",
				Region.Jp => "jp1",
				Region.Kr => "kr",
				Region.Lan => "la1",
				Region.Las => "la2",
				Region.Me => "me1",
				Region.Na => "na1",
				Region.Oce => "oc1",
				Region.Ph => "ph2",
				Region.Ru => "ru",
				Region.Sg => "sg2",
				Region.Th => "th2",
				Region.Tr => "tr1",
				Region.Tw => "tw2",
				Region.Vn => "vn2",
				Region.Americas => "americas",
				Region.Asia => "asia",
				Region.Europe => "europe",
				Region.Esports => "esports",
				Region.Sea => "sea",
				Region.Global => "global",
				_ => throw new NotImplementedException()
			};
		}
        #endregion

    }
}
