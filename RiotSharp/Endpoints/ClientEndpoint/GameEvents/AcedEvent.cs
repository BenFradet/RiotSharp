using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class AcedEvent : BaseGameEvent
    {
        internal AcedEvent()
        {
        }

        [JsonProperty("Acer")]
        public string AcerSummonerName { get; set; }

        [JsonProperty("AcingTeam")]
        public TeamType AcingTeam { get; set; }
    }
}