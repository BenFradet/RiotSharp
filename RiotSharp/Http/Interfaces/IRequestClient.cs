using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Http.Interfaces
{
    public interface IRequestClient
    {
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
