using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.LoREndpoint
{
    /// <summary>
    /// LoRPlayer class containing all properties to define a player in LoR
    /// </summary>
    public class LoRPlayer
    {
        internal LoRPlayer() { }

        /// <summary>
        /// Player name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Player Rank
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
