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
    /// Talent (Summoner API).
    /// </summary>
    public class Talent : Thing
    {
        /// <summary>
        /// Talent id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Talent name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Talent rank.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
