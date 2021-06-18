using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class ParticipantPerksStatPerks
    {
        internal ParticipantPerksStatPerks() { }

        /// <summary>
        /// Perk Id of the defense stat perk.
        /// </summary>
        [JsonProperty("defense")]
        public int Defense { get; set; }

        /// <summary>
        /// Perk Id of the flex stat perk.
        /// </summary>
        [JsonProperty("flex")]
        public int Flex { get; set; }

        /// <summary>
        /// Perk Id of the offense stat perk.
        /// </summary>
        [JsonProperty("offense")]
        public int Offense { get; set; }
    }
}
