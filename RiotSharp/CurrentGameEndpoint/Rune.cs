using Newtonsoft.Json;

namespace RiotSharp.CurrentGameEndpoint
{
    /// <summary>
    /// Class representing a Rune in the API.
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// The count of this rune used by the participant
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// The ID of the rune
        /// </summary>
        [JsonProperty("runeId")]
        public long RuneId { get; set; }
    }
}
