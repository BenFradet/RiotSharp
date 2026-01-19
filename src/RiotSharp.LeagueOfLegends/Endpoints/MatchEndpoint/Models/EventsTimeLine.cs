using RiotSharp.Core.Misc.Converters;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Timeline event data.
    /// The documentation is fucking pisspoor!!! LIKE WTF Riot???
    /// There are so many json fields that are not documented at all, but are still returned by the API.
    /// </summary>
    public class EventsTimeLine
    {
        /// <summary>
        /// Timestamp of the event (in milliseconds). Relative to game start.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public required TimeSpan Timestamp { get; set; }

        /// <summary>
        /// Real timestamp of the event (in milliseconds, epoch time).
        /// </summary>
        [JsonPropertyName("realTimestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime? RealTimestamp { get; set; }

        /// <summary>
        /// Type of the event.
        /// ITEM_PURCHASED, ITEM_DESTROYED and so on. Many different.
        /// </summary>
        [JsonPropertyName("type")]
        public required string Type { get; set; }

        /// <summary>
        /// Creator ID (for WARD_PLACED events).
        /// </summary>
        /// <remarks>Not officially documented, but observed in practice.</remarks>
        [JsonPropertyName("creatorId")]
        public int? CreatorId { get; set; }

        /// <summary>
        /// Ward type (for WARD_PLACED events).
        /// </summary>
        [JsonPropertyName("wardType")]
        public string? WardType { get; set; }

        /// <summary>
        /// Killer ID (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("killerId")]
        public int? KillerId { get; set; }

        /// <summary>
        /// Victim ID (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("victimId")]
        public int? VictimId { get; set; }

        /// <summary>
        /// Assisting participant IDs (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("assistingParticipantIds")]
        public List<int>? AssistingParticipantIds { get; set; }

        /// <summary>
        /// Position of the event.
        /// </summary>
        [JsonPropertyName("position")]
        public Position? Position { get; set; }

        /// <summary>
        /// Bounty amount (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("bounty")]
        public int? Bounty { get; set; }

        /// <summary>
        /// Shutdown bounty amount (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("shutdownBounty")]
        public int? ShutdownBounty { get; set; }

        /// <summary>
        /// Kill streak length (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("killStreakLength")]
        public int? KillStreakLength { get; set; }

        /// <summary>
        /// Damage dealt by victim (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("victimDamageDealt")]
        public List<VictimDamage>? VictimDamageDealt { get; set; }

        /// <summary>
        /// Damage received by victim (for CHAMPION_KILL events).
        /// </summary>
        [JsonPropertyName("victimDamageReceived")]
        public List<VictimDamage>? VictimDamageReceived { get; set; }

        /// <summary>
        /// Kill type (for CHAMPION_SPECIAL_KILL events).
        /// </summary>
        [JsonPropertyName("killType")]
        public string? KillType { get; set; }

        /// <summary>
        /// Multi kill length (for CHAMPION_SPECIAL_KILL events).
        /// </summary>
        [JsonPropertyName("multiKillLength")]
        public int? MultiKillLength { get; set; }

        /// <summary>
        /// Item ID (for ITEM_PURCHASED/ITEM_DESTROYED events).
        /// </summary>
        [JsonPropertyName("itemId")]
        public int? ItemId { get; set; }

        /// <summary>
        /// Participant ID (for item events).
        /// </summary>
        [JsonPropertyName("participantId")]
        public int? ParticipantId { get; set; }

        /// <summary>
        /// Game ID (for GAME_END events).
        /// </summary>
        [JsonPropertyName("gameId")]
        public long? GameId { get; set; }

        /// <summary>
        /// Winning team (for GAME_END events).
        /// </summary>
        [JsonPropertyName("winningTeam")]
        public int? WinningTeam { get; set; }
    }
}
