using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class BaseKilledGameEvent : GameEvent
    {
        internal BaseKilledGameEvent() { }

        [JsonProperty("KillerName")]
        public string KillerSummonerName { get; set; }
    }
}