using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents the destruction of an inhibitor.
    /// </summary>
    public class InhibitorKilledEvent : BaseKilledWithAssistsGameEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InhibitorKilled"/> class.
        /// </summary>
        internal InhibitorKilledEvent() { }

        /// <summary>
        /// Gets or sets the inhibitor that has been destroyed.
        /// </summary>
        [JsonProperty("InhibKilled")]
        public string InhibitorKilled { get; set; }
    }
}