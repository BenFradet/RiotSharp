using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.ChampionMasteryEndpoint
{
    /// <summary>
    /// Class representing a champion mastery for
    /// specified player and champion combination (ChampionMastery API).
    /// </summary>
    public class ChampionMastery
    {
        /// <summary>
        /// Champion ID for this entry.
        /// </summary>
        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// Champion level for specified player and champion combination.
        /// </summary>
        [JsonPropertyName("championLevel")]
        public int ChampionLevel { get; set; }

        /// <summary>
        /// Total number of champion points for this player and champion combination -
        /// they are used to determine championLevel.
        /// </summary>
        [JsonPropertyName("championPoints")]
        public int ChampionPoints { get; set; }

        /// <summary>
        /// Number of points earned since current level has been achieved.
        /// Zero if player reached maximum champion level for this champion.
        /// </summary>
        [JsonPropertyName("championPointsSinceLastLevel")]
        public long ChampionPointsSinceLastLevel { get; set; }

        /// <summary>
        /// Number of points needed to achieve next level.
        /// Zero if player reached maximum champion level for this champion.
        /// </summary>
        [JsonPropertyName("championPointsUntilNextLevel")]
        public long ChampionPointsUntilNextLevel { get; set; }

        /// <summary>
        /// Is chest granted for this champion or not in current season.
        /// </summary>
        [JsonPropertyName("chestGranted")]
        public bool ChestGranted { get; set; }

        /// <summary>
        /// Last time this champion was played by this player.
        /// </summary>
        [JsonPropertyName("lastPlayTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastPlayTime { get; set; }

        /// <summary>
        /// Player ID for this entry.
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }
    }
}
