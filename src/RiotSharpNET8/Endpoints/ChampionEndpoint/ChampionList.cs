using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.ChampionEndpoint
{
    class ChampionList
    {
        /// <summary>
        /// List of Champions.
        /// </summary>
        [JsonPropertyName("champions")]
        public List<Champion> Champions { get; set; }
    }
}
