using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Test.EndpointTests.TFTEndpoints
{
    [TestClass]
    public class TFTSummonerEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTftSummonerBySummonerIdAsync_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.TftSummoner.GetTFTSummonerBySummonerIdAsync(Summoner1And2Region,
                    Summoner1Id);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTftSummonerByAccountIdAsync_ExistingAccountId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.TftSummoner.GetTFTSummonerByAccountIDAsync(Summoner1And2Region,
                    Summoner1AccountId);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTftSummonerByNameAsync_ExistingName_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.TftSummoner.GetTFTSummonerByNameAsync(Summoner1And2Region,
                    Summoner1Name);

                Assert.AreEqual(Summoner1Id, summoner.Result.Id);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTftSummonerBySummonerPuuidAsync_ExistingId_ReturnsSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.TftSummoner.GetTFTSummonerByAccountPuuidAsync(Summoner1And2Region,
                    Summoner1Puuid);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }
    }
}
