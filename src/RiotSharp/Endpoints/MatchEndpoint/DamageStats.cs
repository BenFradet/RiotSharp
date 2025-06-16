using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class DamageStats
    {
        internal DamageStats() { }


        [JsonProperty("magicDamageDone")]
        public int MagicDamageDone { get; set; }


        [JsonProperty("magicDamageDoneToChampions")]
        public int MagicDamageDoneToChampions { get; set; }


        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }


        [JsonProperty("physicalDamageDone")]
        public int PhysicalDamageDone { get; set; }


        [JsonProperty("physicalDamageDoneToChampions")]
        public int PhysicalDamageDoneToChampions { get; set; }


        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }


        [JsonProperty("totalDamageDone")]
        public int TotalDamageDone { get; set; }


        [JsonProperty("totalDamageDoneToChampions")]
        public int TotalDamageDoneToChampions { get; set; }


        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }


        [JsonProperty("trueDamageDone")]
        public int TrueDamageDone { get; set; }


        [JsonProperty("trueDamageDoneToChampions")]
        public int TrueDamageDoneToChampions { get; set; }


        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }

    }
}
