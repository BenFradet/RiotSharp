using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class ParticipantPerkSelection
    {
        internal ParticipantPerkSelection() { }

        /// <summary>
        /// Perk Id of the <see cref="ParticipantPerkSelection"/>
        /// </summary>
        [JsonProperty("perk")]
        public int Perk { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonProperty("var1")]
        public int Var1 { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonProperty("var2")]
        public int Var2 { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonProperty("var3")]
        public int Var3 { get; set; }
    }
}
