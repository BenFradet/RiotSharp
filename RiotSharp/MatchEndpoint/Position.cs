// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Position.cs" company="">
//   
// </copyright>
// <summary>
//   Participant's position (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Participant's position (Match API).
    /// </summary>
    [Serializable]
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        internal Position() { }

        /// <summary>
        /// Participant's X coordinate.
        /// </summary>
        [JsonProperty("x")]
        public int X { get; set; }

        /// <summary>
        /// Participant's Y coordinate.
        /// </summary>
        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
