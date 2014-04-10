using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Mastery (Summoner API).
    /// </summary>
    [Serializable]
    public class Mastery
    {
        internal Mastery() { }

        /// <summary>
        /// Mastery id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Mastery rank (i.e. the number of points put into this mastery).
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
