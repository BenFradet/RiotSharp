using RiotSharp.Misc;
using RiotSharp.StaticDataEndpoint.SummonerSpell;
using System;

namespace RiotSharp.Test
{
    public class StaticRiotApiTestBase : CommonTestBase
    {
        public static Region region = (Region)Enum.Parse(typeof(Region), "na");
        public static int staticChampionId = 1;
        public static string staticChampionName = "Annie";
        public static int staticItemId = 1001;
        public static string staticItemName = "Boots of Speed";
        public static int staticMasteryId = 6111;
        public static string staticMasteryName = "Fury";
        public static int staticRuneId = 5001;
        public static string staticRuneName = "Lesser Mark of Attack Damage";
        public static SummonerSpell staticSummonerSpell = (SummonerSpell)Enum.Parse(typeof(SummonerSpell), "Barrier");
        public static string staticSummonerSpellName = "Barrier";
    }
}
