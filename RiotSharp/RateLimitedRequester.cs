using System;
using System.Collections.Generic;
using System.Net;
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

        public static int RateLimitPer10S { get; set; }
        public static int RateLimitPer10M { get; set; }

        private DateTime firstRequestInLastTenS = DateTime.MinValue;
        private DateTime firstRequestInLastTenM = DateTime.MinValue;
        private int numberOfRequestsInLastTenS = 0;
        private int numberOfRequestInLastTenM = 0;

        private SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public string CreateRequest(string relativeUrl, Region region, List<string> addedArguments = null)
        {
            rootDomain = region.ToString() + ".api.pvp.net";
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

                if (numberOfRequestInLastTenM > RateLimitPer10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalSeconds <= 601) ;
                    numberOfRequestInLastTenM = 1;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (numberOfRequestsInLastTenS > RateLimitPer10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 11) ;
                    numberOfRequestsInLastTenS = 1;
                    firstRequestInLastTenS = DateTime.Now;
                }

                if ((DateTime.Now - firstRequestInLastTenS).TotalSeconds > 10)
                {
                    firstRequestInLastTenS = DateTime.Now;
                    numberOfRequestsInLastTenS = 1;
                }
                if ((DateTime.Now - firstRequestInLastTenM).TotalMinutes > 10)
                {
                    firstRequestInLastTenM = DateTime.Now;
                    numberOfRequestInLastTenM = 1;
                }
            }
            semaphore.Release();

            return GetResponse(request);
        }

        public async Task<string> CreateRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null)
        {
            rootDomain = region.ToString() + ".api.pvp.net";
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


                if (numberOfRequestInLastTenM > RateLimitPer10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM).TotalSeconds <= 601) ;
                    numberOfRequestInLastTenM = 1;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (numberOfRequestsInLastTenS > RateLimitPer10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 11) ;
                    numberOfRequestsInLastTenS = 1;
                    firstRequestInLastTenS = DateTime.Now;
                }

                if ((DateTime.Now - firstRequestInLastTenS).TotalSeconds > 10)
                {
                    firstRequestInLastTenS = DateTime.Now;
                    numberOfRequestsInLastTenS = 1;
                }
                if ((DateTime.Now - firstRequestInLastTenM).TotalMinutes > 10)
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
