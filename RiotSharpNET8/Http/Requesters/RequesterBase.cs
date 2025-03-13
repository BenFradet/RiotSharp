using System.Net;
using RiotSharpNET8.Http.Interfaces;

namespace RiotSharpNET8.Http.Requesters
{
    public abstract class RequesterBase
    {
	    protected abstract string PlatformDomain { get; }
        
        private bool _isUsingApiKey = false;
		private readonly IHttpRequester _httpRequester;
        private string _apiKey = "";
        protected readonly HashSet<HttpStatusCode> RiotHttpStatusCodeBadResponse =
        [
	        HttpStatusCode.BadRequest, HttpStatusCode.Unauthorized,
	        HttpStatusCode.Forbidden, HttpStatusCode.NotFound,
	        HttpStatusCode.MethodNotAllowed, HttpStatusCode.UnsupportedMediaType,
	        HttpStatusCode.InternalServerError, HttpStatusCode.BadRequest,
	        HttpStatusCode.ServiceUnavailable, HttpStatusCode.GatewayTimeout
        ];

        /// <summary>
        /// Initializes a new instance of the <see cref="RequesterBase"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="httpRequester">httpRequester that sends the messages.</param>
        /// <exception cref="ArgumentNullException">apiKey, httpRequester</exception>
        protected RequesterBase(string apiKey, IHttpRequester httpRequester)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            _apiKey = apiKey;
            _httpRequester = httpRequester ?? throw new ArgumentNullException(nameof(httpRequester));
            _isUsingApiKey = true;
        }

		/// <summary>
		/// Used when no API key is required.
		/// </summary>
		/// <param name="httpRequester"></param>
		/// <exception cref="ArgumentNullException">httpRequester</exception>
		protected RequesterBase(IHttpRequester httpRequester)
		{
			_httpRequester = httpRequester ?? throw new ArgumentNullException(nameof(httpRequester));
			_isUsingApiKey = false;
		}

		#region Methods

		protected async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request)
		{
			var response = await _httpRequester.SendMessageAsync(request).ConfigureAwait(false);
			
			return response;
		}

        /// <summary>
        /// Prepares the request with all the relevant information.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="relativeUrl"></param>
        /// <param name="queryParameters"></param>
        /// <param name="useHttps"></param>
        /// <param name="httpMethod"></param>
        /// <returns>The Request ready to send.</returns>
        protected HttpRequestMessage PrepareRequest(string host, string relativeUrl, List<string>? queryParameters,
            bool useHttps, HttpMethod httpMethod)
        {
            var scheme = useHttps ? "https" : "http";
            var url = queryParameters == null ?
                $"{scheme}://{host}{relativeUrl}" :
                $"{scheme}://{host}{relativeUrl}?{BuildArgumentsString(queryParameters)}";

            var requestMessage = new HttpRequestMessage(httpMethod, url);
            
            if (_isUsingApiKey)
				requestMessage.Headers.Add("X-Riot-Token", _apiKey);
            
            return requestMessage;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .Aggregate(string.Empty, (current, arg) => current + ("&" + arg));
        }

        /// <summary>
        /// Handles the failure of a request if any.
        /// <remarks>Should be more specific as to which type of limit has been breached.</remarks>
        /// </summary>
        /// <param name="response"></param>
        /// <exception cref="RiotSharpRateLimitException"></exception>
        /// <exception cref="RiotSharpException"></exception>
        public abstract void HandleRequestFailure(HttpResponseMessage response);
        
        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            using (response)
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
        
        #endregion
    }
}
