using System.Text.Json;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;

namespace RiotSharp.Core.Endpoints
{
	/// <summary>
	/// This base class will be used for all endpoints that are rate limited.
	/// </summary>
	public class RateLimitedEndpointBase
	{
		private readonly IRateLimitedRequester _requester;

		public RateLimitedEndpointBase(IRateLimitedRequester requester)
		{
			_requester = requester ?? throw new ArgumentNullException(nameof(requester), "Requester cannot be null.");
		}

        /// <summary>
        /// Gets the content from the given region and request URL, deserializing it into the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="region"></param>
        /// <param name="requestUrl"></param>
        /// <param name="queryParameters">Optional query parameters to append to the request URL.</param>
        /// <returns>The object</returns>
        /// <exception cref="Exceptions.RiotSharpRateLimitException">Will be thrown if the RateLimit is breached locally or at the API server</exception>
        /// <exception cref="Exceptions.RiotSharpException">An exception of a kind. Use the <see cref="Exceptions.RiotSharpException.HttpStatusCode"/> to handle the error.</exception>
        protected async Task<T?> GetContentAsync<T>(Region region, string requestUrl, List<string>? queryParameters = null)
		{
			var request = _requester.CreateGetRequest(region, requestUrl, queryParameters);

			var response = await _requester.SendMessageAsync(request, region).ConfigureAwait(false);

			if (!response.IsSuccessStatusCode)
			{
				_requester.HandleRequestFailure(response);
			}

			var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			var result = JsonSerializer.Deserialize<T>(jsonString);

			return result;
		}
	}
}
