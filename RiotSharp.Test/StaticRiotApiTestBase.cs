using System;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    public class StaticRiotApiTestBase : CommonTestBase
    {
        public static readonly Region Region = (Region)Enum.Parse(typeof(Region), "na");
        public const string StaticVersion = "8.13.1";

        public const string StaticChampionKey = "Annie";
        public const string StaticChampionName = "Annie";

        public const int StaticItemId = 1001;
        public const string StaticItemName = "Boots of Speed";

        public const int StaticMasteryId = 6111;
        public const string StaticMasteryName = "Fury";

        public const int StaticRuneId = 5001;
        public const string StaticRuneName = "Lesser Mark of Attack Damage";

        public const int StaticReforgedRunePathId = 8200;
        public const string StaticReforgedRunePathName = "Sorcery";

        public const int StaticReforgedRuneId = 8210;
        public const string StaticReforgedRuneName = "Transcendence";

        public static readonly SummonerSpell StaticSummonerSpell = (SummonerSpell)Enum.Parse(typeof(SummonerSpell), "Barrier");
        public const string StaticSummonerSpellName = "Barrier";

        public static readonly string StaticTarballLinkBaseUrl = "http://ddragon.leagueoflegends.com/cdn/dragontail-";
        public const string StaticTarballLinkVersion = "0.151.2";
        public const string StaticTarballLinkExtension = ".tgz";
        public static readonly string StaticTarballLinkVersionUrl = $"{StaticTarballLinkBaseUrl}{StaticTarballLinkVersion}{StaticTarballLinkExtension}";
        
    }
}
