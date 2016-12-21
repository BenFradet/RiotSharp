using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;

namespace RiotSharpTest
{
    [TestClass]
    public class RateLimiterTest
    {
        public static readonly TimeSpan TenSeconds = TimeSpan.FromSeconds(10);
        /// <summary>
        /// Slightly more than the percentage extra delay tests tend to take.
        /// </summary>
        public const double ErrorFactor = 1.003;
        public static readonly TimeSpan ErrorDelay = TimeSpan.FromMilliseconds(20);
        public const int Limit = 10;

        internal RateLimiter RateLimiter;
        public Stopwatch Stopwatch = new Stopwatch();

        [TestInitialize]
        public void Initialize()
        {
            RateLimiter = new RateLimiter(Limit, int.MaxValue);
            Stopwatch.Restart();
        }

        /// <summary>
        /// Sends a single request, expected to unblock immediately.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter")]
        public void SingleRequest()
        {
            RateLimiter.HandleRateLimit();
            AssertDelayed(TimeSpan.Zero);
        }

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        public async Task SingleRequestAsync()
        {
            await RateLimiter.HandleRateLimitAsync();
            AssertDelayed(TimeSpan.Zero);
        }

        /// <summary>
        /// Basic check of the SetRetryAfter.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter")]
        public void RetryAfterBasic()
        {
            RateLimiter.HandleRateLimit();
            AssertDelayed(TimeSpan.Zero);

            var delay = TimeSpan.FromSeconds(5);
            RateLimiter.SetRetryAfter(delay);
            RateLimiter.HandleRateLimit();
            AssertDelayed(delay);
        }

