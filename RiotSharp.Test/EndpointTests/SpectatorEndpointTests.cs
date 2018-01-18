using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RiotSharp.Endpoints.SpectatorEndpoint;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class SpectatorEndpointTests
    {
        private Mock<IRateLimitedRequester> _requester;
        private CurrentGame _currentGameResponse;
        private FeaturedGames _featuredGamesResponse;
        private IRiotApi _riotApi;

        [TestInitialize]
        public void Initialize()
        {
            _requester = new Mock<IRateLimitedRequester>();

            _currentGameResponse = new CurrentGame
            {
                GameId = 1,
                GameLength = 60,
                GameMode = "GameMode",
                GameQueueType = "Normal Draft",
                GameType = GameType.MatchedGame,
                MapType = MapType.SummonersRift,
                GameStartTime = DateTime.Today,
                Platform = Platform.EUW1
            };

            _featuredGamesResponse = new FeaturedGames
            {
                GameList = new List<CurrentGame>
                {
                    _currentGameResponse
                },
                ClientRefreshInterval = 30
            };
            _riotApi = new RiotApi(_requester.Object);
        }

        [TestMethod]
        public async Task GetCurrentGameAsync_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(JsonConvert.SerializeObject(_currentGameResponse));
            var currentGame = await _riotApi.Spectator.GetCurrentGameAsync(Region.Europe, 1);
            Assert.AreEqual(1, currentGame.GameId);
        }

        [TestMethod]
        public async Task GetFeaturedGamesAsync_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(JsonConvert.SerializeObject(_featuredGamesResponse));
            var featuredGames = await _riotApi.Spectator.GetFeaturedGamesAsync(Region.Europe);
            Assert.AreEqual(1, featuredGames.GameList.First().GameId);
        }
    }
}