using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing one instance of damage recieved or dealt by a victim.
    /// </summary>
    public class VictimDamage
    {
        internal VictimDamage() { }

        [JsonPropertyName("basic")]
        public bool Basic { get; set; }

        [JsonPropertyName("magicDamage")]
        public int MagicDamage { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        [JsonPropertyName("physicalDamage")]
        public int PhysicalDamage { get; set; }

        [JsonPropertyName("spellName")]
        public string SpellName { get; set; }

        [JsonPropertyName("spellSlot")]
        public int SpellSlot { get; set; }

        [JsonPropertyName("trueDamage")]
        public int TrueDamage { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
