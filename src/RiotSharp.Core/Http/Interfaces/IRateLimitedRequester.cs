using RiotSharp.Core.Misc;
using RiotSharpNET8;

namespace RiotSharp.Core.Http.Interfaces
{
	public interface IRateLimitedRequester
	{
		/// <summary>
		/// Create a get request message.
		/// </summary>
		/// <param name="region">The region the message should be created for.</param>
		/// <param name="relativeUrl">The relative URL.</param>
		/// <param name="queryParameters">The query parameters.</param>
		/// <param name="useHttps">Use HTTPS based on the boolean. Default = true</param>
		HttpRequestMessage CreateGetRequest(Region region, string relativeUrl, List<string>? queryParameters = null, bool useHttps = true);

		/// <summary>
		/// Send a message to a specific region asynchronously.
		/// </summary>
		/// <param name="request">The request message to be sent.</param>
		/// <param name="region">The region to send the message to.</param>
		/// <exception cref="RiotSharpRateLimitException"></exception>
		Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request, Region region);

		/// <summary>
		/// Create a post request and send it asynchronously to the server.
		/// </summary>
		/// <param name="relativeUrl"></param>
		/// <param name="region"></param>
		/// <param name="body"></param>
		/// <param name="queryParameters"></param>
		/// <param name="useHttps"></param>
		/// <returns>The content of the response.</returns>
		/// <exception cref="RiotSharpException">
		/// Thrown if an Http error occurs. 
		/// Contains the Http error code and error message.
		/// </exception>
		Task<string> CreatePostRequestAsync(Region region, string relativeUrl, string body, List<string>? queryParameters = null, bool useHttps = true);

        /// <summary>
        /// Create a post request and send it asynchronously to the server.
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="region"></param>
        /// <param name="body"></param>
        /// <param name="queryParameters"></param>
        /// <param name="useHttps"></param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="RiotSharpException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<bool> CreatePutRequestAsync(Region region, string relativeUrl, string body, List<string>? queryParameters = null, bool useHttps = true);

		/// <summary>
		/// Handles the failure of a request if any.
		/// Throws Exceptions
		/// </summary>
		/// <param name="response"></param>
		/// <exception cref="RiotSharpRateLimitException"></exception>
		/// <exception cref="RiotSharpException"></exception>
		void HandleRequestFailure(HttpResponseMessage response);
	}
}
