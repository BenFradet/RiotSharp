using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents a list of <see cref="GameEvent"/>.
    /// </summary>
    public class GameEventList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEventList"/> class.
        /// </summary>
        internal GameEventList() { }

        /// <summary>
        /// Gets or sets the list of <see cref="GameEvent"/> that already happened in the game.
        /// </summary>
        [JsonProperty("Events", ItemConverterType = typeof(GameEventConverter))]
        public List<GameEvent> Events { get; set; }
    }
}