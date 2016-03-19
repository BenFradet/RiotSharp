using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotSharp
{
    class Requester
    {
        protected string rootDomain;
        private readonly HttpClient httpClient;
        public string ApiKey { get; set; }

        internal Requester(string apiKey = "")
        {
            ApiKey = apiKey;
            httpClient = new HttpClient();
        }

        public string CreateGetRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null,
            bool useHttps = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            return GetResult(request);
        }

        public async Task<string> CreateGetRequestAsync(string relativeUrl, string rootDomain,
            List<string> addedArguments = null, bool useHttps = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            return await GetResultAsync(request);
        }

        protected HttpRequestMessage PrepareRequest(string relativeUrl, List<string> addedArguments,
            bool useHttps, HttpMethod httpMethod)
        {
            var scheme = useHttps ? "https" : "http";
            var url = addedArguments == null ?
                string.Format("{0}://{1}{2}?api_key={3}", scheme, rootDomain, relativeUrl, ApiKey) :
                string.Format("{0}://{1}{2}?{3}api_key={4}",
                    scheme, rootDomain, relativeUrl, BuildArgumentsString(addedArguments), ApiKey);

            return new HttpRequestMessage(httpMethod, url);
        }

        protected string GetResult(HttpRequestMessage request)
        {
            var result = string.Empty;
            using (var response = httpClient.GetAsync(request.RequestUri).Result)
            {
                if (!response.IsSuccessStatusCode)
                {
                    HandleRequestFailure(response.StatusCode);
                }
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        protected async Task<string> GetResultAsync(HttpRequestMessage request)
        {
            var result = string.Empty;
            using (var response = await httpClient.GetAsync(request.RequestUri))
            {
                if (!response.IsSuccessStatusCode)
                {
                    HandleRequestFailure(response.StatusCode);
                }
                using (var content = response.Content)
                {
                    result = await content.ReadAsStringAsync();
                }
            }
            return result;
        }

        protected HttpResponseMessage Put(HttpRequestMessage request)
        {
            var result = httpClient.PutAsync(request.RequestUri, request.Content).Result;
            if (!result.IsSuccessStatusCode)
            {
                HandleRequestFailure(result.StatusCode);
            }
            return result;
        }

        protected async Task<HttpResponseMessage> PutAsync(HttpRequestMessage request)
        {
            var result = await httpClient.PutAsync(request.RequestUri, request.Content);
            if (!result.IsSuccessStatusCode)
            {
                HandleRequestFailure(result.StatusCode);
            }
            return result;
        }

        protected string Post(HttpRequestMessage request)
        {
            var result = string.Empty;
            using (var response = httpClient.PostAsync(request.RequestUri, request.Content).Result)
            {
                if (!response.IsSuccessStatusCode)
                {
                    HandleRequestFailure(response.StatusCode);
                }
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        protected async Task<string> PostAsync(HttpRequestMessage request)
        {
            var result = string.Empty;
            using (var response = await httpClient.PostAsync(request.RequestUri, request.Content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    HandleRequestFailure(response.StatusCode);
                }
                using (var content = response.Content)
                {
                    result = await content.ReadAsStringAsync();
                }
            }
            return result;
        }



        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => arg != string.Empty)
                .Aggregate(string.Empty, (current, arg) => current + (arg + "&"));
        }

        protected void HandleRequestFailure(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.ServiceUnavailable:
                    throw new RiotSharpException("503, Service unavailable");
                case HttpStatusCode.InternalServerError:
                    throw new RiotSharpException("500, Internal server error");
                case HttpStatusCode.Unauthorized:
                    throw new RiotSharpException("401, Unauthorized");
                case HttpStatusCode.BadRequest:
                    throw new RiotSharpException("400, Bad request");
                case HttpStatusCode.NotFound:
                    throw new RiotSharpException("404, Resource not found");
                case HttpStatusCode.Forbidden:
                    throw new RiotSharpException("403, Forbidden");
            }
        }
    }
}
