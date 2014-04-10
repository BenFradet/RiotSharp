using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Slot for a rune (Summoner API).
    /// </summary>
    [Serializable]
    [Obsolete("The summoner api v1.3 is deprecated, please use RuneSlot instead.")]
    public class RuneSlotV13
    {
        internal RuneSlotV13() { }

        /// <summary>
        /// Rune associated with the rune slot.
        /// </summary>
        [JsonProperty("rune")]
        public RuneV13 Rune { get; set; }

        /// <summary>
        /// Rune slot ID.
        /// </summary>
        [JsonProperty("runeSlotId")]
        public int RuneSlotId { get; set; }
    }
}
