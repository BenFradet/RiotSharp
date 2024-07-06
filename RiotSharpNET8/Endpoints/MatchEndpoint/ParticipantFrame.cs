using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
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
        [JsonPropertyName("championStats")]
        public ChampionStats ChampionStats { get; set; }

        /// <summary>
        /// Participant's current gold.
        /// </summary>
        [JsonPropertyName("currentGold")]
        public int CurrentGold { get; set; }

        /// <summary>
        /// Participant's damage stats.
        /// </summary>
        [JsonPropertyName("damageStats")]
        public DamageStats DamageStats { get; set; }

        /// <summary>
        /// Participant's gold per second.
        /// </summary>
        [JsonPropertyName("goldPerSecond")]
        public int GoldPerSecond { get; set; }

        /// <summary>
        /// Number of jungle minions killed by participant.
        /// </summary>
        [JsonPropertyName("jungleMinionsKilled")]
        public int JungleMinionsKilled { get; set; }

        /// <summary>
        /// Participant's current level.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// Number of minions killed by participant.
        /// </summary>
        [JsonPropertyName("minionsKilled")]
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Participant's position.
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Participant's total gold.
        /// </summary>
        [JsonPropertyName("timeEnemySpentControlled")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan TimeEnemySpentControlled { get; set; }

        /// <summary>
        /// Participant's total gold.
        /// </summary>
        [JsonPropertyName("totalGold")]
        public int TotalGold { get; set; }

        /// <summary>
        /// Experience earned by participant.
        /// </summary>
        [JsonPropertyName("xp")]
        public int XP { get; set; }
    }
}
