using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RiotSharp
{
    class Requester
    {
        private static Requester instance;
        protected Requester() { }
        public static Requester Instance
        {
            get { return instance ?? (instance = new Requester()); }
        }

        protected string rootDomain;
        public static string ApiKey { get; set; }

        public string CreateRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null,
            bool useHttps = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps);
            return GetResponse(request);
        }

        public async Task<string> CreateRequestAsync(string relativeUrl, string rootDomain,
            List<string> addedArguments = null, bool useHttps = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps);
            return await GetResponseAsync(request);
        }

        protected HttpWebRequest PrepareRequest(string relativeUrl, List<string> addedArguments, bool useHttps)
        {
            HttpWebRequest request;
            string scheme = useHttps ? System.Uri.UriSchemeHttps : System.Uri.UriSchemeHttp;
            if (addedArguments == null)
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("{0}://{1}{2}?api_key={3}"
                    , scheme, rootDomain, relativeUrl, ApiKey));
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("{0}://{1}{2}?{3}api_key={4}"
                    , scheme, rootDomain, relativeUrl, BuildArgumentsString(addedArguments), ApiKey));
            }
            request.Method = "GET";

            return request;
        }

        protected string GetResponse(HttpWebRequest request)
        {
            string result = string.Empty;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            return result;
        }

        protected async Task<string> GetResponseAsync(HttpWebRequest request)
        {
            string result = string.Empty;
            try
            {
                var response = (HttpWebResponse)(await request.GetResponseAsync());

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = await reader.ReadToEndAsync();
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
            string result = string.Empty;
            foreach (string arg in arguments)
            {
                if (arg != string.Empty)
                {
                    result += arg + "&";
                }
            }
            return result;
        }

        private void HandleWebException(WebException ex)
        {
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)ex.Response;
            }
            catch (System.NullReferenceException)
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
            }
        }
    }
}
