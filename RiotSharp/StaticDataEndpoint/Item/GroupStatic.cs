// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupStatic.cs" company="">
//
// </copyright>
// <summary>
//   Class representing an item's group (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing an item's group (Static API).
    /// </summary>
    [Serializable]
    public class GroupStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupStatic"/> class.
        /// </summary>
        internal GroupStatic() { }

        /// <summary>
        /// Max group ownable.
        /// </summary>
        [JsonProperty("MaxGroupOwnable")]
        public string MaxGroupOwnable { get; set; }

        /// <summary>
        /// Key of the group.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
