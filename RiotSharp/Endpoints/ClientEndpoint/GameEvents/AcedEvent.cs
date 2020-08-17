using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents the death of an entire team.
    /// </summary>
    public class AcedEvent : GameEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcedEvent"/> class.
        /// </summary>
        internal AcedEvent() { }

        /// <summary>
        /// The summoner, who killed the last remaining player on the enemy team.
        /// </summary>
        [JsonProperty("Acer")]
        public string AcerSummonerName { get; set; }

        /// <summary>
        /// The team, which got eliminated entirely.
        /// </summary>
        [JsonProperty("AcingTeam")]
        public TeamType AcingTeam { get; set; }
    }
}