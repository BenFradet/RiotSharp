using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents a <see cref="BaseNeutralObjectiveKilledGameEvent" /> where a dragon has been killed.
    /// </summary>
    public class DragonKilledEvent : BaseNeutralObjectiveKilledGameEvent
    {
        /// <summary>
        ///     Indicates the <see cref="DragonType" /> that has been killed.
        /// </summary>
        [JsonProperty("DragonType")]
        public DragonType DragonType { get; set; }
    }
}