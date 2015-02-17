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
        private static RiotApi api = RiotApi.GetInstance(apiKey);
        private static Platform faultyPlatform = (Platform) Enum.Parse(typeof(Platform), ConfigurationManager.AppSettings["FaultyPlatform"]);        

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetSummoner(Region.euw, id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetChampions(Region.euw);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetCurrentGame_ShouldThrowRiotSharpException_Test()
        {
            var game = api.GetCurrentGame(faultyPlatform, id);
        }
    }
}
