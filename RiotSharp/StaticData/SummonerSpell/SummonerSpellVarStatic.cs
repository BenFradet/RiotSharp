using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing various information about a summoner spell (Static API).
    /// </summary>
    [Serializable]
    public class SummonerSpellVarStatic
    {
        internal SummonerSpellVarStatic() { }

        /// <summary>
        /// Coeff for this summoner spell for the summoner's level.
        /// </summary>
        [JsonProperty("coeff")]
        public object Coeff { get; set; }

        /// <summary>
        /// Key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Link.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
