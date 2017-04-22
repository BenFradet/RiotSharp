using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    interface IRequester
    {
        /// <summary>
        /// The api key. Required to for all requests.
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// Create a get request and send it to the server.
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="rootDomain"></param>
        /// <param name="addedArguments"></param>
        /// <param name="useHttps"></param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        string CreateGetRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null,
            bool useHttps = true);

        /// <summary>
        /// Create a get request and send it to the server asynchronously.
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="rootDomain"></param>
        /// <param name="addedArguments"></param>
        /// <param name="useHttps"></param>
        /// <returns>The content of the response.</returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        Task<string> CreateGetRequestAsync(string relativeUrl, string rootDomain,
            List<string> addedArguments = null, bool useHttps = true);

        /// <summary>
        /// Send a get request synchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        HttpResponseMessage Get(HttpRequestMessage request);

        /// <summary>
        /// Send a get request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        Task<HttpResponseMessage> GetAsync(HttpRequestMessage request);

        /// <summary>
        /// Send a put request synchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        HttpResponseMessage Put(HttpRequestMessage request);

        /// <summary>
        /// Send a put request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        Task<HttpResponseMessage> PutAsync(HttpRequestMessage request);

        /// <summary>
        /// Send a post request synchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        HttpResponseMessage Post(HttpRequestMessage request);

        /// <summary>
        /// Send a post request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        Task<HttpResponseMessage> PostAsync(HttpRequestMessage request);
    }
}
