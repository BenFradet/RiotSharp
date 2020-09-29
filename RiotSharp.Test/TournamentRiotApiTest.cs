using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Endpoints.TournamentEndpoint.Enums;

namespace RiotSharp.Test
{
    [TestClass]
    public class TournamentRiotApiTest : TournamentRiotApiTestBase
    {
        // Cannot use constant tournament id
        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateProviderAsync_CreateATournamentCodeAnd_ReturnUpdateTournamentCodes()
        {
            EnsureCredibility(() =>
            {
                var providerId = api.CreateProviderAsync(TournamentRegion, TournamentUrl).Result;
                var tournamentId = api.CreateTournamentAsync(providerId, TournamentName).Result;
                Assert.AreNotEqual(0, tournamentId);
                var tournamentCodes = api.CreateTournamentCodesAsync(tournamentId, 2, 5, 
                    tournamentSpectatorType,
                    tournamentPickType, tournamentMapType).Result;
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

        #region CreateTournamentCodes

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_InvalidTeamSize_ReturnThrowsArgumentException()
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

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_CountGreaterThan1000_ReturnThrowsArgumentException()
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

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_CountLessThan1_ReturnThrowsArgumentException()
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
