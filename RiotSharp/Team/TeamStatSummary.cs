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
    /// Stat summary of the team (Team API).
    /// </summary>
    [Serializable]
    public class TeamStatSummary
    {
        internal TeamStatSummary() { }

        /// <summary>
        /// Team id.
        /// </summary>
        [JsonProperty("fullId")]
        public string FullId { get; set; }

        /// <summary>
        /// List of team stats.
        /// </summary>
        [JsonProperty("teamStatDetails")]
        public List<TeamStatDetail> TeamStatDetails { get; set; }
    }
}
