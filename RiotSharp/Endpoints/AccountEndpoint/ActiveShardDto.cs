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
        /// The game.
        /// </summary>
        [JsonProperty("game")]
        public Game Game { get; set; }

        /// <summary>
        /// Active shard for combination Puuid and Game.
        /// </summary>
        [JsonProperty("activeShard")]
        public Region ActiveShard { get; set; }
    }
}
