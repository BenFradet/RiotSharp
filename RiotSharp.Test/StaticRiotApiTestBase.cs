using RiotSharp.Misc;
using System;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;

namespace RiotSharp.Test
{
    public class StaticRiotApiTestBase : CommonTestBase
    {
        public static readonly Region Region = (Region)Enum.Parse(typeof(Region), "na");

        public const int StaticChampionId = 1;
        public const string StaticChampionName = "Annie";

        public const int StaticItemId = 1001;
        public const string StaticItemName = "Boots of Speed";

        public const int StaticMasteryId = 6111;
        public const string StaticMasteryName = "Fury";

        public const int StaticRuneId = 5001;
        public const string StaticRuneName = "Lesser Mark of Attack Damage";

        public const int StaticReforgedRuneId = 8139;
        public const string StaticReforgedRuneName = "Taste of Blood";

        public static readonly SummonerSpell StaticSummonerSpell = (SummonerSpell)Enum.Parse(typeof(SummonerSpell), "Barrier");
        public const string StaticSummonerSpellName = "Barrier";
    }
}
