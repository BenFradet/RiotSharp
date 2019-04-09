using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.Misc;


namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class StatusEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var shardStatus = Api.Status.GetShardStatusAsync(Summoner1And2Region);

                Assert.AreEqual(StatusRiotApiTestBase.Platform.ToString().ToLower(),
                    shardStatus.Result.RegionTag);
            });
        }
    }
}
