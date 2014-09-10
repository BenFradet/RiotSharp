using System;
using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a participant's timeline (Match API).
    /// </summary>
    [Serializable]
    public class ParticipantTimeline
    {
        internal ParticipantTimeline() { }

        /// <summary>
        /// Ancient golem assists per minute timeline counts.
        /// </summary>
        [JsonProperty("ancientGolemAssistsPerMinCounts")]
        public ParticipantTimelineData AncientGolemAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Ancient golem kills per minute timeline counts.
        /// </summary>
        [JsonProperty("ancientGolemKillsPerMinCounts")]
        public ParticipantTimelineData AncientGolemKillsPerMinCounts { get; set; }

        /// <summary>
        /// Assisted lane deaths per minute timeline data.
        /// </summary>
        [JsonProperty("assistedLaneDeathsPerMinDeltas")]
        public ParticipantTimelineData AssistedLaneDeathsPerMinDeltas { get; set; }

        /// <summary>
        /// Assisted lane kills per minute timeline data.
        /// </summary>
        [JsonProperty("assistedLaneKillsPerMinDeltas")]
        public ParticipantTimelineData AssistedLaneKillsPerMinDeltas { get; set; }

        /// <summary>
        /// Baron assists per minute timeline counts.
        /// </summary>
        [JsonProperty("baronAssistsPerMinCounts")]
        public ParticipantTimelineData BaronAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Baron kills per minute timeline counts.
        /// </summary>
        [JsonProperty("baronKillsPerMinCounts")]
        public ParticipantTimelineData BaronKillsPerMinCounts { get; set; }

        /// <summary>
        /// Creeps per minute timeline data.
        /// </summary>
        [JsonProperty("creepsPerMinDeltas")]
        public ParticipantTimelineData CreepsPerMinDeltas { get; set; }

        /// <summary>
        /// Creep score difference per minute timeline data.
        /// </summary>
        [JsonProperty("csDiffPerMinDeltas")]
        public ParticipantTimelineData CsDiffPerMinDeltas { get; set; }

        /// <summary>
        /// Damage taken difference per minute timeline data.
        /// </summary>
        [JsonProperty("damageTakenDiffPerMinDeltas")]
        public ParticipantTimelineData DamageTakenDiffPerMinDeltas { get; set; }

        /// <summary>
        /// Damage taken per minute timeline data.
        /// </summary>
        [JsonProperty("damageTakenPerMinDeltas")]
        public ParticipantTimelineData DamageTakenPerMinDeltas { get; set; }

        /// <summary>
        /// Dragon assists per minute timeline counts.
        /// </summary>
        [JsonProperty("dragonAssistsPerMinCounts")]
        public ParticipantTimelineData DragonAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Dragon kills per minute timeline counts.
        /// </summary>
        [JsonProperty("dragonKillsPerMinCounts")]
        public ParticipantTimelineData DragonKillsPerMinCounts { get; set; }

        /// <summary>
        /// Elder lizard assists per minute timeline counts.
        /// </summary>
        [JsonProperty("elderLizardAssistsPerMinCounts")]
        public ParticipantTimelineData ElderLizardAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Elder lizard kills per minute timeline counts.
        /// </summary>
        [JsonProperty("elderLizardKillsPerMinCounts")]
        public ParticipantTimelineData ElderLizardKillsPerMinCounts { get; set; }

        /// <summary>
        /// Gold per minute timeline data.
        /// </summary>
        [JsonProperty("goldPerMinDeltas")]
        public ParticipantTimelineData GoldPerMinDeltas { get; set; }

        /// <summary>
        /// Inhibitor assists per minute timeline counts.
        /// </summary>
        [JsonProperty("inhibitorAssistsPerMinCounts")]
        public ParticipantTimelineData InhibitorAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Inhibitor kills per minute timeline counts.
        /// </summary>
        [JsonProperty("inhibitorKillsPerMinCounts")]
        public ParticipantTimelineData InhibitorKillsPerMinCounts { get; set; }

        /// <summary>
        /// Participant's lane.
        /// </summary>
        [JsonProperty("lane")]
        [JsonConverter(typeof(LaneConverter))]
        public Lane Lane { get; set; }

        /// <summary>
        /// Participant's role.
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(RoleConverter))]
        public Role Role { get; set; }

        /// <summary>
        /// Tower assists per minute timeline counts.
        /// </summary>
        [JsonProperty("towerAssistsPerMinCounts")]
        public ParticipantTimelineData TowerAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Tower kills per minute timeline counts.
        /// </summary>
        [JsonProperty("towerKillsPerMinCounts")]
        public ParticipantTimelineData TowerKillsPerMinCounts { get; set; }

        /// <summary>
        /// Tower kills per minute timeline data.
        /// </summary>
        [JsonProperty("towerKillsPerMinDeltas")]
        public ParticipantTimelineData TowerKillsPerMinDeltas { get; set; }

        /// <summary>
        /// Vilemaw assists per minute timeline counts.
        /// </summary>
        [JsonProperty("vilemawAssistsPerMinCounts")]
        public ParticipantTimelineData VilemawAssistsPerMinCounts { get; set; }

        /// <summary>
        /// Vilemaw kills per minute timeline counts.
        /// </summary>
        [JsonProperty("vilemawKillsPerMinCounts")]
        public ParticipantTimelineData VilemawKillsPerMinCounts { get; set; }

        /// <summary>
        /// Wards placed per minute timeline data.
        /// </summary>
        [JsonProperty("wardsPerMinDeltas")]
        public ParticipantTimelineData WardsPerMinDeltas { get; set; }

        /// <summary>
        /// Experience difference per minute timeline data.
        /// </summary>
        [JsonProperty("xpDiffPerMinDeltas")]
        public ParticipantTimelineData XpDiffPerMinDeltas { get; set; }

        /// <summary>
        /// Experience per minute timeline data.
        /// </summary>
        [JsonProperty("xpPerMinDeltas")]
        public ParticipantTimelineData XpPerMinDeltas { get; set; }
    }
}
