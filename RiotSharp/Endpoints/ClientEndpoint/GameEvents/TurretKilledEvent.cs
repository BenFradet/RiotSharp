using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class TurretKilledEvent : BaseKilledWithAssistsGameEvent
    {
        internal TurretKilledEvent() { }
        
        [JsonProperty("TurretKilled")]
        public string TurretKilled { get; set; }
    }
}