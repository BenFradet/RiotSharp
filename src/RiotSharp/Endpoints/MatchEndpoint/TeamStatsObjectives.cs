using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class TeamStatsObjectives
    {
        internal TeamStatsObjectives() { }

        /// <summary>
        /// Baron objective.
        /// </summary>
        [JsonProperty("baron")]
        public TeamStatsObjective Baron { get; set; }

        /// <summary>
        /// Champion objective.
        /// </summary>
        [JsonProperty("champion")]
        public TeamStatsObjective Champion { get; set; }

        /// <summary>
        /// Dragon objective.
        /// </summary>
        [JsonProperty("dragon")]
        public TeamStatsObjective Dragon { get; set; }

        /// <summary>
        /// Inhibitor objective.
        /// </summary>
        [JsonProperty("inhibitor")]
        public TeamStatsObjective Inhibitor { get; set; }

        /// <summary>
        /// RiftHerald objective.
        /// </summary>
        [JsonProperty("riftHerald")]
        public TeamStatsObjective RiftHerald { get; set; }

        /// <summary>
        /// Tower objective.
        /// </summary>
        [JsonProperty("tower")]
        public TeamStatsObjective Tower { get; set; }
    }

    public class TeamStatsObjective
    {
        internal TeamStatsObjective() { }

        /// <summary>
        /// Flag whether team got the objective first.
        /// </summary>
        [JsonProperty("first")]
        public bool First { get; set; }

        /// <summary>
        /// Number of kills of the objective.
        /// </summary>
        [JsonProperty("kills")]
        public long Kills { get; set; }
    }
}
