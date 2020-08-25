using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents a multi kill.
    /// </summary>
    public class MultiKillEvent : BaseKilledGameEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MultiKillEvent" /> class.
        /// </summary>
        internal MultiKillEvent() { }

        /// <summary>
        ///     Gets or sets the number of killed victims in this streak.
        /// </summary>
        [JsonProperty("KillStreak")]
        public int KillStreak { get; set; }
    }
}