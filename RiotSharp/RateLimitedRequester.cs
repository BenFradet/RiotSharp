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

        //private DateTime firstRequestInLastTenS = DateTime.MinValue;
        //private DateTime firstRequestInLastTenM = DateTime.MinValue;
        //private int numberOfRequestsInLastTenS;
        //private int numberOfRequestInLastTenM;

        private Dictionary<Region, DateTime> firstRequestInLastTenS = new Dictionary<Region, DateTime>();
        private Dictionary<Region, DateTime> firstRequestInLastTenM = new Dictionary<Region, DateTime>();
        private Dictionary<Region, int> numberOfRequestsInLastTenS = new Dictionary<Region, int>();
        private Dictionary<Region, int> numberOfRequestInLastTenM = new Dictionary<Region, int>();

        private SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public async Task<string> CreateRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null, bool useSsl = true)
        {
            rootDomain = region + ".api.pvp.net";
            HttpWebRequest request = PrepareRequest(relativeUrl, addedArguments, useSsl);

            await semaphore.WaitAsync();
            {
                if (firstRequestInLastTenM.ContainsKey(region))
                {
                    if (firstRequestInLastTenM[region] == DateTime.MinValue)
                    {
                        firstRequestInLastTenM[region] = DateTime.Now;
                    }
                }
                else
                {
                    firstRequestInLastTenM.Add(region, DateTime.MinValue);
                }

                if (numberOfRequestInLastTenM.ContainsKey(region))
                {
                    numberOfRequestInLastTenM[region] = numberOfRequestInLastTenM[region]++;
                }
                else
                {
                    numberOfRequestInLastTenM.Add(region, 1);
                }


                if (firstRequestInLastTenS.ContainsKey(region))
                {
                    if (firstRequestInLastTenS[region] == DateTime.MinValue)
                    {
                        firstRequestInLastTenS[region] = DateTime.Now;
                    }
                }
                else
                {
                    firstRequestInLastTenS.Add(region, DateTime.MinValue);
                }

                if (numberOfRequestsInLastTenS.ContainsKey(region))
                {
                    numberOfRequestsInLastTenS[region] = numberOfRequestsInLastTenS[region]++;
                }
                else
                {
                    numberOfRequestsInLastTenS.Add(region, 1);
                }


                if (numberOfRequestInLastTenM[region] > RateLimitPer10M)
                {
                    while ((DateTime.Now - firstRequestInLastTenM[region]).TotalSeconds <= 601)
                    {
                    }
                    numberOfRequestInLastTenM[region] = 1;
                    firstRequestInLastTenM[region] = DateTime.Now;
                }
                if (numberOfRequestsInLastTenS[region] > RateLimitPer10S)
                {
                    while ((DateTime.Now - firstRequestInLastTenS[region]).TotalSeconds <= 11)
                    {
                    }
                    numberOfRequestsInLastTenS[region] = 1;
                    firstRequestInLastTenS[region] = DateTime.Now;
                }

                if ((DateTime.Now - firstRequestInLastTenS[region]).TotalSeconds > 10)
                {
                    firstRequestInLastTenS[region] = DateTime.Now;
                    numberOfRequestsInLastTenS[region] = 1;
                }
                if ((DateTime.Now - firstRequestInLastTenM[region]).TotalMinutes > 10)
                {
                    firstRequestInLastTenM[region] = DateTime.Now;
                    numberOfRequestInLastTenM[region] = 1;
                }

            }
            semaphore.Release();

            return await GetResponseAsync(request);
        }
    }
}
