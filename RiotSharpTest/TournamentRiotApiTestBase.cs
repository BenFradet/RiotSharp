using RiotSharp.Misc;
using RiotSharp.TournamentEndpoint.Enums;
using System;
using System.Configuration;

namespace RiotSharpTest
{
    public class TournamentRiotApiTestBase : CommonTestBase
    {
        public static string tournamentApiKey = ConfigurationManager.AppSettings["TournamentApiKey"];
        public static Region tournamentRegion = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["TournamentRegion"]);
        public static string tournamentCode = ConfigurationManager.AppSettings["TounamentCode"];
        public static long tournamentMatchId = long.Parse(ConfigurationManager.AppSettings["TournamentMatchId"]);
        public static int tournamentId = int.Parse(ConfigurationManager.AppSettings["TournamentId"]);
        public static string tournamentName = ConfigurationManager.AppSettings["TournamentMatchName"];
        public static string tournamentUrl = ConfigurationManager.AppSettings["TournamentUrl"];
        public static TournamentSpectatorType tournamentSpectatorType = (TournamentSpectatorType)Enum.Parse(typeof(TournamentSpectatorType), ConfigurationManager.AppSettings["TournamentSpectatorType"]);
        public static TournamentPickType tournamentPickType = (TournamentPickType)Enum.Parse(typeof(TournamentPickType), ConfigurationManager.AppSettings["TournamentPickType"]);
        public static TournamentMapType tournamentMapType = (TournamentMapType)Enum.Parse(typeof(TournamentMapType), ConfigurationManager.AppSettings["TournamentMapType"]);

    }
}
