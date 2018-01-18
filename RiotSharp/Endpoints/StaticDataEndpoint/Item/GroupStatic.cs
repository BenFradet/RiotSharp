﻿using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Class representing an item's group (Static API).
    /// </summary>
    public class GroupStatic
    {
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
