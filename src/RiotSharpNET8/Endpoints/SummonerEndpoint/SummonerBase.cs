using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.SummonerEndpoint
{
    /// <summary>
    /// Class representing the name and id of a Summoner in the API.
    /// </summary>
    public class SummonerBase
    {
        /// <summary>
        /// Defines the Region of a Summoner.
        /// </summary>
        public Region Region { get; set; }

        internal SummonerBase() { }

        internal SummonerBase(string id, string name, Region region)
        {
            Region = region;
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Encrypted summoner ID. Max length 63 characters.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Encrypted account ID. Max length 56 characters.
        /// </summary>
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Encrypted PUUID. Exact length of 78 characters.
        /// </summary>
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }
    }
}
