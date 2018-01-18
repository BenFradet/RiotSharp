﻿using Newtonsoft.Json;

namespace RiotSharp.Endpoints.SummonerEndpoint
{
    /// <summary>
    /// Class representing a Mastery in the API.
    /// </summary>
    public class Mastery
    {
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
