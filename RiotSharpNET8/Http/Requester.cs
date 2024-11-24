using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http
{
    /// <summary>
    /// A requester without a rate limiter.
    /// </summary>
    /// <seealso cref="RequesterBase" />
    /// <seealso cref="IRequester" />
    public class Requester : RequesterBase, IRequester
    {
        /// <inheritdoc />
        public Requester(string apiKey) : base(apiKey, new HttpRequester(new HttpClient())) { }

        /// <inheritdoc />
        public Requester() : base("", new HttpRequester(new HttpClient()))
        { }

        #region Public Methods

        /// <inheritdoc />
        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string>? queryParameters = null, bool useHttps = true)
        {
	        var host = "GetPlatformHost(region);";
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            var response = await SendMessageAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<string> CreateGetRequestAsync(string host, string relativeUrl, 
            List<string>? queryParameters = null, bool useHttps = true)
        {
            var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
            var response = await SendMessageAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }
        #endregion

        protected override string platformDomain { get; }
        public override void HandleRequestFailure(HttpResponseMessage response)
        {
	        throw new NotImplementedException();
        }
    }
}
