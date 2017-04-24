using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Linq;
using RiotSharp.Misc;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StatusRiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["apiKey"];
        private static StatusRiotApi api = StatusRiotApi.GetInstance(apiKey);
        private static Platform platform = Platform.NA1;

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShardStatus_Test()
        {
            var shardStatus = api.GetShardStatus(platform);

            Assert.IsNotNull(shardStatus);
            Assert.AreEqual("na", shardStatus.Slug.ToString());
            Assert.AreEqual("North America", shardStatus.Name);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            var shardStatus = api.GetShardStatusAsync(platform);

            Assert.IsNotNull(shardStatus.Result);
            Assert.AreEqual("na", shardStatus.Result.Slug.ToString());
            Assert.AreEqual("North America", shardStatus.Result.Name);
        }
    }
}
