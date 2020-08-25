using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents a <see cref="BaseKilledWithAssistsGameEvent" /> where a champion has been killed.
    /// </summary>
    public class ChampionKilledEvent : BaseKilledWithAssistsGameEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChampionKilledEvent" /> class.
        /// </summary>
        internal ChampionKilledEvent() { }

        /// <summary>
        ///     The name of the summoner, who's champion has been killed.
        /// </summary>
        [JsonProperty("VictimName")]
        public string VictimSummonerName { get; set; }
    }
}