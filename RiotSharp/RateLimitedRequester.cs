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
    class RateLimitedRequester : Requester
    {
        private static RateLimitedRequester instance;
        private RateLimitedRequester()
         : base() { }
        public static RateLimitedRequester Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RateLimitedRequester();
                }
                return instance;
            }
        }

        //temporary fix because I dont know the limits for a production api key
        //if you have a dev key, this property should be true
        public static bool IsProdApi { get; set; }

        private DateTime firstRequestInLastTenS = DateTime.MinValue;
        private DateTime firstRequestInLastTenM = DateTime.MinValue;
        private int numberOfRequestsInLastTenS = 0;
        private int numberOfRequestInLastTenM = 0;

        private SemaphoreSlim semaphore = new SemaphoreSlim(1);

        private const int MAX_REQUEST_PER_10S = 10;
        private const int MAX_REQUEST_PER_10M = 500;

        public override string CreateRequest(string relativeUrl, string addedArgument = null)
        {
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArgument);

            semaphore.Wait();
            {
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

                if (!IsProdApi && numberOfRequestInLastTenM >= MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalMinutes <= 10) ;
                    numberOfRequestInLastTenM = 0;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (!IsProdApi && numberOfRequestsInLastTenS >= MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 10) ;
                    numberOfRequestsInLastTenS = 0;
                    firstRequestInLastTenS = DateTime.Now;
                }
            }
            semaphore.Release();

            return GetResponse(request);
        }

        public override async Task<string> CreateRequestAsync(string relativeUrl, string addedArgument = null)
        {
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArgument);

            await semaphore.WaitAsync();
            {
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

                if (!IsProdApi && numberOfRequestInLastTenM >= MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalMinutes <= 10) ;
                    numberOfRequestInLastTenM = 0;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (!IsProdApi && numberOfRequestsInLastTenS >= MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 10) ;
                    numberOfRequestsInLastTenS = 0;
                    firstRequestInLastTenS = DateTime.Now;
                }
            }
            semaphore.Release();

            return await GetResponseAsync(request);
        }
    }
}
