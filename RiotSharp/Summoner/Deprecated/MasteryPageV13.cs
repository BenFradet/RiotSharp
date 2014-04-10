using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Mastery page (Summoner API).
    /// </summary>
    [Serializable]
    [Obsolete("The summoner api v1.3 is deprecated, please use MasteryPage instead.")]
    public class MasteryPageV13
    {
        internal MasteryPageV13() { }

        /// <summary>
        /// Indicates if the mastery page is the current mastery page.
        /// </summary>
        [JsonProperty("current")]
        public bool Current { get; set; }

        /// <summary>
        /// Mastery page id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Mastery page name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of mastery page talents associated with the mastery page.
        /// </summary>
        [JsonProperty("talents")]
        public List<TalentV13> Talents { get; set; }
    }
}
