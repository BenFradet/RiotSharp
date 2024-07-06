using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a Perks in the API.
    /// </summary>
    public class Perks
    {
        /// <summary>
        /// Primary runes path
        /// </summary>
        [JsonPropertyName("perkStyle")]
        public long PerkStyle { get; set; }

        /// <summary>
        /// Secondary runes path
        /// </summary>
        [JsonPropertyName("perkSubStyle")]
        public long PerkSubStyle { get; set; }

        /// <summary>
        /// IDs of the perks/runes assigned.
        /// </summary>
        [JsonPropertyName("perkIds")]
        public List<long> PerkIds { get; set; }      
    }
}
