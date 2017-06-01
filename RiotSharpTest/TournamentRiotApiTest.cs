using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.MatchEndpoint.Enums;
using System;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharpTest
{
    [TestClass]
    public class TournamentRiotApiTest : CommonTestBase
    {
        private static readonly TournamentRiotApi api = TournamentRiotApi.GetInstance(TournamentRiotApiTestBase.tournamentApiKey);

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateProvider_CreateTournament_CreateTournamentCode_UpdateTournamentCode_Test()
        {
            EnsureCredibility(() =>
            {
                var providerId = api.CreateProvider(TournamentRiotApiTestBase.tournamentRegion, 
                    TournamentRiotApiTestBase.tournamentUrl);
                var tournamentId = api.CreateTournament(providerId, TournamentRiotApiTestBase.tournamentName);
                Assert.AreNotEqual(0, tournamentId);
                var tournamentCodes = api.CreateTournamentCodes(tournamentId, 2, 5, 
                    TournamentRiotApiTestBase.tournamentSpectatorType,
                    TournamentRiotApiTestBase.tournamentPickType, TournamentRiotApiTestBase.tournamentMapType);
                Assert.AreEqual(2, tournamentCodes.Count);

                var tournamentCode = tournamentCodes[0];
                var tournamentCodeDetails = api.GetTournamentCodeDetails(tournamentCode);
                var success = api.UpdateTournamentCode(tournamentCode, pickType: TournamentPickType.AllRandom,
                    mapType: TournamentMapType.HowlingAbyss);

                Assert.IsTrue(success);
                var tournamentCodeDetailsUpdated = api.GetTournamentCodeDetails(tournamentCode);
                Assert.AreNotEqual(tournamentCodeDetails.PickType, tournamentCodeDetailsUpdated.PickType);
                Assert.AreNotEqual(tournamentCodeDetails.Map, tournamentCodeDetailsUpdated.Map);
            }); 
        }

        [Ignore] // Cannot use constant tournament code
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentMatchId_Test()
        {
            EnsureCredibility(() =>
            {
                var id = api.GetTournamentMatchId(TournamentRiotApiTestBase.tournamentRegion, 
                    TournamentRiotApiTestBase.tournamentCode);
                Assert.AreEqual(TournamentRiotApiTestBase.tournamentMatchId, id);
            });
        }

        [Ignore] // Cannot use constant tournament match id
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentMatch_Test()
        {
            EnsureCredibility(() =>
            {
                var details = api.GetTournamentMatch(TournamentRiotApiTestBase.tournamentRegion,
                TournamentRiotApiTestBase.tournamentMatchId, TournamentRiotApiTestBase.tournamentCode, false);
                Assert.AreEqual(Season.PreSeason2016, details.Season);
                Assert.AreEqual("5.24.0.256", details.MatchVersion);
            });
        }

        [Ignore] // Cannot use constant tournament id
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateProviderAsync_CreateTournamentAsync_CreateTournamentCodeAsync_UpdateTournamentCodeAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var providerId = api.CreateProviderAsync(TournamentRiotApiTestBase.tournamentRegion,
                TournamentRiotApiTestBase.tournamentUrl).Result;
                var tournamentId = api.CreateTournamentAsync(providerId, TournamentRiotApiTestBase.tournamentName).Result;
                Assert.AreNotEqual(0, tournamentId);
                var tournamentCodes = api.CreateTournamentCodesAsync(tournamentId, 2, 5, 
                    TournamentRiotApiTestBase.tournamentSpectatorType,
                    TournamentRiotApiTestBase.tournamentPickType, TournamentRiotApiTestBase.tournamentMapType).Result;
                Assert.AreEqual(2, tournamentCodes.Count);

                var tournamentCode = tournamentCodes[0];
                var tournamentCodeDetails = api.GetTournamentCodeDetailsAsync(tournamentCode).Result;
                var success = api.UpdateTournamentCodeAsync(tournamentCode, pickType: TournamentPickType.AllRandom,
                    mapType: TournamentMapType.HowlingAbyss).Result;

                Assert.IsTrue(success);
                var tournamentCodeDetailsUpdated = api.GetTournamentCodeDetailsAsync(tournamentCode).Result;
                Assert.AreNotEqual(tournamentCodeDetails.PickType, tournamentCodeDetailsUpdated.PickType);
                Assert.AreNotEqual(tournamentCodeDetails.Map, tournamentCodeDetailsUpdated.Map);
            });
        }

        [Ignore] // Cannot use constant tournament code
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void GetTournamentMatchIdAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var id = api.GetTournamentMatchIdAsync(TournamentRiotApiTestBase.tournamentRegion,
                TournamentRiotApiTestBase.tournamentCode).Result;
                Assert.AreEqual(TournamentRiotApiTestBase.tournamentMatchId, id);
            });
        }

        [Ignore] // Cannot use constant tournament match id
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void GetTournamentMatchAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var details = api.GetTournamentMatchAsync(TournamentRiotApiTestBase.tournamentRegion,
                TournamentRiotApiTestBase.tournamentMatchId, TournamentRiotApiTestBase.tournamentCode, false).Result;
                Assert.AreEqual(Season.PreSeason2016, details.Season);
                Assert.AreEqual("5.24.0.256", details.MatchVersion);
            });
        }

        #region CreateTournamentCodes
       
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodes_InvalidTeamSize_ThrowsArgumentException()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    // Act 
                    var tournamentCodes = api.CreateTournamentCodes(0, 1, 0, TournamentSpectatorType.All,
                        TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift);
                }
                catch (ArgumentException e)
                {
                    // Assert
                    Assert.IsInstanceOfType(e, typeof(ArgumentException));
                    Assert.AreEqual("teamSize", e.ParamName);
                }
            });
        }
         
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_InvalidTeamSize_ThrowsArgumentException()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    // Act 
                    var tournamentCodes = api.CreateTournamentCodesAsync(0, 1, 0, TournamentSpectatorType.All,
                        TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift).Result;
                }
                catch (AggregateException e)
                {
                    // Assert
                    Assert.IsInstanceOfType(e, typeof(AggregateException));
                    Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));
                    var argumentException = (ArgumentException)e.InnerException;
                    Assert.AreEqual("teamSize", argumentException.ParamName);
                }
            });
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodes_CountGreaterThan1000_ThrowsArgumentException()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    // Act 
                    var tournamentCodes = api.CreateTournamentCodes(0, 1001, 5, TournamentSpectatorType.All,
                        TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift);
                }
                catch (ArgumentException e)
                {
                    // Assert
                    Assert.IsInstanceOfType(e, typeof(ArgumentException));
                    Assert.AreEqual("count", e.ParamName);
                }
            });
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_CountGreaterThan1000_ThrowsArgumentException()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    // Act 
                    var tournamentCodes = api.CreateTournamentCodesAsync(0, 1001, 5, TournamentSpectatorType.All,
                        TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift).Result;
                }
                catch (AggregateException e)
                {
                    // Assert
                    Assert.IsInstanceOfType(e, typeof(AggregateException));
                    Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));
                    var argumentException = (ArgumentException)e.InnerException;
                    Assert.AreEqual("count", argumentException.ParamName);
                }
            });
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodes_CountLessThan1_ThrowsArgumentException()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    // Act 
                    var tournamentCodes = api.CreateTournamentCodes(0, 0, 5, TournamentSpectatorType.All,
                        TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift);
                }
                catch (ArgumentException e)
                {
                    // Assert
                    Assert.IsInstanceOfType(e, typeof(ArgumentException));
                    Assert.AreEqual("count", e.ParamName);
                }
            });
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_CountLessThan1_ThrowsArgumentException()
        {
            EnsureCredibility(() =>
            {
                try
                {
                    // Act 
                    var tournamentCodes = api.CreateTournamentCodesAsync(0, 0, 5, TournamentSpectatorType.All,
                        TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift).Result;
                }
                catch (AggregateException e)
                {
                    // Assert
                    Assert.IsInstanceOfType(e, typeof(AggregateException));
                    Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));
                    var argumentException = (ArgumentException)e.InnerException;
                    Assert.AreEqual("count", argumentException.ParamName);
                }
            });
        }

        #endregion
    }
}
