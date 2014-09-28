// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SummonerTest.cs" company="">
//
// </copyright>
// <summary>
//   The summoner test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;
using RiotSharp.StatsEndpoint;
using RiotSharp.SummonerEndpoint;

namespace RiotSharpTest
{
    /// <summary>
    /// The summoner test.
    /// </summary>
    [TestClass]
    public class SummonerTest
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
        /// The api.
        /// </summary>
        private static RiotApi api = RiotApi.GetInstance(apiKey);

        /// <summary>
        /// The summoner.
        /// </summary>
        private static Summoner summoner = api.GetSummoner(Region.euw, id);

        /// <summary>
        /// The champion id.
        /// </summary>
        private static int championId = 28;

        /// <summary>
        /// The queue.
        /// </summary>
        private static Queue queue = Queue.RankedSolo5x5;

        /// <summary>
        /// The get rune pages_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRunePages_Test()
        {
            var runePages = summoner.GetRunePages();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        /// <summary>
        /// The get rune pages async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runePages = summoner.GetRunePagesAsync();

            Assert.IsNotNull(runePages.Result);
            Assert.IsTrue(runePages.Result.Count() > 0);
        }

        /// <summary>
        /// The get mastery pages_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMasteryPages_Test()
        {
            var masteryPages = summoner.GetMasteryPages();

            Assert.IsNotNull(masteryPages);
            Assert.IsTrue(masteryPages.Count() > 0);
        }

        /// <summary>
        /// The get mastery pages async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteryPages = summoner.GetMasteryPagesAsync();

            Assert.IsNotNull(masteryPages.Result);
            Assert.IsTrue(masteryPages.Result.Count() > 0);
        }

        /// <summary>
        /// The get recent games_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRecentGames_Test()
        {
            var games = summoner.GetRecentGames();

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        /// <summary>
        /// The get recent games async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = summoner.GetRecentGamesAsync();

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

        /// <summary>
        /// The get leagues_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetLeagues_Test()
        {
            var leagues = summoner.GetLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        /// <summary>
        /// The get leagues async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetLeaguesAsync_Test()
        {
            var leagues = summoner.GetLeaguesAsync();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        /// <summary>
        /// The get entire leagues_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetEntireLeagues_Test()
        {
            var leagues = summoner.GetEntireLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        /// <summary>
        /// The get entire leagues async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_Test()
        {
            var leagues = summoner.GetEntireLeaguesAsync();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        /// <summary>
        /// The get leagues v 24_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetLeaguesV24_Test()
        {
            var leagues = summoner.GetLeaguesV24();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        /// <summary>
        /// The get leagues v 24 async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesV24Async_Test()
        {
            var leagues = summoner.GetLeaguesV24Async();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        /// <summary>
        /// The get entire leagues v 24_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV24_Test()
        {
            var leagues = summoner.GetEntireLeaguesV24();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        /// <summary>
        /// The get entire leagues v 24 async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV24Async_Test()
        {
            var leagues = summoner.GetEntireLeaguesV24Async();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsSummaries_Test()
        {
            var stats = summoner.GetStatsSummaries(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = summoner.GetStatsSummariesAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsSummaries();

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats summaries async_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsSummariesAsync();

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsRanked_Test()
        {
            var stats = summoner.GetStatsRanked(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = summoner.GetStatsRankedAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsRanked();

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        /// <summary>
        /// The get stats ranked async_ current season_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsRankedAsync();

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        /// <summary>
        /// The get teams_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetTeams_Test()
        {
            var teams = summoner.GetTeams();

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count() > 0);
        }

        /// <summary>
        /// The get teams async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetTeamsAsync_Test()
        {
            var teams = summoner.GetTeamsAsync();

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count() > 0);
        }

        /// <summary>
        /// The get teams v 23_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetTeamsV23_Test()
        {
            var teams = summoner.GetTeamsV23();

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count() > 0);
        }

        /// <summary>
        /// The get teams v 23 async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetTeamsV23Async_Test()
        {
            var teams = summoner.GetTeamsV23Async();

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count() > 0);
        }

        /// <summary>
        /// The get match history_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMatchHistory_Test()
        {
            var matches = summoner.GetMatchHistory();

            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }

        /// <summary>
        /// The get match history_ champion ids_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMatchHistory_ChampionIds_Test()
        {
            var matches = summoner.GetMatchHistory(0, 14, new List<int> { championId });

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
        [TestCategory("Summoner")]
        public void GetMatchHistory_RankedQueues_Test()
        {
            var matches = summoner.GetMatchHistory(0, 14, null, new List<Queue> { queue });

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
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMatchHistoryAsync_Test()
        {
            var matches = summoner.GetMatchHistoryAsync();

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
        }

        /// <summary>
        /// The get match history async_ champion ids_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMatchHistoryAsync_ChampionIds_Test()
        {
            var matches = summoner.GetMatchHistoryAsync(0, 14, new List<int> { championId });

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
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMatchHistoryAsync_RankedQueues_Test()
        {
            var matches = summoner.GetMatchHistoryAsync(0, 14, null, new List<Queue> { queue });

            Assert.IsNotNull(matches.Result);
            Assert.IsTrue(matches.Result.Count() > 0);
            foreach (var match in matches.Result)
            {
                Assert.AreEqual(queue.ToString(), match.QueueType.ToString());
            }
        }
    }
}
