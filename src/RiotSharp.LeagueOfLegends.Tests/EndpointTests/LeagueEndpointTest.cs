using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using Xunit.Abstractions;

namespace RiotSharp.LeagueOfLegends.Tests.EndpointTests
{
	[Collection("Shared fixture")]
	public class LeagueEndpointTest
	{
		private static readonly Region TestRegion = Region.Euw;
		private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";

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
	}
}
