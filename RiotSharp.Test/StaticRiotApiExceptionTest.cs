using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        private static StaticRiotApi faultyStaticApi = StaticRiotApi.GetInstance(StaticRiotApiExceptionTestBase.faultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            faultyStaticApi.GetChampion(Region.euw, 1, ChampionData.All);
        }
    }
}
