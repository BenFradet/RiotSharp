using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        private static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];
        private static StaticRiotApi faultyStaticApi = StaticRiotApi.GetInstance(faultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            faultyStaticApi.GetChampion(Region.euw, 1, ChampionData.all);
        }
    }
}
