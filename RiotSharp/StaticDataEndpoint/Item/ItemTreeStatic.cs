// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemTreeStatic.cs" company="">
//   
// </copyright>
// <summary>
//   Class representing an item tree in the shop (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing an item tree in the shop (Static API).
    /// </summary>
    [Serializable]
    public class ItemTreeStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemTreeStatic"/> class.
        /// </summary>
        internal ItemTreeStatic() { }

        /// <summary>
        /// Tree's header (Tools, Defense, Attack, Magic, Movement).
        /// </summary>
        [JsonProperty("header")]
        public string Header { get; set; }

        /// <summary>
        /// Tags available in this tree.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
