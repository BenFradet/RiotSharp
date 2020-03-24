using System.Collections.Generic;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion
{
    internal class ChampionStandAloneStatic
    {
        internal string Type { get; set; }
        internal string Format { get; set; }
        internal string Version { get; set; }
        internal Dictionary<string, ChampionStatic> Data { get; set; }
    }
}
