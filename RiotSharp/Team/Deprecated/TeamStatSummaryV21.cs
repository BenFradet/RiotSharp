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
    [Obsolete("The team api v2.1 is deprecated, please use TeamStatSummary instead.")]
    public class TeamStatSummaryV21
    {
        internal TeamStatSummaryV21() { }

        /// <summary>
        /// Team id.
        /// </summary>
        [JsonProperty("teamId")]
        public TeamIdV21 TeamId { get; set; }

        /// <summary>
        /// List of team stats.
        /// </summary>
        [JsonProperty("teamStatDetails")]
        public List<TeamStatDetailV21> TeamStatDetails { get; set; }
    }
}