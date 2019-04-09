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

        #region Summoner Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerBySummonerIdAsync_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.Summoner.GetSummonerBySummonerIdAsync(Summoner1And2Region, 
                    Summoner1Id);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByAccountIdAsync_ExistingAccountId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.Summoner.GetSummonerByAccountIdAsync(Summoner1And2Region, 
                    Summoner1AccountId);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByNameAsync_ExistingName_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.Summoner.GetSummonerByNameAsync(Summoner1And2Region, 
                    Summoner1Name);

                Assert.AreEqual(Summoner1Id, summoner.Result.Id);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerBySummonerPuuidAsync_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.Summoner.GetSummonerByPuuidAsync(Summoner1And2Region,
                    Summoner1Puuid);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }
        #endregion

        #region Champion Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionRotationAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var championRotation = Api.Champion.GetChampionRotationAsync(Summoner1And2Region).Result;

                Assert.IsTrue(championRotation.FreeChampionIds.Count() == 14);
                Assert.IsTrue(championRotation.FreeChampionIdsForNewPlayers.Count() == 10);
                Assert.IsTrue(championRotation.MaxNewPlayerLevel > 0);
            });
        }
        #endregion

        #region League Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguePositionsAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.League.GetLeaguePositionsAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.SummonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.League.GetChallengerLeagueAsync(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.League.GetMasterLeagueAsync(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }
        #endregion

        #region Match Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_RunesMasteries_Test()
        {
            EnsureCredibility(() =>
            {
                var match = Api.Match.GetMatchAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.RunesMasteriesGameId).Result;

                Assert.AreEqual(RiotApiTestBase.RunesMasteriesGameId, match.GameId);
                Assert.IsNotNull(match.ParticipantIdentities);
                Assert.IsNotNull(match.Participants);
                Assert.IsNotNull(match.Teams);
                foreach (var participant in match.Participants)
                {
                    Assert.IsNotNull(participant.Runes);
                    Assert.IsNotNull(participant.Masteries);
                    foreach(var rune in participant.Runes)
                    {
                        Assert.IsTrue(rune.RuneId != 0);
                        Assert.IsTrue(rune.Rank != 0);
                    }
                    foreach (var mastery in participant.Masteries)
                    {
                        Assert.IsTrue(mastery.MasteryId != 0);
                        Assert.IsTrue(mastery.Rank != 0);
                    }
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_Perks_Test()
        {
            EnsureCredibility(() =>
            {
                var match = Api.Match.GetMatchAsync(RiotSharp.Misc.Region.Euw, RiotApiTestBase.PerksGameId).Result;

                Assert.AreEqual(RiotApiTestBase.PerksGameId, match.GameId);
                Assert.IsNotNull(match.ParticipantIdentities);
                Assert.IsNotNull(match.Participants);
                Assert.IsNotNull(match.Teams);
                foreach(var participant in match.Participants)
                {
                    Assert.IsTrue(participant.Stats.Perk0 != 0);
                    Assert.IsTrue(participant.Stats.Perk1 != 0);
                    Assert.IsTrue(participant.Stats.Perk2 != 0);
                    Assert.IsTrue(participant.Stats.Perk3 != 0);
                    Assert.IsTrue(participant.Stats.Perk4 != 0);
                    Assert.IsTrue(participant.Stats.Perk5 != 0);
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchTimelineAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matchTimeline = Api.Match.GetMatchTimelineAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.GameId).Result;

                Assert.IsNotNull(matchTimeline.Frames);
                Assert.IsTrue(matchTimeline.Frames.First().Timestamp == TimeSpan.FromMilliseconds(144));
                Assert.IsTrue(matchTimeline.FrameInterval == TimeSpan.FromMilliseconds(60000));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion, 
                    RiotApiTestBase.Summoner1AccountId).Result.Matches;

                Assert.IsTrue(matches.Any());
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_ChampionIds_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                    RiotApiTestBase.Summoner1AccountId, new List<int> { RiotApiTestBase.ChampionId }).Result.Matches;

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.ChampionId.ToString(), 
                        match.ChampionID.ToString());
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Queues_Test()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                        RiotApiTestBase.AccountIds.First(), null,
                        new List<int> { RiotApiTestBase.QueueId }).Result.Matches;

                    foreach (var match in matches)
                    {
                        Assert.AreEqual(RiotApiTestBase.QueueId, match.Queue);
                    }
                });
            }, "No Matches found fot the test summoner (404).");
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Seasons_Test()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var matches = Api.Match.GetMatchListAsync(Summoner3Region,
                        Summoner3AccountId, null, null,
                        new List<Season> {}).Result.Matches;

                    Assert.IsTrue(matches.Any());

                    foreach (var match in matches)
                    {
                        Assert.AreEqual(Season.Season2018.ToString(), match.Season.ToString());
                    }
                });
            }, "No Matches found fot the test summoner (404).");
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_DateTimes_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                    RiotApiTestBase.AccountIds.First(), null, null, null, BeginTime, EndTime).Result.Matches;

                foreach (var match in matches)
                {
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, BeginTime) >= 0);
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, EndTime) <= 0);
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Index_Test()
        {
            EnsureCredibility(() =>
            {
                const int beginIndex = 0;
                const int endIndex = 32;

                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                    RiotApiTestBase.Summoner1AccountId, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

                Assert.IsTrue(matches.Count <= endIndex - beginIndex);
            });
        }
        #endregion

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
                foreach(var participant in currentGame.Participants)
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
                foreach(var game in games.GameList)
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

        #region Champion Mastery Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var championMastery = Api.ChampionMastery.GetChampionMasteryAsync(Summoner1And2Region,
                    Summoner1Id, RiotApiTestBase.Summoner1MasteryChampionId).Result;

                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionId, 
                    championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionLevel, 
                    championMastery.ChampionLevel);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsMasteriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = Api.ChampionMastery.GetChampionMasteriesAsync(
                    Summoner1And2Region, Summoner1Id).Result;

                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.Summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var totalChampionMasteryScore = Api.ChampionMastery.GetTotalChampionMasteryScoreAsync(
                    Summoner1And2Region, Summoner1Id).Result;

                Assert.IsTrue(totalChampionMasteryScore > -1);
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
