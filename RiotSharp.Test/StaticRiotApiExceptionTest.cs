using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        private static readonly StaticRiotApi FaultyStaticApi = StaticRiotApi.GetInstance(CommonTestBase.FaultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            FaultyStaticApi.GetChampion(Region.euw, 1);
        }
    }
}
