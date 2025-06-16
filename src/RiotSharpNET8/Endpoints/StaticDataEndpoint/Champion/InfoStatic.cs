using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// Basic information for a champion (Static API).
    /// </summary>
    public class InfoStatic
    {
        /// <summary>
        /// Number between 1 and 10 representing the attack power of a champion.
        /// </summary>
        [JsonPropertyName("attack")]
        public int Attack { get; set; }

        /// <summary>
        /// Number between 1 and 10 representing the defense power of a champion.
        /// </summary>
        [JsonPropertyName("defense")]
        public int Defense { get; set; }

        /// <summary>
        /// Number between 1 and 10 representing the difficulty of a champion.
        /// </summary>
        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }

        /// <summary>
        /// Number between 1 and 10 representing the magic power of a champion.
        /// </summary>
        [JsonPropertyName("magic")]
        public int Magic { get; set; }
    }
}
