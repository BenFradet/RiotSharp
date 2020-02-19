using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Test.EndpointTests.LoRTests
{
    [TestClass]
    public class LoRRankedEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        [TestMethod]
        [TestCategory("LoR"), TestCategory("Async")]
        public void GetLoRRankedLeaderboardsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leaderboards = Api.LoR_Leaderboards.GetLoRRankedLeaderboardsAsync(Region.Europe).Result;

                Assert.IsTrue(leaderboards.Players.Count == 6);
                Assert.AreEqual(0, leaderboards.Players[0].Rank);
            });
        }
    }
}
