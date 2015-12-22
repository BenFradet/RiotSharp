using System;
using System.Collections.Generic;
using RiotSharp;
using RiotSharp.MatchEndpoint;
using RiotSharp.TournamentEndpoint;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RiotSharpTest
{
    [TestClass]
    public class TournamentRiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["TournamentApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        private static Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["TournamentRegion"]);
        private static string tournamentCode = ConfigurationManager.AppSettings["TournamentCode"];
        private static long matchId = long.Parse(ConfigurationManager.AppSettings["MatchId"]);
        private static long tournamentId = int.Parse(ConfigurationManager.AppSettings["TournamentId"]);
        private static string url = "http://www.example.com";
        private static string tournamentName = "RiotSharpTestTournament";
        private static TournamentSpectatorType spectatorType = TournamentSpectatorType.All;
        private static TournamentPickType pickType = TournamentPickType.TournamentDraft;
        private static TournamentMapType mapType = TournamentMapType.SummonersRift;

        private static TournamentRiotApi api = TournamentRiotApi.GetInstance(apiKey);

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void CreateProvider_CreateTournament_CreateTournamentCode_UpdateTournamentCode_Test()
        {
            var provider = api.CreateProvider(region, url);
            Assert.AreNotEqual(0, provider.Id);
            var tournament = api.CreateTournament(provider.Id, tournamentName);
            Assert.AreNotEqual(0, tournament.Id);
            var tournamentCode = api.CreateTournamentCode(tournament.Id, 1, new List<long> { id, id2 }, spectatorType, pickType, mapType, string.Empty);
            Assert.AreNotEqual("", tournamentCode);
            var tournamentCodes = api.CreateTournamentCodes(tournament.Id, 1, spectatorType, pickType, mapType, string.Empty, 2);
            Assert.AreEqual(2, tournamentCodes.Count);
            api.UpdateTournamentCode(tournamentCode, new List<long> { id, id2 }, TournamentSpectatorType.All, TournamentPickType.AllRandom, TournamentMapType.HowlingAbyss);
        }

        [TestMethod]
        [TestCategory("TournamentRiotApi")]
        public void GetTournamentCodeDetails_Test()
        {
            var details = api.GetTournamentCodeDetails(tournamentCode);
            Assert.AreEqual(tournamentId, details.TournamentId);
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
        
    }
}
