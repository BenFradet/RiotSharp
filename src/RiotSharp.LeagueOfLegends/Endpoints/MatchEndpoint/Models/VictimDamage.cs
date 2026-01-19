using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Damage data for victim in kill events.
    /// </summary>
    public class VictimDamage
    {
        /// <summary>
        /// Whether this was a basic attack.
        /// </summary>
        [JsonPropertyName("basic")]
        public required bool Basic { get; set; }

        /// <summary>
        /// Magic damage amount.
        /// </summary>
        [JsonPropertyName("magicDamage")]
        public required int MagicDamage { get; set; }

        /// <summary>
        /// Name of the champion or entity.
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public required int ParticipantId { get; set; }

        /// <summary>
        /// Physical damage amount.
        /// </summary>
        [JsonPropertyName("physicalDamage")]
        public required int PhysicalDamage { get; set; }

        /// <summary>
        /// Spell name.
        /// </summary>
        [JsonPropertyName("spellName")]
        public required string SpellName { get; set; }

        /// <summary>
        /// Spell slot.
        /// </summary>
        [JsonPropertyName("spellSlot")]
        public required int SpellSlot { get; set; }

        /// <summary>
        /// True damage amount.
        /// </summary>
        [JsonPropertyName("trueDamage")]
        public required int TrueDamage { get; set; }

        /// <summary>
        /// Type of damage source.
        /// </summary>
        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
}
