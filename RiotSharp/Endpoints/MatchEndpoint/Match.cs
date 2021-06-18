using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Match class containing all properties to define a match.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Metadata of the match.
        /// </summary>
        [JsonProperty("metadata")]
        public MatchMetadata Metadata { get; set; }

        /// <summary>
        /// Info containing the most information about the match.
        /// </summary>
        [JsonProperty("info")]
        public MatchInfo Info { get; set; }
    }
}
