﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlockStatic.cs" company="">
//
// </copyright>
// <summary>
//   Block of recommended items by type (starting, essential, offensive, etc) for a champion (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Block of recommended items by type (starting, essential, offensive, etc) for a champion (Static API).
    /// </summary>
    [Serializable]
    public class BlockStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStatic"/> class.
        /// </summary>
        internal BlockStatic() { }

        /// <summary>
        /// List of recommended items.
        /// </summary>
        [JsonProperty("items")]
        public List<BlockItemStatic> Items { get; set; }

        /// <summary>
        /// Rec math.
        /// </summary>
        [JsonProperty("recMath")]
        public bool RecMath { get; set; }

        /// <summary>
        /// Type of items (starting, essential, offensive, etc).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
