using RiotSharp.Misc;
using System;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;

namespace RiotSharp.Test
{
    public class StaticRiotApiTestBase : CommonTestBase
    {
        public static Region Region = (Region)Enum.Parse(typeof(Region), "na");
        public static int StaticChampionId = 1;
        public static string StaticChampionName = "Annie";
        public static int StaticItemId = 1001;
        public static string StaticItemName = "Boots of Speed";
        public static int StaticMasteryId = 6111;
        public static string StaticMasteryName = "Fury";
        public static int StaticRuneId = 5001;
        public static string StaticRuneName = "Lesser Mark of Attack Damage";
        public static SummonerSpell StaticSummonerSpell = (SummonerSpell)Enum.Parse(typeof(SummonerSpell), "Barrier");
        public static string StaticSummonerSpellName = "Barrier";
    }
}
