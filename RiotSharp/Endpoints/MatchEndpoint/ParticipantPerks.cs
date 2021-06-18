using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class ParticipantPerks
    {
        internal ParticipantPerks() { }

        /// <summary>
        /// Stat perks selected by participant.
        /// </summary>
        [JsonProperty("statPerks")]
        public ParticipantPerksStatPerks StatPerks { get; set; }

        /// <summary>
        /// Styles and perks selected by participant.
        /// </summary>
        [JsonProperty("styles")]
        public List<ParticipantPerksStyle> Styles { get; set; }

    }
}
