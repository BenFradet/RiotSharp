using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Linq;
using RiotSharp.Misc;


namespace RiotSharpTest
{
    [TestClass]
    public class StatusRiotApiTest
    {
        private static StatusRiotApi api = StatusRiotApi.GetInstance(CommonTestBase.apiKey);

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShards_Test()
        {
            var shards = api.GetShards();

            Assert.IsNotNull(shards);
            Assert.IsTrue(shards.Count() > 0);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardsAsync_Test()
        {
            var shards = api.GetShardsAsync();

            Assert.IsNotNull(shards.Result);
            Assert.IsTrue(shards.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShardStatus_Test()
        {
            var shardStatus = api.GetShardStatus(StatusRiotApiTestBase.region);

            Assert.IsNotNull(shardStatus);
            Assert.AreEqual(StatusRiotApiTestBase.region.ToString(), shardStatus.Slug.ToString());
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            var shardStatus = api.GetShardStatusAsync(StatusRiotApiTestBase.region);

            Assert.IsNotNull(shardStatus.Result);
            Assert.AreEqual(StatusRiotApiTestBase.region.ToString(), shardStatus.Result.Slug.ToString());
        }
    }
}
