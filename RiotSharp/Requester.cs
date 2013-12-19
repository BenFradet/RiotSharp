using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    internal class Requester : IRequester
    {
        private static Requester instance;
        private Requester() { }
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
        //temporary fix because I dont know the limits for a production api key
        //if you have a dev key, this property should be true
        public static bool IsProdApi { get; set; }

        private static DateTime firstRequestInLastTenS = DateTime.MinValue;
        private static DateTime firstRequestInLastTenM = DateTime.MinValue;
        private static int numberOfRequestsInLastTenS = 0;
        private static int numberOfRequestInLastTenM = 0;
        private static Object _lock = new Object();

        private const int MAX_REQUEST_PER_10S = 10;
        private const int MAX_REQUEST_PER_10M = 500;

        public JObject CreateRequest(string relativeUrl, string addedArgument = null)
        {
            HttpWebRequest request = null;
            if (addedArgument == null)
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://{0}{1}?api_key={2}"
                    , RootDomain, relativeUrl, ApiKey));
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://{0}{1}?{2}&api_key={3}"
                    , RootDomain, relativeUrl, addedArgument, ApiKey));
            }
            request.Method = "GET";

            lock (_lock)
            {
                if (!IsProdApi && numberOfRequestInLastTenM >= MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalMinutes < 11) ;
                    numberOfRequestInLastTenM = 0;
                    firstRequestInLastTenM = DateTime.Now;
                }
                else if (!IsProdApi && numberOfRequestsInLastTenS >= MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds < 11) ;
                    numberOfRequestsInLastTenS = 0;
                    firstRequestInLastTenS = DateTime.Now;
                }

                if (firstRequestInLastTenM == DateTime.MinValue)
                {
                    firstRequestInLastTenM = DateTime.Now;
                }
                numberOfRequestInLastTenM++;

                if (firstRequestInLastTenS == DateTime.MinValue)
                {
                    firstRequestInLastTenS = DateTime.Now;
                }
                numberOfRequestsInLastTenS++;
            }

            var response = (HttpWebResponse)request.GetResponse();
            string result = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            return JObject.Parse(result);
        }

        public async Task<JObject> CreateRequestAsync(string relativeUrl, string addedArgument = null)
        {
            HttpWebRequest request = null;
            if (addedArgument == null)
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://{0}{1}?api_key={2}"
                    , RootDomain, relativeUrl, ApiKey));
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://{0}{1}?{2}&api_key={3}"
                    , RootDomain, relativeUrl, addedArgument, ApiKey));
            }
            request.Method = "GET";

            lock (_lock)
            {
                if (!IsProdApi && numberOfRequestInLastTenM >= MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalMinutes < 11) ;
                    numberOfRequestInLastTenM = 0;
                    firstRequestInLastTenM = DateTime.Now;
                }
                else if (!IsProdApi && numberOfRequestsInLastTenS >= MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds < 11) ;
                    numberOfRequestsInLastTenS = 0;
                    firstRequestInLastTenS = DateTime.Now;
                }

                if (firstRequestInLastTenM == DateTime.MinValue)
                {
                    firstRequestInLastTenM = DateTime.Now;
                }
                numberOfRequestInLastTenM++;

                if (firstRequestInLastTenS == DateTime.MinValue)
                {
                    firstRequestInLastTenS = DateTime.Now;
                }
                numberOfRequestsInLastTenS++;
            }

            var response = (HttpWebResponse)(await request.GetResponseAsync());
            string result = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = await reader.ReadToEndAsync();
            }

            return JObject.Parse(result);
        }
    }
}
