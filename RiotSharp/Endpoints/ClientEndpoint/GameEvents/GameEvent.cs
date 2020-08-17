using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents a generic event that occurred during the game.
    /// </summary>
    public class GameEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEvent"/> class.
        /// </summary>
        internal GameEvent() { }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("EventID")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="GameEventType"/>.
        /// </summary>
        [JsonProperty("EventName")]
        public GameEventType Type { get; set; }

        /// <summary>
        /// Gets or sets the time of occurrence.
        /// </summary>
        [JsonProperty("EventTime")]
        public double Time { get; set; }
    }
}