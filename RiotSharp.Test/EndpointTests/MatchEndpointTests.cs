using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class MatchEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IMatchEndpoint _matchEndpoint;

        private const string ResponsePath = "./Resources/MatchEndpoint/MatchList_EUW_Response.txt";

        // The maximum time range allowed is one week, otherwise a 400 error code is returned.
        private static readonly DateTime BeginTime = DateTime.Now.AddDays(-6);
        private static DateTime EndTime => DateTime.Now;

        [TestInitialize]
        public void Initialize()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _matchEndpoint = new MatchEndpoint(_rateLimitedRequester.Object, new PassThroughCache());
        }

        [TestMethod]
        public void GetMatchListAsync2_Test()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(File.ReadAllText(ResponsePath));

            var matchList = _matchEndpoint.GetMatchListAsync(Region.Euw, "SummonerId").Result;

            Assert.IsNotNull(matchList);
            foreach(var matchReference in matchList.Matches)
            {
                Assert.AreEqual(matchReference.PlatformId, Platform.EUW1);
                Assert.AreEqual(matchReference.Region, Region.Euw);
            }
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_RunesMasteries_Test()
        {
            EnsureCredibility(() =>
            {
                var match = Api.Match.GetMatchAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.RunesMasteriesGameId).Result;

                Assert.AreEqual(RiotApiTestBase.RunesMasteriesGameId, match.GameId);
                Assert.IsNotNull(match.ParticipantIdentities);
                Assert.IsNotNull(match.Participants);
                Assert.IsNotNull(match.Teams);
                /*foreach (var participant in match.Participants)
                {
                    //Assert.IsNotNull(participant.Runes);      // List of legacy Rune information. Not included for matches played with Runes Reforged.
                    //Assert.IsNotNull(participant.Masteries);  // List of legacy Mastery information. Not included for matches played with Runes Reforged.
                    //foreach (var rune in participant.Runes)
                    //{
                    //    Assert.IsTrue(rune.RuneId != 0);
                    //    Assert.IsTrue(rune.Rank != 0);
                    //}
                    //foreach (var mastery in participant.Masteries)
                    //{
                    //    Assert.IsTrue(mastery.MasteryId != 0);
                    //    Assert.IsTrue(mastery.Rank != 0);
                    //}
                }*/
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_Perks_Test()
        {
            EnsureCredibility(() =>
            {
                var match = Api.Match.GetMatchAsync(RiotSharp.Misc.Region.Euw, RiotApiTestBase.PerksGameId).Result;

                Assert.AreEqual(RiotApiTestBase.PerksGameId, match.GameId);
                Assert.IsNotNull(match.ParticipantIdentities);
                Assert.IsNotNull(match.Participants);
                Assert.IsNotNull(match.Teams);
                foreach (var participant in match.Participants)
                {
                    Assert.IsTrue(participant.Stats.Perk0 != 0);
                    Assert.IsTrue(participant.Stats.Perk1 != 0);
                    Assert.IsTrue(participant.Stats.Perk2 != 0);
                    Assert.IsTrue(participant.Stats.Perk3 != 0);
                    Assert.IsTrue(participant.Stats.Perk4 != 0);
                    Assert.IsTrue(participant.Stats.Perk5 != 0);
                    Assert.IsTrue(participant.Stats.StatPerk0 != 0);
                    Assert.IsTrue(participant.Stats.StatPerk1 != 0);
                    Assert.IsTrue(participant.Stats.StatPerk2 != 0);
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchTimelineAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matchTimeline = Api.Match.GetMatchTimelineAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.GameId).Result;

                Assert.IsNotNull(matchTimeline.Frames);
                Assert.IsTrue(matchTimeline.Frames.First().Timestamp == TimeSpan.FromMilliseconds(144));
                Assert.IsTrue(matchTimeline.FrameInterval == TimeSpan.FromMilliseconds(60000));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.Summoners1Region,
                    RiotApiTestBase.Summoner1AccountId).Result.Matches;

                Assert.IsTrue(matches.Any());
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_ChampionIds_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(Region.Eun1,
                    RiotApiTestBase.Summoner1AccountId, new List<int> { RiotApiTestBase.ChampionId }).Result.Matches;

                foreach (var match in matches)
                {
                    Assert.AreEqual(RiotApiTestBase.ChampionId.ToString(),
                        match.ChampionID.ToString());
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Queues_Test()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                        RiotApiTestBase.AccountIds[1], null,
                        new List<int> { RiotApiTestBase.QueueId },
                        null, BeginTime, EndTime, 1, 10).Result.Matches;

                    foreach (var match in matches)
                    {
                        Assert.AreEqual(RiotApiTestBase.QueueId, match.Queue);
                    }
                });
            }, "No Matches found fot the test summoner (404).");
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Seasons_Test()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.Summoners1Region,
                        Summoner1AccountId, null, null,
                        new List<Season> { }).Result.Matches;

                    Assert.IsTrue(matches.Any());

                    foreach (var match in matches)
                    {
                        Assert.AreEqual(Season.Season2019.ToString(), match.Season.ToString());
                    }
                });
            }, "No Matches found fot the test summoner (404).");
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_DateTimes_Test()
        {
            EnsureCredibility(() =>
            {
                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                    RiotApiTestBase.AccountIds[0], null, null, null, BeginTime, EndTime).Result.Matches;

                foreach (var match in matches)
                {
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, BeginTime) >= 0);
                    Assert.IsTrue(DateTime.Compare(match.Timestamp, EndTime) <= 0);
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_Index_Test()
        {
            EnsureCredibility(() =>
            {
                const int beginIndex = 0;
                const int endIndex = 32;

                var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.Summoners1Region,
                    RiotApiTestBase.Summoner1AccountId, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

                Assert.IsTrue(matches.Count <= endIndex - beginIndex);
            });
        }

    }
}
