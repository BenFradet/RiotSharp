using RiotSharp.Misc;
using RiotSharp.TournamentEndpoint.Enums;
using System;
using System.Linq;

namespace RiotSharp.Test
{
    public class TournamentRiotApiTestBase : CommonTestBase
    {    
        public static string tournamentApiKey = configuration["TournamentApiKey"];
        public static Region tournamentRegion = (Region)Enum.Parse(typeof(Region), "euw");
        public static string tournamentName = "RiotSharp.TestTournament";
        public static string tournamentUrl = "http://example.com";

        public static TournamentSpectatorType tournamentSpectatorType = 
            (TournamentSpectatorType)Enum.Parse(typeof(TournamentSpectatorType), "All");
        public static TournamentPickType tournamentPickType = 
            (TournamentPickType)Enum.Parse(typeof(TournamentPickType), "TournamentDraft");
        public static TournamentMapType tournamentMapType = 
            (TournamentMapType)Enum.Parse(typeof(TournamentMapType), "SummonersRift");

        protected static readonly TournamentRiotApi api = TournamentRiotApi.GetInstance(tournamentApiKey, useStub: true);

        public static int providerId = api.CreateProvider(Region.na, tournamentUrl);
        public static int tournamentId = api.CreateTournament(providerId, tournamentName);
        public static string tournamentCode = api.CreateTournamentCodes(tournamentId, 1, 5, tournamentSpectatorType, tournamentPickType, tournamentMapType).First();
    }
}
