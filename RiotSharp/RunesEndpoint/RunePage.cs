﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.RunesEndpoint
{
    /// <summary>
    /// Page of runes (Summoner API).
    /// </summary>
    public class RunePage
    {
        internal RunePage() { }

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
        public List<RuneSlot> Slots { get; set; }
    }
}
