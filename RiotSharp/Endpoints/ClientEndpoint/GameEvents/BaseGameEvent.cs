using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class BaseGameEvent
    {
        internal BaseGameEvent() { }

        [JsonProperty("EventID")]
        public int Id { get; set; }

        [JsonProperty("EventName")]
        public GameEventType Type { get; set; }

        [JsonProperty("EventTime")]
        public double Time { get; set; }
    }
}