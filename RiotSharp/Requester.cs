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
        protected string RootDomain;
        public string ApiKey { get; set; }

        internal Requester(string apiKey = "")
        {
            ApiKey = apiKey;
        }

        public string CreateGetRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null,
            bool useHttps = true)
        {
            RootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            return GetResponse(request);
        }

        public async Task<string> CreateGetRequestAsync(string relativeUrl, string rootDomain,
            List<string> addedArguments = null, bool useHttps = true)
        {
            RootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            return await GetResponseAsync(request);
        }



        protected HttpWebRequest PrepareRequest(string relativeUrl, List<string> addedArguments, bool useHttps,
            string httpMethod = "GET")
        {
            HttpWebRequest request;
            string scheme = useHttps ? "https" : "http";
            if (addedArguments == null)
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("{0}://{1}{2}?api_key={3}"
                    , scheme, RootDomain, relativeUrl, ApiKey));
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("{0}://{1}{2}?{3}api_key={4}"
                    , scheme, RootDomain, relativeUrl, BuildArgumentsString(addedArguments), ApiKey));
            }
            request.Method = httpMethod;

            return request;
        }

        protected HttpRequestMessage PrepareRequest(string relativeUrl, List<string> addedArguments,
            bool useHttps, HttpMethod httpMethod)
        {
            var scheme = useHttps ? "https" : "http";
            var url = addedArguments == null ?
                $"{scheme}://{RootDomain}{relativeUrl}?api_key={ApiKey}" :
                $"{scheme}://{RootDomain}{relativeUrl}?{BuildArgumentsString(addedArguments)}api_key={ApiKey}";

            return new HttpRequestMessage(httpMethod, url);
        }

        protected string GetResponse(HttpRequestMessage request)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                using (var response = client.GetAsync(request.RequestUri).Result)
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync().Result;
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            return result;
        }

        protected string PostResponse(HttpRequestMessage request)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                using (var response = client.PostAsync(request.RequestUri, request.Content).Result)
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync().Result;
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            return result;
        }

        protected async Task<string> PostResponseAsync(HttpRequestMessage request)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                using (var response = await client.PostAsync(request.RequestUri, request.Content))
                using (var content = response.Content)
                {
                    result = await content.ReadAsStringAsync();
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            return result;
        }

        protected async Task<string> GetResponseAsync(HttpRequestMessage request)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                using (var response = await client.GetAsync(request.RequestUri))
                using (var content = response.Content)
                {
                    result = await content.ReadAsStringAsync();
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            return result;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            return arguments
                .Where(arg => arg != string.Empty)
                .Aggregate(string.Empty, (current, arg) => current + (arg + "&"));
        }

        protected void HandleWebException(WebException ex)
        {
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)ex.Response;
            }
            catch (NullReferenceException)
            {
                response = null;
            }

            if (response == null)
            {
                throw new RiotSharpException(ex.Message);
            }

            switch (response.StatusCode)
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
