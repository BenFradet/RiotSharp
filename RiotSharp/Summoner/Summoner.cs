﻿using System;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a Summoner in the API.
    /// </summary>
    [Serializable]
    public class Summoner : SummonerBase
    {
        internal Summoner() : base() { }

        /// <summary>
        /// ID of the summoner icon associated with the summoner.
        /// </summary>
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Date summoner was last modified.
        /// </summary>
        [JsonProperty("revisionDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime RevisionDate { get; set; }

        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }
    }
}
