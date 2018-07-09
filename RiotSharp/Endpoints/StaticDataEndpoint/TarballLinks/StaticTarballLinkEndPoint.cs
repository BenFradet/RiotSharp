using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.TarballLinks
{
    public class StaticTarballLinkEndPoint : IStaticTarballLinkEndPoint, IStaticEndpoint
    {
        public string GetTarballLink(string version)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/dragontail-{version}.tgz";
        }
    }
}