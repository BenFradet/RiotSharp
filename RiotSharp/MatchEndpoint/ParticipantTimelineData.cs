using System;
using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class holding timeline values (Match API).
    /// </summary>
    [Serializable]
    public class ParticipantTimelineData
    {
        internal ParticipantTimelineData() { }

        /// <summary>
        /// Value per minute from 10 min to 20 min.
        /// </summary>
        [JsonProperty("tenToTwenty")]
        public double TenToTwenty { get; set; }

        /// <summary>
        /// Value per minute from 30 min to the end of the game.
        /// </summary>
        [JsonProperty("thirtyToEnd")]
        public double ThirtyToEnd { get; set; }

        /// <summary>
        /// Value per minute from 20 min to 30 min.
        /// </summary>
        [JsonProperty("twentyToThirty")]
        public double TwentyToThirty { get; set; }

        /// <summary>
        /// Value per minute from the beginning of the game to 10 min.
        /// </summary>
        [JsonProperty("zeroToTen")]
        public double ZeroToTen { get; set; }
    }
}
