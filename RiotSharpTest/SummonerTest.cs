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
        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRunePages_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            RiotApi api = new RiotApi(apiKey, false);
            Summoner summoner = api.GetSummoner(Region.euw, 20937547);

            var runePages = summoner.GetRunePages();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMasteryPages_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            RiotApi api = new RiotApi(apiKey, false);
            Summoner summoner = api.GetSummoner(Region.euw, 20937547);

            var runePages = summoner.GetMasteryPages();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRecentGames_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            RiotApi api = new RiotApi(apiKey, false);
            Summoner summoner = api.GetSummoner(Region.euw, 20937547);

            var runePages = summoner.GetRecentGames();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetLeagues_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            RiotApi api = new RiotApi(apiKey, false);
            Summoner summoner = api.GetSummoner(Region.euw, 20937547);

            var runePages = summoner.GetRecentGames();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }
    }
}
