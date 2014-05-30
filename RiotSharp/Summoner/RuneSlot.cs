using System;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Slot for a rune (Summoner API).
    /// </summary>
    [Serializable]
    public class RuneSlot
    {
        internal RuneSlot() { }

        /// <summary>
        /// Rune associated with the rune slot.
        /// </summary>
        [JsonProperty("rune")]
        public Rune Rune { get; set; }

        /// <summary>
        /// <para>Rune slot ID.</para>
        /// <para>Valid: 1 - 30</para>
        /// </summary>
        [JsonProperty("runeSlotId")]
        public int RuneSlotId { get; set; }
    }
}
