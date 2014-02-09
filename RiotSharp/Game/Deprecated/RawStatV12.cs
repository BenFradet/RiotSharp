using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Raw stat of a game (Game API).
    /// </summary>
    [Obsolete("The game api v1.2 is deprecated, please use RawStat instead.")]
    public class RawStatV12
    {
        internal RawStatV12() { }

        /// <summary>
        /// Raw stat ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Raw stat name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Raw stat value.
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
