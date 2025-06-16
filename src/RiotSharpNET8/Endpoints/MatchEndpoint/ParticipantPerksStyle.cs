using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class ParticipantPerksStyle
    {
        /// <summary>
        /// Description of the Style. <br/>
        /// Values might be 'primaryStyle' or 'subStyle'
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Selected perks of this style.
        /// </summary>
        [JsonPropertyName("selections")]
        public List<ParticipantPerkSelection> Selections { get; set; }

        /// <summary>
        /// Style Id.
        /// </summary>
        [JsonPropertyName("style")]
        public int Style { get; set; }
    }
}
