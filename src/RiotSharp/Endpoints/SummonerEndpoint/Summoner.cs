using System;
using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.SummonerEndpoint
{
    /// <summary>
    /// Class representing a Summoner in the API.
    /// </summary>
    public class Summoner : SummonerBase
    {
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
