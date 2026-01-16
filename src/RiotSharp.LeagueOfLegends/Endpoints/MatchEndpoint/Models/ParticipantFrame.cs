using RiotSharp.Core.Misc.Converters;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Participant frame data for a specific timestamp.
    /// </summary>
    public class ParticipantFrame
    {
        /// <summary>
        /// Champion statistics at this frame.
        /// </summary>
        [JsonPropertyName("championStats")]
        public ChampionStats ChampionStats { get; set; }

        /// <summary>
        /// Current gold amount.
        /// </summary>
        [JsonPropertyName("currentGold")]
        public int CurrentGold { get; set; }

        /// <summary>
        /// Damage statistics at this frame.
        /// </summary>
        [JsonPropertyName("damageStats")]
        public DamageStats DamageStats { get; set; }

        /// <summary>
        /// Gold per second.
        /// </summary>
        [JsonPropertyName("goldPerSecond")]
        public int GoldPerSecond { get; set; }

        /// <summary>
        /// Number of jungle minions killed.
        /// </summary>
        [JsonPropertyName("jungleMinionsKilled")]
        public int JungleMinionsKilled { get; set; }

        /// <summary>
        /// Current level.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// Number of minions killed.
        /// </summary>
        [JsonPropertyName("minionsKilled")]
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Position on the map.
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Time enemy spent controlled (in milliseconds).
        /// </summary>
        [JsonPropertyName("timeEnemySpentControlled")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan TimeEnemySpentControlled { get; set; }

        /// <summary>
        /// Total gold accumulated.
        /// </summary>
        [JsonPropertyName("totalGold")]
        public int TotalGold { get; set; }

        /// <summary>
        /// Total experience points.
        /// </summary>
        [JsonPropertyName("xp")]
        public int Xp { get; set; }
    }
}
