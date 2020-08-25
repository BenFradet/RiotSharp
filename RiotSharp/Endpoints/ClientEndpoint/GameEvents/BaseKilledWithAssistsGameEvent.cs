using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents a generic <see cref="BaseKilledGameEvent" /> where other summoners (besides the actual killer) contributed.
    /// </summary>
    public abstract class BaseKilledWithAssistsGameEvent : BaseKilledGameEvent
    {
        /// <summary>
        ///     Gets or sets the list of contributors, who have not killed the victim.
        /// </summary>
        [JsonProperty("Assisters")]
        public List<string> AssistersNames { get; set; }
    }
}