using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a rune (Static API).
    /// </summary>
    public class RuneStatic
    {
        /// <summary>
        /// String descripting the rune.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Rune's image.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Rune's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Plain text descripting the rune.
        /// </summary>
        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        /// <summary>
        /// Rune's type.
        /// </summary>
        [JsonProperty("rune")]
        public RuneTypeStatic RuneType { get; set; }

        /// <summary>
        /// Rune's stats.
        /// </summary>
        [JsonProperty("stats")]
        public StatsStatic Stats { get; set; }

        /// <summary>
        /// List of tags for this rune (defense, perlevel, mark, etc).
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
