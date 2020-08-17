using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents an event where someone (could be a champion, a minion, or a neutral objective) killed something or someone. 
    /// </summary>
    public abstract class BaseKilledGameEvent : GameEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseKilledGameEvent"/> class.
        /// </summary>
        internal BaseKilledGameEvent() { }

        /// <summary>
        /// Gets or sets the name of the killer (could be a summoner's name, a minion's name, or a neutral objective's name).
        /// </summary>
        [JsonProperty("KillerName")]
        public string KillerName { get; set; }
    }
}