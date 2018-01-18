using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class MatchList
    {
        /// <summary>
        /// The end index of the list of matches.
        /// </summary>
        [JsonProperty("endIndex")]
        public int EndIndex { get; set; }

        /// <summary>
        /// List of matches for the player
        /// </summary>
        [JsonProperty("matches")]
        public List<MatchReference> Matches { get; set; }

        /// <summary>
        /// The start index of the list of matches.
        /// </summary>
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        /// <summary>
        /// Total number of games within the list.
        /// </summary>
        [JsonProperty("totalGames")]
        public int TotalGames { get; set; }
    }
}
