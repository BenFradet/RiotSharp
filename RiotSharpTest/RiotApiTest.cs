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
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ById_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = ConfigurationManager.AppSettings["Summoner1Name"];
            RiotApi api = new RiotApi(apiKey, false);

            Summoner summoner = api.GetSummoner(Region.euw, id);

            Assert.AreEqual(summoner.Name, name);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoner_ByName_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            string name = ConfigurationManager.AppSettings["Summoner1Name"];
            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            RiotApi api = new RiotApi(apiKey, false);

            Summoner summoner = api.GetSummoner(Region.euw, name);

            Assert.AreEqual(summoner.Id, id);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummoners_ByIds_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            int id1 = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
            RiotApi api = new RiotApi(apiKey, false);

            var summoners = api.GetSummoners(Region.euw, new List<int>() { id1, id2 });

            Assert.IsNotNull(summoners);
            Assert.IsTrue(summoners.Count() == 2);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampions_Test()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            RiotApi api = new RiotApi(apiKey, false);

            var champions = api.GetChampions(Region.euw);

            Assert.IsNotNull(champions);
            Assert.IsTrue(champions.Count() > 0);
        }
    }
}
