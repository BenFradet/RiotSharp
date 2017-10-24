using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.MatchEndpoint.Enums;
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
        [TestCategory("RiotApi")]
        public void GetSummonerBySummonerId_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.GetSummonerBySummonerId(Summoner1And2Region, 
                    Summoner1Id);

                Assert.AreEqual(Summoner1Name, summoner.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerBySummonerIdAsync_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.GetSummonerBySummonerIdAsync(Summoner1And2Region, 
                    Summoner1Id);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerByAccountId_ExistingAccountId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.GetSummonerByAccountId(Summoner1And2Region, 
                    Summoner1AccountId);

                Assert.AreEqual(Summoner1Name, summoner.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByAccountIdAsync_ExistingAccountId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.GetSummonerByAccountIdAsync(Summoner1And2Region, 
                    Summoner1AccountId);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerByName_ExistingName_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.GetSummonerByName(Summoner1And2Region, 
                    Summoner1Name);

                Assert.AreEqual(Summoner1Id, summoner.Id);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByNameAsync_ExistingName_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.GetSummonerByNameAsync(Summoner1And2Region, 
                    Summoner1Name);

                Assert.AreEqual(Summoner1Id, summoner.Result.Id);
            });
        }
        #endregion

        #region Champion Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = Api.GetChampions(Summoner1And2Region);

                Assert.IsTrue(champions.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = Api.GetChampionsAsync(Summoner1And2Region);

                Assert.IsTrue(champions.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_FreeToPlay_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = Api.GetChampions(Summoner1And2Region, true);

                Assert.IsTrue(champions.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = Api.GetChampionsAsync(Summoner1And2Region, true);

                Assert.IsTrue(champions.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            EnsureCredibility(() =>
            {
                var champion = Api.GetChampion(Summoner1And2Region, 12);

                Assert.AreEqual(12, champion.Id);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champion = Api.GetChampionAsync(Summoner1And2Region, 12);

                Assert.AreEqual(12, champion.Result.Id);
            });
        }
        #endregion

        #region Masteries Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_ExistingSummonerId_HasMasteryPages()
        {
            EnsureCredibility(() =>
            {
                var pages = Api.GetMasteryPages(RiotApiTestBase.SummonersRegion, Summoner1Id);

                Assert.IsTrue(pages.Count >= 1 && pages.Count <= 20);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_InvalidSummonerId_ThrowsResouceNotFound()
        {
            try
            {
                EnsureCredibility(() =>
                {
                    Api.GetMasteryPages(RiotApiTestBase.SummonersRegion, InvalidSummonerId);
                    Assert.Fail();
                });
            }
            catch (RiotSharpException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.HttpStatusCode);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_ExistingSummonerId_HasMasteryPages()
        {
            EnsureCredibility(() =>
            {
                var pages = Api.GetMasteryPagesAsync(RiotApiTestBase.SummonersRegion, Summoner1Id);

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
                    var task = Api.GetMasteryPagesAsync(RiotApiTestBase.SummonersRegion, InvalidSummonerId);
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
        [TestCategory("RiotApi")]
        public void GetRunePages_ExistingSummonerId_HasRunePages()
        {
            EnsureCredibility(() =>
            {
                var runes = Api.GetRunePages(RiotApiTestBase.SummonersRegion, Summoner1Id);

                Assert.IsTrue(runes.Count >= 0 && runes.Count <= 20);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_InvalidSummonerId_ThrowsResouceNotFound()
        {
            try
            {
                EnsureCredibility(() =>
                {
                    Api.GetRunePages(RiotApiTestBase.SummonersRegion, InvalidSummonerId);
                    Assert.Fail();
                });
            }
            catch (RiotSharpException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.HttpStatusCode);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_ExistingSummonerId_HasRunePages()
        {
            EnsureCredibility(() =>
            {
                var runes = Api.GetRunePagesAsync(RiotApiTestBase.SummonersRegion, Summoner1Id);

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
                    var task = Api.GetRunePagesAsync(RiotApiTestBase.SummonersRegion, InvalidSummonerId);
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
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.GetLeagues(RiotApiTestBase.SummonersRegion, RiotApiTestBase.SummonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.GetLeaguesAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.SummonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_ByUnrankedSummoner_Test()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    Api.GetLeagues(Region.na, RiotApiTestBase.UnrankedSummonerId);
                }
                catch (RiotSharpException e)
                {
                    // API gives 404 when valid summoner is unranked.
                    if (e.HttpStatusCode == HttpStatusCode.NotFound)
                        Assert.IsTrue(true);
                    else
                        throw e;
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeaguePositions_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.GetLeaguePositions(RiotApiTestBase.SummonersRegion, RiotApiTestBase.SummonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguePositionsAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.GetLeaguePositionsAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.SummonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.GetChallengerLeague(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.GetChallengerLeagueAsync(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasterLeague_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.GetMasterLeague(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.GetMasterLeagueAsync(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }
        #endregion

        #region Match Tests
        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            EnsureCredibility(() =>
            {
                var game = Api.GetMatch(Summoner1And2Region, RiotApiTestBase.GameId);

                Assert.AreEqual(RiotApiTestBase.GameId, game.MatchId);
                Assert.IsNull(game.Timeline);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            EnsureCredibility(() =>
            {
                var game = Api.GetMatch(Summoner1And2Region, RiotApiTestBase.GameId, true);

                Assert.AreEqual(RiotApiTestBase.GameId, game.MatchId);
                Assert.IsNotNull(game.Timeline);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithoutTimeline_Test()
        {
            EnsureCredibility(() =>
            {
                var game = Api.GetMatchAsync(Summoner1And2Region, RiotApiTestBase.GameId);

                Assert.AreEqual(RiotApiTestBase.GameId, game.Result.MatchId);
                Assert.IsNull(game.Result.Timeline);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithTimeline_Test()
        {
            EnsureCredibility(() =>
            {
                var game = Api.GetMatchAsync(Summoner1And2Region, RiotApiTestBase.GameId, true);

                Assert.AreEqual(RiotApiTestBase.GameId, game.Result.MatchId);
                Assert.IsNotNull(game.Result.Timeline);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchList(Summoner1And2Region, 
                    Summoner1Id).Matches;

                Assert.IsTrue(matches.Any());
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_ChampionIds_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchList(Summoner1And2Region, 
                    Summoner1Id, new List<long> { RiotApiTestBase.ChampionId }).Matches;

                Assert.IsTrue(matches.Any());
                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.ChampionId.ToString(), 
                        match.ChampionID.ToString());
                }
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_RankedQueues_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchList(Summoner1And2Region, 
                    Summoner1Id, null, new List<string> { RiotApiTestBase.Queue }).Matches;

                Assert.IsTrue(matches.Any());

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.Queue, match.Queue);
                }
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Seasons_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchList(Summoner1And2Region, 
                    Summoner1Id, null, null, new List<Season> { RiotApiTestBase.season }).Matches;

                Assert.IsTrue(matches.Any());

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.season.ToString(), match.Season.ToString());
                }
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_DateTimes_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchList(Summoner1And2Region,
                    Summoner1Id, null, null, null, BeginTime, EndTime).Matches;

                Assert.IsTrue(matches.Any());
                foreach (var match in matches)
                {
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, BeginTime) >= 0);
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, EndTime) <= 0);
                }
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Index_Test()
        {
            EnsureCredibility(() =>
            {
                const int beginIndex = 0;
                const int endIndex = 32;

                var matches = Api.GetMatchList(Summoner1And2Region,
                    Summoner1Id, null, null, null, null, null, beginIndex, endIndex).Matches;

                Assert.IsTrue(matches.Count <= endIndex - beginIndex);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchListAsync(Summoner1And2Region, 
                    Summoner1Id).Result.Matches;

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
                var matches = Api.GetMatchListAsync(Summoner1And2Region,
                    Summoner1Id, new List<long> { RiotApiTestBase.ChampionId }).Result.Matches;

                Assert.IsTrue(matches.Any());

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
        public void GetMatchListAsync_RankedQueues_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.GetMatchListAsync(Summoner1And2Region,
                    Summoner1Id, null, 
                    new List<string> { RiotApiTestBase.Queue }).Result.Matches;

                Assert.IsTrue(matches.Any());

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
                var matches = Api.GetMatchListAsync(Summoner1And2Region, 
                    Summoner1Id, null, null, 
                    new List<Season> { RiotApiTestBase.season }).Result.Matches;

                Assert.IsTrue(matches.Any());

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.season.ToString(), match.Season.ToString());
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
                var matches = Api.GetMatchListAsync(Summoner1And2Region,
                    Summoner1Id, null, null, null, BeginTime, EndTime).Result.Matches;

                Assert.IsTrue(matches.Any());

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

                var matches = Api.GetMatchListAsync(Summoner1And2Region,
                    Summoner1Id, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

                Assert.IsTrue(matches.Count <= endIndex - beginIndex);
            });
        }
        #endregion

        #region Spectator Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            EnsureCredibility(() =>
            {
                var games = Api.GetRecentGames(Summoner1And2Region, Summoner1Id);

                Assert.IsTrue(games.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var games = Api.GetRecentGamesAsync(Summoner1And2Region, Summoner1Id);

                Assert.IsTrue(games.Result.Any());
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames_Test()
        {
            EnsureCredibility(() =>
            {
                var games = Api.GetFeaturedGames(Summoner1And2Region);

                Assert.IsNotNull(games);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var games = Api.GetFeaturedGamesAsync(Summoner1And2Region);

                Assert.IsNotNull(games.Result);
            });
        }
        #endregion

        #region Champion Mastery Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMastery_Test()
        {
            EnsureCredibility(() =>
            {
                var championMastery = Api.GetChampionMastery(Summoner1And2Region,
                    Summoner1Id, RiotApiTestBase.Summoner1MasteryChampionId);

                Assert.AreEqual(Summoner1Id, championMastery.PlayerId);
                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionId, championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionLevel, championMastery.ChampionLevel);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var championMastery = Api.GetChampionMasteryAsync(Summoner1And2Region,
                    Summoner1Id, RiotApiTestBase.Summoner1MasteryChampionId).Result;

                Assert.AreEqual(Summoner1Id, championMastery.PlayerId);
                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionId, 
                    championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionLevel, 
                    championMastery.ChampionLevel);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionsMasteries_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = Api.GetChampionMasteries(
                    Summoner1And2Region, Summoner1Id);

                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.Summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsMasteriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = Api.GetChampionMasteriesAsync(
                    Summoner1And2Region, Summoner1Id).Result;

                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.Summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTotalChampionMasteryScore_Test()
        {
            EnsureCredibility(() =>
            {
                var totalChampionMasteryScore = Api.GetTotalChampionMasteryScore(
                    Summoner1And2Region, Summoner1Id);

                Assert.IsTrue(totalChampionMasteryScore > -1);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var totalChampionMasteryScore = Api.GetTotalChampionMasteryScoreAsync(
                    Summoner1And2Region, Summoner1Id).Result;

                Assert.IsTrue(totalChampionMasteryScore > -1);
            });
        }
        #endregion
    }
}
