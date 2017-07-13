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

        #region Summoner-V3 Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerBySummonerId_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = api.GetSummonerBySummonerId(RiotApiTestBase.summoner1and2Region, 
                    RiotApiTestBase.summoner1Id);

                Assert.AreEqual(summoner.Name, RiotApiTestBase.summoner1Name);
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

                Assert.AreEqual(summoner.Result.Name, RiotApiTestBase.summoner1Name);
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

                Assert.AreEqual(summoner.Name, RiotApiTestBase.summoner1Name);
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

                Assert.AreEqual(summoner.Result.Name, RiotApiTestBase.summoner1Name);
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

                Assert.AreEqual(summoner.Id, RiotApiTestBase.summoner1Id);
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

                Assert.AreEqual(summoner.Result.Id, RiotApiTestBase.summoner1Id);
            });
        }
        #endregion

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            EnsureCredibility(() =>
            {
                var champions = api.GetChampions(RiotApiTestBase.summoner1and2Region);

                Assert.IsNotNull(champions);
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

                Assert.IsNotNull(champions.Result);
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

                Assert.IsNotNull(champions);
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

                Assert.IsNotNull(champions.Result);
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

                Assert.IsNotNull(champion);
                Assert.AreEqual(champion.Id, 12);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champion = api.GetChampionAsync(RiotApiTestBase.summoner1and2Region, 12);

                Assert.IsNotNull(champion.Result);
                Assert.AreEqual(champion.Result.Id, 12);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_ExistingSummonerId_HasMasteryPages()
        {
            EnsureCredibility(() =>
            {
                var pages = api.GetMasteryPages(RiotApiTestBase.summonersRegion, RiotApiTestBase.summoner1Id);

                Assert.IsNotNull(pages);
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
                Assert.AreEqual(e.HttpStatusCode, HttpStatusCode.NotFound);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_ExistingSummonerId_HasMasteryPages()
        {
            EnsureCredibility(() =>
            {
                var pages = api.GetMasteryPagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summoner1Id);

                Assert.IsNotNull(pages.Result);
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
                Assert.AreEqual(exception.HttpStatusCode, HttpStatusCode.NotFound);  
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            EnsureCredibility(() =>
            {
                var runes = api.GetRunePages(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

                Assert.IsNotNull(runes);
                Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), runes.Count);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var runes = api.GetRunePagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

                Assert.IsNotNull(runes.Result);
                Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), 
                    runes.Result.Count);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = api.GetLeagues(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

                Assert.IsNotNull(leagues);
                Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), leagues.Count);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = api.GetLeaguesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

                Assert.IsNotNull(leagues);
                Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), 
                    leagues.Result.Count);
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
                    api.GetLeagues(Region.na, 
                        new List<long>(1) { RiotApiTestBase.unrankedSummonerId });
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
        public void GetEntireLeagues_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = api.GetEntireLeagues(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

                Assert.IsNotNull(leagues);
                Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), leagues.Count);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = api.GetEntireLeaguesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

                Assert.IsNotNull(leagues.Result);
                Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(),
                    leagues.Result.Count);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            EnsureCredibility(() =>
            {
                var league = api.GetChallengerLeague(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

                Assert.IsNotNull(league.Entries);
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

                Assert.IsNotNull(league.Result.Entries);
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

                Assert.IsNotNull(league.Entries);
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

                Assert.IsNotNull(league.Result.Entries);
                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            EnsureCredibility(() =>
            {
                var game = api.GetMatch(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId);

                Assert.IsNotNull(game);
                Assert.IsTrue(game.MatchId == RiotApiTestBase.gameId);
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

                Assert.IsNotNull(game);
                Assert.IsTrue(game.MatchId == RiotApiTestBase.gameId);
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

                Assert.IsNotNull(game.Result);
                Assert.IsTrue(game.Result.MatchId == RiotApiTestBase.gameId);
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

                Assert.IsNotNull(game.Result);
                Assert.IsTrue(game.Result.MatchId == RiotApiTestBase.gameId);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
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

                Assert.IsNotNull(matches);
                Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            EnsureCredibility(() =>
            {
                var games = api.GetRecentGames(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

                Assert.IsNotNull(games);
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

                Assert.IsNotNull(games.Result);
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

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMastery_Test()
        {
            EnsureCredibility(() =>
            {
                var championMastery = api.GetChampionMastery(RiotApiTestBase.summoner1Platform,
                    RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1MasteryChampionId);

                Assert.IsNotNull(championMastery);
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
                var championMastery = api.GetChampionMasteryAsync(RiotApiTestBase.summoner1Platform,
                    RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1MasteryChampionId).Result;

                Assert.IsNotNull(championMastery);
                Assert.AreEqual(RiotApiTestBase.summoner1Id, championMastery.PlayerId);
                Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionId, 
                    championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionLevel, 
                    championMastery.ChampionLevel);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetAllChampionsMasteryEntries_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = api.GetChampionMasteries(
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id);

                Assert.IsNotNull(allChampionsMastery);
                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetAllChampionsMasteryEntriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var allChampionsMastery = api.GetChampionMasteriesAsync(
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id).Result;

                Assert.IsNotNull(allChampionsMastery);
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
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id);

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
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id).Result;

                Assert.IsTrue(totalChampionMasteryScore > -1);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTopChampionsMasteryEntries_Test()
        {
            EnsureCredibility(() =>
            {
                var threeTopChampions = api.GetTopChampionsMasteries(
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id);

                Assert.IsNotNull(threeTopChampions);
                Assert.IsTrue(threeTopChampions.Count == 3);

                var sixTopChampions = api.GetTopChampionsMasteries(
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id, 6);

                Assert.IsNotNull(threeTopChampions);
                Assert.IsTrue(sixTopChampions.Count == 6);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTopChampionsMasteryEntriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var threeTopChampions = api.GetTopChampionsMasteriesAsync(
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id).Result;

                Assert.IsNotNull(threeTopChampions);
                Assert.IsTrue(threeTopChampions.Count == 3);

                var sixTopChampions = api.GetTopChampionsMasteriesAsync(
                    RiotApiTestBase.summoner1Platform, RiotApiTestBase.summoner1Id, 6).Result;

                Assert.IsNotNull(threeTopChampions);
                Assert.IsTrue(sixTopChampions.Count == 6);
            });
        }
    }
}
