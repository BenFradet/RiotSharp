using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Page of runes (Summoner API).
    /// </summary>
    [Serializable]
    [Obsolete("The summoner api v1.3 is deprecated, please use RunePage instead.")]
    public class RunePageV13
    {
        internal RunePageV13() { }

        /// <summary>
        /// Indicates if the page is the current page.
        /// </summary>
        [JsonProperty("current")]
        public bool Current { get; set; }

        /// <summary>
        /// Rune page ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Rune page name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of rune slots associated with the rune page.
        /// </summary>
        [JsonProperty("slots")]
        public List<RuneSlotV13> Slots { get; set; }
    }
}
