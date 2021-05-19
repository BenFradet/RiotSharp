using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing one instance of damage recieved or dealt by a victim.
    /// </summary>
    public class VictimDamage
    {
        internal VictimDamage() { }

        [JsonProperty("basic")]
        public bool Basic { get; set; }

        [JsonProperty("magicDamage")]
        public int MagicDamage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("physicalDamage")]
        public int PhysicalDamage { get; set; }

        [JsonProperty("spellName")]
        public string SpellName { get; set; }

        [JsonProperty("spellSlot")]
        public int SpellSlot { get; set; }

        [JsonProperty("trueDamage")]
        public int TrueDamage { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
