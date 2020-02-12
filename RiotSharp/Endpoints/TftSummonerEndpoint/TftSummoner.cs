using Newtonsoft.Json;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;
using System;

namespace RiotSharp.Endpoints.TftSummonerEndpoint
{
    public class TftSummoner
    {
        /// <summary>
        /// Defines the Region of a Summoner.
        /// </summary>
        public Region Region { get; set; }

        internal TftSummoner() { }

        internal TftSummoner(string id, string name, Region region)
        {
            Region = region;
            Name = name;
            Id = id;
        }

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

        /// <summary>
        /// Encrypted summoner ID. Max length 63 characters.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Encrypted account ID. Max length 56 characters.
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Encrypted PUUID. Exact length of 78 characters.
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }
    }
}
