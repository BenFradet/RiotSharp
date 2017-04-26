using System;
using System.Threading;
using System.Threading.Tasks;

namespace RiotSharp.Http
{
    /// <summary>
    /// A rate limiter for a single region.
    /// </summary>
    internal class RateLimiter
    {
        private static readonly TimeSpan TenSeconds = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan TenMinutes = TimeSpan.FromMinutes(10);

        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

        private readonly int rateLimitPer10Seconds;
        private readonly int rateLimitPer10Minutes;

        private DateTime firstRequestInLast10Seconds = DateTime.MinValue;
        private DateTime firstRequestInLast10Minutes = DateTime.MinValue;

        private int requestsInLast10Seconds = 0;
        private int requestsInLast10Minutes = 0;

        /// <summary>Stores the retryAfter time if a request returns 429.</summary>
        private DateTime retryAfter = DateTime.MinValue;

        public RateLimiter(int rateLimitPer10Seconds, int rateLimitPer10Minutes)
        {
            this.rateLimitPer10Seconds = rateLimitPer10Seconds;
            this.rateLimitPer10Minutes = rateLimitPer10Minutes;
        }

        /// <summary>
        /// Blocks until a request can be made without violating rate limit rules.
        /// </summary>
        public void HandleRateLimit()
        {
            semaphore.Wait();
            try
            {
                Task.Delay(GetDelay()).Wait();
                UpdateDelay();
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <summary>
        /// Creates a task that blocks until a request can be made without violating rate limit rules. 
        /// </summary>
        /// <returns></returns>
        public async Task HandleRateLimitAsync()
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(GetDelay());
                UpdateDelay();
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <summary>
        /// Sets the retry after delay when a request returns 429.
        /// 
        /// Note that this won't affect a (single) request that has already called HandleRateLimitAsync and is currently waiting.
        /// </summary>
        /// <param name="delay"></param>
        public void SetRetryAfter(TimeSpan delay)
        {
            retryAfter = DateTime.Now + delay;
        }

        /// <summary>
        /// Gets the delay required. Should only be called when semaphore is currently owned. Non-destructive.
        /// </summary>
        /// <returns></returns>
        private TimeSpan GetDelay()
        {
            var now = DateTime.Now;
            
            // check if we are at the rate limit, find the longest delay
            var delay = TimeSpan.Zero;
            // 10 minutes
            if (requestsInLast10Minutes >= rateLimitPer10Minutes)
            {
                var newDelay = firstRequestInLast10Minutes + TenMinutes - now;
                if (newDelay > delay)
                    delay = newDelay;
            }
            // 10 seconds
            if (requestsInLast10Seconds >= rateLimitPer10Seconds)
            {
                var newDelay = firstRequestInLast10Seconds + TenSeconds - now;
                if (newDelay > delay)
                    delay = newDelay;
            }
            // retryAfter delay
            var retryDelay = retryAfter - now;
            if (retryDelay > delay)
                delay = retryDelay;

            return delay;
        }

        /// <summary>
        /// Update the delays counters after GetDelay() has been waited.
        /// </summary>
        private void UpdateDelay()
        {
            var now = DateTime.Now;

            // reset if rate limit timespan is over
            if (firstRequestInLast10Minutes < now - TenMinutes)
            {
                firstRequestInLast10Minutes = now;
                requestsInLast10Minutes = 0;
            }
            if (firstRequestInLast10Seconds < now - TenSeconds)
            {
                firstRequestInLast10Seconds = now;
                requestsInLast10Seconds = 0;
            }

            // increment the request counters
            requestsInLast10Minutes++;
            requestsInLast10Seconds++;
        }
    }
}
