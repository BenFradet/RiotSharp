using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp.Http.Interfaces
{
    public interface IRequester
    {
        /// <summary>
        /// Creates and sends a get request. Deserializes the response.
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="region"></param>
        /// <param name="addedArguments"></param>
        /// <param name="useHttps"></param>
        /// <returns>The response deserialized to the requested type</returns>
        /// <exception cref="RiotSharpException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        T Get<T>(string relativeUrl, Region region, List<string> addedArguments = null, bool useHttps = true);

        /// <summary>
        /// Creates and asynchronously sends a get request. Deserializes the response.
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="region"></param>
        /// <param name="addedArguments"></param>
        /// <param name="useHttps"></param>
        /// <returns>The response deserialized to the requested type</returns>
        /// <exception cref="RiotSharpException">
        /// Thrown if an Http error occurs. 
        /// Contains the Http error code and error message.
        /// </exception>
        Task<T> GetAsync<T>(string relativeUrl, Region region, List<string> addedArguments = null, bool useHttps = true);

        T Post<T>(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true);

        Task<T> PostAsync<T>(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true);

        bool Put(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true);

        Task<bool> PutAsync(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true);

    }
}
