using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharpNET8.Http;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Http.RateLimiting;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Test.RateLimiterTests
{
	[TestFixture]
	[Parallelizable(ParallelScope.Children)] // Enable parallel execution
	public class ApplicationRateLimiterTest
	{
		[SetUp]
		public void Setup()
		{
			// No setup

		}

		[Test]
		public void Constructor_NullRateLimits_ThrowsArgumentException()
		{
			IRateLimiter uut = null;
			Dictionary<TimeSpan, int>? emptyDictionary = null;
			
			Assert.That(() => uut = new ApplicationRateLimiter(emptyDictionary),
				Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void Constructor_EmptyRateLimits_ThrowsArgumentException()
		{
			IRateLimiter uut = null;
			var emptyDictionary = new Dictionary<TimeSpan, int>();

			Assert.That(() => uut = new ApplicationRateLimiter(emptyDictionary),
				Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void Constructor_ValidRateLimits_CreatesApplicationRateLimiter()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20},
				{TimeSpan.FromMinutes(2), 100}
			};

			// Act and assert
			Assert.That(() => uut = new ApplicationRateLimiter(rateLimits), Throws.Nothing);
			Assert.That(uut, Is.Not.Null);
		}

		[Test]
		public async Task GetLeaseForRegion_20LeasesIn1Request_20AllowedIn1Second()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var lease = await uut.GetLeaseForRegion(Region.Euw, 20);

			// Assert
			Assert.That(lease.IsAcquired, Is.True);
			Assert.That(lease.RetryAfter, Is.Null);
		}

		[Test]
		public async Task GetLeaseForRegion_25LeasesIn1Request_ArgumentOutOfRange()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act and Assert
			Assert.That(() => uut.GetLeaseForRegion(Region.Euw, 25).Result, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public async Task GetLeaseForRegion_15LeasePlus10Lease_1IsAcquired1IsNot()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var lease1 = await uut.GetLeaseForRegion(Region.Euw, 15);
			var lease2 = await uut.GetLeaseForRegion(Region.Euw, 10);

			// Assert
			Assert.That(lease1.IsAcquired, Is.True);
			Assert.That(lease1.RetryAfter, Is.Null);
			Assert.That(lease2.IsAcquired, Is.False);
			Assert.That(lease2.RetryAfter, Is.Not.Null);
			Assert.That(lease2.RetryAfter, Is.EqualTo(TimeSpan.FromSeconds(1)));
		}

		[Test]
		public async Task GetLeaseForRegion_21AsyncRequests_20AllowedIn1Second()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var leases = new List<RequestLease>();
			for (int i = 0; i < 21; i++)
			{
				leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
			}

			// Assert
			Assert.That(leases.Count(lease => lease.IsAcquired), Is.EqualTo(20));
			Assert.That(leases.Count(lease => !lease.IsAcquired), Is.EqualTo(1));
		}

		[Test]
		public async Task GetLeaseForRegion_DeveloperRateLimitTest_Accept100In6Seconds()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20},
				{TimeSpan.FromMinutes(2), 100}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var leases = new List<RequestLease>();
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
				}
				await Task.Delay(TimeSpan.FromSeconds(1.2));
			}

			// Assert
			Assert.That(leases.Count(lease => lease.IsAcquired), Is.EqualTo(100));
		}
		
		[Test]
		public async Task GetLeaseForRegion_DeveloperRateLimitTest_Accept100In6Seconds_Decline1()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20},
				{TimeSpan.FromMinutes(2), 100}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var leases = new List<RequestLease>();
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
				}
				await Task.Delay(TimeSpan.FromSeconds(1.2));
			}

			leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));

			// Assert
			Assert.That(leases.Count(lease => lease.IsAcquired), Is.EqualTo(100));
			Assert.That(leases.Count(lease => !lease.IsAcquired), Is.EqualTo(1));
		}

		[Test]
		public async Task GetLeaseForRegion_DeveloperRateLimitTest_RetryAfter1Second()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20},
				{TimeSpan.FromMinutes(2), 100}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var leases = new List<RequestLease>();
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					leases.Add(await uut.GetLeaseForRegion(Region.Euw, 1));
				}
				if(i!=4)
					await Task.Delay(TimeSpan.FromSeconds(1.2));
			}

			var lastLease = await uut.GetLeaseForRegion(Region.Euw, 1);
			leases.Add(lastLease);

			// Assert
			Assert.That(leases.Count(lease => lease.IsAcquired), Is.EqualTo(100));
			Assert.That(leases.Count(lease => !lease.IsAcquired), Is.EqualTo(1));
			Assert.That(lastLease.RetryAfter, Is.EqualTo(TimeSpan.FromSeconds(1)));
		}

		[Test]
		public async Task GetLeaseForRegion_DeveloperRateLimitTest_RetryAfter2minutes()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20},
				{TimeSpan.FromMinutes(2), 100}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var leases = new List<RequestLease>();
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

			// Assert
			Assert.That(leases.Count(lease => lease.IsAcquired), Is.EqualTo(100));
			Assert.That(leases.Count(lease => !lease.IsAcquired), Is.EqualTo(1));
			Assert.That(lastLease.RetryAfter, Is.EqualTo(TimeSpan.FromMinutes(2)));
		}

		[Test]
		public async Task GetLeaseForRegion_DeveloperRateLimitTest_RetryAfterIDK()
		{
			// Arrange
			IRateLimiter uut = null;
			var rateLimits = new Dictionary<TimeSpan, int>
			{
				{TimeSpan.FromSeconds(1), 20},
				{TimeSpan.FromMinutes(2), 100}
			};
			uut = new ApplicationRateLimiter(rateLimits);

			// Act
			var leases = new List<RequestLease>();
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

			// Assert
			Assert.That(leases.Count(lease => lease.IsAcquired), Is.EqualTo(100));
			Assert.That(leases.Count(lease => !lease.IsAcquired), Is.EqualTo(1));
			Assert.That(lastLease.RetryAfter, Is.EqualTo(TimeSpan.FromMinutes(2)));
		}

	}
}