        /// <summary>
        /// Sends 30 requests, expects each block of 10 requests to unblock after 10 second intervals.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter")]
        [Timeout(1000 * 10 * 3)]
        public void ManyRequests()
        {
            for (var i = 0; i < Limit * 3; i++)
            {
                RateLimiter.HandleRateLimit();
                AssertDelayed(TimeSpan.FromTicks(i / Limit * TenSeconds.Ticks));
            }
        }

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 3)]
        public async Task ManyRequestsAsync()
        {
            var tasks = Enumerable.Range(0, Limit*3).Select(i => RateLimiter.HandleRateLimitAsync()
                .ContinueWith(task => {
                    AssertDelayed(TimeSpan.FromTicks(i / Limit * TenSeconds.Ticks), i);
                })).ToList();

            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNull(task.Exception);
            }
        }

        /// <summary>
        /// Sends 10 requests, waits 10 seconds, sends another 10 requests. Expects requests to unblock immediately.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter")]
        [Timeout(1000 * 10 * 2)]
        public void DelayedRequests()
        {
            for (var i = 0; i < Limit; i++)
            {
                RateLimiter.HandleRateLimit();
                AssertDelayed(TimeSpan.Zero);
            }
            var delay = TenSeconds;
            Task.Delay(delay).Wait();
            for (var i = 0; i < Limit; i++)
            {
                RateLimiter.HandleRateLimit();
                AssertDelayed(delay);
            }
        }

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 2)]
        public async Task DelayedRequestsAsync()
        {
            var expectedDelayed = TenSeconds;
            // delayed tasks first, just for fun
            var tasks = Enumerable.Range(Limit * 2, Limit).Select(i => Task.Delay(expectedDelayed)
                .ContinueWith(task => RateLimiter.HandleRateLimitAsync())
                .ContinueWith(task =>
                {
                    AssertDelayed(expectedDelayed, i);
                })).ToList();
            // immediate tasks`
            var expected = TimeSpan.Zero;
            tasks.AddRange(Enumerable.Range(0, Limit).Select(i => RateLimiter.HandleRateLimitAsync()
                .ContinueWith(task =>
                {
                    AssertDelayed(expected, i);
                })));

            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNull(task.Exception);
            }
        }

        /// <summary>
        /// Sends 10 requests, waits 20 seconds, sends another 10 requests. Expects requests to unblock immediately.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter")]
        [Timeout(1000 * 10 * 3)]
        public void AlternatingRequests()
        {
            for (var i = 0; i < Limit; i++)
            {
                RateLimiter.HandleRateLimit();
                AssertDelayed(TimeSpan.Zero);
            }
            var delay = TimeSpan.FromTicks(TenSeconds.Ticks * 2);
            Task.Delay(delay).Wait();
            for (var i = 0; i < Limit; i++)
            {
                RateLimiter.HandleRateLimit();
                AssertDelayed(delay);
            }
        }

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 3)]
        public async Task AlternatingRequestsAsync()
        {
            var expectedDelayed = TimeSpan.FromTicks(TenSeconds.Ticks * 2);
            // delayed tasks first, just for fun
            var tasks = Enumerable.Range(Limit*2, Limit).Select(i => Task.Delay(expectedDelayed)
                .ContinueWith(task => RateLimiter.HandleRateLimitAsync())
                .ContinueWith(task =>
                {
                    AssertDelayed(expectedDelayed, i);
                })).ToList();
            // immediate tasks
            var expected = TimeSpan.Zero;
            tasks.AddRange(Enumerable.Range(0, Limit).Select(i => RateLimiter.HandleRateLimitAsync()
                .ContinueWith(task =>
                {
                    AssertDelayed(expected, i);
                })));

            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNull(task.Exception);
            }
        }

        /// <summary>
        /// Sends 5 requests. Waits 5 seconds. Sends 10 More requests.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 2)]
        public async Task MultipleManyRequests15Async()
        {
            // first 5 requests
            var tasks = Enumerable.Range(0, 5).Select(i => RateLimiter.HandleRateLimitAsync()
                .ContinueWith(t => AssertDelayed(TimeSpan.Zero, i))).ToList();
            var fiveSeconds = TimeSpan.FromSeconds(5);
            await Task.Delay(fiveSeconds);
            tasks.AddRange(Enumerable.Range(5, 10).Select(i => RateLimiter.HandleRateLimitAsync()
                .ContinueWith(t => AssertDelayed(i < 10 ? fiveSeconds : TenSeconds, i))));
            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNull(task.Exception);
            }
        }

        /// <summary>
        /// Same as above, but does the delay within the task.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 2)]
        public async Task MultipleManyRequests15InlineAsync()
        {
            // order is more random, so we keep track of each group instead
            int[] counts = {0, 0, 0};
            // first 5 requests
            var tasks = Enumerable.Range(0, 5).Select(async i => {
                await RateLimiter.HandleRateLimitAsync();
                counts[Stopwatch.Elapsed.Seconds / 10]++;
            }).ToList();
            var fiveSeconds = TimeSpan.FromSeconds(5);
            tasks.AddRange(Enumerable.Range(5, 10).Select(async i =>
            {
                await Task.Delay(fiveSeconds);
                await RateLimiter.HandleRateLimitAsync();
                counts[Stopwatch.Elapsed.Seconds / 10]++;
            }));

            await Task.WhenAll(tasks);
            Assert.AreEqual(10, counts[0]);
            Assert.AreEqual(5, counts[1]);
            Assert.AreEqual(0, counts[2]);
            foreach (var task in tasks)
            {
                Assert.IsNull(task.Exception);
            }
        }

        /// <summary>
        /// Sends 15 requests. Waits 10 seconds. Expects 10 requests each to be delayed by 0, 10, and 20 seconds.
        /// </summary>
        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 3)]
        public async Task MultipleManyRequests30InlineAsync()
        {
            // order is more random, so we keep track of each group instead
            int[] counts = { 0, 0, 0 };
            // last 15 tasks first, just for fun
            var tasks = Enumerable.Range(15, 15).Select(async i =>
            {
                await Task.Delay(TenSeconds);
                await RateLimiter.HandleRateLimitAsync();
                counts[Stopwatch.Elapsed.Seconds / 10]++;
            }).ToList();
            // first 15 tasks
            tasks.AddRange(Enumerable.Range(0, 15).Select(async i =>
            {
                await RateLimiter.HandleRateLimitAsync();
                counts[Stopwatch.Elapsed.Seconds / 10]++;
            }));

            await Task.WhenAll(tasks);
            Assert.AreEqual(10, counts[0]);
            Assert.AreEqual(10, counts[1]);
            Assert.AreEqual(10, counts[2]);
            foreach (var task in tasks)
            {
                Assert.IsNull(task.Exception);
            }
        }

        private void AssertDelayed(TimeSpan expected, int i=0)
        {
            var actual = Stopwatch.Elapsed;
            Assert.IsTrue(expected < actual,
                string.Format("{0} too soon. Expected: {1}. Actual: {2}.", i, expected, actual));
            Assert.IsTrue(actual < TimeSpan.FromTicks((int) (expected.Ticks * ErrorFactor + ErrorDelay.Ticks)),
                string.Format("{0} too late. Expected: {1}. Actual: {2}.", i, expected, actual));
        }
    }
}
