using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.AccountEndpoint.Enums
{
    /// <summary>
    /// The games.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
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
