using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a list of summoner spells (Static API).
    /// </summary>
    public class SummonerSpellListStatic
    {
        /// <summary>
        /// Map of summoner spells indexed by their name.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, SummonerSpellStatic> SummonerSpells { get; set; }

        /// <summary>
        /// API type (summoner).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
