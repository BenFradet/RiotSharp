using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class FirstBloodEvent : BaseGameEvent
    {
        internal FirstBloodEvent() { }

        [JsonProperty("Recipient")]
        public string RecipientSummonerName { get; set; }
    }
}