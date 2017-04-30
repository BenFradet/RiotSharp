using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RiotSharp.Misc;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiTest
    {
        private static RiotApi api = RiotApi.GetInstance(RiotApiTestBase.apiKey);
        private static DateTime beginTime = new DateTime(2015, 01, 01);
        private static DateTime endTime { get { return DateTime.Now; } }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            var summoner = api.GetSummoner(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.AreEqual(summoner.Name, RiotApiTestBase.summoner1Name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var summoner = api.GetSummonerAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.AreEqual(summoner.Result.Name, RiotApiTestBase.summoner1Name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ById_Test()
        {
            var summoners = api.GetSummoners(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(summoners);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), summoners.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ById_Test()
        {
            var summoners = api.GetSummonersAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(summoners.Result);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), summoners.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            var summoner = api.GetSummoner(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Name);

            Assert.AreEqual(summoner.Id, RiotApiTestBase.summoner1Id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var summoner = api.GetSummonerAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Name);

            Assert.AreEqual(summoner.Result.Id, RiotApiTestBase.summoner1Id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByName_Test()
        {
            var summoners = api.GetSummoners(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerNames);

            Assert.IsNotNull(summoners);
            Assert.AreEqual(RiotApiTestBase.summonerNames.Distinct().Count(), summoners.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ByName_Test()
        {
            var summoners = api.GetSummonersAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerNames);

            Assert.IsNotNull(summoners.Result);
            Assert.AreEqual(RiotApiTestBase.summonerNames.Distinct().Count(), summoners.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerName_Test()
        {
            var summoner = api.GetSummonerName(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.AreEqual(summoner.Name, RiotApiTestBase.summoner1Name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerNameAsync_Test()
        {
            var summoner = api.GetSummonerNameAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.AreEqual(summoner.Result.Name, RiotApiTestBase.summoner1Name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonersNames_Test()
        {
            var summoners = api.GetSummonerNames(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(summoners);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), summoners.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersNamesAsync_Test()
        {
            var summoners = api.GetSummonerNamesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(summoners.Result);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), summoners.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            var champions = api.GetChampions(RiotApiTestBase.summoner1and2Region);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champions = api.GetChampionsAsync(RiotApiTestBase.summoner1and2Region);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }

        [TestMethod]
        [Ignore]
        [TestCategory("RiotApi")]
        public void GetChampions_FreeToPlay_Test()
        {
            var champions = api.GetChampions(RiotApiTestBase.summoner1and2Region, true);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() == 10);
        }

        [TestMethod]
        [Ignore]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            var champions = api.GetChampionsAsync(RiotApiTestBase.summoner1and2Region, true);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() == 10);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            var champion = api.GetChampion(RiotApiTestBase.summoner1and2Region, 12);

            Assert.IsNotNull(champion);
            Assert.AreEqual(champion.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champion = api.GetChampionAsync(RiotApiTestBase.summoner1and2Region, 12);

            Assert.IsNotNull(champion.Result);
            Assert.AreEqual(champion.Result.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_Test()
        {
            var masteries = api.GetMasteryPages(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(masteries);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), masteries.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteries = api.GetMasteryPagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(masteries.Result);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), masteries.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            var runes = api.GetRunePages(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(runes);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), runes.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runes = api.GetRunePagesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(runes.Result);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), runes.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            var leagues = api.GetLeagues(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), leagues.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetLeaguesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), leagues.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetLeagues_ByUnrankedSummoner_Test()
        {
            try
            {
                api.GetLeagues(Region.na, new List<long>(1) { RiotApiTestBase.unrankedSummonerId });
            }
            catch (RiotSharpException e)
            {
                // API gives 404 when valid summoner is unranked.
                Assert.AreEqual(HttpStatusCode.NotFound, e.HttpStatusCode);
                throw;
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_BySummoner_Test()
        {
            var leagues = api.GetEntireLeagues(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(leagues);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), leagues.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(RiotApiTestBase.summonersRegion, RiotApiTestBase.summonerIds);

            Assert.IsNotNull(leagues.Result);
            Assert.AreEqual(RiotApiTestBase.summonerIds.Distinct().Count(), leagues.Result.Count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            var league = api.GetChallengerLeague(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            var league = api.GetChallengerLeagueAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasterLeague_Test()
        {
            var league = api.GetMasterLeague(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            var league = api.GetMasterLeagueAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.queue);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            var game = api.GetMatch(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == RiotApiTestBase.gameId);
            Assert.IsNull(game.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            var game = api.GetMatch(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId, true);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == RiotApiTestBase.gameId);
            Assert.IsNotNull(game.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithoutTimeline_Test()
        {
            var game = api.GetMatchAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == RiotApiTestBase.gameId);
            Assert.IsNull(game.Result.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithTimeline_Test()
        {
            var game = api.GetMatchAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.gameId, true);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == RiotApiTestBase.gameId);
            Assert.IsNotNull(game.Result.Timeline);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Test()
        {
            var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_ChampionIds_Test()
        {
            var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id, 
                new List<long> { RiotApiTestBase.championId }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(RiotApiTestBase.championId.ToString(), match.ChampionID.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_RankedQueues_Test()
        {
            var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id, null,
                new List<string> { RiotApiTestBase.queue }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(RiotApiTestBase.queue.ToString(), match.Queue.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Seasons_Test()
        {
            var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id, null, null,
                new List<RiotSharp.MatchEndpoint.Enums.Season> { RiotApiTestBase.season }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(RiotApiTestBase.season.ToString(), match.Season.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_DateTimes_Test()
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
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Index_Test()
        {
            int beginIndex = 0;
            int endIndex = 32;

            var matches = api.GetMatchList(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, null, null, null, null, null, beginIndex, endIndex).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_ChampionIds_Test()
        {
            var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, new List<long> { RiotApiTestBase.championId }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(RiotApiTestBase.championId.ToString(), match.ChampionID.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_RankedQueues_Test()
        {
            var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, null, new List<string> { RiotApiTestBase.queue }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(RiotApiTestBase.queue.ToString(), match.Queue.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Seasons_Test()
        {
            var matches = api.GetMatchListAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id, null, null,
                new List<RiotSharp.MatchEndpoint.Enums.Season> { RiotApiTestBase.season }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(RiotApiTestBase.season.ToString(), match.Season.ToString());
            }
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_DateTimes_Test()
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
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Index_Test()
        {
            int beginIndex = 0;
            int endIndex = 32;

            var matches = api
                .GetMatchListAsync(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_Test()
        {
            var stats = api.GetStatsSummaries(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1Season);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = api.GetStatsSummariesAsync(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1Season);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummaries(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummariesAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_Test()
        {
            var stats = api.GetStatsRanked(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1Season);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = api.GetStatsRankedAsync(RiotApiTestBase.summoner1and2Region, 
                RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1Season);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = api.GetStatsRanked(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsRankedAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            var games = api.GetRecentGames(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = api.GetRecentGamesAsync(RiotApiTestBase.summoner1and2Region, RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames_Test()
        {
            var games = api.GetFeaturedGames(RiotApiTestBase.summoner1and2Region);

            Assert.IsNotNull(games);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            var games = api.GetFeaturedGamesAsync(RiotApiTestBase.summoner1and2Region);

            Assert.IsNotNull(games.Result);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMastery_Test()
        {
            var championMastery = api.GetChampionMastery(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1MasteryChampionId);

            Assert.IsNotNull(championMastery);
            Assert.AreEqual(RiotApiTestBase.summoner1Id, championMastery.PlayerId);
            Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionId, championMastery.ChampionId);
            Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionLevel, championMastery.ChampionLevel);
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_Test()
        {
            var championMastery = api.GetChampionMasteryAsync(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id, RiotApiTestBase.summoner1MasteryChampionId).Result;

            Assert.IsNotNull(championMastery);
            Assert.AreEqual(RiotApiTestBase.summoner1Id, championMastery.PlayerId);
            Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionId, championMastery.ChampionId);
            Assert.AreEqual(RiotApiTestBase.summoner1MasteryChampionLevel, championMastery.ChampionLevel);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetAllChampionsMasteryEntries_Test()
        {
            var allChampionsMastery = api.GetChampionMasteries(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(allChampionsMastery);
            Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                championMastery.ChampionId == RiotApiTestBase.summoner1MasteryChampionId));
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetAllChampionsMasteryEntriesAsync_Test()
        {
            var allChampionsMastery = api.GetChampionMasteriesAsync(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id).Result;

            Assert.IsNotNull(allChampionsMastery);
            Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                championMastery.ChampionId == RiotApiTestBase.summoner1MasteryChampionId));
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTotalChampionMasteryScore_Test()
        {
            var totalChampionMasteryScore = api.GetTotalChampionMasteryScore(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id);

            Assert.IsTrue(totalChampionMasteryScore > -1);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_Test()
        {
            var totalChampionMasteryScore = api.GetTotalChampionMasteryScoreAsync(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id).Result;

            Assert.IsTrue(totalChampionMasteryScore > -1);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTopChampionsMasteryEntries_Test()
        {
            var threeTopChampions = api.GetTopChampionsMasteries(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id);

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(threeTopChampions.Count == 3);

            var sixTopChampions = api.GetTopChampionsMasteries(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id, 6);

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(sixTopChampions.Count == 6);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTopChampionsMasteryEntriesAsync_Test()
        {
            var threeTopChampions = api.GetTopChampionsMasteriesAsync(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id).Result;

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(threeTopChampions.Count == 3);

            var sixTopChampions = api.GetTopChampionsMasteriesAsync(RiotApiTestBase.summoner1Platform, 
                RiotApiTestBase.summoner1Id, 6).Result;

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(sixTopChampions.Count == 6);
        }
    }
}
