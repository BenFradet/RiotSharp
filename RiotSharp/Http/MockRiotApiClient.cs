using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Http
{
    public class MockRiotApiClient : IRiotApiClient
    {
        private readonly Dictionary<Uri, HttpResponseMessage> responses;

        public MockRiotApiClient()
        {
            responses = new Dictionary<Uri, HttpResponseMessage>();
        }

        public MockRiotApiClient(Dictionary<Uri, HttpResponseMessage> mockResponses)
        {
            responses = mockResponses;
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return Task.FromResult(responses.ContainsKey(requestUri) ? responses[requestUri] : new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return Task.FromResult(responses.ContainsKey(requestUri) ? responses[requestUri] : new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return Task.FromResult(responses.ContainsKey(requestUri) ? responses[requestUri] : new HttpResponseMessage(HttpStatusCode.NotFound));
        }
    }
}
