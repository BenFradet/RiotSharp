// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mastery.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a Mastery in the API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// Class representing a Mastery in the API.
    /// </summary>
    [Serializable]
    public class Mastery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mastery"/> class.
        /// </summary>
        internal Mastery() { }

        /// <summary>
        /// Mastery id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Mastery rank (i.e. the number of points put into this mastery).
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
