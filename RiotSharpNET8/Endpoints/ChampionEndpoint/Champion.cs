using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.ChampionEndpoint
{
    /// <summary>
    /// Class representing a Champion in the API.
    /// </summary>
    public class Champion
    {
        /// <summary>
        /// Indicates if the champion is active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Bot enabled flag (for custom games).
        /// </summary>
        [JsonPropertyName("botEnabled")]
        public bool BotEnabled { get; set; }

        /// <summary>
        /// Bot Match Made enabled flag (for Co-op vs. AI games).
        /// </summary>
        [JsonPropertyName("botMmEnabled")]
        public bool BotMmEnabled { get; set; }

        /// <summary>
        /// Indicates if the champion is free to play. Free to play champions are rotated periodically.
        /// </summary>
        [JsonPropertyName("freeToPlay")]
        public bool FreeToPlay { get; set; }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Ranked play enabled flag.
        /// </summary>
        [JsonPropertyName("rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; set; }
    }
}
