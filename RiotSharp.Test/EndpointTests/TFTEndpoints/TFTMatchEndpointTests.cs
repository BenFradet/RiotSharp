using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Test.EndpointTests.TFTEndpoints
{
    [TestClass]
    public class TFTMatchEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);


        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTMatchListBySummonerPuuidAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matchList = Api.TftMatch.GetTftMatchListByPuuidAsync(Region.Europe, "NrPw06OU-eP-iQEh-V1oXcA3IeIA9ofQf5e-1dgt7uY5TT_FFDTaGQgiDKNaDqat8IXTpRTUuj5mIA");

                Assert.IsTrue(matchList.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTMatchByMatchIdAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matchList = Api.TftMatch.GetTftMatchByMatchIdAsync(Region.Europe, "EUN1_2365690165");

                Assert.IsNotNull(matchList.Result);
            });
        }
    }

}