using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static readonly RiotApi FaultyApi = RiotApi.GetDevelopmentInstance(CommonTestBase.FaultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            FaultyApi.GetSummonerBySummonerId(CommonTestBase.Summoner1And2Region, CommonTestBase.Summoner1Id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            FaultyApi.GetChampions(CommonTestBase.Summoner1And2Region);
        }
    }
}
