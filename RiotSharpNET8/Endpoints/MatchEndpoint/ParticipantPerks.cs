using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class ParticipantPerks
    {
        internal ParticipantPerks() { }

        /// <summary>
        /// Stat perks selected by participant.
        /// </summary>
        [JsonPropertyName("statPerks")]
        public ParticipantPerksStatPerks StatPerks { get; set; }

        /// <summary>
        /// Styles and perks selected by participant.
        /// </summary>
        [JsonPropertyName("styles")]
        public List<ParticipantPerksStyle> Styles { get; set; }

    }
}
