using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static readonly RiotApi FaultyApi = RiotApi.GetDevelopmentInstance(CommonTestBase.FaultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummonerBySummonerIdAsync_ThrowException_ReturnThrowRiotSharpException()
        {
            FaultyApi.Summoner.GetSummonerBySummonerIdAsync(CommonTestBase.Summoner1Region, CommonTestBase.Summoner1Id).GetAwaiter().GetResult();
        }
    }
}
