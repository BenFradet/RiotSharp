using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RiotSharp.Misc;
using RiotSharp.MatchEndpoint.Enums;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiTest : CommonTestBase
    {
        private static RiotApi api = RiotApi.GetDevelopmentInstance(RiotApiTestBase.apiKey);
        private static DateTime beginTime = new DateTime(2015, 01, 01);
        private static DateTime endTime { get { return DateTime.Now; } }

        #region Summoner Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerBySummonerId_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerBySummonerId(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id);

                Assert.AreEqual(RiotApiTestBase.summoner1Name, summoner.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerBySummonerIdAsync_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerBySummonerIdAsync(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id);

                Assert.AreEqual(RiotApiTestBase.summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerByAccountId_ExistingAccountId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerByAccountId(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1AccountId);

                Assert.AreEqual(RiotApiTestBase.summoner1Name, summoner.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByAccountIdAsync_ExistingAccountId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerByAccountIdAsync(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1AccountId);

                Assert.AreEqual(RiotApiTestBase.summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerByName_ExistingName_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerByName(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Name);

                Assert.AreEqual(RiotApiTestBase.summoner1Id, summoner.Id);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByNameAsync_ExistingName_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerByNameAsync(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Name);

                Assert.AreEqual(RiotApiTestBase.summoner1Id, summoner.Result.Id);
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
                var champions = api.GetChampions(RiotApiTestBase.summoner1and2Region);

                Assert.IsTrue(champions.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = api.GetChampionsAsync(RiotApiTestBase.summoner1and2Region);

                Assert.IsTrue(champions.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_FreeToPlay_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = api.GetChampions(RiotApiTestBase.summoner1and2Region, true);

                Assert.IsTrue(champions.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = api.GetChampionsAsync(RiotApiTestBase.summoner1and2Region, true);

                Assert.IsTrue(champions.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            EnsureCredibility(() =>
            {
                var champion = api.GetChampion(RiotApiTestBase.summoner1and2Region, 12);

                Assert.AreEqual(12, champion.Id);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champion = api.GetChampionAsync(RiotApiTestBase.summoner1and2Region, 12);

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
                var pages = api.GetMasteryPages(RiotApiTestBase.summonersRegion, RiotApiTestBase.summoner1Id);

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
                    api.GetMasteryPages(RiotApiTestBase.summonersRegion, RiotApiTestBase.invalidSummonerId);
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
                var pages = api.GetMasteryPagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summoner1Id);

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
                    var task = api.GetMasteryPagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.invalidSummonerId);
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
                var runes = api.GetRunePages(RiotApiTestBase.summonersRegion, RiotApiTestBase.summoner1Id);

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
                    api.GetRunePages(RiotApiTestBase.summonersRegion, RiotApiTestBase.invalidSummonerId);
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
                var runes = api.GetRunePagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summoner1Id);

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
                    var task = api.GetRunePagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.invalidSummonerId);
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
                var leagues = api.GetLeagues(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = api.GetLeaguesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds.FirstOrDefault());

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
                    api.GetLeagues(Region.na, RiotApiTestBase.unrankedSummonerId);
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
                var leagues = api.GetLeaguePositions(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguePositionsAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = api.GetLeaguePositionsAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            EnsureCredibility(() =>
            {
                var league = api.GetChallengerLeague(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

                Assert.IsTrue(league.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = api.GetChallengerLeagueAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasterLeague_Test()
        {
            EnsureCredibility(() =>
            {
                var league = api.GetMasterLeague(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

                Assert.IsTrue(league.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = api.GetMasterLeagueAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

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
                var game = api.GetMatch(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId);

                Assert.AreEqual(RiotApiTestBase.gameId, game.MatchId);
                Assert.IsNull(game.Timeline);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            EnsureCredibility(() =>
            {
                var game = api.GetMatch(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId, true);

                Assert.AreEqual(RiotApiTestBase.gameId, game.MatchId);
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
                var game = api.GetMatchAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId);

                Assert.AreEqual(RiotApiTestBase.gameId, game.Result.MatchId);
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
                var game = api.GetMatchAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId, true);

                Assert.AreEqual(RiotApiTestBase.gameId, game.Result.MatchId);
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
                var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id).Matches;

                Assert.IsTrue(matches.Count() > 0);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_ChampionIds_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id, new List<long> { RiotApiTestBase.championId }).Matches;

                Assert.IsTrue(matches.Count() > 0);
                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.championId.ToString(), 
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
                var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id, null, new List<string> { RiotApiTestBase.queue }).Matches;

                Assert.IsTrue(matches.Count() > 0);
                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.queue.ToString(), match.Queue.ToString());
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
                var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id, null, null, new List<Season> { RiotApiTestBase.season }).Matches;

                Assert.IsTrue(matches.Count() > 0);
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
                var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, null, null, null, beginTime, endTime).Matches;

                Assert.IsTrue(matches.Count() > 0);
                foreach (var match in matches)
                {
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, beginTime) >= 0);
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, endTime) <= 0);
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
                int beginIndex = 0;
                int endIndex = 32;

                var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, null, null, null, null, null, beginIndex, endIndex).Matches;

                Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id).Result.Matches;

                Assert.IsTrue(matches.Count() > 0);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_ChampionIds_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, new List<long> { RiotApiTestBase.championId }).Result.Matches;

                Assert.IsTrue(matches.Count() > 0);
                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.championId.ToString(), 
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
                var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, null, 
                    new List<string> { RiotApiTestBase.queue }).Result.Matches;

                Assert.IsTrue(matches.Count() > 0);
                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.queue.ToString(), match.Queue.ToString());
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
                var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id, null, null, 
                    new List<Season> { RiotApiTestBase.season }).Result.Matches;

                Assert.IsTrue(matches.Count() > 0);
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
                var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, null, null, null, beginTime, endTime).Result.Matches;

                Assert.IsTrue(matches.Count() > 0);
                foreach (var match in matches)
                {
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, beginTime) >= 0);
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, endTime) <= 0);
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
                int beginIndex = 0;
                int endIndex = 32;

                var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

                Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
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
                var games = api.GetRecentGames(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

                Assert.IsTrue(games.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var games = api.GetRecentGamesAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

                Assert.IsTrue(games.Result.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames_Test()
        {
            EnsureCredibility(() =>
            {
                var games = api.GetFeaturedGames(RiotApiTestBase.summoner1and2Region);

                Assert.IsNotNull(games);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var games = api.GetFeaturedGamesAsync(RiotApiTestBase.summoner1and2Region);

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
                var championMastery = api.GetChampionMastery(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1MasteryChampionId);

                Assert.AreEqual(RiotApiTestBase.summoner1Id, championMastery.PlayerId);
                Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionId, championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionLevel, championMastery.ChampionLevel);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var championMastery = api.GetChampionMasteryAsync(RiotApiTestBase.summoner1and2Region,
                    RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1MasteryChampionId).Result;

                Assert.AreEqual(RiotApiTestBase.summoner1Id, championMastery.PlayerId);
                Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionId, 
                    championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionLevel, 
                    championMastery.ChampionLevel);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionsMasteries_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = api.GetChampionMasteries(
                    RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsMasteriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = api.GetChampionMasteriesAsync(
                    RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id).Result;

                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTotalChampionMasteryScore_Test()
        {
            EnsureCredibility(() =>
            {
                var totalChampionMasteryScore = api.GetTotalChampionMasteryScore(
                    RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

                Assert.IsTrue(totalChampionMasteryScore > -1);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var totalChampionMasteryScore = api.GetTotalChampionMasteryScoreAsync(
                    RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id).Result;

                Assert.IsTrue(totalChampionMasteryScore > -1);
            });
        }
        #endregion
    }
}
