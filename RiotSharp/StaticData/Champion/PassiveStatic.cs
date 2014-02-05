using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a champion's passive (Static API).
    /// </summary>
    public class PassiveStatic
    {
        /// <summary>
        /// String descripting the passive.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Image of the passive.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Name of the passive.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
