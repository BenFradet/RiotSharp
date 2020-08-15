using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class InhibitorKilledEvent : BaseKilledWithAssistsGameEvent
    {
        internal InhibitorKilledEvent() { }

        [JsonProperty("InhibKilled")]
        public string InhibitorKilled { get; set; }
    }
}