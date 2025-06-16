using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// A ban
    /// </summary>
    public class TeamBan
    {
        internal TeamBan() { }

        /// <summary>
        /// The pick turn where the champion has been banned.
        /// </summary>
        [JsonPropertyName("pickTurn")]
        public int PickTurn { get; set; }
        /// <summary>
        /// ID of the banned champion.
        /// </summary>
        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }
    }
}
