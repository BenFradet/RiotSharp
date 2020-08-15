using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class DragonKilledEvent : BaseNeutralObjectiveKilledGameEvent
    {
        [JsonProperty("DragonType")]
        public DragonType DragonType { get; set; }
    }
}