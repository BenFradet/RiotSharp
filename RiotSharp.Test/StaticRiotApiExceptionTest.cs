using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        private static readonly StaticDataEndpoint FaultyStaticApi = StaticDataEndpoint.GetInstance(CommonTestBase.FaultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            FaultyStaticApi.Champion.GetChampionAsync(Region.euw, 1).GetAwaiter().GetResult();
        }
    }
}
