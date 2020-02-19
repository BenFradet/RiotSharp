using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Test.EndpointTests.TFTEndpoints
{
    [TestClass]
    public class TFTLeagueEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);


        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTChallengerLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.TftLeague.GetTFTChallengerLeagueAsync(Region.Eun1);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTGrandmasterLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.TftLeague.GetTFTGrandmasterLeagueAsync(Region.Eun1);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTMasterLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.TftLeague.GetTFTMasterLeagueAsync(Region.Eun1);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTLeagueEntriesBySummonerAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.TftLeague.GetTFTLeagueEntriesBySummonerIdAsync(Region.Eun1, RiotApiTestBase.Summoner1Id);

                Assert.IsNotNull(leagues.Result);
            });
        }

        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTLeagueEntriesByTierAndDivisionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.TftLeague.GetTFTLeagueEntriesByTierAndDivisionAsync(Region.Eun1, Tier.Gold, Division.II);

                Assert.IsNotNull(leagues.Result);
            });
        }

        [TestMethod]
        [TestCategory("TFT"), TestCategory("Async")]
        public void GetTFTLeagueByLeagueIdAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.TftLeague.GetTFTLeaguesByLeagueIdAsync(Region.Eun1, RiotApiTestBase.TftLeagueId);

                Assert.IsTrue(leagues.Result.Queue != null);
                Assert.AreEqual(Tier.Silver, leagues.Result.Tier);
            });
        }
    }
}
