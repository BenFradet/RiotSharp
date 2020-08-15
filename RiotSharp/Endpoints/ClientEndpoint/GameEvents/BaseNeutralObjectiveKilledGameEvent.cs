using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class BaseNeutralObjectiveKilledGameEvent : BaseKilledWithAssistsGameEvent
    {
        [JsonProperty("Stolen")]
        public bool HasBeenStolen { get; set; }
    }
}