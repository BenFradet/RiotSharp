using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using Xunit.Abstractions;

namespace RiotSharp.LeagueOfLegends.Tests.EndpointTests
{
	[Collection("Shared fixture")]
	public class ChampionRotationEndpointTest
	{
		private static readonly Region TestRegion = Region.Euw;

		private IChampionRotationEndpoint _championRotation;
		private ITestOutputHelper _testOutputHelper;

		public ChampionRotationEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
		{
			_testOutputHelper = testOutputHelper;
			_championRotation = fixture.LeagueOfLegends.ChampionRotation 
			                    ?? throw new ArgumentNullException(nameof(fixture), "Champion rotation endpoint cannot be null when running Tests!");
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetChampionMasteriesByPuuidAsync_ReturnsChampionMasteryList()
		{
			var result = await _championRotation.GetChampionRotationAsync(TestRegion);
			//_testOutputHelper.WriteLine(result.ToString());
			Assert.NotNull(result);
			Assert.NotNull(result.FreeChampionIds);
			Assert.NotEmpty(result.FreeChampionIds);
			Assert.NotNull(result.FreeChampionIdsForNewPlayers);
			Assert.NotEmpty(result.FreeChampionIdsForNewPlayers);
			Assert.True(result.MaxNewPlayerLevel > 0, "MaxNewPlayerLevel should be greater than 0");
		}

	}
}
