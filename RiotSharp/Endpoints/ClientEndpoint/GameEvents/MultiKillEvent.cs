using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class MultiKillEvent : BaseKilledGameEvent
    {
        internal MultiKillEvent() { }
        
        [JsonProperty("KillStreak")]
        public int KillStreak { get; set; }
    }
}