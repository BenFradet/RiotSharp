using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class ParticipantPerksStyle
    {
        internal ParticipantPerksStyle() { }

        /// <summary>
        /// Description of the Style. <br/>
        /// Values might be 'primaryStyle' or 'subStyle'
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Selected perks of this style.
        /// </summary>
        [JsonProperty("selections")]
        public List<ParticipantPerkSelection> Selections { get; set; }

        /// <summary>
        /// Style Id.
        /// </summary>
        [JsonProperty("style")]
        public int Style { get; set; }
    }
}
