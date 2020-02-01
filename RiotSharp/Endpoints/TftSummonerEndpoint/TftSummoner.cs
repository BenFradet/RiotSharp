using Newtonsoft.Json;
using RiotSharp.Misc.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.TftSummonerEndpoint
{
    public class TftSummoner : TftSummonerBase
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
