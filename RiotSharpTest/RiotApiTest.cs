using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiTest
    {
        static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        static string name = ConfigurationManager.AppSettings["Summoner1Name"];
        static int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        static RiotApi api = RiotApi.GetInstance(apiKey, false);

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ById_Test()
        {
            var summoner = api.GetSummonerAsync(Region.euw, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetSummonerV11_ById_Test()
        {
            Summoner summoner = api.GetSummonerV11(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetSummonerV11Async_ById_Test()
        {
            var summoner = api.GetSummonerV11Async(Region.euw, id);

            Assert.AreEqual(summoner.Result.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            Summoner summoner = api.GetSummoner(Region.euw, name);

            Assert.AreEqual(summoner.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerAsync_ByName_Test()
        {
            var summoner = api.GetSummonerAsync(Region.euw, name);

            Assert.AreEqual(summoner.Result.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetSummonerV11_ByName_Test()
        {
            Summoner summoner = api.GetSummonerV11(Region.euw, name);

            Assert.AreEqual(summoner.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetSummonerV11Async_ByName_Test()
        {
            var summoner = api.GetSummonerV11Async(Region.euw, name);

            Assert.AreEqual(summoner.Result.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_Test()
        {
            var summoners = api.GetSummoners(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonersAsync_Test()
        {
            var summoners = api.GetSummonersAsync(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Deprecated")]
        public void GetSummonersV11_Test()
        {
            var summoners = api.GetSummonersV11(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetSummonersV11Async_Test()
        {
            var summoners = api.GetSummonersV11Async(Region.euw, new List<int>() { id, id2 });

            Assert.IsNotNull(summoners.Result);
            Assert.IsTrue(summoners.Result.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            var champions = api.GetChampions(Region.euw);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champions = api.GetChampionsAsync(Region.euw);

            Assert.IsNotNull(champions.Result);
            Assert.IsTrue(champions.Result.Count() > 0);
        }
    }
}
