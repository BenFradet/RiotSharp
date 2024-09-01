using System.Net;
using System.Text.Json;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http
{
    public abstract class RequesterBase
    {
        protected const string PlatformDomain = ".api.riotgames.com";
        private readonly HttpClient _httpClient;
        private static readonly HashSet<HttpStatusCode> RiotHttpStatusCodeBadResponse =
        [
	        HttpStatusCode.BadRequest, HttpStatusCode.Unauthorized,
	        HttpStatusCode.Forbidden, HttpStatusCode.NotFound,
	        HttpStatusCode.MethodNotAllowed, HttpStatusCode.UnsupportedMediaType,
	        HttpStatusCode.InternalServerError, HttpStatusCode.BadRequest,
	        HttpStatusCode.ServiceUnavailable, HttpStatusCode.GatewayTimeout
        ];

        public string ApiKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequesterBase"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="ArgumentNullException">apiKey</exception>
        protected RequesterBase(string apiKey) : this()
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            ApiKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequesterBase"/> class.
        /// </summary>
        protected RequesterBase()
        {
            _httpClient = new HttpClient();
        }

        #region Protected Methods

        /// <summary>
        /// Send a <see cref="HttpRequestMessage"/> asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                HandleRequestFailure(response); //Pass Response to get status code, Then Dispose Object.
            }
            return response;
        }

        protected HttpRequestMessage PrepareRequest(string host, string relativeUrl, List<string>? queryParameters,
            bool useHttps, HttpMethod httpMethod)
        {
            var scheme = useHttps ? "https" : "http";
            var url = queryParameters == null ?
                $"{scheme}://{host}{relativeUrl}" :
                $"{scheme}://{host}{relativeUrl}?{BuildArgumentsString(queryParameters)}";

            var requestMessage = new HttpRequestMessage(httpMethod, url);
            if (!string.IsNullOrEmpty(ApiKey))
            {
                requestMessage.Headers.Add("X-Riot-Token", ApiKey);
            }
            return requestMessage;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .Aggregate(string.Empty, (current, arg) => current + ("&" + arg));
        }

        protected void HandleRequestFailure(HttpResponseMessage response)
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

        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            using (response)
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        protected string GetPlatformHost(Region region)
        {
            return GetPlatform(region) + PlatformDomain;
        }

        private string GetPlatform(Region region)
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
                case Region.Na:
                    return "na1";
                case Region.Oce:
                    return "oc1";
                case Region.Tr:
                    return "tr1";
                case Region.Ru:
                    return "ru";
                case Region.Global:
                    return "global";
                case Region.Americas:
                    return "americas";
                case Region.Europe:
                    return "europe";
                case Region.Asia:
                    return "asia";
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion
    }
}
