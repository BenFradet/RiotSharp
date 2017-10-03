using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using RiotSharp.Misc;

namespace RiotSharp.Http.Maps
{
    public static class RegionPlatformMap
    {

        private static readonly IDictionary<Region, string> Map = new Dictionary<Region, string>
        {
            { Region.br, "br1" },
            { Region.eune , "eun1" },
            { Region.euw , "euw1" },
            { Region.jp , "jp1" },
            { Region.kr , "kr" },
            { Region.lan , "la1" },
            { Region.las , "la2" },
            { Region.na , "na1" },
            { Region.oce , "oc1" },
            { Region.tr , "tr1" },
            { Region.ru , "ru" },
            { Region.global , "global" }
        };

        public static string GetPlatform(Region region)
            => Map.ContainsKey(region) ? Map[region] : throw new NotImplementedException("Unsupported region");

        public static string GetPlatformDomain(Region region)
            => $"{GetPlatform(region)}.api.riotgames.com";

    }
}
