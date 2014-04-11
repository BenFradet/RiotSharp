using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing an item's group (Static API).
    /// </summary>
    [Serializable]
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
