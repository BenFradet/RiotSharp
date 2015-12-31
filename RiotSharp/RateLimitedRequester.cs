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

        private Dictionary<Region, DateTime> firstRequestsInLastTenS = new Dictionary<Region, DateTime>();
        private Dictionary<Region, DateTime> firstRequestsInLastTenM = new Dictionary<Region, DateTime>();
        private Dictionary<Region, int> numberOfRequestsInLastTenS = new Dictionary<Region, int>();
        private Dictionary<Region, int> numberOfRequestsInLastTenM = new Dictionary<Region, int>();

        private SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public string CreateRequest(string relativeUrl, Region region, List<string> addedArguments = null,
            bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArguments, useHttps);

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return GetResponse(request);
        }

        public async Task<string> CreateRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArguments, useHttps);

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return await GetResponseAsync(request);
        }

        private void HandleRateLimit(Region region)
        {
            if (firstRequestsInLastTenM.ContainsKey(region))
            {
                if (firstRequestsInLastTenM[region] == DateTime.MinValue)
                {
                    firstRequestsInLastTenM[region] = DateTime.Now;
                }
            }
            else
            {
                firstRequestsInLastTenM.Add(region, DateTime.MinValue);
            }
            if (numberOfRequestsInLastTenM.ContainsKey(region))
            {
                numberOfRequestsInLastTenM[region]++;
            }
            else
            {
                numberOfRequestsInLastTenM[region] = 1;
            }

            if (firstRequestsInLastTenS.ContainsKey(region))
            {
                if (firstRequestsInLastTenS[region] == DateTime.MinValue)
                {
                    firstRequestsInLastTenS[region] = DateTime.Now;
                }
            }
            else
            {
                firstRequestsInLastTenS.Add(region, DateTime.MinValue);
            }
            if (numberOfRequestsInLastTenS.ContainsKey(region))
            {
                numberOfRequestsInLastTenS[region]++;
            }
            else
            {
                numberOfRequestsInLastTenS.Add(region, 1);
            }

            if (numberOfRequestsInLastTenM[region] > RateLimitPer10M)
            {
                while ((DateTime.Now - firstRequestsInLastTenM[region]).TotalMinutes <= 11)
                {
                }
                numberOfRequestsInLastTenM[region] = 1;
                firstRequestsInLastTenM[region] = DateTime.Now;
            }
            if (numberOfRequestsInLastTenS[region] > RateLimitPer10S)
            {
                while ((DateTime.Now - firstRequestsInLastTenS[region]).TotalSeconds <= 11)
                {
                }
                numberOfRequestsInLastTenS[region] = 1;
                firstRequestsInLastTenS[region] = DateTime.Now;
            }

            if ((DateTime.Now - firstRequestsInLastTenM[region]).TotalMinutes > 10)
            {
                numberOfRequestsInLastTenM[region] = 1;
                firstRequestsInLastTenM[region] = DateTime.Now;
            }
            if ((DateTime.Now - firstRequestsInLastTenS[region]).TotalSeconds > 10)
            {
                numberOfRequestsInLastTenS[region] = 1;
                firstRequestsInLastTenS[region] = DateTime.Now;
            }
        }
    }
}
