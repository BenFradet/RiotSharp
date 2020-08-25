using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents the first death of the game.
    /// </summary>
    public class FirstBloodEvent : GameEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FirstBloodEvent" /> class.
        /// </summary>
        internal FirstBloodEvent() { }

        /// <summary>
        ///     The name of the summoner, who's champion has drawn first blood.
        /// </summary>
        [JsonProperty("Recipient")]
        public string RecipientSummonerName { get; set; }
    }
}