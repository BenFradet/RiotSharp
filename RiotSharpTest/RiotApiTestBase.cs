using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RiotSharpTest
{
    class RiotApiTestBase : CommonTestBase
    {
        public static int gameId = int.Parse(ConfigurationManager.AppSettings["GameId"]);
        public static int championId = int.Parse(ConfigurationManager.AppSettings["ChampionId"]);
        public static Platform summoner1Platform = (Platform)Enum.Parse(typeof(Platform), 
            ConfigurationManager.AppSettings["Summoner1Platform"]);
        public static int summoner1MasteryChampionId = int.Parse(ConfigurationManager.AppSettings["Summoner1MasteryChampionId"]);
        public static int summoner1MasteryChampionLevel = int.Parse(ConfigurationManager.AppSettings["Summoner1MasteryChampionLevel"]);
        public static int unrankedSummonerId = int.Parse(ConfigurationManager.AppSettings["UnrankedSummonerId"]);
        public static List<long> summonerIds = ConfigurationManager.AppSettings["SummonerIds"].Split(',').Select(long.Parse).ToList();
        public static List<string> summonerNames = ConfigurationManager.AppSettings["SummonerNames"].Split(',').Select(name => name.Trim()).ToList();
        public static Region summonersRegion = (Region)Enum.Parse(typeof(Region), 
            ConfigurationManager.AppSettings["SummonersRegion"]);
        public static string queue = ConfigurationManager.AppSettings["Queue"];
        public static RiotSharp.MatchEndpoint.Enums.Season season = (RiotSharp.MatchEndpoint.Enums.Season)Enum.Parse(typeof(RiotSharp.MatchEndpoint.Enums.Season), 
            ConfigurationManager.AppSettings["Season"]);
    }
}
