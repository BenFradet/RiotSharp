using System.Net;
using RiotSharp.Core.Misc;
using Xunit.Abstractions;
using RiotSharp.Account.Endpoints;
using RiotSharp.Account.Tests.Shared;
using RiotSharp.Core.Exceptions;

namespace RiotSharp.Account.Tests.EndpointTests
{
	[Collection("Shared fixture")]
    public class AccountEndpointTest
    {
        private static readonly Region TestRegion = Region.Europe; // could be asia, americas or esports
		private static readonly string TestPuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJwVbEZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";
		private static readonly string FakePuuid = "mM9tG5eORZWYqLxYhKhtW5udauLToo7n90UiMPcUJw83EZhIoqEhUwO24EhtElhscoMzau8rKV0kjw";
		private static readonly string GameName = "AZZEBJ0RNEN";
		private static readonly string TagLine = "EUW";

        private ITestOutputHelper _testOutputHelper;
        private IAccountEndpoint _accountEndpoint;

        public AccountEndpointTest(AccountTextFixture fixture, ITestOutputHelper testOutputHelper)
        {
			_testOutputHelper = testOutputHelper;
			_accountEndpoint = fixture.RiotAccount.Account ?? throw new ArgumentNullException(nameof(fixture), "Account endpoint cannot be null when running Tests!");
		}

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetAccountByPuuid()
        {
			// Act
			var accountInfo = await _accountEndpoint.GetAccountByPuuidAsync(TestRegion, TestPuuid);
			// Assert
			Assert.NotNull(accountInfo);
            Assert.IsType<Endpoints.Account>(accountInfo);
			Assert.Equal(TestPuuid, accountInfo.Puuid);
            Assert.Equal(TagLine, accountInfo.TagLine);
			Assert.Equal(GameName, accountInfo.GameName);
			_testOutputHelper.WriteLine($"RiotAccount Info: {accountInfo}");
		}

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetAccountByPuuid_EsportsThrowsFailure()
        {
			var exception = await Assert.ThrowsAsync<RiotSharpException>(async () =>
			{
				await _accountEndpoint.GetAccountByPuuidAsync(Region.Esports, TestPuuid);
			});

			Assert.IsType<RiotSharpException>(exception);
			Assert.Equal(HttpStatusCode.NotFound, exception.HttpStatusCode);
		}

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetAccountByRiotIdAsync()
        {
			// Act
	        var accountInfo = await _accountEndpoint.GetAccountByRiotIdAsync(TestRegion, GameName, TagLine);
	        // Assert
	        Assert.NotNull(accountInfo);
	        Assert.IsType<Endpoints.Account>(accountInfo);
	        Assert.Equal(TestPuuid, accountInfo.Puuid);
	        Assert.Equal(TagLine, accountInfo.TagLine);
	        Assert.Equal(GameName, accountInfo.GameName);
	        _testOutputHelper.WriteLine($"RiotAccount Info: {accountInfo}");
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetAccountByRiotIdAsync_EsportsThrowsFailure()
        {
	        var exception = await Assert.ThrowsAsync<RiotSharpException>(async () =>
	        {
		        await _accountEndpoint.GetAccountByRiotIdAsync(Region.Esports, GameName, TagLine);
	        });

			Assert.IsType<RiotSharpException>(exception);
            Assert.Equal(HttpStatusCode.NotFound, exception.HttpStatusCode);
		}


        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetActiveShardByPuuidAsync()
        {
			var activeShard = await _accountEndpoint.GetActiveShardByPuuidAsync(TestRegion, TestPuuid, Game.LoR);

			Assert.NotNull(activeShard);
			Assert.IsType<Endpoints.ActiveShardDto>(activeShard);
			Assert.Equal(TestPuuid, activeShard.Puuid);
			Assert.Equal(Game.LoR, activeShard.Game);
			Assert.Equal("europe", activeShard.ActiveShard);
			// For real the inconsistencies in the API is crazy. In LoR its Europe, in Valorant its eu

			_testOutputHelper.WriteLine($"RiotAccount Info: {activeShard}");
		}
		
        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetActiveShardByPuuidAsync_NonexistingPlayerThrowsBadRequest()
        {
	        var exception = await Assert.ThrowsAsync<RiotSharpException>(async () =>
	        {
		        await _accountEndpoint.GetActiveRegionByPuuidAsync(TestRegion, FakePuuid, Game.LoL);
	        });

	        Assert.IsType<RiotSharpException>(exception);
	        Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
        }

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetActiveRegionByPuuidAsync()
        {
			var activeRegion = await _accountEndpoint.GetActiveRegionByPuuidAsync(TestRegion, TestPuuid, Game.LoL);

			Assert.NotNull(activeRegion);
			Assert.IsType<Endpoints.ActiveRegion>(activeRegion);
			Assert.Equal(TestPuuid, activeRegion.Puuid);
			Assert.Equal(Game.LoL, activeRegion.Game);
			Assert.Equal("euw1", activeRegion.Region);
		}

        [Fact]
        [Trait("Category", TestCategories.OnlyLocal)]
        public async Task GetActiveRegionByPuuidAsync_NonexistingPlayerThrowsBadRequest()
        {
	        var exception = await Assert.ThrowsAsync<RiotSharpException>(async () =>
	        {
		        await _accountEndpoint.GetActiveRegionByPuuidAsync(TestRegion, FakePuuid, Game.LoL);
	        });

	        Assert.IsType<RiotSharpException>(exception);
	        Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
        }
	}
}
