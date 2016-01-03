using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.GameEndpoint
{
    class RecentGames
    {
        /// <summary>
        /// A list of games for a summoner.
        /// </summary>
        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        /// <summary>
        /// The summonerId assosiated with the games.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
