using System;
using System.Collections.Generic;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    internal class RiotApiTestBase : CommonTestBase
    {
        public static long RunesMasteriesGameId = 3518102254; // Game from a patch where the old masteries and runes were active (Platform NA1)
        public static long PerksGameId = 3857603699;  // Game from a patch with reforged runes (Platform EUW)

        public static long GameId = 3518102254;
        public static int ChampionId = 497;
        public static Platform Summoner1Platform = (Platform) Enum.Parse(typeof(Platform), "NA1");
        public static int Summoner1MasteryChampionId = 497;
        public static int Summoner1MasteryChampionLevel = 7;
        public static long UnrankedSummonerId = 76723437;
        public static string TftLeagueId = "a8750230-0e29-11ea-ade7-a6f857269bfa";

        public static List<string> AccountIds = new List<string>
        {
            "h1O1kZfsBNz5koxxRagxoddngVBXRYGUUm5PUVBihvjE7w",
            "39_s8uzR2RkzRT3_0qgMfLBPhamNxw0l79n-nlsy8cdHh9A",
            "4EsSNLw0tijFP1ckk1pYxBjhAYywCuBdgTWaa-2UtVwbkRCtelop_Xn1",
            "JRqk5qeN_ABHsoG_uO8iMooed5EGV69rrJQ0JI39FeiDUAA",
            "idJeoVA3X-ypIlRAJge29A82gR2FfVWJ5y5Oa9hgB_HBY9A",

        };

        public static List<string> SummonerIds = new List<string>
        {
            "HW96gOrX-QhzSo57KbITsibEBbTYRstm5d4RfRrsa1gBNDE",
            "r8pDRHnmw1MqZWWvaOCNl-rntPATTWRzCERTn45JHHK1oCnj",
            "ff3si8hPRgvXu0knr-tbzSd_hBhbR8bKE9TN5XjWkBWQC7Dl",
            "vBsQ_rxBLUHiU8JxcksbaH3eX9AjJLZU4EuV0ZHdKMiocfzt"
        };

        public static List<string> SummonerNames = new List<string>
        {
            "Hi Im DEPA",
            "From Iron",
            "Adrian Seira",
            "Liquid Impact"
        };

        public static Region Summoners1Region = (Region)Enum.Parse(typeof(Region), "Eun1");
        public static Region SummonersRegion = (Region) Enum.Parse(typeof(Region), "Euw");
        public static string Queue = "RANKED_SOLO_5x5";

        // Normal 5v5 Draft Pick games
        public static int QueueId = 850;
        public static Season Season = (Season) Enum.Parse(typeof(Season), "Season2020");
        public static readonly string ThirdPartyCode = "test-third-party-code";
    }
}
