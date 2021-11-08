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
        public void GetSummonerByNameAsync_ThrowException_ReturnThrowRiotSharpException()
        {
            FaultyApi.Summoner.GetSummonerByNameAsync(CommonTestBase.Summoner1Platform, CommonTestBase.Summoner1Name).GetAwaiter().GetResult();
        }
    }
}
