using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Stat summary of the team (Team API).
    /// </summary>
    [Obsolete("The team api v2.2 is deprecated, please use TeamStatDetail instead.")]
    [Serializable]
    public class TeamStatSummaryV22
    {
        internal TeamStatSummaryV22() { }

        /// <summary>
        /// Team id.
        /// </summary>
        [JsonProperty("fullId")]
        public string FullId { get; set; }

        /// <summary>
        /// List of team stats.
        /// </summary>
        [JsonProperty("teamStatDetails")]
        public List<TeamStatDetailV22> TeamStatDetails { get; set; }
    }
}
