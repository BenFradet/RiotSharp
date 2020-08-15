using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class ChampionKilledEvent : BaseKilledWithAssistsGameEvent
    {
        internal ChampionKilledEvent() { }

        [JsonProperty("VictimName")]
        public string VictimSummonerName { get; set; }
    }
}