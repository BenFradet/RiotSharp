using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;

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
            faultyApi.GetSummoner(Region.euw, id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetChampions(Region.euw);
        }
    }
}
