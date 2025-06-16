using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.AccountEndpoint.Enums
{
    /// <summary>
    /// The games.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<Game>))]
    public enum Game
    {
        /// <summary>
        /// Legends of Runeterra
        /// </summary>
        LoR,

        /// <summary>
        /// VALORANT
        /// </summary>
        Val
    }
}
