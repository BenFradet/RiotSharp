using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps);

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return GetResponse(request);
        }

        public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps);

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            return await GetResponseAsync(request);
        }

        public string CreatePostRequest(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, "POST");
            request.ContentType = "application/json";

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            var byteArray = Encoding.UTF8.GetBytes(body);
            var dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            return GetResponse(request);
        }

        public async Task<string> CreatePostRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, "POST");
            request.ContentType = "application/json";

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            var byteArray = Encoding.UTF8.GetBytes(body);
            var dataStream = await request.GetRequestStreamAsync();

            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            return await GetResponseAsync(request);
        }

        public bool CreatePutRequest(string relativeUrl, Region region, string body, List<string> addedArguments = null,
            bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, "PUT");
            request.ContentType = "application/json";

            semaphore.Wait();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            var byteArray = Encoding.UTF8.GetBytes(body);
            var dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                // if code is in 2xx (=OK) range, return success value = true.
                return (int) response.StatusCode >= 200 && (int) response.StatusCode < 300;
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
                return false;
            }
        }

        public async Task<bool> CreatePutRequestAsync(string relativeUrl, Region region, string body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            rootDomain = region + ".api.pvp.net";
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, "PUT");
            request.ContentType = "application/json";

            await semaphore.WaitAsync();
            {
                HandleRateLimit(region);
            }
            semaphore.Release();

            var byteArray = Encoding.UTF8.GetBytes(body);
            var dataStream = await request.GetRequestStreamAsync();

            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                var response = (HttpWebResponse)(await request.GetResponseAsync());

                // if code is in 2xx (=OK) range, return success value = true.
                return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
                return false;
            }
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
