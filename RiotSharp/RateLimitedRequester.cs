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
        private RateLimitedRequester() : base() { }
        public static new RateLimitedRequester Instance
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

        public override string CreateRequest(string relativeUrl, Region region, List<string> addedArguments = null)
        {
            RootDomain = region.ToString() + ".api.pvp.net";
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArguments);

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

                if (!IsProdApi && numberOfRequestInLastTenM > MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalSeconds <= 601) ;
                    numberOfRequestInLastTenM = 1;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (!IsProdApi && numberOfRequestsInLastTenS > MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 11) ;
                    numberOfRequestsInLastTenS = 1;
                    firstRequestInLastTenS = DateTime.Now;
                }

                if (!IsProdApi && ((DateTime.Now - firstRequestInLastTenS).TotalSeconds > 10))
                {
                    firstRequestInLastTenS = DateTime.Now;
                    numberOfRequestsInLastTenS = 1;
                }
                if (!IsProdApi && ((DateTime.Now - firstRequestInLastTenM).TotalMinutes > 10))
                {
                    firstRequestInLastTenM = DateTime.Now;
                    numberOfRequestInLastTenM = 1;
                }
            }
            semaphore.Release();

            return GetResponse(request);
        }

        public override async Task<string> CreateRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null)
        {
            RootDomain = region.ToString() + ".api.pvp.net";
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArguments);

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


                if (!IsProdApi && numberOfRequestInLastTenM > MAX_REQUEST_PER_10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalSeconds <= 601) ;
                    numberOfRequestInLastTenM = 1;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (!IsProdApi && numberOfRequestsInLastTenS > MAX_REQUEST_PER_10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 11) ;
                    numberOfRequestsInLastTenS = 1;
                    firstRequestInLastTenS = DateTime.Now;
                }

                if (!IsProdApi && ((DateTime.Now - firstRequestInLastTenS).TotalSeconds > 10))
                {
                    firstRequestInLastTenS = DateTime.Now;
                    numberOfRequestsInLastTenS = 1;
                }
                if (!IsProdApi && ((DateTime.Now - firstRequestInLastTenM).TotalMinutes > 10))
                {
                    firstRequestInLastTenM = DateTime.Now;
                    numberOfRequestInLastTenM = 1;
                }

            }
            semaphore.Release();

            return await GetResponseAsync(request);
        }
    }
}
