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

        private static DateTime firstRequestInLastTenS = DateTime.MinValue;
        private static DateTime firstRequestInLastTenM = DateTime.MinValue;
        private static int numberOfRequestsInLastTenS = 0;
        private static int numberOfRequestInLastTenM = 0;
        private static object _lock = new object();

        private const int REQUEST_PER_10S = 5;
        private const int REQUEST_PER_10M = 50;

        public HttpWebRequest CreateRequest(string relativeUrl)
        {
            lock (_lock)
            {
                if (LimitEnabled && numberOfRequestsInLastTenS >= REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds < 10) ;
                    numberOfRequestsInLastTenS = 0;
                    firstRequestInLastTenS = DateTime.Now;
                }
                else if(LimitEnabled && numberOfRequestInLastTenM >= REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalMinutes < 2) ;
                    numberOfRequestInLastTenM = 0;
                    firstRequestInLastTenM = DateTime.Now;
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
