using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.LeagueEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using Xunit.Abstractions;

namespace RiotSharp.LeagueOfLegends.Tests.EndpointTests
{
	[Collection("Shared fixture")]
	public class LeagueEndpointTest
	{
		private static readonly Region TestRegion = Region.Euw;
		private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";
		private static readonly string LeagueId = "fa09d37f-f773-3aea-a2dc-df9750ee3933";

		private ILeagueEndpoint _leagueEndpoint;
		private ITestOutputHelper _testOutputHelper;

		public LeagueEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
		{
			_testOutputHelper = testOutputHelper;

			_leagueEndpoint = fixture.LeagueOfLegends.League 
			                   ?? throw new ArgumentNullException(nameof(fixture), "League endpoint cannot be null when running Tests!");

		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetChallengerLeagueAsync_RankedSolo5x5_ReturnsValid()
		{
			var result = await _leagueEndpoint.GetChallengerLeagueAsync(TestRegion, Queue.RankedSolo5x5);

			Assert.NotNull(result);
			Assert.Equal(Queue.RankedSolo5x5, result.Queue);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetChallengerLeagueAsync_RankedSolo5x5_NotNull()
		{
			var result = await _leagueEndpoint.GetChallengerLeagueAsync(TestRegion, Queue.RankedSolo5x5);
			Assert.NotNull(result);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetLeagueGrandmastersByQueueAsync_RankedSolo5x5_NotNull()
		{
			var result = await _leagueEndpoint.GetLeagueGrandmastersByQueueAsync(TestRegion, Queue.RankedSolo5x5);
			Assert.NotNull(result);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetMasterLeagueAsync_RankedSolo5x5_NotNull()
		{
			var result = await _leagueEndpoint.GetMasterLeagueAsync(TestRegion, Queue.RankedSolo5x5);
			Assert.NotNull(result);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetLeagueEntriesByPuuidAsync_ValidPuuid_NotNull()
		{
			var result = await _leagueEndpoint.GetLeagueEntriesByPuuidAsync(TestRegion, TestPuuid);
			Assert.NotNull(result);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetLeagueEntriesAsync_ValidParams_NotNull()
		{
			var result = await _leagueEndpoint.GetLeagueEntriesAsync(TestRegion, Division.I, Tier.Diamond, Queue.RankedSolo5x5, 1);
			Assert.NotNull(result);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetLeagueByLeagueIdAsync_ValidLeagueId_NotNull()
		{
			var result = await _leagueEndpoint.GetLeagueByLeagueIdAsync(TestRegion, LeagueId);
			Assert.NotNull(result);
		}
	}
}
