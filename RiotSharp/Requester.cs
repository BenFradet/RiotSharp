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

        public static String RootDomain { get; set; }
        public static String ApiKey { get; set; }
        //temporary fix because I dont know the limits for a production api key
        //if you have a dev key, this property should be true
        public static bool IsProdApi { get; set; }

        private static DateTime firstRequestInLastTenS = DateTime.MinValue;
        private static DateTime firstRequestInLastTenM = DateTime.MinValue;
        private static int numberOfRequestsInLastTenS = 0;
        private static int numberOfRequestInLastTenM = 0;
        private static Object _lock = new Object();

        private const int MAX_REQUEST_PER_10S = 5;
        private const int MAX_REQUEST_PER_10M = 50;

        public HttpWebRequest CreateRequest(string relativeUrl)
        {
            lock (_lock)
            {
                if (!IsProdApi && numberOfRequestInLastTenM >= MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalMinutes < 2) ;
                    numberOfRequestInLastTenM = 0;
                    firstRequestInLastTenM = DateTime.Now;
                }
                else if (!IsProdApi && numberOfRequestsInLastTenS >= MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds < 10) ;
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

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://{0}{1}?api_key={2}", RootDomain, relativeUrl, ApiKey));
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
