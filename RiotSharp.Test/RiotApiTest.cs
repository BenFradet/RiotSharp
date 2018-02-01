using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiTest : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);
        private static readonly DateTime BeginTime = new DateTime(2015, 01, 01);
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
        #endregion

        #region Champion Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = Api.Champion.GetChampionsAsync(Summoner1And2Region);

                Assert.IsTrue(champions.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = Api.Champion.GetChampionsAsync(Summoner1And2Region, true);

                Assert.IsTrue(champions.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champion = Api.Champion.GetChampionAsync(Summoner1And2Region, 12);

                Assert.AreEqual(12, champion.Result.Id);
            });
        }
        #endregion

        #region Masteries Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_ExistingSummonerId_HasMasteryPages()
        {
            EnsureCredibility(() =>
            {
                var pages = Api.Masteries.GetMasteryPagesAsync(RiotApiTestBase.SummonersRegion, Summoner1Id);

                Assert.IsTrue(pages.Result.Count >= 1 && pages.Result.Count <= 20);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_InvalidSummonerId_ThrowsResouceNotFound()
        {
            try
            {
                EnsureCredibility(() =>
                {
                    var task = Api.Masteries.GetMasteryPagesAsync(RiotApiTestBase.SummonersRegion, InvalidSummonerId);
                    task.Wait();
                    Assert.Fail();
                });
            }
            catch (RiotSharpException exception)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, exception.HttpStatusCode);  
            }
        }
        #endregion

        #region Runes Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_ExistingSummonerId_HasRunePages()
        {
            EnsureCredibility(() =>
            {
                var runes = Api.Runes.GetRunePagesAsync(RiotApiTestBase.SummonersRegion, Summoner1Id);

                Assert.IsTrue(runes.Result.Count >= 0 && runes.Result.Count <= 20);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_InvalidSummonerId_ThrowsResouceNotFound()
        {
            try
            {
                EnsureCredibility(() =>
                {
                    var task = Api.Runes.GetRunePagesAsync(RiotApiTestBase.SummonersRegion, InvalidSummonerId);
                    task.Wait();
                    Assert.Fail();
                });
            }
            catch (RiotSharpException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.HttpStatusCode);
            }
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
        public void GetMatchAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var match = Api.Match.GetMatchAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.GameId).Result;

                Assert.AreEqual(RiotApiTestBase.GameId, match.GameId);
                Assert.IsNotNull(match.ParticipantIdentities);
                Assert.IsNotNull(match.Participants);
                Assert.IsNotNull(match.Teams);
            });
        }

        [Ignore]
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

        [Ignore]
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

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Queues_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                    RiotApiTestBase.Summoner1AccountId, null, 
                    new List<int> { RiotApiTestBase.QueueId }).Result.Matches;

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.Queue, match.Queue);
                }
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Seasons_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion, 
                    RiotApiTestBase.Summoner1AccountId, null, null, 
                    new List<Season> { RiotApiTestBase.Season }).Result.Matches;

                Assert.IsTrue(matches.Any());

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.Season.ToString(), match.Season.ToString());
                }
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_DateTimes_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                    RiotApiTestBase.Summoner1AccountId, null, null, null, BeginTime, EndTime).Result.Matches;

                foreach (var match in matches)
                {
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, BeginTime) >= 0);
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, EndTime) <= 0);
                }
            });
        }

        [Ignore]
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

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var games = Api.Spectator.GetFeaturedGamesAsync(Summoner1And2Region);

                Assert.IsNotNull(games.Result);
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

                Assert.AreEqual(Summoner1Id, championMastery.PlayerId);
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
            EnsureCredibility(() =>
            {
                var code = Api.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Summoner1And2Region,
                    Summoner1Id).Result;

                Assert.AreEqual(RiotApiTestBase.ThirdPartyCode, code);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetThirdPartyCodeAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var code = Api.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Summoner1And2Region,
                    Summoner1Id);

                Assert.AreEqual(RiotApiTestBase.ThirdPartyCode, code.Result);
            });
        }
        #endregion
    }
}
