using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Block of recommended items by type (starting, essential, offensive, etc) for a champion (Static API).
    /// </summary>
    [Serializable]
    public class BlockStatic
    {
        internal BlockStatic() { }

        /// <summary>
        /// List of recommended items.
        /// </summary>
        [JsonProperty("items")]
        public List<BlockItemStatic> Items { get; set; }

        /// <summary>
        /// Type of items (starting, essential, offensive, etc).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
