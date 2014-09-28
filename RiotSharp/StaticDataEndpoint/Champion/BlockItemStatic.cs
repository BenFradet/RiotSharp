// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlockItemStatic.cs" company="">
//
// </copyright>
// <summary>
//   Recommended items in a block (starting, essential, offensive, etc) for a champion (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Recommended items in a block (starting, essential, offensive, etc) for a champion (Static API).
    /// </summary>
    [Serializable]
    public class BlockItemStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockItemStatic"/> class.
        /// </summary>
        internal BlockItemStatic() { }

        /// <summary>
        /// Recommended count.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Id of the recommended item.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
