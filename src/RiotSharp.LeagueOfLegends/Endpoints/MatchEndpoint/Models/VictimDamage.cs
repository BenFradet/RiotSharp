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
        public bool Basic { get; set; }

        /// <summary>
        /// Magic damage amount.
        /// </summary>
        [JsonPropertyName("magicDamage")]
        public int MagicDamage { get; set; }

        /// <summary>
        /// Name of the champion or entity.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Physical damage amount.
        /// </summary>
        [JsonPropertyName("physicalDamage")]
        public int PhysicalDamage { get; set; }

        /// <summary>
        /// Spell name.
        /// </summary>
        [JsonPropertyName("spellName")]
        public string SpellName { get; set; }

        /// <summary>
        /// Spell slot.
        /// </summary>
        [JsonPropertyName("spellSlot")]
        public int SpellSlot { get; set; }

        /// <summary>
        /// True damage amount.
        /// </summary>
        [JsonPropertyName("trueDamage")]
        public int TrueDamage { get; set; }

        /// <summary>
        /// Type of damage source.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
