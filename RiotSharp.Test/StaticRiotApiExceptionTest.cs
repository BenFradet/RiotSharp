using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            FaultyStaticApi.GetChampionAsync(Region.euw, 1).GetAwaiter().GetResult();
        }
    }
}
