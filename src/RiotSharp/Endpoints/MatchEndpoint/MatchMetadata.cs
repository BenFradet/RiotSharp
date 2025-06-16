using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class MatchMetadata
    {
        /// <summary>
        /// Data Version of the data.
        /// </summary>
        [JsonProperty("dataVersion")]
        public string DataVersion { get; set; }

        /// <summary>
        /// Match ID of the match.
        /// </summary>
        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        /// <summary>
        /// Participant Puuids.
        /// </summary>
        [JsonProperty("participants")]
        public List<string> Participants { get; set; }
    }
}
