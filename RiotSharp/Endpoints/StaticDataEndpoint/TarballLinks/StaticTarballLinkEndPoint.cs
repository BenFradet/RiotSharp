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
        private const string TarballLinkUrl = StaticEndpointBase.Host + "/cdn/dragontail-{0}.tgz";

        public string Get(string version, bool useHttps = true)
        {
            return useHttps ? "https://": "http://" + string.Format(TarballLinkUrl, version);
        }
    }
}