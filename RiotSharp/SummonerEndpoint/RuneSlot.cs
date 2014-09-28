// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuneSlot.cs" company="">
//
// </copyright>
// <summary>
//   Slot for a rune (Summoner API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// Slot for a rune (Summoner API).
    /// </summary>
    [Serializable]
    public class RuneSlot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuneSlot"/> class.
        /// </summary>
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
