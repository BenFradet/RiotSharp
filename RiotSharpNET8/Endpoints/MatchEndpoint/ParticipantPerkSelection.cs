using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class ParticipantPerkSelection
    {
        internal ParticipantPerkSelection() { }

        /// <summary>
        /// Perk Id of the <see cref="ParticipantPerkSelection"/>
        /// </summary>
        [JsonPropertyName("perk")]
        public int Perk { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonPropertyName("var1")]
        public int Var1 { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonPropertyName("var2")]
        public int Var2 { get; set; }

        /// <summary>
        /// Post game rune stat of perk.
        /// </summary>
        [JsonPropertyName("var3")]
        public int Var3 { get; set; }
    }
}
