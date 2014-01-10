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
        static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        static RiotApi api = RiotApi.GetInstance(apiKey, false);

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRunePages_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var runePages = summoner.GetRunePages();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var runePages = summoner.GetRunePagesAsync();

            Assert.IsNotNull(runePages.Result);
            Assert.IsTrue(runePages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMasteryPages_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var masteryPages = summoner.GetMasteryPages();

            Assert.IsNotNull(masteryPages);
            Assert.IsTrue(masteryPages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var masteryPages = summoner.GetMasteryPagesAsync();

            Assert.IsNotNull(masteryPages.Result);
            Assert.IsTrue(masteryPages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRecentGames_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var recentGames = summoner.GetRecentGames();

            Assert.IsNotNull(recentGames);
            Assert.IsTrue(recentGames.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var recentGames = summoner.GetRecentGamesAsync();

            Assert.IsNotNull(recentGames.Result);
            Assert.IsTrue(recentGames.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetRecentGamesV11_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var recentGames = summoner.GetRecentGamesV11();

            Assert.IsNotNull(recentGames);
            Assert.IsTrue(recentGames.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetRecentGamesV11Async_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var recentGames = summoner.GetRecentGamesV11Async();

            Assert.IsNotNull(recentGames.Result);
            Assert.IsTrue(recentGames.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetLeagues_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var leagues = summoner.GetLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetLeaguesAsync_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var leagues = summoner.GetLeaguesAsync();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetLeaguesV21_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var leagues = summoner.GetLeaguesV21();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetLeaguesV21Async_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var leagues = summoner.GetLeaguesV21Async();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsSummaries_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var stats = summoner.GetStatsSummaries(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var stats = summoner.GetStatsSummariesAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetStatsSummariesV11_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var stats = summoner.GetStatsSummariesV11(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetStatsSummariesV11Async_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            var stats = summoner.GetStatsSummariesV11Async(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }
    }
}
