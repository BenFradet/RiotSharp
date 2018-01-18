using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RiotSharp.Test")]
namespace RiotSharp.Http
{
    internal class RateLimiter
    {
        /// <summary>Semaphore to prevent multiple requests from interferering with each other's rate limit
        /// calculations.</summary>
        private readonly SemaphoreSlim accessSemaphore = new SemaphoreSlim(1);

        /// <summary>Time to retry when 429 Retry-After headers are set.</summary>
        private DateTime? retryAfter;

        /// <summary>Key is rate limit interval, value is the maximum requests allowed in that interval.</summary>
        private readonly IDictionary<TimeSpan, int> rateLimits;

        /// <summary>Key is rate limit interval, value is time the inteval started.</summary>
        private readonly IDictionary<TimeSpan, DateTime> rateLimitStarts = new Dictionary<TimeSpan, DateTime>();

        /// <summary>Key is rate limit interval, value is the current request count.</summary>
        private readonly IDictionary<TimeSpan, int> rateLimitCounts = new Dictionary<TimeSpan, int>();

        public RateLimiter(IDictionary<TimeSpan, int> rateLimits)
        {
            this.rateLimits = rateLimits;
        }

        /// <summary>
        /// Sets the retry after delay when a request returns 429.
        /// Note that this won't affect a (single) request that has already called HandleRateLimitAsync and is
        /// currently waiting.
        /// </summary>
        /// <param name="delay">Time to delay.</param>
        public void SetRetryAfter(TimeSpan delay)
        {
            retryAfter = DateTime.Now + delay;
        }

        /// <summary>Creates a task that blocks until a request can be made without violating rate limit rules. Release
        /// must be called after the task completes.</summary>
        public async Task HandleRateLimitAsync()
        {
            await accessSemaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                await Task.Delay(GetDelay()).ConfigureAwait(false);
                UpdateDelay();
            }
            finally
            {
                accessSemaphore.Release();
            }
        }

        /// <summary>
        /// Gets the delay required. Should only be called when accessSemaphore is currently owned. Non-destructive.
        /// </summary>
        /// <returns></returns>
        private TimeSpan GetDelay()
        {
            var now = DateTime.Now;

            // Check if we are at the rate limit, find the longest delay.
            var delay = TimeSpan.Zero;
            
            // RetryAfter delay.
            var retryDelay = retryAfter - now;
            if (retryDelay > delay)
                delay = (TimeSpan) retryDelay;

            // Rate limits.
            foreach (var rateLimitCount in rateLimitCounts)
            {
                // For each rate limit count.
                var timeSpan = rateLimitCount.Key;
                var count = rateLimitCount.Value;
                var limit = rateLimits[timeSpan];

                // If request count is a limit, update the delay to match.
                if (count >= limit)
                {
                    // Start should exist if count exists.
                    var start = rateLimitStarts[timeSpan];
                    var newDelay = start + timeSpan - now;
                    if (newDelay > delay)
                        delay = newDelay;
                }
            }

            return delay;
        }

        /// <summary>
        /// Update the delays counters after GetDelay() has been waited.
        /// </summary>
        private void UpdateDelay()
        {
            var now = DateTime.Now;

            foreach (var rateLimit in rateLimits)
            {
                var timeSpan = rateLimit.Key;

                int count;
                DateTime start = DateTime.MinValue;
                rateLimitStarts.TryGetValue(timeSpan, out start);

                // If the rate limit hasn't been initialized (no start value) or the time span has ended.
                if (start == DateTime.MinValue || start <= now - timeSpan)
                {
                    rateLimitStarts[timeSpan] = now;
                    count = 0;
                }
                else
                {
                    // Rate limit must've been initialized and is current.
                    count = rateLimitCounts[timeSpan];
                }

                rateLimitCounts[timeSpan] = count + 1;
            }
        }
    }
}
