using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiotSharp.Test
{
    class RiotApiTestBase : CommonTestBase
    {
        public static long gameId = 2510454764;
        public static int championId = 38;
        public static Platform summoner1Platform = (Platform)Enum.Parse(typeof(Platform), "NA1");
        public static int summoner1MasteryChampionId = 98;
        public static int summoner1MasteryChampionLevel = 7;
        public static long unrankedSummonerId = 76723437;
        public static List<long> summonerIds = new List<long> { 19887289, 77179274, 44989337, 77211704, 77629935, 59189004, 20964624, 71899217,
           55629820, 32932398, 56539172 };
        public static List<string> summonerNames = new List<string> { "Imaqtpie", "C9 Ray", "C9 Gun", "C9 Winter", "Fox Brandini", "P1 Shady",
            "clg imaqtpie69", "Anivia Kid", "Butler Delta", "Contractz", "LL Stylish" };
        public static Region summonersRegion = (Region)Enum.Parse(typeof(Region), "na");
        public static string queue = "RANKED_SOLO_5x5";
        public static RiotSharp.MatchEndpoint.Enums.Season season = 
            (RiotSharp.MatchEndpoint.Enums.Season)Enum.Parse(typeof(RiotSharp.MatchEndpoint.Enums.Season), "Season2015");
    }
}
