using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.MatchEndpoint.Enums;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a particular event during a match (Match API).
    /// </summary>
    public class MatchEvent
    {
        internal MatchEvent() { }

        /// <summary>
        /// The ascended type of the event. Only present if relevant.
        /// Note that CLEAR_ASCENDED refers to when a participants kills the ascended player.
        /// </summary>
        [JsonPropertyName("ascendedType")]
        public AscendedType AscendedType { get; set; }

        /// <summary>
        /// The assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("assistingParticipantIds")]
        public List<int> AssistingParticipantIds { get; set; }

        /// <summary>
        /// The building type of the event (tower or inhibitor). Only present if relevant.
        /// </summary>
        [JsonPropertyName("buildingType")]
        public BuildingType? BuildingType { get; set; }

        /// <summary>
        /// Amount of bounty recieved by the killer. Only present if relevant.
        /// </summary>
        [JsonPropertyName("bounty")]
        public int Bounty { get; set; }

        /// <summary>
        /// The creator ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("creatorId")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Event type (building kills, champion kills, ward placements, items purchases, etc).
        /// </summary>
        [JsonPropertyName("type")]
        public MatchEventType? EventType { get; set; }

        /// <summary>
        /// The ending item ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("afterId")]
        public int ItemAfterId { get; set; }

        /// <summary>
        /// The starting item ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("beforeId")]
        public int ItemBeforeId { get; set; }

        /// <summary>
        /// Amount of gold gained by the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("goldGain")]
        public int GoldGain { get; set; }

        /// <summary>
        /// The item ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// The killer ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("killerId")]
        public int KillerId { get; set; }

        /// <summary>
        /// Amount of kills in a kill streak. Only present if relevant.
        /// </summary>
        [JsonPropertyName("killStreakLength")]
        public int KillStreakLength { get; set; }

        /// <summary>
        /// The killer team ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("killerTeamId")]
        public int KillerTeamId { get; set; }

        /// <summary>
        /// The type of the kill. Only present if relevant.
        /// </summary>
        [JsonPropertyName("killType")]
        public string KillType { get; set; }

        /// <summary>
        /// The lane type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("laneType")]
        public LaneType? LaneType { get; set; }

        /// <summary>
        /// The level up type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level{ get; set; }

        /// <summary>
        /// The level up type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("levelUpType")]
        public LevelUpType? LevelUpType { get; set; }

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("monsterType")]
        public MonsterType? MonsterType { get; set; }

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("monsterSubType")]
        public MonsterSubType? MonsterSubType { get; set; }

        /// <summary>
        /// The participant ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// The point captured in the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("pointCaptured")]
        public CapturedPoint? CapturedPoint { get; set; }

        /// <summary>
        /// The position of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Timestamp in the real world. Only present for game start.
        /// </summary>
        [JsonPropertyName("realTimestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime RealTimestamp { get; set; }

        /// <summary>
        /// The skill slot of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("skillSlot")]
        public int SkillSlot { get; set; }

        /// <summary>
        /// The team ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Represents how much time into the game the event occurred.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan Timestamp { get; set; }

        /// <summary>
        /// The tower type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("towerType")]
        public TowerType? TowerType { get; set; }

        /// <summary>
        /// The victim ID of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("victimId")]
        public int VictimId { get; set; }

        /// <summary>
        /// List of Damage Instances dealt by the victim. Only present if relevant.
        /// </summary>
        [JsonPropertyName("victimDamageDealt")]
        public List<VictimDamage> VictimDamageDealt { get; set; }

        /// <summary>
        /// List of Damage Instances received by the victim. Only present if relevant.
        /// </summary>
        [JsonPropertyName("victimDamageReceived")]
        public List<VictimDamage> VictimDamageReceived { get; set; }

        /// <summary>
        /// The ward type of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("wardType")]
        public WardType? WardType { get; set; }

        /// <summary>
        /// The winning team of the event. Only present if relevant.
        /// </summary>
        [JsonPropertyName("winningTeam")]
        public int WinningTeam { get; set; }
    }
}
