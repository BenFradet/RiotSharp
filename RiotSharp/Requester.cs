using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RiotSharp
{
    public class Requester : IRequester
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
        public static bool LimitEnabled { get; set; }

        private static DateTime lastRequest = DateTime.MinValue;
        private static DateTime firstRequestInLastTenS = DateTime.MinValue;
        private static DateTime firstRequestInLastTenM = DateTime.MinValue;
        private static int numberOfRequestsInLastTenS = 0;
        private static object _lock = new object();

        public HttpWebRequest CreateRequest(string relativeUrl)
        {
            //5 requests per 10 secs
            //50 requests per 10 mins
            lock (_lock)
            {
                if (numberOfRequestsInLastTenS >= 5)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds < 10) ;
                    numberOfRequestsInLastTenS = 0;
                    firstRequestInLastTenS = DateTime.Now;
                }
                if (firstRequestInLastTenS == DateTime.MinValue)
                {
                    firstRequestInLastTenS = DateTime.Now;
                }
                numberOfRequestsInLastTenS++;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://{0}{1}?api_key={2}", RootDomain, relativeUrl, ApiKey));
                request.Method = "GET";
                return request;
            }
        }

        public string GetResponseString(Stream stream)
        {
            var data = new StreamReader(stream).ReadToEnd();
            stream.Close();
            return data;
        }
    }
}
