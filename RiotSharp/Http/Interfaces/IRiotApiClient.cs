using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotSharp.Http.Interfaces
{
    public interface IRiotApiClient
    {
        /// <summary>
        /// Send a get request asynchronously to the riot api.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(Uri requestUri);
        /// <summary>
        /// Send a put request asynchronously to the riot api.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
        /// <summary>
        /// Send a post request asynchronously to the riot api.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
    }
}
