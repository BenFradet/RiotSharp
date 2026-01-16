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
        public Objective Baron { get; set; }

        /// <summary>
        /// Champion objective.
        /// </summary>
        [JsonPropertyName("champion")]
        public Objective Champion { get; set; }

        /// <summary>
        /// Dragon objective.
        /// </summary>
        [JsonPropertyName("dragon")]
        public Objective Dragon { get; set; }

        /// <summary>
        /// Horde objective.
        /// </summary>
        [JsonPropertyName("horde")]
        public Objective Horde { get; set; }

        /// <summary>
        /// Inhibitor objective.
        /// </summary>
        [JsonPropertyName("inhibitor")]
        public Objective Inhibitor { get; set; }

        /// <summary>
        /// Rift Herald objective.
        /// </summary>
        [JsonPropertyName("riftHerald")]
        public Objective RiftHerald { get; set; }

        /// <summary>
        /// Tower objective.
        /// </summary>
        [JsonPropertyName("tower")]
        public Objective Tower { get; set; }
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
        public bool First { get; set; }

        /// <summary>
        /// Number of kills of this objective.
        /// </summary>
        [JsonPropertyName("kills")]
        public int Kills { get; set; }
    }
}
