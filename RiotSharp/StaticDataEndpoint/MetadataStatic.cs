// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataStatic.cs" company="">
//
// </copyright>
// <summary>
//   Class representing metadata on runes and items (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing metadata on runes and items (Static API).
    /// </summary>
    [Serializable]
    public class MetadataStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataStatic"/> class.
        /// </summary>
        internal MetadataStatic() { }

        /// <summary>
        /// Whether this item is a rune or not.
        /// </summary>
        [JsonProperty("isRune")]
        public bool IsRune { get; set; }

        /// <summary>
        /// Tier of the rune.
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }

        /// <summary>
        /// Type of the rune.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
