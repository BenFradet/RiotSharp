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
    /// Class representing the name and id of a Summoner in the API.
    /// </summary>
    public class SummonerBase : Thing
    {
        private const string RootUrl = "/api/lol/{0}/v1.1/summoner";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string GameRootUrl = "/api/lol/{0}/v1.1/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueRootUrl = "/api/{0}/v2.1/league";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";

        private const string StatsRootUrl = "/api/lol/{0}/v1.1/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        protected IRequester requester;
        protected Region region;

        public SummonerBase(JToken json, IRequester requester, Region region)
        {
            this.requester = requester;
            this.region = region;
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Get rune pages for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        public Collection<RunePage> GetRunePages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        public async Task<Collection<RunePage>> GetRunePagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        public Collection<MasteryPage> GetMasteryPages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        public async Task<Collection<MasteryPage>> GetMasteryPagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of 10 games.</returns>
        public Collection<Game> GetRecentGames()
        {
            var json = requester.CreateRequest(string.Format(GameRootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<Game>(json, requester, region, "games");
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of 10 games.</returns>
        public async Task<Collection<Game>> GetRecentGamesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameRootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<Game>(json, requester, region, "games");
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        public Collection<League> GetLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<League>(json, requester, region);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        public async Task<Collection<League>> GetLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<League>(json, requester, region);
        }

        /// <summary>
        /// Get player stats summaries for this summoner synchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of player stats summaries.</returns>
        public Collection<PlayerStatsSummary> GetStatsSummaries(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<PlayerStatsSummary>(json, requester, region, "playerStatSummaries");
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of player stats summaries.</returns>
        public async Task<Collection<PlayerStatsSummary>> GetStatsSummariesAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<PlayerStatsSummary>(json, requester, region, "playerStatSummaries");
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of champions stats.</returns>
        public Collection<ChampionStats> GetStatsRanked(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<ChampionStats>(json, requester, region, "champions");
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of champions stats.</returns>
        public async Task<Collection<ChampionStats>> GetStatsRankedAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<ChampionStats>(json, requester, region, "champions");
        }
    }
}
