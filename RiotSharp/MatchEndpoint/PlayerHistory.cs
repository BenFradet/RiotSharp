using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    class PlayerHistory
    {
        /// <summary>
        /// List of matches for the player.
        /// </summary>
        [JsonProperty("matches")]
        public List<MatchSummary> Matches { get; set; }
    }
}
