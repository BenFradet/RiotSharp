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
    /// Team id (Team API).
    /// </summary>
    [Obsolete("The team api v2.1 is deprecated.")]
    public class TeamIdV21
    {
        internal TeamIdV21() { }

        /// <summary>
        /// Full id.
        /// </summary>
        [JsonProperty("fullId")]
        public string FullId { get; set; }
    }
}