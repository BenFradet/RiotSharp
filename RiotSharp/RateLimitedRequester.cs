using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RiotSharp
{
    internal class RateLimitedRequester : Requester
    {
        public int RateLimitPer10S { get; set; }
        public int RateLimitPer10M { get; set; }

        internal RateLimitedRequester(string apiKey, int rateLimitPer10s, int rateLimitPer10m)
        {
            ApiKey = apiKey;
            RateLimitPer10S = rateLimitPer10s;
            RateLimitPer10M = rateLimitPer10m;
        }

        private readonly Dictionary<Region, DateTime> firstRequestsInLastTenS = new Dictionary<Region, DateTime>();
        private readonly Dictionary<Region, DateTime> firstRequestsInLastTenM = new Dictionary<Region, DateTime>();
        private readonly Dictionary<Region, int> numberOfRequestsInLastTenS = new Dictionary<Region, int>();
        private readonly Dictionary<Region, int> numberOfRequestsInLastTenM = new Dictionary<Region, int>();

        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public string CreateGetRequest(string relativeUrl, Region region, List<string> addedArguments = null,
            bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return GetResult(request);
        }


        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return await GetResultAsync(request);
        }

        public string CreatePostRequest(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();
            return Post(request);
        }

        public async Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Post);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return await PostAsync(request);
        }

        public bool CreatePutRequest(string relativeUrl, Region region, string body, List<string> addedArguments = null,
            bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            var response = Put(request);
            return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
        }

        public async Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Put);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            var response = await PutAsync(request);
            return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
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
