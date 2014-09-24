using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

using RiotSharp;
using RiotSharp.StaticDataEndpoint;

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
            var champ = faultyStaticApi.GetChampion(Region.euw, 1, ChampionData.all);
        }
    }
}
