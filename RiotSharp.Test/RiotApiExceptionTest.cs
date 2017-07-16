using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static RiotApi faultyApi = RiotApi.GetDevelopmentInstance(RiotApiExceptionTestBase.faultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetSummonerBySummonerId(RiotApiExceptionTestBase.summoner1and2Region, RiotApiExceptionTestBase.summoner1Id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetChampions(RiotApiExceptionTestBase.summoner1and2Region);
        }
    }
}
