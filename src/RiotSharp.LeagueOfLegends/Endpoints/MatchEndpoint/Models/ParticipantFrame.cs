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
        public required ChampionStats ChampionStats { get; set; }

        /// <summary>
        /// Current gold amount.
        /// </summary>
        [JsonPropertyName("currentGold")]
        public required int CurrentGold { get; set; }

        /// <summary>
        /// Damage statistics at this frame.
        /// </summary>
        [JsonPropertyName("damageStats")]
        public required DamageStats DamageStats { get; set; }

        /// <summary>
        /// Gold per second.
        /// </summary>
        [JsonPropertyName("goldPerSecond")]
        public required int GoldPerSecond { get; set; }

        /// <summary>
        /// Number of jungle minions killed.
        /// </summary>
        [JsonPropertyName("jungleMinionsKilled")]
        public required int JungleMinionsKilled { get; set; }

        /// <summary>
        /// Current level.
        /// </summary>
        [JsonPropertyName("level")]
        public required int Level { get; set; }

        /// <summary>
        /// Number of minions killed.
        /// </summary>
        [JsonPropertyName("minionsKilled")]
        public required int MinionsKilled { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public required int ParticipantId { get; set; }

        /// <summary>
        /// Position on the map.
        /// </summary>
        [JsonPropertyName("position")]
        public required Position Position { get; set; }

        /// <summary>
        /// Time enemy spent controlled (in milliseconds).
        /// </summary>
        [JsonPropertyName("timeEnemySpentControlled")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public required TimeSpan TimeEnemySpentControlled { get; set; }

        /// <summary>
        /// Total gold accumulated.
        /// </summary>
        [JsonPropertyName("totalGold")]
        public required int TotalGold { get; set; }

        /// <summary>
        /// Total experience points.
        /// </summary>
        [JsonPropertyName("xp")]
        public required int Xp { get; set; }
    }
}
