using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class SummonerTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static RiotApi api = RiotApi.GetInstance(apiKey, false);
        private static Summoner summoner = api.GetSummoner(Region.euw, id);

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRunePages_Test()
        {
            var runePages = summoner.GetRunePages();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runePages = summoner.GetRunePagesAsync();

            Assert.IsNotNull(runePages.Result);
            Assert.IsTrue(runePages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMasteryPages_Test()
        {
            var masteryPages = summoner.GetMasteryPages();

            Assert.IsNotNull(masteryPages);
            Assert.IsTrue(masteryPages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteryPages = summoner.GetMasteryPagesAsync();

            Assert.IsNotNull(masteryPages.Result);
            Assert.IsTrue(masteryPages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRecentGames_Test()
        {
            var recentGames = summoner.GetRecentGames();

            Assert.IsNotNull(recentGames);
            Assert.IsTrue(recentGames.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var recentGames = summoner.GetRecentGamesAsync();

            Assert.IsNotNull(recentGames.Result);
            Assert.IsTrue(recentGames.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetRecentGamesV11_Test()
        {
            var recentGames = summoner.GetRecentGamesV11();

            Assert.IsNotNull(recentGames);
            Assert.IsTrue(recentGames.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetRecentGamesV11Async_Test()
        {
            var recentGames = summoner.GetRecentGamesV11Async();

            Assert.IsNotNull(recentGames.Result);
            Assert.IsTrue(recentGames.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetLeagues_Test()
        {
            var leagues = summoner.GetLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetLeaguesAsync_Test()
        {
            var leagues = summoner.GetLeaguesAsync();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetLeaguesV21_Test()
        {
            var leagues = summoner.GetLeaguesV21();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesV21Async_Test()
        {
            var leagues = summoner.GetLeaguesV21Async();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsSummaries_Test()
        {
            var stats = summoner.GetStatsSummaries(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = summoner.GetStatsSummariesAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetStatsSummariesV11_Test()
        {
            var stats = summoner.GetStatsSummariesV11(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetStatsSummariesV11Async_Test()
        {
            var stats = summoner.GetStatsSummariesV11Async(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsRanked_Test()
        {
            var stats = summoner.GetStatsRanked(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = summoner.GetStatsRankedAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetStatsRankedV11_Test()
        {
            var stats = summoner.GetStatsRankedV11(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetStatsRankedV11Async_Test()
        {
            var stats = summoner.GetStatsRankedV11Async(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsNotNull(stats.Result.Count() > 0);
        }
    }
}
