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

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateProvider_CreateTournament_CreateTournamentCode_UpdateTournamentCode_Test()
        {
            var provider = api.CreateProvider(region, url);
            Assert.AreNotEqual(0, provider.Id);
            var tournament = api.CreateTournament(provider.Id, tournamentName);
            Assert.AreNotEqual(0, tournament.Id);
            var tmpTournamentCode = api.CreateTournamentCode(tournament.Id, 1, new List<long> { id, id2 }, spectatorType,
                pickType, mapType, string.Empty);
            Assert.AreNotEqual("", tmpTournamentCode);
            var tournamentCodes = api.CreateTournamentCodes(tournament.Id, 1, spectatorType, pickType, mapType,
                string.Empty, 2);
            Assert.AreEqual(2, tournamentCodes.Count);

            var tournamentCodeDetails = api.GetTournamentCodeDetails(tmpTournamentCode);
            var success = api.UpdateTournamentCode(tmpTournamentCode, null, null, TournamentPickType.AllRandom,
                TournamentMapType.HowlingAbyss);
            Assert.IsTrue(success);
            var tournamentCodeDetailsUpdated = api.GetTournamentCodeDetails(tmpTournamentCode);
            Assert.AreNotEqual(tournamentCodeDetails.PickType, tournamentCodeDetailsUpdated.PickType);
            Assert.AreNotEqual(tournamentCodeDetails.Map, tournamentCodeDetailsUpdated.Map);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentMatchId_Test()
        {
            var id = api.GetTournamentMatchId(region, tournamentCode);
            Assert.AreEqual(matchId, id);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentMatch_Test()
        {
            var details = api.GetTournamentMatch(region, matchId, tournamentCode, false);
            Assert.AreEqual(Season.PreSeason2016, details.Season);
            Assert.AreEqual("5.24.0.256", details.MatchVersion);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void CreateProviderAsync_CreateTournamentAsync_CreateTournamentCodeAsync_UpdateTournamentCodeAsync_Test()
        {
            var provider = api.CreateProviderAsync(region, url).Result;
            Assert.AreNotEqual(0, provider.Id);
            var tournament = api.CreateTournamentAsync(provider.Id, tournamentName).Result;
            Assert.AreNotEqual(0, tournament.Id);
            var tmpTournamentCode = api
                .CreateTournamentCodeAsync(tournament.Id, 1, new List<long> { id, id2 }, spectatorType, pickType, mapType, string.Empty)
                .Result;
            Assert.AreNotEqual("", tmpTournamentCode);
            var tournamentCodes = api
                .CreateTournamentCodesAsync(tournament.Id, 1, spectatorType, pickType, mapType, string.Empty, 2)
                .Result;
            Assert.AreEqual(2, tournamentCodes.Count);
            var tournamentCodeDetails = api.GetTournamentCodeDetails(tmpTournamentCode);
            var success = api
                .UpdateTournamentCodeAsync(tmpTournamentCode,
                    new List<long> { id, id2 }, TournamentSpectatorType.All,
                    TournamentPickType.AllRandom, TournamentMapType.HowlingAbyss)
                .Result;
            Assert.IsTrue(success);
            var tournamentCodeDetailsUpdated = api.GetTournamentCodeDetails(tmpTournamentCode);
            Assert.AreNotEqual(tournamentCodeDetails.PickType, tournamentCodeDetailsUpdated.PickType);
            Assert.AreNotEqual(tournamentCodeDetails.Map, tournamentCodeDetailsUpdated.Map);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void GetTournamentMatchIdAsync_Test()
        {
            var id = api.GetTournamentMatchIdAsync(region, tournamentCode).Result;
            Assert.AreEqual(matchId, id);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("TournamentRiotApi"), TestCategory("Async")]
        public void GetTournamentMatchAsync_Test()
        {
            var details = api.GetTournamentMatchAsync(region, matchId, tournamentCode, false).Result;
            Assert.AreEqual(Season.PreSeason2016, details.Season);
            Assert.AreEqual("5.24.0.256", details.MatchVersion);
        }
    }
}
