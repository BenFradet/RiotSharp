using Newtonsoft.Json;
using RiotSharp.Misc.Converters;
using System;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a particular frame for a participant during a match (Match API).
    /// </summary>
    public class ParticipantFrame
    {
        internal ParticipantFrame() { }

        /// <summary>
        /// Participant's champion stats.
        /// </summary>
        [JsonProperty("championStats")]
        public ChampionStats ChampionStats { get; set; }

        /// <summary>
        /// Participant's current gold.
        /// </summary>
        [JsonProperty("currentGold")]
        public int CurrentGold { get; set; }

        /// <summary>
        /// Participant's damage stats.
        /// </summary>
        [JsonProperty("damageStats")]
        public DamageStats DamageStats { get; set; }

        /// <summary>
        /// Participant's gold per second.
        /// </summary>
        [JsonProperty("goldPerSecond")]
        public int GoldPerSecond { get; set; }

        /// <summary>
        /// Number of jungle minions killed by participant.
        /// </summary>
        [JsonProperty("jungleMinionsKilled")]
        public int JungleMinionsKilled { get; set; }

        /// <summary>
        /// Participant's current level.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Number of minions killed by participant.
        /// </summary>
        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Participant's position.
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Participant's total gold.
        /// </summary>
        [JsonProperty("timeEnemySpentControlled")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan TimeEnemySpentControlled { get; set; }

        /// <summary>
        /// Participant's total gold.
        /// </summary>
        [JsonProperty("totalGold")]
        public int TotalGold { get; set; }

        /// <summary>
        /// Experience earned by participant.
        /// </summary>
        [JsonProperty("xp")]
        public int XP { get; set; }
    }
}
