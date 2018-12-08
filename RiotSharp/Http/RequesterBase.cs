using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotSharp.Http
{
    public abstract class RequesterBase
    {
        protected const string platformDomain = ".api.riotgames.com";
        private readonly HttpClient httpClient;

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
            httpClient = new HttpClient();
        }

        #region Protected Methods

        /// <summary>
        /// Send a get request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            var response = await httpClient.GetAsync(request.RequestUri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                await HandleRequestFailureAsync(response);
            }
            return response;
        }

        /// <summary>
        /// Send a put request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> PutAsync(HttpRequestMessage request)
        {
            var response = await httpClient.PutAsync(request.RequestUri, request.Content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                await HandleRequestFailureAsync(response);
            }
            return response;
        }

        /// <summary>
        /// Send a post request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="RiotSharpException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request)
        {
            var response = await httpClient.PostAsync(request.RequestUri, request.Content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                await HandleRequestFailureAsync(response);
            }
            return response;
        }

        protected HttpRequestMessage PrepareRequest(string host, string relativeUrl, List<string> queryParameters,
            bool useHttps, HttpMethod httpMethod)
        {
            if (!string.IsNullOrWhiteSpace(ApiKey))
            {
                if (queryParameters == null)
                    queryParameters = new List<string> { "api_key=" + ApiKey };                
                else
                    queryParameters.Add("api_key=" + ApiKey);
            }

            var scheme = useHttps ? "https" : "http";
            var url = queryParameters == null ?
                $"{scheme}://{host}{relativeUrl}" :
                $"{scheme}://{host}{relativeUrl}?{BuildArgumentsString(queryParameters)}";

            var requestMessage = new HttpRequestMessage(httpMethod, url);        
            return requestMessage;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .Aggregate(string.Empty, (current, arg) => current + ("&" + arg));
        }

        protected async Task HandleRequestFailureAsync(HttpResponseMessage message)
        {
            try
            {
                var content = await GetResponseContentAsync(message);
                var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(content);
                throw new RiotSharpException(errorResponse.Status.Message, message.StatusCode);
            }
            catch
            {
                switch (message.StatusCode)
                {
                    case HttpStatusCode.ServiceUnavailable:
                        throw new RiotSharpException("503, Service unavailable", message.StatusCode);
                    case HttpStatusCode.InternalServerError:
                        throw new RiotSharpException("500, Internal server error", message.StatusCode);
                    case HttpStatusCode.Unauthorized:
                        throw new RiotSharpException("401, Unauthorized", message.StatusCode);
                    case HttpStatusCode.BadRequest:
                        throw new RiotSharpException("400, Bad request", message.StatusCode);
                    case HttpStatusCode.NotFound:
                        throw new RiotSharpException("404, Resource not found", message.StatusCode);
                    case HttpStatusCode.Forbidden:
                        throw new RiotSharpException("403, Forbidden", message.StatusCode);
                    case (HttpStatusCode)429:
                        throw new RiotSharpException("429, Rate Limit Exceeded", message.StatusCode);
                    default:
                        throw new RiotSharpException("Unexpeced failure", message.StatusCode);
                }
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
            return GetPlatform(region) + platformDomain;
        }

        private string GetPlatform(Region region)
        {
            switch (region)
            {
                case Region.br:
                    return "br1";
                case Region.eune:
                    return "eun1";
                case Region.euw:
                    return "euw1";
                case Region.jp:
                    return "jp1";
                case Region.kr:
                    return "kr";
                case Region.lan:
                    return "la1";
                case Region.las:
                    return "la2";
                case Region.na:
                    return "na1";
                case Region.oce:
                    return "oc1";
                case Region.tr:
                    return "tr1";
                case Region.ru:
                    return "ru";
                case Region.global:
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
