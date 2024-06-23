using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Endpoints.MatchEndpoint.Enums;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiTest : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        // The maximum time range allowed is one week, otherwise a 400 error code is returned.
        private static readonly DateTime BeginTime = DateTime.Now.AddDays(-6);
        private static DateTime EndTime => DateTime.Now;

        #region Account Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetAccountByPuuidAsync_ExistingPuuid_ReturnAccount()
        {
            EnsureCredibility(() =>
            {
                var accountFromRid = Api.Account.GetAccountByRiotIdAsync(RiotSharp.Misc.Region.Americas, AccountGameName, AccountTagLine).Result;
                var accountFromPuuid = Api.Account.GetAccountByPuuidAsync(RiotSharp.Misc.Region.Americas, accountFromRid.Puuid).Result;

                Assert.AreEqual(accountFromRid.Puuid, accountFromPuuid.Puuid);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetAccounBytRiotIdAsync_ExistingAccount_ReturnAccount()
        {
            EnsureCredibility(() =>
            {
                var account = Api.Account.GetAccountByRiotIdAsync(RiotSharp.Misc.Region.Americas, AccountGameName, AccountTagLine).Result;

                Assert.IsNotNull(account.Puuid);
                Assert.IsNotNull(account.GameName);
                Assert.IsNotNull(account.TagLine);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetActiveShardByPuuidAsync_LoR_ExistingPuuid_ReturnActiveShard()
        {
            EnsureCredibility(() =>
            {
                var accountFromRid = Api.Account.GetAccountByRiotIdAsync(RiotSharp.Misc.Region.Americas, AccountGameName, AccountTagLine).Result;
                var activeShard = Api.Account.GetActiveShardByPuuidAsync(RiotSharp.Misc.Region.Americas, Endpoints.AccountEndpoint.Enums.Game.LoR, accountFromRid.Puuid).Result;

                Assert.AreEqual(activeShard.Puuid, accountFromRid.Puuid);
            });
        }
        #endregion

        #region Summoner Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerBySummonerIdAsync_ExistingId_ReturnSummoner()
        {
            EnsureCredibility(() =>
            {
                var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name).Result;
                var summoner = Api.Summoner.GetSummonerBySummonerIdAsync(Summoner1Platform, summonerFromName.Id);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByAccountIdAsync_ExistingAccountId_ReturnSummoner()
        {
            EnsureCredibility(() =>
            {
                var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name).Result;
                var summoner = Api.Summoner.GetSummonerByAccountIdAsync(Summoner1Platform, summonerFromName.AccountId);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerByNameAsync_ExistingName_ReturnSummoner()
        {
            EnsureCredibility(() =>
            {
                var summoner = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetSummonerBySummonerPuuidAsync_ExistingId_ReturnSummoner()
        {
            EnsureCredibility(() =>
            {
                var accountFromRid = Api.Account.GetAccountByRiotIdAsync(RiotSharp.Misc.Region.Americas, AccountGameName, AccountTagLine).Result;
                var summoner = Api.Summoner.GetSummonerByPuuidAsync(Summoner1Platform, accountFromRid.Puuid);

                Assert.AreEqual(Summoner1Name, summoner.Result.Name);
            });
        }
        #endregion

        #region Champion Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionRotationAsync_TestChampionRotationValues_ReturnAnChampionRotation()
        {
            EnsureCredibility(() =>
            {
                var championRotation = Api.Champion.GetChampionRotationAsync(Summoner1Platform).Result;

                Assert.IsTrue(championRotation.FreeChampionIds.Count() >= 14);
                Assert.IsTrue(championRotation.FreeChampionIdsForNewPlayers.Count() >= 10);
                Assert.IsTrue(championRotation.MaxNewPlayerLevel > 0);
            });
        }
        #endregion

        #region League Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueEntriesBySummonerAsync_ProperlyImplementEncryptedSummonerId_ReturnTrue()
        {
            EnsureCredibility(() =>
            {
                // TODO: Properly implement encrypted SummonerId tests
                return;
                var leagues = Api.League.GetLeagueEntriesBySummonerAsync(RiotApiTestBase.SummonersPlatform, RiotApiTestBase.SummonerIds.FirstOrDefault());

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueByIdAsync_ProperlyImplementLeagueId_ReturnTrue()
        {
            EnsureCredibility(() =>
            {
                // TODO: Properly implement League id test
                return;
                var leagues = Api.League.GetLeagueByIdAsync(RiotApiTestBase.SummonersPlatform, "LEAGUE-ID-HERE");

                Assert.IsTrue(leagues.Result.Queue != null);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueEntriesAsync_GetLeagueEntries_ReturnLeagueEntries()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.League.GetLeagueEntriesAsync(RiotApiTestBase.SummonersPlatform,
                    Endpoints.LeagueEndpoint.Enums.Division.I,
                    Endpoints.LeagueEndpoint.Enums.Tier.Bronze,
                    RiotSharp.Misc.Queue.RankedSolo5x5);

                Assert.IsTrue(leagues.Result.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetLeagueGrandmastersByQueueAsync_GetLeagueGrandmastersByQueue_ReturnLeagueGrandmastersByQueue()
        {
            EnsureCredibility(() =>
            {
                var leagues = Api.League.GetLeagueGrandmastersByQueueAsync(RiotApiTestBase.SummonersPlatform, RiotSharp.Misc.Queue.RankedSolo5x5);

                Assert.IsTrue(leagues.Result.Queue != null);
            });
        }


        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChallengerLeagueAsync_GetsAChallengerLeague_ReturnChallengerLeague()
        {
            EnsureCredibility(() =>
            {
                var league = Api.League.GetChallengerLeagueAsync(Summoner1Platform, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMasterLeagueAsync_GetsAMasterLeague_ReturnMasterLeague()
        {
            EnsureCredibility(() =>
            {
                var league = Api.League.GetMasterLeagueAsync(Summoner1Platform, RiotApiTestBase.Queue);

                Assert.IsTrue(league.Result.Entries.Count > 0);
            });
        }
        #endregion

        #region Match Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchAsync_GetMatchPerks_ReturnMatchPerks()
        {
            EnsureCredibility(() =>
            {
                var match = Api.Match.GetMatchAsync(RiotSharp.Misc.Region.Americas, RiotApiTestBase.GameId).Result;

                Assert.IsNotNull(match);
                Assert.IsNotNull(match.Metadata);
                Assert.AreEqual(RiotApiTestBase.GameId, match.Metadata.MatchId);
                Assert.IsNotNull(match.Info);
                Assert.IsNotNull(match.Info.Participants);
                Assert.IsNotNull(match.Info.Teams);
                foreach (var participant in match.Info.Participants)
                {
                    Assert.IsNotNull(participant.Perks);
                    Assert.IsNotNull(participant.Perks.StatPerks);
                    Assert.IsNotNull(participant.Perks.Styles);
                    Assert.AreEqual(2, participant.Perks.Styles.Count);
                    foreach (var style in participant.Perks.Styles)
                    {
                        Assert.IsNotNull(style);
                        foreach (var selection in style.Selections)
                        {
                            Assert.IsTrue(selection.Perk != 0);
                        }
                    }
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchTimelineAsync_GetMatchTimeline_ReturnMatchTimeline()
        {
            EnsureCredibility(() =>
            {
                var matchTimeline = Api.Match.GetMatchTimelineAsync(RiotApiTestBase.SummonersRegion, RiotApiTestBase.GameId).Result;

                Assert.IsNotNull(matchTimeline);
                Assert.IsNotNull(matchTimeline.Info);
                Assert.IsNotNull(matchTimeline.Info.Frames);
                Assert.AreEqual(TimeSpan.FromMilliseconds(0), matchTimeline.Info.Frames.First().Timestamp);
                Assert.AreEqual(TimeSpan.FromMilliseconds(60000), matchTimeline.Info.FrameInterval);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_GetMatchList_ReturnMatchList()
        {
            EnsureCredibility(() =>
            {
                var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name).Result;
                var matches = Api.Match.GetMatchListAsync(Summoner1Region, summonerFromName.Puuid).Result;

                Assert.IsTrue(matches.Any());
            });
        }

        [TestMethod]
        [Ignore] // TODO: Unstable IDs
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetMatchListAsync_GetMatchListQueues_ReturnMatchList()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
                        RiotApiTestBase.AccountIds.First(), null,
                        RiotApiTestBase.QueueId).Result;

                    Assert.IsTrue(matches.Any());
                });
            }, "No Matches found fot the test summoner (404).");
        }

        // TODO
        //[TestMethod]
        //[TestCategory("RiotApi"), TestCategory("Async")]
        //public void GetMatchListAsync_GetMatchListDateTimes_ReturnMatchList()
        //{
        //    EnsureCredibility(() =>
        //    {
        //        var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
        //            RiotApiTestBase.AccountIds.First(), null, null, null, BeginTime, EndTime).Result.Matches;

        //        foreach (var match in matches)
        //        {
        //            Assert.IsTrue(DateTime.Compare(match.Timestamp, BeginTime) >= 0);
        //            Assert.IsTrue(DateTime.Compare(match.Timestamp, EndTime) <= 0);
        //        }
        //    });
        //}

        // TODO
        //[TestMethod]
        //[TestCategory("RiotApi"), TestCategory("Async")]
        //public void GetMatchListAsync_UseTheIndexToTest_ReturnMatches()
        //{
        //    EnsureCredibility(() =>
        //    {
        //        const int beginIndex = 0;
        //        const int endIndex = 32;

        //        var matches = Api.Match.GetMatchListAsync(RiotApiTestBase.SummonersRegion,
        //            RiotApiTestBase.Summoner1AccountId, null, null, null, null, null, beginIndex, endIndex).Result.Matches;

        //        Assert.IsTrue(matches.Count <= endIndex - beginIndex);
        //    });
        //}
        #endregion

        #region Spectator Tests
        [Ignore] // Needs to be manually adjusted for testing
        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetCurrentGameAsync_GetCurrentGame_ReturnGetCurrentGame()
        {
            EnsureCredibility(() =>
            {
                var currentGame = Api.Spectator.GetCurrentGameAsync(RiotSharp.Misc.Region.Euw, "w1_k11kGq3N2zydfKN5xc7XcGwv-4jrnJJGsuQfHJmDFVFs").Result;

                Assert.IsNotNull(currentGame);
                Assert.IsTrue(currentGame.GameId != 0);
                Assert.IsNotNull(currentGame.Participants);
                Assert.IsNotNull(currentGame.GameStartTime);
                Assert.IsNotNull(currentGame.GameQueueType);
                Assert.IsNotNull(currentGame.Observers);
                foreach (var participant in currentGame.Participants)
                {
                    Assert.IsNotNull(participant.Perks);
                    Assert.IsNotNull(participant.GameCustomizationObjects);
                }
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetFeaturedGamesAsync_GetFeaturedGames_ReturnGetFeaturedGames()
        {
            EnsureCredibility(() =>
            {
                var games = Api.Spectator.GetFeaturedGamesAsync(Summoner1Platform).Result;

                Assert.IsNotNull(games);
                Assert.IsNotNull(games.GameList);
                foreach (var game in games.GameList)
                {
                    Assert.IsNotNull(game);
                    Assert.IsTrue(game.GameId != 0);
                    Assert.IsNotNull(game.Participants);
                    Assert.IsNotNull(game.GameStartTime);
                    Assert.IsNotNull(game.GameQueueType);
                    Assert.IsNotNull(game.Observers);
                }
            });
        }
        #endregion

        #region Champion Mastery Tests

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionMasteryAsync_GetAChampionMastery_ReturnChampionMastery()
        {
            EnsureCredibility(() =>
            {
                var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name).Result;
                var championMastery = Api.ChampionMastery.GetChampionMasteryAsync(Summoner1Platform,
                    summonerFromName.Id, RiotApiTestBase.Summoner1MasteryChampionId).Result;

                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionId,
                    championMastery.ChampionId);
                Assert.AreEqual(RiotApiTestBase.Summoner1MasteryChampionLevel,
                    championMastery.ChampionLevel);
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetChampionsMasteriesAsync_GetsChampionMasteries_ReturnChampionMasteries()
        {
            EnsureCredibility(() =>
            {
                var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name).Result;
                var allChampionsMastery = Api.ChampionMastery.GetChampionMasteriesAsync(
                    Summoner1Platform, summonerFromName.Id).Result;

                Assert.IsNotNull(allChampionsMastery.Find(championMastery =>
                    championMastery.ChampionId == RiotApiTestBase.Summoner1MasteryChampionId));
            });
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetTotalChampionMasteryScoreAsync_GetsTheTotalChampionMasteryScore_ReturnTotalChampionMasteryScore()
        {
            EnsureCredibility(() =>
            {
                var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner1Platform, Summoner1Name).Result;
                var totalChampionMasteryScore = Api.ChampionMastery.GetTotalChampionMasteryScoreAsync(
                    Summoner1Platform, summonerFromName.Id).Result;

                Assert.IsTrue(totalChampionMasteryScore > -1);
            });
        }
        #endregion

        #region Third Party Tests
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetThirdPartyCodeBySummonerIdAsync_GetThirdPartyCodeBySummonerId_ReturnThirdPartyCodeBySummonerIdResult()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner3Platform, Summoner3Name).Result;
                    var code = Api.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Summoner3Platform, summonerFromName.Id).Result;

                    Assert.AreEqual(RiotApiTestBase.ThirdPartyCode, code);
                });
            }, "Third party code was not found for the summoner. (404)");
        }

        [TestMethod]
        [TestCategory("RiotApi"), TestCategory("Async")]
        public void GetThirdPartyCodeBySummonerIdAsync_GetThirdPartyCodeBySummonerId_ReturnThirdPartyCodeBySummonerId()
        {
            EnsureData(() =>
            {
                EnsureCredibility(() =>
                {
                    var summonerFromName = Api.Summoner.GetSummonerByNameAsync(Summoner3Platform, Summoner3Name).Result;
                    var code = Api.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Summoner3Platform, summonerFromName.Id);

                    Assert.AreEqual(RiotApiTestBase.ThirdPartyCode, code.Result);
                });
            }, "Third party code was not found for the summoner. (404)");
        }
        #endregion
    }
}
