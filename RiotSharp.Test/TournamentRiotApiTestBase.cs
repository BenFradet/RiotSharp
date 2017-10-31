using RiotSharp.Misc;
using RiotSharp.TournamentEndpoint.Enums;
using System;
using System.Linq;

namespace RiotSharp.Test
{
    public class TournamentRiotApiTestBase : CommonTestBase
    {    
        public static string TournamentApiKey = Configuration["TournamentApiKey"];
        public static Region TournamentRegion = (Region)Enum.Parse(typeof(Region), "euw");
        public static string TournamentName = "RiotSharp.TestTournament";
        public static string TournamentUrl = "http://example.com";

        public static TournamentSpectatorType tournamentSpectatorType = 
            (TournamentSpectatorType)Enum.Parse(typeof(TournamentSpectatorType), "All");
        public static TournamentPickType tournamentPickType = 
            (TournamentPickType)Enum.Parse(typeof(TournamentPickType), "TournamentDraft");
        public static TournamentMapType tournamentMapType = 
            (TournamentMapType)Enum.Parse(typeof(TournamentMapType), "SummonersRift");

        protected static readonly TournamentRiotApi api = TournamentRiotApi.GetInstance(TournamentApiKey, useStub: true);

        public static int ProviderId = api.CreateProvider(Region.na, TournamentUrl);
        public static int TournamentId = api.CreateTournament(ProviderId, TournamentName);
        public static string TournamentCode = api.CreateTournamentCodes(TournamentId, 1, 5, tournamentSpectatorType, tournamentPickType, tournamentMapType).First();
    }
}
