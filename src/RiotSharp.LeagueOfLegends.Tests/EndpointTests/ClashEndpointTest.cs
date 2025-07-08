using System.Net;
using RiotSharp.Core.Exceptions;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Tests.Shared;
using Xunit.Abstractions;

namespace RiotSharp.LeagueOfLegends.Tests.EndpointTests
{
	[Collection("Shared fixture")]
	public class ClashEndpointTest
	{
		private static readonly Region TestRegion = Region.Euw;
		private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";
		private static readonly string FakeTeamId = "123456789"; // Random ID that should not exist
		private static readonly int TournamentId = 37501; // Tournament ID that should exist
		
		private ITestOutputHelper _testOutputHelper;
		private IClashEndpoint _clashEndpoint;

		public ClashEndpointTest(LeagueOfLegendsTextFixture fixture, ITestOutputHelper testOutputHelper)
		{
			_testOutputHelper = testOutputHelper;

			// Initialize the Clash endpoint from the LeagueOfLegends instance in the fixture
			_clashEndpoint = fixture.LeagueOfLegends.Clash
							?? throw new ArgumentNullException(nameof(fixture), "Clash endpoint cannot be null when running Tests!");
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetPlayersByPuuidAsync_ReturnsEmptyList()
		{
			
			var result = await _clashEndpoint.GetClashPlayersByPuuidAsync(TestRegion, TestPuuid);
			Assert.NotNull(result);
			Assert.True(result.Count == 0);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetClashTeamByTeamIdAsync_ThrowsError()
		{
			var exception = await Assert.ThrowsAsync<RiotSharpException>(async () =>
			{
				await _clashEndpoint.GetClashTeamByTeamIdAsync(TestRegion, FakeTeamId);
			});

			Assert.IsType<RiotSharpException>(exception);
			Assert.Equal(HttpStatusCode.NotFound, exception.HttpStatusCode);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetClashTournamentListAsync_ReturnsMaybeEmptyList()
		{
			var result = await _clashEndpoint.GetClashTournamentListAsync(TestRegion);
			Assert.NotNull(result);
			Assert.True(result.Count >= 0);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetClashTournamentByTeamAsync_ThrowsError()
		{
			var exception = await Assert.ThrowsAsync<RiotSharpException>(async () =>
			{
				await _clashEndpoint.GetClashTournamentByTeamAsync(TestRegion, FakeTeamId);
			});

			Assert.IsType<RiotSharpException>(exception);
			Assert.Equal(HttpStatusCode.NotFound, exception.HttpStatusCode);
		}

		[Fact]
		[Trait("Category", TestCategories.OnlyLocal)]
		public async Task GetClashTournamentByIdAsync_ReturnsTournament()
		{
			var result = await _clashEndpoint.GetClashTournamentByIdAsync(TestRegion, TournamentId);
			Assert.NotNull(result);
			Assert.Equal(TournamentId, result.Id);
			Assert.NotNull(result.Schedule);
			var registrationTime = result.Schedule.FirstOrDefault()?.RegistrationTime;
			Assert.True(registrationTime < DateTime.Today);
		}
	}
}
