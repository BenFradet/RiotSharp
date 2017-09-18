using Newtonsoft.Json;
using RiotSharp.GameEndpoint;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.LeagueEndpoint;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// Class representing the name and id of a Summoner in the API.
    /// </summary>
    public class SummonerBase
    {

        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string IdUrl = "/{0}";

        private IRateLimitedRequester requester;
        public Region Region { get; set; }

        internal SummonerBase()
        {
            requester = Requesters.RiotApiRequester;
        }

        //summoner base not default constructor
        internal SummonerBase(string id, string name, IRateLimitedRequester requester, Region region)
        {
            this.requester = requester;
            Region = region;
            Name = name;
            Id = long.Parse(id);
        }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public List<Game> GetRecentGames()
        {
            var json = requester.CreateGetRequest(
                string.Format(GameRootUrl, Region) + string.Format(RecentGamesUrl, Id),
                Region);
            return JsonConvert.DeserializeObject<RecentGames>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public async Task<List<Game>> GetRecentGamesAsync()
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(GameRootUrl, Region) + string.Format(RecentGamesUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RecentGames>(json))).Games;
        }
    }
}
