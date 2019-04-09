using System;
using System.Collections.Generic;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    internal class RiotApiTestBase : CommonTestBase
    {
        public static long RunesMasteriesGameId = 2510454764; // Game from a patch where the old masteries and runes were active (Platform NA1)
        public static long PerksGameId = 3857603699;  // Game from a patch with reforged runes (Platform EUW)

        public static long GameId = 2510454764;        
        public static int ChampionId = 38;
        public static Platform Summoner1Platform = (Platform) Enum.Parse(typeof(Platform), "NA1");
        public static int Summoner1MasteryChampionId = 98;
        public static int Summoner1MasteryChampionLevel = 7;
        public static long UnrankedSummonerId = 76723437;

        public static List<string> AccountIds = new List<string>
        {
            "6GwG-_gvthMjC4bMSh-K_n89fXmwAO2r_xW_bydQX6jsQdI",
            "sfezrcI0J4ujlyNhM-CF_ImoIheDW-CHL3Jr-yegcZ5Rkm8",
            "K36_BOxYJ6zc22ROFJz3lNpUnUM0fXlbRM6bxNIcjrK53Gw",
            "h36GnnMLKm0Nuu4gKUgzGOpKUNfn8YOMufZWL8FGq1kY550"
        };

        public static List<string> SummonerIds = new List<string>
        {
            "Ki6Ed6nkLuc3kCYQhqG922A3baTTdAwRX7LOlVfLl29Ka30",
            "pU48DLZmrnwJaowPfWj1eIL-wmh5S7EEi2_8Qthdc5w07Hs",
            "EJSU56nc6omjP9doWiuBErFDpqbSsuEIslJEIvY-mRi-fHw",
            "e9LoFSVipdsgZtPX-CLPA5rbd4z4_6rOm65YA451J2P8atU",
            "alGEcJUa85NZOlCbwYwKTTXRLiTEiuCVtfYIAkTclMKoamk",
            "XD6QLPpYK7jPPuiJ6XLle3gY9-nfWEzknMRJKltpzJiFp4Q",
            "T4Pdm6UMGtllvS_NcPBoMBGdVv0-6DWf5olYUPfBLusGFnw",
            "YC2q7TM2hWbCS9y-HaFiPDpzQT7TynVydJN1OExcKnO3HR8",
            "7Ux5zHUPUeXcfFOTb6MMzijl0iSIt5yMqlWOnR0CxriH6Qk",
            "v7tt3i1nryKVQvqknf8RK5_5WZTW4iWKtccIiAhLLyLLPpw",
            "AFd-eTKqedjdKxaYlzSV00_gGPQNDvuKkdwG1PMvHafpjq0"
        };

        public static List<string> SummonerNames = new List<string>
        {
            "Imaqtpie",
            "C9 Ray",
            "C9 Gun",
            "C9 Winter",
            "Fox Brandini",
            "P1 Shady",
            "clg imaqtpie69",
            "Anivia Kid",
            "Butler Delta",
            "Contractz",
            "LL Stylish"
        };

        public static Region SummonersRegion = (Region) Enum.Parse(typeof(Region), "Na");
        public static string Queue = "RANKED_SOLO_5x5";

        // Normal 5v5 Draft Pick games
        public static int QueueId = 400;
        public static Season Season = (Season) Enum.Parse(typeof(Season), "Season2015");
        public static readonly string ThirdPartyCode = "test-third-party-code";
    }
}
