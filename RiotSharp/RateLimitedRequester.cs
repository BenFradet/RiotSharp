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
        private RateLimitedRequester() { }
        public static new RateLimitedRequester Instance
        {
            get { return instance ?? (instance = new RateLimitedRequester()); }
        }

        public static int RateLimitPer10S { get; set; }
        public static int RateLimitPer10M { get; set; }

        private DateTime firstRequestInLastTenS = DateTime.MinValue;
        private DateTime firstRequestInLastTenM = DateTime.MinValue;
        private int numberOfRequestsInLastTenS;
        private int numberOfRequestInLastTenM;

        private SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public string CreateRequest(string relativeUrl, Region region, List<string> addedArguments = null)
        {
            rootDomain = region + ".api.pvp.net";
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
                    while ((DateTime.Now - firstRequestInLastTenM).TotalSeconds <= 601)
                    {
                    }
                    numberOfRequestInLastTenM = 1;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (numberOfRequestsInLastTenS > RateLimitPer10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 11)
                    {
                    }
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
            rootDomain = region + ".api.pvp.net";
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
                    while ((DateTime.Now - firstRequestInLastTenM).TotalSeconds <= 601)
                    {
                    }
                    numberOfRequestInLastTenM = 1;
                    firstRequestInLastTenM = DateTime.Now;
                }
                if (numberOfRequestsInLastTenS > RateLimitPer10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS).TotalSeconds <= 11)
                    {
                    }
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
