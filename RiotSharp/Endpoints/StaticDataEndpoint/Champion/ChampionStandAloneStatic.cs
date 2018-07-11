using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion
{
    public class ChampionStandAloneStatic
    {
        public string Type { get; set; }
        public string Format { get; set; }
        public string Version { get; set; }
        public Dictionary<string, ChampionStatic> Data { get; set; }
    }
}
