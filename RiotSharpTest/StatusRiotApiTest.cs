// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusRiotApiTest.cs" company="">
//   
// </copyright>
// <summary>
//   The status riot api test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;

namespace RiotSharpTest
{
    /// <summary>
    /// The status riot api test.
    /// </summary>
    [TestClass]
    public class StatusRiotApiTest
    {
        /// <summary>
        /// The api.
        /// </summary>
        private static StatusRiotApi api = StatusRiotApi.GetInstance();

        /// <summary>
        /// The region.
        /// </summary>
        private static Region region = Region.euw;

        /// <summary>
        /// The get shards_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShards_Test()
        {
            var shards = api.GetShards();

            Assert.IsNotNull(shards);
            Assert.IsTrue(shards.Count() > 0);
        }

        /// <summary>
        /// The get shards async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardsAsync_Test()
        {
            var shards = api.GetShardsAsync();

            Assert.IsNotNull(shards.Result);
            Assert.IsTrue(shards.Result.Count() > 0);
        }

        /// <summary>
        /// The get shard status_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShardStatus_Test()
        {
            var shardStatus = api.GetShardStatus(region);

            Assert.IsNotNull(shardStatus);
            Assert.AreEqual(region, shardStatus.Slug);
        }

        /// <summary>
        /// The get shard status async_ test.
        /// </summary>
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
