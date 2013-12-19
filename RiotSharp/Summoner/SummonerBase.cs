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

        public Collection<RunePage> GetRunePages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        public async Task<Collection<RunePage>> GetRunePagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        public Collection<MasteryPage> GetMasteryPages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPage>(json, requester, region, "pages");
        }

        public async Task<Collection<MasteryPage>> GetMasteryPagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPage>(json, requester, region, "pages");
        }

        public Collection<Game> GetRecentGames()
        {
            var json = requester.CreateRequest(string.Format(GameRootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<Game>(json, requester, region, "games");
        }

        public async Task<Collection<Game>> GetRecentGamesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameRootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<Game>(json, requester, region, "games");
        }

        public Collection<League> GetLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<League>(json, requester, region);
        }

        public async Task<Collection<League>> GetLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<League>(json, requester, region);
        }

        public Collection<PlayerStatsSummary> GetStatSummaries(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<PlayerStatsSummary>(json, requester, region, "playerStatSummaries");
        }

        public async Task<Collection<PlayerStatsSummary>> GetStatSummariesAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<PlayerStatsSummary>(json, requester, region, "playerStatSummaries");
        }

        public Collection<ChampionStats> GetStatsRanked(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<ChampionStats>(json, requester, region, "champions");
        }

        public async Task<Collection<ChampionStats>> GetStatsRankedAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<ChampionStats>(json, requester, region, "champions");
        }
    }
}
