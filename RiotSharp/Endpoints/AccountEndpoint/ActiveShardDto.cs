using Newtonsoft.Json;
using RiotSharp.Endpoints.AccountEndpoint.Enums;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.AccountEndpoint
{
    /// <summary>
    /// Class representing an activeShard.
    /// </summary>
    public class ActiveShardDto
    {
        internal ActiveShardDto() { }

        /// <summary>
        /// Encrypted PUUID. Exact length of 78 characters.
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("game")]
        public Game Game { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Missing support for Valorant's platforms.
        /// </remarks>
        [JsonProperty("activeShard")]
        public Region ActiveShard { get; set; }
    }
}
