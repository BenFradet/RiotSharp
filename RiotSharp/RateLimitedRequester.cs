// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RateLimitedRequester.cs" company="">
//
// </copyright>
// <summary>
//   The rate limited requester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// The rate limited requester.
    /// </summary>
    class RateLimitedRequester : Requester
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static RateLimitedRequester instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="RateLimitedRequester"/> class from being created.
        /// </summary>
        private RateLimitedRequester()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static new RateLimitedRequester Instance
        {
            get
            {
                return instance ?? (instance = new RateLimitedRequester());
            }
        }

        /// <summary>
        /// Gets or sets the rate limit per 10 s.
        /// </summary>
        public static int RateLimitPer10S { get; set; }

        /// <summary>
        /// Gets or sets the rate limit per 10 m.
        /// </summary>
        public static int RateLimitPer10M { get; set; }

        /// <summary>
        /// The first request in last ten s.
        /// </summary>
        private DateTime firstRequestInLastTenS = DateTime.MinValue;

        /// <summary>
        /// The first request in last ten m.
        /// </summary>
        private DateTime firstRequestInLastTenM = DateTime.MinValue;

        /// <summary>
        /// The number of requests in last ten s.
        /// </summary>
        private int numberOfRequestsInLastTenS;

        /// <summary>
        /// The number of request in last ten m.
        /// </summary>
        private int numberOfRequestInLastTenM;

        /// <summary>
        /// The semaphore.
        /// </summary>
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

        /// <summary>
        /// The create request.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative url.
        /// </param>
        /// <param name="region">
        /// The region.
        /// </param>
        /// <param name="addedArguments">
        /// The added arguments.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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

        /// <summary>
        /// The create request async.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative url.
        /// </param>
        /// <param name="region">
        /// The region.
        /// </param>
        /// <param name="addedArguments">
        /// The added arguments.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<string> CreateRequestAsync(
            string relativeUrl,
            Region region,
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
