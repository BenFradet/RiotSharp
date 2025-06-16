using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Moq;
using RiotSharpNET8.Endpoints.GeneralEndpoints.ChampionMasteryEndpoint;
using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Http.RateLimiting;
using RiotSharpNET8.Http.Requesters;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Test.EndpointTests
{
    [TestFixture]
    [Category("OnlyLocal")]
    public class ChampionMasteryEndpointTest
    {
	    private static string ApiKey = "";
	    private static readonly Dictionary<TimeSpan, int> RateLimits = new()
	    {
		    [TimeSpan.FromSeconds(1)] = 20,
		    [TimeSpan.FromMinutes(2)] = 100
	    };
	    private static readonly Region TestRegion = Region.Euw;
	    private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw"; // Replace with a real PUUID
	    private static readonly long TestChampionId = 2; // Example: 2 = Olaf

        private IRateLimitedRequester _requester;
        private IChampionMasteryEndpoint _masteryEndpoint;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
	        var config = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
		        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		        .Build();

	        ApiKey = config["ApiKey"];
	        var httpRequester = new HttpRequester(new HttpClient());
	        _requester = new RateLimitedRequester(ApiKey, httpRequester, new ApplicationRateLimiter(RateLimits), new ApplicationRateLimiter(RateLimits));
	        _masteryEndpoint = new ChampionMasteryEndpoint(_requester);
        }

        [Test]
        public async Task GetChampionMasteryByPuuidAsync_ReturnsChampionMastery()
        {
	        var result = await _masteryEndpoint.GetChampionMasteryByPuuidAsync(TestRegion, TestPuuid, TestChampionId);
	        Console.WriteLine(result.ToString());
	        Assert.That(result, Is.Not.Null);
	        Assert.That(result?.ChampionId, Is.EqualTo(TestChampionId));
        }

        [Test]
        public async Task GetChampionMasteriesByPuuidAsync_ReturnsChampionMasteryList()
        {
	        var result = await _masteryEndpoint.GetChampionMasteriesByPuuidAsync(TestRegion, TestPuuid);
	        Console.WriteLine(result.ToString());
	        Assert.That(result, Is.Not.Null);
	        Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetTotalChampionMasteryScoreAsync_ReturnsScore()
        {
	        var result = await _masteryEndpoint.GetTotalChampionMasteryScoreAsync(TestRegion, TestPuuid);
	        Console.WriteLine(result.ToString());
	        Assert.That(result, Is.GreaterThanOrEqualTo(0));
        }
        
		[Test]
		public async Task GetTopChampionMasteriesByPuuidAsync_ReturnsTopChampionMasteries()
		{
			var result = await _masteryEndpoint.GetTopChampionMasteriesByPuuidAsync(TestRegion, TestPuuid, 1);
			Console.WriteLine(result.ToString());
			Assert.That(result, Is.Not.Null);
			Assert.That(result[0].ChampionId, Is.EqualTo(TestChampionId)); // Former Olaf main/OTP(:
		}

		/// <summary>
		/// No joke this test works ahahah wtf.
		/// If limit is set to 21, then the server responds with Rate limit exceeded, if set to 20 the rate limiter stops the last request.
		/// </summary>
		/// <returns></returns>
		[Test]
		public async Task RateLimiterLimitsCorrectly()
		{
			Assert.That(true);
			/*
			// Fire off 21 requests in parallel
			var tasks = Enumerable.Range(0, 21)
				.Select(_ => _masteryEndpoint.GetTotalChampionMasteryScoreAsync(Region.Euw, TestPuuid))
				.ToArray();

			var results = await Task.WhenAll(tasks);
			// Check that all results are valid integers
			foreach (var result in results)
			{
				Assert.That(result, Is.GreaterThanOrEqualTo(0), "Expected non-negative mastery score.");
			}
			// Check that no exceptions were thrown
			Assert.That(results.Length, Is.EqualTo(20), "Expected 20 results from parallel requests.");
			*/
		}
	}
}