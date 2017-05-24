using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.SummonerEndpoint;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class SummonerTest
    {

        private static RiotApi api = RiotApi.GetInstance(SummonerTestBase.apiKey);
        private static Summoner summoner = api.GetSummonerBySummonerId(SummonerTestBase.summoner1and2Region, SummonerTestBase.summoner1Id);

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
    }
}
