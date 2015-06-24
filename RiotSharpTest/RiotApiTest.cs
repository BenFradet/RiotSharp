using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.StatsEndpoint;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static string name = ConfigurationManager.AppSettings["Summoner1Name"];
        private static int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        private static string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
        private static string team = ConfigurationManager.AppSettings["Team1Id"];
        private static string team2 = ConfigurationManager.AppSettings["Team2Id"];
        private static int gameId = int.Parse(ConfigurationManager.AppSettings["GameId"]);
        private static int championId = int.Parse(ConfigurationManager.AppSettings["ChampionId"]);
        private static RiotApi api = RiotApi.GetInstance(apiKey);
        private static Queue queue = Queue.RankedSolo5x5;
        private static Region region = (Region) Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            var summoner = api.GetSummoner(region, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var summoner = api.GetSummonerAsync(region, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ById_Test()
        {
            var summoners = api.GetSummoners(region, new List<int> { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ById_Test()
        {
            var summoners = api.GetSummonersAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            var summoner = api.GetSummoner(region, name);

            Assert.AreEqual(summoner.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var summoner = api.GetSummonerAsync(region, name);

            Assert.AreEqual(summoner.Result.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByName_Test()
        {
            var summoners = api.GetSummoners(region, new List<string> { name, name2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ByName_Test()
        {
            var summoners = api.GetSummonersAsync(region, new List<string> { name, name2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerName_Test()
        {
            var summoner = api.GetSummonerName(region, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerNameAsync_Test()
        {
            var summoner = api.GetSummonerNameAsync(region, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonersNames_Test()
        {
            var summoners = api.GetSummonersNames(region, new List<int> { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersNamesAsync_Test()
        {
            var summoners = api.GetSummonersNamesAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            var champions = api.GetChampions(region);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champions = api.GetChampionsAsync(region);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_FreeToPlay_Test()
        {
            var champions = api.GetChampions(region, true);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() == 10);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_FreeToPlay_Test()
        {
            var champions = api.GetChampionsAsync(region, true);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() == 10);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            var champion = api.GetChampion(region, 12);

            Assert.IsNotNull(champion);
            Assert.AreEqual(champion.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champion = api.GetChampionAsync(region, 12);

            Assert.IsNotNull(champion.Result);
            Assert.AreEqual(champion.Result.Id, 12);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_Test()
        {
            var masteries = api.GetMasteryPages(region, new List<int> { id, id2 });

            Assert.IsNotNull(masteries);
            Assert.IsTrue(masteries.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteries = api.GetMasteryPagesAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(masteries.Result);
            Assert.IsTrue(masteries.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            var runes = api.GetRunePages(region, new List<int> { id, id2 });

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runes = api.GetRunePagesAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Count == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            var leagues = api.GetLeagues(region, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetLeaguesAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_BySummoner_Test()
        {
            var leagues = api.GetEntireLeagues(region, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_ByTeam_Test()
        {
            var leagues = api.GetLeagues(region, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetLeaguesAsync(region, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_ByTeam_Test()
        {
            var leagues = api.GetEntireLeagues(region, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(region, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            var league = api.GetChallengerLeague(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            var league = api.GetChallengerLeagueAsync(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasterLeague_Test()
        {
            var league = api.GetMasterLeague(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            var league = api.GetMasterLeagueAsync(region, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Summoners_Test()
        {
            var teams = api.GetTeams(region, new List<int> { id, id2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Summoners_Test()
        {
            var teams = api.GetTeamsAsync(region, new List<int> { id, id2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Test()
        {
            var teams = api.GetTeams(region, new List<string> { team, team2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Test()
        {
            var teams = api.GetTeamsAsync(region, new List<string> { team, team2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            var game = api.GetMatch(region, gameId);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNull(game.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            var game = api.GetMatch(region, gameId, true);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNotNull(game.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithoutTimeline_Test()
        {
            var game = api.GetMatchAsync(region, gameId);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNull(game.Result.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithTimeline_Test()
        {
            var game = api.GetMatchAsync(region, gameId, true);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNotNull(game.Result.Timeline);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchHistory_Test()
        {
            var matches = api.GetMatchHistory(region, id);

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchHistory_ChampionIds_Test()
        {
            var matches = api.GetMatchHistory(region, id, 0, 14, new List<int> { championId });

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(championId, match.Participants[0].ChampionId);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchHistory_RankedQueues_Test()
        {
            var matches = api.GetMatchHistory(region, id, 0, 14, null, new List<Queue> { queue });

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(queue.ToString(), match.QueueType.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchHistoryAsync_Test()
        {
            var matches = api.GetMatchHistoryAsync(region, id);

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchHistoryAsync_ChampionIds_Test()
        {
            var matches = api.GetMatchHistoryAsync(region, id, 0, 14, new List<int> { championId });

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
            foreach (var match in matches.Result)
            {
                Assert.AreEqual(championId, match.Participants[0].ChampionId);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchHistoryAsync_RankedQueues_Test()
        {
            var matches = api.GetMatchHistoryAsync(region, id, 0, 14, null, new List<Queue> { queue });

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
            foreach (var match in matches.Result)
            {
                Assert.AreEqual(queue.ToString(), match.QueueType.ToString());
            }
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_Test()
        {
            var stats = api.GetStatsSummaries(region, id, Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = api.GetStatsSummariesAsync(region, id, Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummaries(region, id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummariesAsync(region, id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_Test()
        {
            var stats = api.GetStatsRanked(region, id, Season.Season2015);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = api.GetStatsRankedAsync(region, id, Season.Season2015);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = api.GetStatsRanked(region, id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsRankedAsync(region, id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            var games = api.GetRecentGames(region, id);

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = api.GetRecentGamesAsync(region, id);

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames_Test()
        {
            var games = api.GetFeaturedGames(region);

            Assert.IsNotNull(games);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_Test()
        {
            var games = api.GetFeaturedGamesAsync(region);

            Assert.IsNotNull(games.Result);
        }



    }
}