// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RiotApiTest.cs" company="">
//
// </copyright>
// <summary>
//   The riot api test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;
using RiotSharp.StatsEndpoint;

namespace RiotSharpTest
{
    /// <summary>
    /// The riot api test.
    /// </summary>
    [TestClass]
    public class RiotApiTest
    {
        /// <summary>
        /// The api key.
        /// </summary>
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];

        /// <summary>
        /// The id.
        /// </summary>
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);

        /// <summary>
        /// The name.
        /// </summary>
        private static string name = ConfigurationManager.AppSettings["Summoner1Name"];

        /// <summary>
        /// The id 2.
        /// </summary>
        private static int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);

        /// <summary>
        /// The name 2.
        /// </summary>
        private static string name2 = ConfigurationManager.AppSettings["Summoner2Name"];

        /// <summary>
        /// The team.
        /// </summary>
        private static string team = ConfigurationManager.AppSettings["Team1Id"];

        /// <summary>
        /// The team 2.
        /// </summary>
        private static string team2 = ConfigurationManager.AppSettings["Team2Id"];

        /// <summary>
        /// The game id.
        /// </summary>
        private static int gameId = int.Parse(ConfigurationManager.AppSettings["GameId"]);

        /// <summary>
        /// The api.
        /// </summary>
        private static RiotApi api = RiotApi.GetInstance(apiKey);

        /// <summary>
        /// The champion id.
        /// </summary>
        private static int championId = 18;

        /// <summary>
        /// The queue.
        /// </summary>
        private static Queue queue = Queue.RankedSolo5x5;

        /// <summary>
        /// The get summoner_ by id_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            var summoner = api.GetSummoner(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        /// <summary>
        /// The get summoner async_ by id_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var summoner = api.GetSummonerAsync(Region.euw, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        /// <summary>
        /// The get summoners_ by id_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ById_Test()
        {
            var summoners = api.GetSummoners(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == 2);
        }

        /// <summary>
        /// The get summoners async_ by id_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ById_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == 2);
        }

        /// <summary>
        /// The get summoner_ by name_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            var summoner = api.GetSummoner(Region.euw, name);

            Assert.AreEqual(summoner.Id, id);
        }

        /// <summary>
        /// The get summoner async_ by name_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var summoner = api.GetSummonerAsync(Region.euw, name);

            Assert.AreEqual(summoner.Result.Id, id);
        }

        /// <summary>
        /// The get summoners_ by name_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByName_Test()
        {
            var summoners = api.GetSummoners(Region.euw, new List<string> { name, name2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count == 2);
        }

        /// <summary>
        /// The get summoners async_ by name_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_ByName_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, new List<string> { name, name2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count == 2);
        }

        /// <summary>
        /// The get summoner name_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerName_Test()
        {
            var summoner = api.GetSummonerName(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        /// <summary>
        /// The get summoner name async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerNameAsync_Test()
        {
            var summoner = api.GetSummonerNameAsync(Region.euw, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        /// <summary>
        /// The get summoners names_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonersNames_Test()
        {
            var summoners = api.GetSummonersNames(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        /// <summary>
        /// The get summoners names async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersNamesAsync_Test()
        {
            var summoners = api.GetSummonersNamesAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count() == 2);
        }

        /// <summary>
        /// The get champions_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            var champions = api.GetChampions(Region.euw);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        /// <summary>
        /// The get champions async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champions = api.GetChampionsAsync(Region.euw);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }

        /// <summary>
        /// The get champion_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampion_Test()
        {
            var champion = api.GetChampion(Region.euw, 12);

            Assert.IsNotNull(champion);
            Assert.AreEqual(champion.Id, 12);
        }

        /// <summary>
        /// The get champion async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champion = api.GetChampionAsync(Region.euw, 12);

            Assert.IsNotNull(champion.Result);
            Assert.AreEqual(champion.Result.Id, 12);
        }

        /// <summary>
        /// The get mastery pages_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryPages_Test()
        {
            var masteries = api.GetMasteryPages(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(masteries);
            Assert.IsTrue(masteries.Count == 2);
        }

        /// <summary>
        /// The get mastery pages async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteries = api.GetMasteryPagesAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(masteries.Result);
            Assert.IsTrue(masteries.Result.Count == 2);
        }

        /// <summary>
        /// The get rune pages_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRunePages_Test()
        {
            var runes = api.GetRunePages(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Count == 2);
        }

        /// <summary>
        /// The get rune pages async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runes = api.GetRunePagesAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Count == 2);
        }

        /// <summary>
        /// The get leagues_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_BySummoner_Test()
        {
            var leagues = api.GetLeagues(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        /// <summary>
        /// The get leagues async_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetLeaguesAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_BySummoner_Test()
        {
            var leagues = api.GetEntireLeagues(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues async_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        /// <summary>
        /// The get leagues_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagues_ByTeam_Test()
        {
            var leagues = api.GetLeagues(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        /// <summary>
        /// The get leagues async_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetLeaguesAsync(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetEntireLeagues_ByTeam_Test()
        {
            var leagues = api.GetEntireLeagues(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues async_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesAsync(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        /// <summary>
        /// The get challenger league_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChallengerLeague_Test()
        {
            var league = api.GetChallengerLeague(Region.euw, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        /// <summary>
        /// The get challenger league async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            var league = api.GetChallengerLeagueAsync(Region.euw, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        /// <summary>
        /// The get leagues v 24_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetLeaguesV24_BySummoner_Test()
        {
            var leagues = api.GetLeaguesV24(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        /// <summary>
        /// The get leagues v 24 async_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesV24Async_BySummoner_Test()
        {
            var leagues = api.GetLeaguesV24Async(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues v 24_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV24_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesV24(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues[id]);
            Assert.IsNotNull(leagues[id2]);
            Assert.IsTrue(leagues[id].Count > 0);
            Assert.IsTrue(leagues[id2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues v 24 async_ by summoner_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV24Async_BySummoner_Test()
        {
            var leagues = api.GetEntireLeaguesV24Async(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(leagues.Result[id]);
            Assert.IsNotNull(leagues.Result[id2]);
            Assert.IsTrue(leagues.Result[id].Count > 0);
            Assert.IsTrue(leagues.Result[id2].Count > 0);
        }

        /// <summary>
        /// The get leagues v 24_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetLeaguesV24_ByTeam_Test()
        {
            var leagues = api.GetLeaguesV24(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        /// <summary>
        /// The get leagues v 24 async_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesV24Async_ByTeam_Test()
        {
            var leagues = api.GetLeaguesV24Async(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues v 24_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV24_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesV24(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues[team2]);
            Assert.IsTrue(leagues[team2].Count > 0);
        }

        /// <summary>
        /// The get entire leagues v 24 async_ by team_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV24Async_ByTeam_Test()
        {
            var leagues = api.GetEntireLeaguesV24Async(Region.euw, new List<string> { team2 });

            Assert.IsNotNull(leagues.Result[team2]);
            Assert.IsTrue(leagues.Result[team2].Count > 0);
        }

        /// <summary>
        /// The get challenger league v 24_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetChallengerLeagueV24_Test()
        {
            var league = api.GetChallengerLeagueV24(Region.euw, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Entries);
            Assert.IsTrue(league.Entries.Count > 0);
        }

        /// <summary>
        /// The get challenger league v 24 async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetChallengerLeagueV24Async_Test()
        {
            var league = api.GetChallengerLeagueV24Async(Region.euw, Queue.RankedSolo5x5);

            Assert.IsNotNull(league.Result.Entries);
            Assert.IsTrue(league.Result.Entries.Count > 0);
        }

        /// <summary>
        /// The get teams_ summoners_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Summoners_Test()
        {
            var teams = api.GetTeams(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        /// <summary>
        /// The get teams async_ summoners_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Summoners_Test()
        {
            var teams = api.GetTeamsAsync(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        /// <summary>
        /// The get teams_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetTeams_Test()
        {
            var teams = api.GetTeams(Region.euw, new List<string> { team, team2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        /// <summary>
        /// The get teams async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTeamsAsync_Test()
        {
            var teams = api.GetTeamsAsync(Region.euw, new List<string> { team, team2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        /// <summary>
        /// The get teams v 23_ summoners_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetTeamsV23_Summoners_Test()
        {
            var teams = api.GetTeamsV23(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        /// <summary>
        /// The get teams v 23 async_ summoners_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetTeamsV23Async_Summoners_Test()
        {
            var teams = api.GetTeamsV23Async(Region.euw, new List<int> { id, id2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        /// <summary>
        /// The get teams v 23_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetTeamsV23_Test()
        {
            var teams = api.GetTeamsV23(Region.euw, new List<string> { team, team2 });

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count > 0);
        }

        /// <summary>
        /// The get teams v 23 async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetTeamsV23Async_Test()
        {
            var teams = api.GetTeamsV23Async(Region.euw, new List<string> { team, team2 });

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count > 0);
        }

        /// <summary>
        /// The get match_ without timeline_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithoutTimeline_Test()
        {
            var game = api.GetMatch(Region.euw, gameId);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNull(game.Timeline);
        }

        /// <summary>
        /// The get match_ with timeline_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatch_WithTimeline_Test()
        {
            var game = api.GetMatch(Region.euw, gameId, true);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.MatchId == gameId);
            Assert.IsNotNull(game.Timeline);
        }

        /// <summary>
        /// The get match async_ without timeline_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithoutTimeline_Test()
        {
            var game = api.GetMatchAsync(Region.euw, gameId);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNull(game.Result.Timeline);
        }

        /// <summary>
        /// The get match async_ with timeline_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_WithTimeline_Test()
        {
            var game = api.GetMatchAsync(Region.euw, gameId, true);

            Assert.IsNotNull(game.Result);
            Assert.IsTrue(game.Result.MatchId == gameId);
            Assert.IsNotNull(game.Result.Timeline);
        }

        /// <summary>
        /// The get match history_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchHistory_Test()
        {
            var matches = api.GetMatchHistory(Region.euw, id);

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        /// <summary>
        /// The get match history_ champion ids_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchHistory_ChampionIds_Test()
        {
            var matches = api.GetMatchHistory(Region.euw, id, 0, 14, new List<int> { championId });

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(championId, match.Participants[0].ChampionId);
            }
        }

        /// <summary>
        /// The get match history_ ranked queues_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchHistory_RankedQueues_Test()
        {
            var matches = api.GetMatchHistory(Region.euw, id, 0, 14, null, new List<Queue> { queue });

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
            foreach (var match in matches)
            {
                Assert.AreEqual(queue.ToString(), match.QueueType.ToString());
            }
        }

        /// <summary>
        /// The get match history async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchHistoryAsync_Test()
        {
            var matches = api.GetMatchHistoryAsync(Region.euw, id);

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
        }

        /// <summary>
        /// The get match history async_ champion ids_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchHistoryAsync_ChampionIds_Test()
        {
            var matches = api.GetMatchHistoryAsync(Region.euw, id, 0, 14, new List<int> { championId });

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
            foreach (var match in matches.Result)
            {
                Assert.AreEqual(championId, match.Participants[0].ChampionId);
            }
        }

        /// <summary>
        /// The get match history async_ ranked queues_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchHistoryAsync_RankedQueues_Test()
        {
            var matches = api.GetMatchHistoryAsync(Region.euw, id, 0, 14, null, new List<Queue> { queue });

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
            foreach (var match in matches.Result)
            {
                Assert.AreEqual(queue.ToString(), match.QueueType.ToString());
            }
        }

        /// <summary>
        /// The get stats summaries_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_Test()
        {
            var stats = api.GetStatsSummaries(Region.euw, id, Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = api.GetStatsSummariesAsync(Region.euw, id, Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummaries(Region.euw, id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries async_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsSummariesAsync(Region.euw, id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_Test()
        {
            var stats = api.GetStatsRanked(Region.euw, id, Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = api.GetStatsRankedAsync(Region.euw, id, Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = api.GetStatsRanked(Region.euw, id);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked async_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = api.GetStatsRankedAsync(Region.euw, id);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get recent games_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentGames_Test()
        {
            var games = api.GetRecentGames(Region.euw, id);

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        /// <summary>
        /// The get recent games async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = api.GetRecentGamesAsync(Region.euw, id);

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

    }
}