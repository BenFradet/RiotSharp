using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a particular event during a match (Match API).
    /// </summary>
    [Serializable]
    public class Event
    {
        internal Event() { }

        /// <summary>
        /// The ascended type of the event. Only present if relevant.
        /// Note that CLEAR_ASCENDED refers to when a participants kills the ascended player.
        /// </summary>
        [JsonProperty("ascendedType")]
        [JsonConverter(typeof(AscendedTypeConverter))]
        public AscendedType AscendedType { get; set; }

        /// <summary>
        /// The assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("assistingParticipantIds")]
        public List<int> AssistingParticipantIds { get; set; }

        /// <summary>
        /// The building type of the event (tower or inhibitor). Only present if relevant.
        /// </summary>
        [JsonProperty("buildingType")]
        [JsonConverter(typeof(BuildingTypeConverter))]
        public BuildingType? BuildingType { get; set; }

        /// <summary>
        /// The creator ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("creatorId")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Event type (building kills, champion kills, ward placements, items purchases, etc).
        /// </summary>
        [JsonProperty("eventType")]
        [JsonConverter(typeof(EventTypeConverter))]
        public EventType? EventType { get; set; }

        /// <summary>
        /// The ending item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemAfter")]
        public int ItemAfter { get; set; }

        /// <summary>
        /// The starting item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemBefore")]
        public int ItemBefore { get; set; }

        /// <summary>
        /// The item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// The killer ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("killerId")]
        public int KillerId { get; set; }

        /// <summary>
        /// The lane type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("laneType")]
        [JsonConverter(typeof(LaneTypeConverter))]
        public LaneType? LaneType { get; set; }

        /// <summary>
        /// The level up type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("levelUpType")]
        [JsonConverter(typeof(LevelUpTypeConverter))]
        public LevelUpType? LevelUpType { get; set; }

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("monsterType")]
        [JsonConverter(typeof(MonsterTypeConverter))]
        public MonsterType? MonsterType { get; set; }

        /// <summary>
        /// The participant ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// The point captured in the event. Only present if relevant.
        /// </summary>
        [JsonProperty("pointCaptured")]
        [JsonConverter(typeof(CapturePointConverter))]
        public CapturePoint PointCaptured { get; set; }

        /// <summary>
        /// The position of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The skill slot of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("skillSlot")]
        public int SkillSlot { get; set; }

        /// <summary>
        /// The team ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Represents how much time into the game the event occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan Timestamp { get; set; }

        /// <summary>
        /// The tower type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("towerType")]
        [JsonConverter(typeof(TowerTypeConverter))]
        public TowerType? TowerType { get; set; }

        /// <summary>
        /// The victim ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("victimId")]
        public int VictimId { get; set; }

        /// <summary>
        /// The ward type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("wardType")]
        [JsonConverter(typeof(WardTypeConverter))]
        public WardType? WardType { get; set; }
    }
}
