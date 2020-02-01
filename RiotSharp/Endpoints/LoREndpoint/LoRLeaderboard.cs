using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.LoREndpoint
{
    /// <summary>
    /// Class containing list of top players in LoR
    /// </summary>
    public class LoRLeaderboard
    {
        internal LoRLeaderboard() { }

        /// <summary>
        /// List of top LoR players
        /// </summary>
        [JsonProperty("players")]
        public List<LoRPlayer> Players { get; set; }
    }
}
