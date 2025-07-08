using Microsoft.Extensions.Configuration;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Http.RateLimiting;
using RiotSharp.Core.Http.Requesters;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint;
using RiotSharp.LeagueOfLegends.Endpoints.EndpointInterfaces;
using RiotSharp.LeagueOfLegends.Tests;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using Xunit.Abstractions;

namespace RiotSharpNET8.Test.EndpointTests
{
	//[Collection("Sequential")]
	[Collection("Shared fixture")]
    public class ChampionMasteryEndpointTest
    {
        private static readonly Region TestRegion = Region.Euw;
        private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";
        private static readonly long TestChampionId = 2;

        private IChampionMasteryEndpoint _masteryEndpoint;
        private ITestOutputHelper _testOutputHelper;

        public ChampionMasteryEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
        {
			_testOutputHelper = testOutputHelper;

            _masteryEndpoint = fixture.LeagueOfLegends.ChampionMastery 
                               ?? throw new ArgumentNullException(nameof(fixture), "Champion rotation endpoint cannot be null when running Tests!");

        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChampionMasteryByPuuidAsync_ReturnsChampionMastery()
        {
	        try
	        {
		        ChampionMastery? result = await _masteryEndpoint.GetChampionMasteryByPuuidAsync(TestRegion, TestPuuid, TestChampionId);
		        _testOutputHelper.WriteLine($"Result: {result}");
        
		        Assert.NotNull(result);
		        Assert.Equal(TestChampionId, result?.ChampionId);
	        }
	        catch (Exception ex)
	        {
		        _testOutputHelper.WriteLine($"Exception occurred: {ex.GetType().Name} - {ex.Message}");
		        _testOutputHelper.WriteLine(ex.StackTrace);
		        throw; // Re-throw to ensure test still fails
	        }
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetChampionMasteriesByPuuidAsync_ReturnsChampionMasteryList()
        {
            var result = await _masteryEndpoint.GetChampionMasteriesByPuuidAsync(TestRegion, TestPuuid);
            //_testOutputHelper.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetTotalChampionMasteryScoreAsync_ReturnsScore()
        {
            var result = await _masteryEndpoint.GetTotalChampionMasteryScoreAsync(TestRegion, TestPuuid);
            //_testOutputHelper.WriteLine(result.ToString());
            Assert.True(result >= 0);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetTopChampionMasteriesByPuuidAsync_ReturnsTopChampionMasteries()
        {
            var result = await _masteryEndpoint.GetTopChampionMasteriesByPuuidAsync(TestRegion, TestPuuid, 1);
            //_testOutputHelper.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.Equal(TestChampionId, result[0].ChampionId);
        }

        [Fact(Skip = "Rate limiter test not implemented; uncomment when verifying behavior")]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task RateLimiterLimitsCorrectly()
        {
            Assert.True(true);
            /*
            var tasks = Enumerable.Range(0, 21)
                .Select(_ => _masteryEndpoint.GetTotalChampionMasteryScoreAsync(Region.Euw, TestPuuid))
                .ToArray();

            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                Assert.True(result >= 0, "Expected non-negative mastery score.");
            }

            Assert.Equal(20, results.Length);
            */
        }
    }
}
