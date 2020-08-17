using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents a generic <see cref="BaseKilledWithAssistsGameEvent"/> event, where the victim is a neutral objective (such as the baron, or a dragon).
    /// </summary>
    public abstract class BaseNeutralObjectiveKilledGameEvent : BaseKilledWithAssistsGameEvent
    {
        /// <summary>
        /// Indicates, whether the objective has been stolen.
        /// </summary>
        [JsonProperty("Stolen")]
        public bool HasBeenStolen { get; set; }
    }
}