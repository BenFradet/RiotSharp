using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Team objectives information (Match API).
    /// </summary>
    public class Objectives
    {
        /// <summary>
        /// Baron objective.
        /// </summary>
        [JsonPropertyName("baron")]
        public required Objective Baron { get; set; }

        /// <summary>
        /// Champion objective.
        /// </summary>
        [JsonPropertyName("champion")]
        public required Objective Champion { get; set; }

        /// <summary>
        /// Dragon objective.
        /// </summary>
        [JsonPropertyName("dragon")]
        public required Objective Dragon { get; set; }

        /// <summary>
        /// Horde objective.
        /// </summary>
        [JsonPropertyName("horde")]
        public required Objective Horde { get; set; }

        /// <summary>
        /// Inhibitor objective.
        /// </summary>
        [JsonPropertyName("inhibitor")]
        public required Objective Inhibitor { get; set; }

        /// <summary>
        /// Rift Herald objective.
        /// </summary>
        [JsonPropertyName("riftHerald")]
        public required Objective RiftHerald { get; set; }

        /// <summary>
        /// Tower objective.
        /// </summary>
        [JsonPropertyName("tower")]
        public required Objective Tower { get; set; }
    }

    /// <summary>
    /// Objective information (Match API).
    /// </summary>
    public class Objective
    {
        /// <summary>
        /// Flag indicating if the team got the first kill of this objective.
        /// </summary>
        [JsonPropertyName("first")]
        public required bool First { get; set; }

        /// <summary>
        /// Number of kills of this objective.
        /// </summary>
        [JsonPropertyName("kills")]
        public required int Kills { get; set; }
    }
}
