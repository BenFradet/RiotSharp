using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.Misc;


namespace RiotSharp.Test
{
    [TestClass]
    public class StatusRiotApiTest : CommonTestBase
    {
        private static readonly StatusRiotApi Api = StatusRiotApi.GetInstance(ApiKey);

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var shardStatus = Api.GetShardStatusAsync(Summoner1And2Region);

                Assert.AreEqual(StatusRiotApiTestBase.Platform.ToString().ToLower(),
                    shardStatus.Result.RegionTag);
            });
        }
    }
}
