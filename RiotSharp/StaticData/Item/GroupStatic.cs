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
    public class GroupStatic
    {
        internal GroupStatic() { }

        /// <summary>
        /// Max group ownable.
        /// </summary>
        [JsonProperty("MaxGroupOwnable")]
        public string MaxGroupOwnable { get; set; }

        /// <summary>
        /// Id of the group.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
