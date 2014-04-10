using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Talent (Summoner API).
    /// </summary>
    [Serializable]
    [Obsolete("The summoner api v1.3 is deprecated, please use Mastery instead.")]
    public class TalentV13
    {
        internal TalentV13() { }

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
