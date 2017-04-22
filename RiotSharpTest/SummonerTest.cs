﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.StatsEndpoint;
using RiotSharp.SummonerEndpoint;
using System;
using System.Configuration;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class SummonerTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static int championId = int.Parse(ConfigurationManager.AppSettings["ChampionId"]);
        private static Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);
        private static RiotApi api = RiotApi.GetInstance(apiKey);
        private static Summoner summoner = api.GetSummoner(region, id);
        private static string queue = Queue.RankedSolo5x5;

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
            var games = summoner.GetRecentGames();

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = summoner.GetRecentGamesAsync();

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
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
        [TestCategory("Summoner")]
        public void GetEntireLeagues_Test()
        {
            var leagues = summoner.GetEntireLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_Test()
        {
            var leagues = summoner.GetEntireLeaguesAsync();

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
        [TestCategory("Summoner")]
        public void GetStatsSummaries_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsSummaries();

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsSummariesAsync_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsSummariesAsync();

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsRanked_Test()
        {
            var stats = summoner.GetStatsRanked(Season.Season2015);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = summoner.GetStatsRankedAsync(Season.Season2015);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsRanked_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsRanked();

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsRankedAsync_CurrentSeason_Test()
        {
            var stats = summoner.GetStatsRankedAsync();

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }
    }
}
