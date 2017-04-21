using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.MatchEndpoint.Enums;
using RiotSharp.TournamentEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharpTest
{
    [TestClass]
    public class TournamentRiotApiTest
    {
        private static readonly string apiKey = ConfigurationManager.AppSettings["TournamentApiKey"];
        private static readonly int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static readonly int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);

        private static readonly Region region =
            (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["TournamentRegion"]);

        private static readonly string tournamentCode = ConfigurationManager.AppSettings["TournamentCode"];
        private static readonly long matchId = long.Parse(ConfigurationManager.AppSettings["MatchId"]);
        private static readonly string url = "http://www.example.com";
        private static readonly string tournamentName = "RiotSharpTestTournament";
        private static readonly TournamentSpectatorType spectatorType = TournamentSpectatorType.All;
        private static readonly TournamentPickType pickType = TournamentPickType.TournamentDraft;
        private static readonly TournamentMapType mapType = TournamentMapType.SummonersRift;

        private static readonly TournamentRiotApi api = TournamentRiotApi.GetInstance(apiKey);

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateProvider_CreateTournament_CreateTournamentCode_UpdateTournamentCode_Test()
        {
            var providerId = api.CreateProvider(region, url);
            Assert.AreNotEqual(0, id);
            var tournamentId = api.CreateTournament(providerId, tournamentName);
            Assert.AreNotEqual(0, tournamentId);
            var tournamentCodes = api.CreateTournamentCodes(tournamentId, 2, 5, spectatorType, pickType, mapType);
            Assert.AreEqual(2, tournamentCodes.Count);

            var tournamentCode = tournamentCodes[0];
            var tournamentCodeDetails = api.GetTournamentCodeDetails(tournamentCode);
            var success = api.UpdateTournamentCode(tournamentCode, pickType: TournamentPickType.AllRandom,
                mapType: TournamentMapType.HowlingAbyss);
            Assert.IsTrue(success);
            var tournamentCodeDetailsUpdated = api.GetTournamentCodeDetails(tournamentCode);
            Assert.AreNotEqual(tournamentCodeDetails.PickType, tournamentCodeDetailsUpdated.PickType);
            Assert.AreNotEqual(tournamentCodeDetails.Map, tournamentCodeDetailsUpdated.Map);
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentMatchId_Test()
        {
            var id = api.GetTournamentMatchId(region, tournamentCode);
            Assert.AreEqual(matchId, id);
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentMatch_Test()
        {
            var details = api.GetTournamentMatch(region, matchId, tournamentCode, false);
            Assert.AreEqual(Season.PreSeason2016, details.Season);
            Assert.AreEqual("5.24.0.256", details.MatchVersion);
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateProviderAsync_CreateTournamentAsync_CreateTournamentCodeAsync_UpdateTournamentCodeAsync_Test()
        {
            var providerId = api.CreateProviderAsync(region, url).Result;
            Assert.AreNotEqual(0, id);
            var tournamentId = api.CreateTournamentAsync(providerId, tournamentName).Result;
            Assert.AreNotEqual(0, tournamentId);
            var tournamentCodes = api.CreateTournamentCodesAsync(tournamentId, 2, 5, spectatorType, pickType, mapType).Result;
            Assert.AreEqual(2, tournamentCodes.Count);

            var tournamentCode = tournamentCodes[0];
            var tournamentCodeDetails = api.GetTournamentCodeDetailsAsync(tournamentCode).Result;
            var success = api.UpdateTournamentCodeAsync(tournamentCode, pickType: TournamentPickType.AllRandom,
                mapType: TournamentMapType.HowlingAbyss).Result;
            Assert.IsTrue(success);
            var tournamentCodeDetailsUpdated = api.GetTournamentCodeDetailsAsync(tournamentCode).Result;
            Assert.AreNotEqual(tournamentCodeDetails.PickType, tournamentCodeDetailsUpdated.PickType);
            Assert.AreNotEqual(tournamentCodeDetails.Map, tournamentCodeDetailsUpdated.Map);
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void GetTournamentMatchIdAsync_Test()
        {
            var id = api.GetTournamentMatchIdAsync(region, tournamentCode).Result;
            Assert.AreEqual(matchId, id);
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void GetTournamentMatchAsync_Test()
        {
            var details = api.GetTournamentMatchAsync(region, matchId, tournamentCode, false).Result;
            Assert.AreEqual(Season.PreSeason2016, details.Season);
            Assert.AreEqual("5.24.0.256", details.MatchVersion);
        }

        #region CreateTournamentCodes
       
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodes_InvalidTeamSize_ThrowsArgumentException()
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
        }
         
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_InvalidTeamSize_ThrowsArgumentException()
        {
            try
            {
                // Act 
                var tournamentCodes = api.CreateTournamentCodesAsync(0, 1, 0, TournamentSpectatorType.All, 
                    TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift).Result;
            }
            catch(AggregateException e)
            {
                // Assert
                Assert.IsInstanceOfType(e, typeof(AggregateException));
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));
                var argumentException = (ArgumentException)e.InnerException;
                Assert.AreEqual("teamSize", argumentException.ParamName);
            }
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodes_CountGreaterThan1000_ThrowsArgumentException()
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
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_CountGreaterThan1000_ThrowsArgumentException()
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
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodes_CountLessThan1_ThrowsArgumentException()
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
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodesAsync_CountLessThan1_ThrowsArgumentException()
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
        }

        #endregion

        #region CreateTournamentCode

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateTournamentCodeV1_InvalidTeamSize_ThrowsArgumentException()
        {
            try
            {
                // Act 
                var tournamentCodes = api.CreateTournamentCodeV1(0, 0, null, TournamentSpectatorType.All, 
                    TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift, string.Empty);
            }
            catch (ArgumentException e)
            {
                // Assert
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual("teamSize", e.ParamName);
            }
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateTournamentCodeAsync_InvalidTeamSize_ThrowsArgumentException()
        {
            try
            {
                // Act 
                var tournamentCodes = api.CreateTournamentCodeV1Async(0, 0, null, TournamentSpectatorType.All, 
                    TournamentPickType.TournamentDraft, TournamentMapType.SummonersRift, string.Empty).Result;
            }
            catch (AggregateException e)
            {
                // Assert
                Assert.IsInstanceOfType(e, typeof(AggregateException));
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));
                var argumentException = (ArgumentException)e.InnerException;
                Assert.AreEqual("teamSize", argumentException.ParamName);
            }
        }

        #endregion
    }
}
