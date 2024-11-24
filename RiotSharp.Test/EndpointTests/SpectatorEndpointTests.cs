using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RiotSharpNET8;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.SpectatorEndpoint;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class SpectatorEndpointTests
    {
        private Mock<IRiotRateLimitedRequester> _rateLimitedRequester;
        private Mock<IRequester> _requester;
        private CurrentGame _currentGameResponse;
        private FeaturedGame _featureGameResponse;
        private FeaturedGames _featuredGamesResponse;
        private IRiotApi _riotApi;

        [TestInitialize]
        public void Initialize()
        {
            _rateLimitedRequester = new Mock<IRiotRateLimitedRequester>();
            _requester = new Mock<IRequester>();
            var staticEndpointProvider = new Mock<IStaticEndpointProvider>();
            _currentGameResponse = new CurrentGame
            {
                GameId = 1,
                GameLength = TimeSpan.FromSeconds(60),
                GameMode = "GameMode",
                GameQueueType = "Normal Draft",
                GameType = GameType.MatchedGame,
                MapType = MapType.SummonersRift,
                GameStartTime = DateTime.Today,
                Platform = Platform.EUW1
            };
            _featureGameResponse = new FeaturedGame
            {
                GameId = 1,
                GameLength = TimeSpan.FromSeconds(60),
                GameMode = "GameMode",
                GameQueueType = "Normal Draft",
                GameType = GameType.MatchedGame,
                MapType = MapType.SummonersRift,
                //GameStartTime = DateTime.Today,
                Platform = Platform.EUW1
            };

            _featuredGamesResponse = new FeaturedGames
            {
                GameList = new List<FeaturedGame>
                {
                    _featureGameResponse
                },
                ClientRefreshInterval = 30
            };
            _riotApi = new RiotApi(_rateLimitedRequester.Object, _requester.Object, staticEndpointProvider.Object);
        }

        [TestMethod]
        [Ignore] // TODO: out-of-date.
        public async Task GetCurrentGameAsync_GetsTheCurrentGameBySummonerIDAsync_ReturnCurrentGameOfTheSummoner()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(JsonConvert.SerializeObject(_currentGameResponse));
            var currentGame = await _riotApi.Spectator.GetCurrentGameAsync(Region.Europe, "summonerId");
            Assert.AreEqual(1, currentGame.GameId);
        }

        [TestMethod]
        [Ignore] // TODO: out-of-date.
        public async Task GetCurrentGameAsync_GetsTheFeaturedGamesByRegionAsync_ReturnFeaturedGamesForTheRegion()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(JsonConvert.SerializeObject(_featuredGamesResponse));
            var featuredGames = await _riotApi.Spectator.GetFeaturedGamesAsync(Region.Europe);
            Assert.AreEqual(1, featuredGames.GameList.First().GameId);
        }
    }
}