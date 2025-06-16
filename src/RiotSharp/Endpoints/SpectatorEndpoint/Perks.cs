using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a Perks in the API.
    /// </summary>
    public class Perks
    {
        /// <summary>
        /// Primary runes path
        /// </summary>
        [JsonProperty("perkStyle")]
        public long PerkStyle { get; set; }

        /// <summary>
        /// Secondary runes path
        /// </summary>
        [JsonProperty("perkSubStyle")]
        public long PerkSubStyle { get; set; }

        /// <summary>
        /// IDs of the perks/runes assigned.
        /// </summary>
        [JsonProperty("perkIds")]
        public List<long> PerkIds { get; set; }      
    }
}
