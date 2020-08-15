using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class BaseKilledWithAssistsGameEvent : BaseKilledGameEvent
    {
        [JsonProperty("Assisters")]
        public List<string> AssistingSummonerNames { get; set; }
    }
}