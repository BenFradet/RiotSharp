using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace RiotSharp
{
    class Requester
    {
        private static Requester instance;
        protected Requester() { }
        public static Requester Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Requester();
                }
                return instance;
            }
        }

        public static string RootDomain { get; set; }
        public static string ApiKey { get; set; }

        public virtual string CreateRequest(string relativeUrl, List<string> addedArguments = null)
        {
            var request = PrepareRequest(relativeUrl, addedArguments);
            return GetResponse(request);
        }

        public virtual async Task<string> CreateRequestAsync(string relativeUrl, List<string> addedArguments = null)
        {
            var request = PrepareRequest(relativeUrl, addedArguments);
            return await GetResponseAsync(request);
        }

        protected HttpWebRequest PrepareRequest(string relativeUrl, List<string> addedArguments)
        {
            HttpWebRequest request = null;
            if (addedArguments == null)
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://{0}{1}?api_key={2}"
                    , RootDomain, relativeUrl, ApiKey));
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://{0}{1}?{2}api_key={3}"
                    , RootDomain, relativeUrl, BuildArgumentsString(addedArguments), ApiKey));
            }
            request.Method = "GET";

            return request;
        }

        protected string GetResponse(HttpWebRequest request)
        {
            var response = (HttpWebResponse)request.GetResponse();
            string result = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        protected async Task<string> GetResponseAsync(HttpWebRequest request)
        {
            var response = (HttpWebResponse)(await request.GetResponseAsync());
            string result = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = await reader.ReadToEndAsync();
            }
            return result;
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            string result = string.Empty;
            foreach (string arg in arguments)
            {
                result += arg + "&";
            }
            return result;
        }
    }
}
