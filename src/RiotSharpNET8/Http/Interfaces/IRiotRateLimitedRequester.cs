using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http.Interfaces
{
    public interface IRiotRateLimitedRequester
    {
        /// <summary>
        /// Create a get request and send it asynchronously to the server.
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="region"></param>
        /// <param name="queryParameters"></param>
        /// <param name="useHttps"></param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="RiotSharpException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<string> CreateGetRequestAsync(string relativeUrl, Region region, List<string>? queryParameters = null, 
            bool useHttps = true);

        /// <summary>
        /// Create a get request message.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="queryParameters">The query parameters.</param>
        /// <param name="useHttps">Use HTTPS based on the boolean. Default = true</param>
        Task<HttpRequestMessage> CreateGetRequestAsync(string host, string relativeUrl,
	        List<string>? queryParameters = null, bool useHttps = true);

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
        Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string>? queryParameters = null, bool useHttps = true);

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
        Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string>? queryParameters = null, bool useHttps = true);
    }
}
