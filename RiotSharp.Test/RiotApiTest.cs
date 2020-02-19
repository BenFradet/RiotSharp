using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Endpoints.MatchEndpoint.Enums;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiTest : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        // The maximum time range allowed is one week, otherwise a 400 error code is returned.
        private static readonly DateTime BeginTime = DateTime.Now.AddDays(-6);
        private static DateTime EndTime => DateTime.Now;



        #region Spectator Tests
        [Ignore] // Needs to be manually adjusted for testing
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetCurrentGameAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var currentGame = Api.Spectator.GetCurrentGameAsync(RiotSharp.Misc.Region.Euw, "w1_k11kGq3N2zydfKN5xc7XcGwv-4jrnJJGsuQfHJmDFVFs").Result;

                Assert.IsNotNull(currentGame);
                Assert.IsTrue(currentGame.GameId != 0);
                Assert.IsNotNull(currentGame.Participants);
                Assert.IsNotNull(currentGame.GameStartTime);
                Assert.IsNotNull(currentGame.GameQueueType);
                Assert.IsNotNull(currentGame.Observers);
                foreach (var participant in currentGame.Participants)
                {
                    Assert.IsNotNull(participant.Perks);
                    Assert.IsNotNull(participant.GameCustomizationObjects);
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var games = Api.Spectator.GetFeaturedGamesAsync(Summoner1And2Region).Result;

                Assert.IsNotNull(games);
                Assert.IsNotNull(games.GameList);
                foreach (var game in games.GameList)
                {
                    Assert.IsNotNull(game);
                    Assert.IsTrue(game.GameId != 0);
                    Assert.IsNotNull(game.Participants);
                    Assert.IsNotNull(game.GameStartTime);
                    Assert.IsNotNull(game.GameQueueType);
                    Assert.IsNotNull(game.Observers);
                }
            });
        }
        #endregion



        #region Third Party Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetThirdPartyCode_Test()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var code = Api.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Summoner3Region,
                        Summoner3Id).Result;

                    Assert.AreEqual(RiotApiTestBase.ThirdPartyCode, code);
                });
            }, "Third party code was not found for the summoner. (404)");
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetThirdPartyCodeAsync_Test()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var code = Api.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Summoner3Region,
                        Summoner3Id);

                    Assert.AreEqual(RiotApiTestBase.ThirdPartyCode, code.Result);
                });
            }, "Third party code was not found for the summoner. (404)");
        }
        #endregion
    }
}
