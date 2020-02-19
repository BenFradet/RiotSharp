using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class LeagueEndpointTest : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueEntriesBySummonerAsync_Test()
        {
            EnsureCredibility(() =>
            {
                // TODO: tests for other sumoners
                var leagues = Api.League.GetLeagueEntriesBySummonerAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.SummonerIds[0]);

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueByIdAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.League.GetLeagueByIdAsync(RiotApiTestBase.SummonersRegion, "5ae26d6d-c07a-3d29-ae0f-1ac9ca4a4f4a");

                Assert.IsTrue(leagues.Result.Queue != null);
                Assert.AreEqual(Tier.Challenger, leagues.Result.Tier);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueEntriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.League.GetLeagueEntriesAsync(RiotApiTestBase.SummonersRegion,
                    RiotSharp.Misc.Queue.RankedSolo5x5,
                    Tier.Bronze,
                    Division.I);

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueGrandmastersByQueueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.League.GetLeagueGrandmastersByQueueAsync(RiotApiTestBase.SummonersRegion, RiotSharp.Misc.Queue.RankedSolo5x5);

                Assert.IsTrue(leagues.Result.Queue != null);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.League.GetChallengerLeagueAsync(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var league = Api.League.GetMasterLeagueAsync(Summoner1And2Region, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }
    }
}
