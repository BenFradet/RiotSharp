using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

using RiotSharp;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static RiotApi faultyApi = RiotApi.GetInstance(faultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            var summoner = faultyApi.GetSummoner(Region.euw, id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            var champions = faultyApi.GetChampions(Region.euw);
        }
    }
}
