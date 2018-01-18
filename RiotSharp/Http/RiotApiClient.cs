using System;
using System.Net.Http;
using System.Threading.Tasks;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Http
{
    public class RiotApiClient : IRiotApiClient
    {
        private readonly HttpClient httpClient;

        public RiotApiClient()
        {
            httpClient = new HttpClient();
        }
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return httpClient.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return httpClient.PutAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return httpClient.PostAsync(requestUri, content);
        }
    }
}
