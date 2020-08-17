namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    /// <summary>
    /// Represents the death of the baron.
    /// </summary>
    public class BaronKilledEvent : BaseNeutralObjectiveKilledGameEvent
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="BaronKilledEvent"/> class.
        /// </summary>
        internal BaronKilledEvent() { }
    }
}