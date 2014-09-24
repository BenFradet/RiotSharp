using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;

namespace RiotSharpTest
{
    [TestClass]
    public class StatusRiotApiTest
    {
        private static StatusRiotApi api = StatusRiotApi.GetInstance();
        private static Region region = Region.euw;

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
            var shardStatus = api.GetShardStatus(region);

            Assert.IsNotNull(shardStatus);
            Assert.AreEqual(region, shardStatus.Slug);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            var shardStatus = api.GetShardStatusAsync(region);

            Assert.IsNotNull(shardStatus.Result);
            Assert.AreEqual(region, shardStatus.Result.Slug);
        }
    }
}
