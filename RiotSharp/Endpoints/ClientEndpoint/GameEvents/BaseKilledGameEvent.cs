using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class BaseKilledGameEvent : BaseGameEvent
    {
        internal BaseKilledGameEvent() { }
        
        [JsonProperty("KillerName")]
        public string KillerSummonerName { get; set; }
    }
}