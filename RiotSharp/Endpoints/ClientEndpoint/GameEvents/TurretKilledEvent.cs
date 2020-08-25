using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    ///     Represents the destruction of a turret.
    /// </summary>
    public class TurretKilledEvent : BaseKilledWithAssistsGameEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TurretKilled" /> class.
        /// </summary>
        internal TurretKilledEvent() { }

        /// <summary>
        ///     Gets or sets the turret that has been destroyed.
        /// </summary>
        [JsonProperty("TurretKilled")]
        public string TurretKilled { get; set; }
    }
}