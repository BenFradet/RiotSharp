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
    /// AggregatedStat (Stats API).
    /// </summary>
    [Obsolete("The stats api v1.1 is deprecated, please use AggregatedStat instead.")]
    public class AggregatedStatV11
    {
        internal AggregatedStatV11() { }

        /// <summary>
        /// Aggregated stat value.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Aggregated stat type ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Aggregated stat type name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
