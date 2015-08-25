using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.CurrentGameEndpoint;

namespace RiotSharp.FeaturedGamesEndpoint
{
    /// <summary>
    /// Class representing Featured Games in the API.
    /// </summary>
    public class FeaturedGames
    {
        /// <summary>
        /// The suggested interval to wait before requesting FeaturedGames again
        /// </summary>
        [JsonProperty("clientRefreshInterval")]
        public long ClientRefreshInterval { get; set; }

        /// <summary>
        /// The list of featured games
        /// </summary>
        [JsonProperty("gameList")]
        public List<CurrentGame> GameList { get; set; }
    }
}
