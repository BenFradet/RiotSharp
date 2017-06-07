using RiotSharp.Misc;
using RiotSharp.TournamentEndpoint.Enums;
using System;

namespace RiotSharp.Test
{
    public class TournamentRiotApiTestBase : CommonTestBase
    {
        public static string tournamentApiKey = Configuration["TournamentApiKey"];
        public static Region tournamentRegion = (Region)Enum.Parse(typeof(Region), "euw");
        public static string tournamentName = "RiotSharp.TestTournament";
        public static string tournamentUrl = "http://example.com";
        public static TournamentSpectatorType tournamentSpectatorType = 
            (TournamentSpectatorType)Enum.Parse(typeof(TournamentSpectatorType), "All");
        public static TournamentPickType tournamentPickType = 
            (TournamentPickType)Enum.Parse(typeof(TournamentPickType), "TournamentDraft");
        public static TournamentMapType tournamentMapType = 
            (TournamentMapType)Enum.Parse(typeof(TournamentMapType), "SummonersRift");
    }
}
