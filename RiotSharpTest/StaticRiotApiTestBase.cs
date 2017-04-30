using RiotSharp.Misc;
using RiotSharp.StaticDataEndpoint.SummonerSpell;
using System;
using System.Configuration;

namespace RiotSharpTest
{
    class StaticRiotApiTestBase : CommonTestBase
    {
        public static Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["StaticRegion"]);
        public static int staticChampionId = int.Parse(ConfigurationManager.AppSettings["StaticChampionId"]);
        public static string staticChampionName = ConfigurationManager.AppSettings["StaticChampionName"];
        public static int staticItemId = int.Parse(ConfigurationManager.AppSettings["staticItemId"]);
        public static string staticItemName = ConfigurationManager.AppSettings["staticItemName"];
        public static int staticMasteryId = int.Parse(ConfigurationManager.AppSettings["staticMasteryId"]);
        public static string staticMasteryName = ConfigurationManager.AppSettings["staticMasteryName"];
        public static int staticRuneId = int.Parse(ConfigurationManager.AppSettings["staticRuneId"]);
        public static string staticRuneName = ConfigurationManager.AppSettings["staticRuneName"];
        public static SummonerSpell staticSummonerSpell = (SummonerSpell)Enum.Parse(typeof(SummonerSpell), 
            ConfigurationManager.AppSettings["StaticSummonerSpellName"]);
        public static string staticSummonerSpellName = ConfigurationManager.AppSettings["staticSummonerSpellName"];
    }
}
