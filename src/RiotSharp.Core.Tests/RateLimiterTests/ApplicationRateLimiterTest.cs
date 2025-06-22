using RiotSharp.Core.Http.RateLimiting;
using RiotSharp.Core.Misc;

namespace RiotSharp.Core.Tests.RateLimiterTests
{
    public class ApplicationRateLimiterTest
    {
        [Fact]
        public void Constructor_NullRateLimits_ThrowsArgumentException()
        {
            Dictionary<TimeSpan, int>? emptyDictionary = null;
            Assert.Throws<ArgumentException>(() => new ApplicationRateLimiter(emptyDictionary));
        }

        [Fact]
        public void Constructor_EmptyRateLimits_ThrowsArgumentException()
        {
            var emptyDictionary = new Dictionary<TimeSpan, int>();
            Assert.Throws<ArgumentException>(() => new ApplicationRateLimiter(emptyDictionary));
        }

        [Fact]
        public void Constructor_ValidRateLimits_CreatesApplicationRateLimiter()
        {
            var rateLimits = new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20},
                {TimeSpan.FromMinutes(2), 100}
            };

            var uut = new ApplicationRateLimiter(rateLimits);
            Assert.NotNull(uut);
        }

        [Fact]
        public async Task GetLeaseForRegion_20LeasesIn1Request_20AllowedIn1Second()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20}
            });

            var lease = await uut.GetLeaseForRegion(Region.Euw, 20);

            Assert.True(lease.IsAcquired);
            Assert.Null(lease.RetryAfter);
        }

        [Fact]
        public void GetLeaseForRegion_25LeasesIn1Request_ArgumentOutOfRange()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20}
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => uut.GetLeaseForRegion(Region.Euw, 25).Result);
        }

        [Fact]
        public async Task GetLeaseForRegion_15LeasePlus10Lease_1IsAcquired1IsNot()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20}
            });

            var lease1 = await uut.GetLeaseForRegion(Region.Euw, 15);
            var lease2 = await uut.GetLeaseForRegion(Region.Euw, 10);

            Assert.True(lease1.IsAcquired);
            Assert.Null(lease1.RetryAfter);
            Assert.False(lease2.IsAcquired);
            Assert.Equal(TimeSpan.FromSeconds(1), lease2.RetryAfter);
        }

        [Fact]
        public async Task GetLeaseForRegion_21AsyncRequests_20AllowedIn1Second()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20}
            });

            var leases = new List<IRequestLease>();
            for (int i = 0; i < 21; i++)
            {
                leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
            }

            Assert.Equal(20, leases.Count(l => l.IsAcquired));
            Assert.Equal(1, leases.Count(l => !l.IsAcquired));
        }

        [Fact]
        public async Task GetLeaseForRegion_DeveloperRateLimitTest_Accept100In6Seconds()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20},
                {TimeSpan.FromMinutes(2), 100}
            });

            var leases = new List<IRequestLease>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
                }
                await Task.Delay(TimeSpan.FromSeconds(1.2));
            }

            Assert.Equal(100, leases.Count(l => l.IsAcquired));
        }

        [Fact]
        public async Task GetLeaseForRegion_DeveloperRateLimitTest_Accept100In6Seconds_Decline1()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20},
                {TimeSpan.FromMinutes(2), 100}
            });

            var leases = new List<IRequestLease>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
                }
                await Task.Delay(TimeSpan.FromSeconds(1.2));
            }

            leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));

            Assert.Equal(100, leases.Count(l => l.IsAcquired));
            Assert.Equal(1, leases.Count(l => !l.IsAcquired));
        }

        [Fact]
        public async Task GetLeaseForRegion_DeveloperRateLimitTest_RetryAfter1Second()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20},
                {TimeSpan.FromMinutes(2), 100}
            });

            var leases = new List<IRequestLease>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
                }
                if (i != 4)
                    await Task.Delay(TimeSpan.FromSeconds(1.2));
            }

            var lastLease = await uut.GetLeaseForRegion(Region.Euw, 1);
            leases.Add(lastLease);

            Assert.Equal(100, leases.Count(l => l.IsAcquired));
            Assert.Equal(1, leases.Count(l => !l.IsAcquired));
            Assert.Equal(TimeSpan.FromSeconds(1), lastLease.RetryAfter);
        }

        [Fact]
        public async Task GetLeaseForRegion_DeveloperRateLimitTest_RetryAfter2minutes()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20},
                {TimeSpan.FromMinutes(2), 100}
            });

            var leases = new List<IRequestLease>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
                }
                await Task.Delay(TimeSpan.FromSeconds(1.2));
            }

            var lastLease = await uut.GetLeaseForRegion(Region.Euw, 1);
            leases.Add(lastLease);

            Assert.Equal(100, leases.Count(l => l.IsAcquired));
            Assert.Equal(1, leases.Count(l => !l.IsAcquired));
            Assert.Equal(TimeSpan.FromMinutes(2), lastLease.RetryAfter);
        }

        [Fact]
        public async Task GetLeaseForRegion_DeveloperRateLimitTest_RetryAfterIDK()
        {
            var uut = new ApplicationRateLimiter(new Dictionary<TimeSpan, int>
            {
                {TimeSpan.FromSeconds(1), 20},
                {TimeSpan.FromMinutes(2), 100}
            });

            var leases = new List<IRequestLease>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
                }
                await Task.Delay(TimeSpan.FromSeconds(1.2));
            }

            await Task.Delay(TimeSpan.FromSeconds(5));
            var lastLease = await uut.GetLeaseForRegion(Region.Euw, 1);
            leases.Add(lastLease);

            Assert.Equal(100, leases.Count(l => l.IsAcquired));
            Assert.Equal(1, leases.Count(l => !l.IsAcquired));
            Assert.Equal(TimeSpan.FromMinutes(2), lastLease.RetryAfter);
        }
    }
}
