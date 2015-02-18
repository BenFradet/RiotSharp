using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];
        private static RiotApi faultyApi = RiotApi.GetInstance(faultyApiKey);
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Region"]);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetSummoner(region, id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetChampions(region);
        }
    }
}
