using System;
using RiotSharp.Misc;

namespace RiotSharp.Test
{
    public class DataDragonApiTestBase : CommonTestBase
    {
        public static readonly Region Region = (Region)Enum.Parse(typeof(Region), "Na");
        public const string StaticVersion = "8.13.1";
        public const string LegacyVersion = "7.13.1"; // For testing deprecated rune and mastery endpoint

        public const string StaticChampionKey = "Annie";
        public const string StaticChampionNameAnnie = "Annie";
        public const string StaticChampionNameAatrox = "Aatrox";

        public static readonly string StaticTarballLinkBaseUrl = "http://ddragon.leagueoflegends.com/cdn/dragontail-";
        public const string StaticTarballLinkVersion = "0.151.2";
        public const string StaticTarballLinkExtension = ".tgz";
        public static readonly string StaticTarballLinkVersionUrl = $"{StaticTarballLinkBaseUrl}{StaticTarballLinkVersion}{StaticTarballLinkExtension}";
    }
}
