using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Http
{
    public class RequestClient : IRequestClient
    {
        private readonly HttpClient client;
        private readonly IFailedRequestHandler failureHandler;
        
        public RequestClient(HttpClient client, IFailedRequestHandler failureHandler)
        {
            this.client = client;
            this.failureHandler = failureHandler;
        }

        public HttpResponseMessage Get(HttpRequestMessage request)
            => GetAsync(request).Result;

        public async Task<HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            var response = await client.GetAsync(request.RequestUri);
            failureHandler.Handle(response);
            return response;
        }

        public HttpResponseMessage Put(HttpRequestMessage request)
            => PutAsync(request).Result;

        public async Task<HttpResponseMessage> PutAsync(HttpRequestMessage request)
        {
            var response = await client.PutAsync(request.RequestUri, request.Content);
            failureHandler.Handle(response);
            return response;
        }

        public HttpResponseMessage Post(HttpRequestMessage request)
            => PostAsync(request).Result;

        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request)
        {
            var response = await client.PostAsync(request.RequestUri, request.Content);
            failureHandler.Handle(response);
            return response;
        }

    }
}
