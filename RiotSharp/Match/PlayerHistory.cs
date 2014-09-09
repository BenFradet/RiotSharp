using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Match history of a player (Match API).
    /// </summary>
    public class PlayerHistory
    {
        internal PlayerHistory() { }

        /// <summary>
        /// List of matches for the player.
        /// </summary>
        [JsonProperty("matches")]
        public List<MatchSummary> Matches { get; set; }
    }
}
