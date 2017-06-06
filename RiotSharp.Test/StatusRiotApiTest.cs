using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.Misc;


namespace RiotSharpTest
{
    [TestClass]
    public class StatusRiotApiTest : CommonTestBase
    {
        private static StatusRiotApi api = StatusRiotApi.GetInstance(CommonTestBase.apiKey);

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShardStatus_Test()
        {
            EnsureCredibility(() =>
            {
                var shardStatus = api.GetShardStatus(StatusRiotApiTestBase.platform);

                Assert.IsNotNull(shardStatus);
                Assert.AreEqual(StatusRiotApiTestBase.platform.ToString().ToLower(),
                    shardStatus.RegionTag.ToString());
            });
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var shardStatus = api.GetShardStatusAsync(StatusRiotApiTestBase.platform);

                Assert.IsNotNull(shardStatus.Result);
                Assert.AreEqual(StatusRiotApiTestBase.platform.ToString().ToLower(),
                    shardStatus.Result.RegionTag.ToString());
            });
        }
    }
}
