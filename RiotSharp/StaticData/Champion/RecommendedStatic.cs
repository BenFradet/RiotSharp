using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a recommended item for a champion (Static API).
    /// </summary>
    public class RecommendedStatic
    {
        internal RecommendedStatic() { }

        /// <summary>
        /// List of recommended items ordered by block.
        /// </summary>
        [JsonProperty("blocks")]
        public List<BlockStatic> Blocks { get; set; }

        /// <summary>
        /// Name of the champion for which those items are recommended.
        /// </summary>
        [JsonProperty("champion")]
        public string Champion { get; set; }

        /// <summary>
        /// Map for which those items are recommended.
        /// </summary>
        [JsonProperty("map")]
        public string Map { get; set; }

        /// <summary>
        /// Mode for which those items are recommended.
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode Mode { get; set; }
        
        /// <summary>
        /// Priority of the recommended items list.
        /// </summary>
        [JsonProperty("priority")]
        public bool Priority { get; set; }

        /// <summary>
        /// Title of the items list.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Type of list.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
