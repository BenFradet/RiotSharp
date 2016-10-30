using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RiotSharp;
using RiotSharp.ChampionEndpoint;
using RiotSharp.SummonerEndpoint;
using Newtonsoft.Json;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiTest
    {
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(1);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var sum1 = ApiTestHelper.GetSummoner();
            var api = RiotApi.GetInstance(mockReq);

            var summoner = api.GetSummoner(ApiTestHelper.GetRegion(), (int)sum1.Id);

            Assert.AreEqual(summoner.Name, sum1.Name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(1);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var sum1 = ApiTestHelper.GetSummoner();
            var api = RiotApi.GetInstance(mockReq);

            var summoner = api.GetSummonerAsync(ApiTestHelper.GetRegion(), (int)sum1.Id);

            Assert.AreEqual(summoner.Result.Name, sum1.Name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ById_Test()
        {
            int count = 2;
            var sumList = ApiTestHelper.GetSummonerList();
            var sumId = sumList.Select(x => (int)x.Id).ToList();
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(count);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var api = RiotApi.GetInstance(mockReq);

            var summoners = api.GetSummoners(ApiTestHelper.GetRegion(), sumId);

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ById_Test()
        {
            int count = 2;
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(count);
            var sumList = ApiTestHelper.GetSummonerList();
            var sumId = sumList.Select(x => (int)x.Id).ToList();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var api = RiotApi.GetInstance(mockReq);

            var summoners = api.GetSummonersAsync(ApiTestHelper.GetRegion(), sumId);

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Result.Count == count);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(1);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var sum1 = ApiTestHelper.GetSummoner();
            var api = RiotApi.GetInstance(mockReq);
            var summoner = api.GetSummoner(ApiTestHelper.GetRegion(), sum1.Name);

            Assert.AreEqual(summoner.Id, sum1.Id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(1);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var sum1 = ApiTestHelper.GetSummoner();
            var api = RiotApi.GetInstance(mockReq);
            var summoner = api.GetSummonerAsync(ApiTestHelper.GetRegion(), sum1.Name);

            Assert.AreEqual(summoner.Result.Id, sum1.Id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByName_Test()
        {
            int count = 2;
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(count);
            var sumList = ApiTestHelper.GetSummonerList();
            var sumId = sumList.Select(x => (int)x.Id).ToList();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var api = RiotApi.GetInstance(mockReq);
            var summoners = api.GetSummoners(ApiTestHelper.GetRegion(), sumId);

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == count);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ByName_Test()
        {
            int count = 2;
            var sumDictionary = ApiTestHelper.GetSummonersIdDictionary(count);
            var sumList = ApiTestHelper.GetSummonerList();
            var sumId = sumList.Select(x => (int)x.Id).ToList();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var api = RiotApi.GetInstance(mockReq);
            var summoners = api.GetSummonersAsync(ApiTestHelper.GetRegion(), sumId);

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == count);
        }

        
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerName_Test()
        {
            var sumDictionary = ApiTestHelper.GetSummonersNameDictionary(1);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var sum1 = ApiTestHelper.GetSummoner();

            var api = RiotApi.GetInstance(mockReq);
            var summoner = api.GetSummonerName(ApiTestHelper.GetRegion(), (int)sum1.Id);

            Assert.AreEqual(summoner.Name, sum1.Name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerNameAsync_Test()
        {
            var sumDictionary = ApiTestHelper.GetSummonersNameDictionary(1);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var sum1 = ApiTestHelper.GetSummoner();

            var api = RiotApi.GetInstance(mockReq);
            var summoner = api.GetSummonerNameAsync(ApiTestHelper.GetRegion(), (int)sum1.Id);

            Assert.AreEqual(summoner.Result.Name, sum1.Name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonersNames_Test()
        {
            int count = 2;
            var sumDictionary = ApiTestHelper.GetSummonersNameDictionary(count);
            var sumList = ApiTestHelper.GetSummonerList();
            var sumId = sumList.Select(x => (int)x.Id).ToList();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var api = RiotApi.GetInstance(mockReq);

            var summoners = api.GetSummonersNames(ApiTestHelper.GetRegion(), sumId);

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersNamesAsync_Test()
        {
            int count = 2;
            var sumDictionary = ApiTestHelper.GetSummonersNameDictionary(count);
            var sumList = ApiTestHelper.GetSummonerList();
            var sumId = sumList.Select(x => (int)x.Id).ToList();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(sumDictionary));
            var api = RiotApi.GetInstance(mockReq);

            var summoners = api.GetSummonersNamesAsync(ApiTestHelper.GetRegion(), sumId);

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count() == 2);
        }

        
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            int count = 2;
            var chpDictionary = ApiTestHelper.GetChampionList(count);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(chpDictionary));
            var api = RiotApi.GetInstance(mockReq);
            var champions = api.GetChampions(ApiTestHelper.GetRegion());

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            int count = 2;
            var chpDictionary = ApiTestHelper.GetChampionList(count);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(chpDictionary));
            var api = RiotApi.GetInstance(mockReq);
            var champions = api.GetChampionsAsync(ApiTestHelper.GetRegion());

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_FreeToPlay_Test()
        {
            int count = 2;
            var chpDictionary = ApiTestHelper.GetChampionList(count, true);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(chpDictionary));
            var api = RiotApi.GetInstance(mockReq);
            var champions = api.GetChampions(ApiTestHelper.GetRegion(), true);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() == 1);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            int count = 2;
            var chpDictionary = ApiTestHelper.GetChampionList(count, true);
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(chpDictionary));
            var api = RiotApi.GetInstance(mockReq);
            var champions = api.GetChampionsAsync(ApiTestHelper.GetRegion(), true);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() == 1);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            var chp1 = ApiTestHelper.GetChampion();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(chp1));
            var api = RiotApi.GetInstance(mockReq);
            var champion = api.GetChampion(ApiTestHelper.GetRegion(), (int)chp1.Id);

            Assert.IsNotNull(champion);
            Assert.AreEqual(champion.Id, chp1.Id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var chp1 = ApiTestHelper.GetChampion();
            var mockReq = ApiTestHelper.GenerateRequester(JsonConvert.SerializeObject(chp1));
            var api = RiotApi.GetInstance(mockReq);
            var champion = api.GetChampionAsync(ApiTestHelper.GetRegion(), (int)chp1.Id);

            Assert.IsNotNull(champion.Result);
            Assert.AreEqual(champion.Result.Id, chp1.Id);
        }

        /*
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_Test()
        {
            var masteries = api.GetMasteryPages(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(masteries);
            Assert.IsTrue(masteries.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteries = api.GetMasteryPagesAsync(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(masteries.Result);
            Assert.IsTrue(masteries.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            var runes = api.GetRunePages(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runes = api.GetRunePagesAsync(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            var leagues = api.GetLeagues(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetLeaguesAsync(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_BySummoner_Test()
        {
            var leagues = api.GetEntireLeagues(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_ByTeam_Test()
        {
            var leagues = api.GetLeagues(ApiTestHelper.GetRegion(), new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetLeaguesAsync(ApiTestHelper.GetRegion(), new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_ByTeam_Test()
        {
            var leagues = api.GetEntireLeagues(ApiTestHelper.GetRegion(), new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(ApiTestHelper.GetRegion(), new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            var league = api.GetChallengerLeague(ApiTestHelper.GetRegion(), Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            var league = api.GetChallengerLeagueAsync(ApiTestHelper.GetRegion(), Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasterLeague_Test()
        {
            var league = api.GetMasterLeague(ApiTestHelper.GetRegion(), Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            var league = api.GetMasterLeagueAsync(ApiTestHelper.GetRegion(), Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Summoners_Test()
        {
            var teams = api.GetTeams(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Summoners_Test()
        {
            var teams = api.GetTeamsAsync(ApiTestHelper.GetRegion(), new List<int> { id, id2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Test()
        {
            var teams = api.GetTeams(ApiTestHelper.GetRegion(), new List<string> { team, team2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Test()
        {
            var teams = api.GetTeamsAsync(ApiTestHelper.GetRegion(), new List<string> { team, team2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            var game = api.GetMatch(ApiTestHelper.GetRegion(), gameId);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNull(game.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            var game = api.GetMatch(ApiTestHelper.GetRegion(), gameId, true);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNotNull(game.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithoutTimeline_Test()
        {
            var game = api.GetMatchAsync(ApiTestHelper.GetRegion(), gameId);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNull(game.Result.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithTimeline_Test()
        {
            var game = api.GetMatchAsync(ApiTestHelper.GetRegion(), gameId, true);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNotNull(game.Result.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Test()
        {
            var matches = api.GetMatchList(ApiTestHelper.GetRegion(), id).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_ChampionIds_Test()
        {
            var matches = api.GetMatchList(ApiTestHelper.GetRegion(), id, new List<long> { championId }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(championId.ToString(), match.ChampionID.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_RankedQueues_Test()
        {
            var matches = api.GetMatchList(ApiTestHelper.GetRegion(), id, null, new List<Queue> { queue }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(queue.ToString(), match.Queue.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Seasons_Test()
        {
            var matches = api.GetMatchList(ApiTestHelper.GetRegion(), id, null, null,
                new List<RiotSharp.MatchEndpoint.Enums.Season> { season }).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(season.ToString(), match.Season.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_DateTimes_Test()
        {
            var matches = api.GetMatchList(ApiTestHelper.GetRegion(), id, null, null, null, beginTime, endTime).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.IsTrue(DateTime.Compare(match.Timestamp, beginTime) >= 0);
                Assert.IsTrue(DateTime.Compare(match.Timestamp, endTime) <= 0);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchList_Index_Test()
        {
            int beginIndex = 0;
            int endIndex = 32;

            var matches = api.GetMatchList(ApiTestHelper.GetRegion(), id, null, null, null, null, null, beginIndex, endIndex).Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            var matches = api.GetMatchListAsync(ApiTestHelper.GetRegion(), id).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_ChampionIds_Test()
        {
            var matches = api.GetMatchListAsync(ApiTestHelper.GetRegion(), id, new List<long> { championId }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(championId.ToString(), match.ChampionID.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_RankedQueues_Test()
        {
            var matches = api.GetMatchListAsync(ApiTestHelper.GetRegion(), id, null, new List<Queue> { queue }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(queue.ToString(), match.Queue.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Seasons_Test()
        {
            var matches = api.GetMatchListAsync(ApiTestHelper.GetRegion(), id, null, null,
                new List<RiotSharp.MatchEndpoint.Enums.Season> { season }).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(season.ToString(), match.Season.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_DateTimes_Test()
        {
            var matches = api.GetMatchListAsync(ApiTestHelper.GetRegion(), id, null, null, null, beginTime, endTime).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.IsTrue(DateTime.Compare(match.Timestamp, beginTime) >= 0);
                Assert.IsTrue(DateTime.Compare(match.Timestamp, endTime) <= 0);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Index_Test()
        {
            int beginIndex = 0;
            int endIndex = 32;

            var matches = api
                .GetMatchListAsync(ApiTestHelper.GetRegion(), id, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() <= endIndex - beginIndex);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_Test()
        {
            var stats = api.GetStatsSummaries(ApiTestHelper.GetRegion(), id, RiotSharp.StatsEndpoint.Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = api.GetStatsSummariesAsync(ApiTestHelper.GetRegion(), id, RiotSharp.StatsEndpoint.Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummaries(ApiTestHelper.GetRegion(), id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummariesAsync(ApiTestHelper.GetRegion(), id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_Test()
        {
            var stats = api.GetStatsRanked(ApiTestHelper.GetRegion(), id, RiotSharp.StatsEndpoint.Season.Season2015);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = api.GetStatsRankedAsync(ApiTestHelper.GetRegion(), id, RiotSharp.StatsEndpoint.Season.Season2015);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = api.GetStatsRanked(ApiTestHelper.GetRegion(), id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsRankedAsync(ApiTestHelper.GetRegion(), id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            var games = api.GetRecentGames(ApiTestHelper.GetRegion(), id);

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = api.GetRecentGamesAsync(ApiTestHelper.GetRegion(), id);

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames_Test()
        {
            var games = api.GetFeaturedGames(ApiTestHelper.GetRegion());

            Assert.IsNotNull(games);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            var games = api.GetFeaturedGamesAsync(ApiTestHelper.GetRegion());

            Assert.IsNotNull(games.Result);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMastery_Test()
        {
            const long lucianId = 236;
            var championMastery = api.GetChampionMastery(Platform.NA1, id, lucianId);
            
            Assert.IsNotNull(championMastery);
           
            Assert.AreEqual(id, championMastery.PlayerId);
            Assert.AreEqual(lucianId, championMastery.ChampionId);
            Assert.AreEqual(6, championMastery.ChampionLevel);
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_Test()
        {
            const long lucianId = 236;
            var championMastery = api.GetChampionMasteryAsync(Platform.NA1, id, lucianId).Result;

            Assert.IsNotNull(championMastery);

            Assert.AreEqual(id, championMastery.PlayerId);
            Assert.AreEqual(lucianId, championMastery.ChampionId);
            Assert.AreEqual(6, championMastery.ChampionLevel);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetAllChampionsMasteryEntries_Test()
        {
            var allChampionsMastery = api.GetAllChampionsMasteryEntries(Platform.NA1, id);

            Assert.IsNotNull(allChampionsMastery);

            const long lucianId = 236;
            Assert.IsNotNull(allChampionsMastery.Find(championMastery => 
                championMastery.ChampionId == lucianId));
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetAllChampionsMasteryEntriesAsync_Test()
        {
            var allChampionsMastery = api.GetAllChampionsMasteryEntriesAsync(Platform.NA1, id).Result;

            Assert.IsNotNull(allChampionsMastery);

            const long lucianId = 236;
            Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                championMastery.ChampionId == lucianId));
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTotalChampionMasteryScore_Test()
        {
            var totalChampionMasteryScore = api.GetTotalChampionMasteryScore(Platform.NA1, id);

            Assert.IsTrue(totalChampionMasteryScore > -1);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_Test()
        {
            var totalChampionMasteryScore = api.GetTotalChampionMasteryScoreAsync(Platform.NA1, id).Result;

            Assert.IsTrue(totalChampionMasteryScore > -1);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTopChampionsMasteryEntries_Test()
        {
            var threeTopChampions = api.GetTopChampionsMasteryEntries(Platform.NA1, id);

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(threeTopChampions.Count == 3);

            var sixTopChampions = api.GetTopChampionsMasteryEntries(Platform.NA1, id, 6);

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(sixTopChampions.Count == 6);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTopChampionsMasteryEntriesAsync_Test()
        {
            var threeTopChampions = api.GetTopChampionsMasteryEntriesAsync(Platform.NA1, id).Result;

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(threeTopChampions.Count == 3);

            var sixTopChampions = api.GetTopChampionsMasteryEntriesAsync(Platform.NA1, id, 6).Result;

            Assert.IsNotNull(threeTopChampions);
            Assert.IsTrue(sixTopChampions.Count == 6);
        } */
    }
}
