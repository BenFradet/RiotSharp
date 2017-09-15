﻿using Newtonsoft.Json;

namespace RiotSharp.RunesEndpoint
{
    /// <summary>
    /// Slot for a rune (Summoner API).
    /// </summary>
    public class RuneSlot
    {
        internal RuneSlot() { }

        /// <summary>
        /// Rune ID associated with the rune slot.
        /// </summary>
        [JsonProperty("runeId")]
        public int RuneId { get; set; }

        /// <summary>
        /// <para>Rune slot ID.</para>
        /// <para>Valid: 1 - 30</para>
        /// </summary>
        [JsonProperty("runeSlotId")]
        public int RuneSlotId { get; set; }
    }
}
