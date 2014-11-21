using Newtonsoft.Json;
using System;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// Class representing a Summoner in the API.
    /// </summary>
    [Serializable]
    public class Summoner : SummonerBase
    {
        internal Summoner() { }

        /// <summary>
        /// ID of the summoner icon associated with the summoner.
        /// </summary>
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Date summoner was last modified.
        /// </summary>
        [JsonProperty("revisionDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime RevisionDate { get; set; }

        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }
    }
}
