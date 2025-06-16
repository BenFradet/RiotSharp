using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class TeamStatsObjectives
    {
        internal TeamStatsObjectives() { }

        /// <summary>
        /// Baron objective.
        /// </summary>
        [JsonPropertyName("baron")]
        public TeamStatsObjective Baron { get; set; }

        /// <summary>
        /// Champion objective.
        /// </summary>
        [JsonPropertyName("champion")]
        public TeamStatsObjective Champion { get; set; }

        /// <summary>
        /// Dragon objective.
        /// </summary>
        [JsonPropertyName("dragon")]
        public TeamStatsObjective Dragon { get; set; }

        /// <summary>
        /// Inhibitor objective.
        /// </summary>
        [JsonPropertyName("inhibitor")]
        public TeamStatsObjective Inhibitor { get; set; }

        /// <summary>
        /// RiftHerald objective.
        /// </summary>
        [JsonPropertyName("riftHerald")]
        public TeamStatsObjective RiftHerald { get; set; }

        /// <summary>
        /// Tower objective.
        /// </summary>
        [JsonPropertyName("tower")]
        public TeamStatsObjective Tower { get; set; }
    }

    public class TeamStatsObjective
    {
        internal TeamStatsObjective() { }

        /// <summary>
        /// Flag whether team got the objective first.
        /// </summary>
        [JsonPropertyName("first")]
        public bool First { get; set; }

        /// <summary>
        /// Number of kills of the objective.
        /// </summary>
        [JsonPropertyName("kills")]
        public long Kills { get; set; }
    }
}
