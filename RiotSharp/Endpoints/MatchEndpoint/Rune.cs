using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a rune of a participant (Match API).
    /// </summary>
    public class Rune
    {
        internal Rune() { }

        /// <summary>
        /// Rune rank.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("runeId")]
        public int RuneId { get; set; }
    }
}
