using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Http;

namespace RiotSharp.Test
{
    [TestClass]
    public class RateLimiterTest
    {
        public static readonly TimeSpan TenSeconds = TimeSpan.FromSeconds(10);
        /// <summary>
        /// Slightly more than the percentage extra delay tests tend to take.
        /// </summary>
        public const double ErrorFactor = 1.003;
        public static readonly TimeSpan ErrorDelay = TimeSpan.FromMilliseconds(100);
        public const int Limit = 10;

        internal RateLimiter RateLimiter;
        public Stopwatch Stopwatch = new Stopwatch();

        [TestInitialize]
        public void Initialize()
        {
            RateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(10)] = Limit
            });
            Stopwatch.Restart();
        }

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        public async Task HandleRateLimitAsync_UseTheHandleRateLimitAsync_ReturnTimeSpanZero()
        {
            await RateLimiter.HandleRateLimitAsync();
            AssertDelayed(TimeSpan.Zero);
        }

        [TestMethod]
        [TestCategory("RateLimiter")]
        public void HandleRateLimitAsync_ThrowOnDelay_ReturnThrowsException()
        {
            var rateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromHours(1)] = 1
            }, true);

            var exception = Assert.ThrowsException<AggregateException>(action: () =>
            {
                for (int i = 0; i < 2; i++)
                {
                    rateLimiter.HandleRateLimitAsync().Wait();
                }
            });
            Assert.IsInstanceOfType(exception.InnerException, typeof(RiotSharpException));
        }

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        public async Task HandleRateLimitAsync_NotThrowOnDelay_ReturnNoException()
        {
            var rateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = 1
            });

            for (int i = 0; i < 2; i++)
            {
                await rateLimiter.HandleRateLimitAsync();
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 3)]
        public async Task WhenAll_ManyRequestsAsync_ReturnTasks()
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

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 2)]
        public async Task WhenAll_DelayedRequestsAsync_ReturnTasks()
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

        [TestMethod]
        [TestCategory("RateLimiter"), TestCategory("Async")]
        [Timeout(1000 * 10 * 3)]
        public async Task AddRange_AlternatingRequestsAsync_ReturnDelayedTasks()
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
        public async Task WhenAll_MultipleManyRequests15Async_ReturnTasks()
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
        public async Task WhenAll_MultipleManyRequests15InlineAsync_ReturnTasks()
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
        public async Task WhenAll_MultipleManyRequests30InlineAsync_ReturnTasks()
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
                $"{i} too soon. Expected: {expected}. Actual: {actual}.");
            Assert.IsTrue(actual < TimeSpan.FromTicks((int) (expected.Ticks * ErrorFactor + ErrorDelay.Ticks)),
                $"{i} too late. Expected: {expected}. Actual: {actual}.");
        }
    }
}
