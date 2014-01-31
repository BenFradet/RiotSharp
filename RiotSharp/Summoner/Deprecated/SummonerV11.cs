using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a Summoner in the API.
    /// </summary>
    public class SummonerV11 : SummonerBase
    {
        internal SummonerV11(string summoner, RateLimitedRequester requester, Region region)
            : base(summoner, requester, region) { }
        
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
        /// Human readable string representing date summoner was last modified.
        /// </summary>
        [JsonProperty("revisionDateStr")]
        public string RevisionDateString { get; set; }

        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }
    }
}
