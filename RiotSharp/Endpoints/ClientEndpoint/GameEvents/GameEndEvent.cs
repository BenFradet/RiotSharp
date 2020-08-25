using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents a specialized <see cref="GameEvent" />, which marks the end of the game.
    /// </summary>
    public class GameEndEvent : GameEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameEndEvent" /> class.
        /// </summary>
        internal GameEndEvent() { }

        /// <summary>
        ///     Gets or sets the <see cref="GameResultType" />.
        /// </summary>
        [JsonProperty("Result")]
        public GameResultType Result { get; set; }
    }
}