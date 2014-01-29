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
        private const string RootV11Url = "/api/lol/{0}/v1.1/summoner";
        private const string RootV12Url = "/api/lol/{0}/v1.2/summoner";
        private const string RootUrl = "/api/lol/{0}/v1.3/summoner";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string GameV11RootUrl = "/api/lol/{0}/v1.1/game";
        private const string GameV12RootUrl = "/api/lol/{0}/v1.2/game";
        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueV21RootUrl = "/api/{0}/v2.1/league";
        private const string LeagueV22RootUrl = "/api/lol/{0}/v2.2/league";
        private const string LeagueRootUrl = "/api/lol/{0}/v2.3/league";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";

        private const string StatsV11RootUrl = "/api/lol/{0}/v1.1/stats";
        private const string StatsRootUrl = "/api/lol/{0}/v1.2/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        private const string TeamV21RootUrl = "/api/{0}/v2.1/team";
        private const string TeamRootUrl = "/api/lol/{0}/v2.2/team";
        private const string TeamBySummonerUrl = "/by-summoner/{0}";

        protected IRequester requester;
        protected Region region;

        public SummonerBase(string id, string name, IRequester requester, Region region)
        {
            this.requester = requester;
            this.region = region;
            this.Name = name;
            this.Id = long.Parse(id);
        }

        public SummonerBase(string json, IRequester requester, Region region)
        {
            this.requester = requester;
            this.region = region;
            JsonConvert.PopulateObject(json, this, RiotApi.JsonSerializerSettings);
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
            var parsed = JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString();
            return new Collection<RunePage>(parsed, requester, region, "pages");
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        public async Task<Collection<RunePage>> GetRunePagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region)
                + string.Format(RunesUrl, Id));
            var parsed = JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString();
            return new Collection<RunePage>(parsed, requester, region, "pages");
        }

        /// <summary>
        /// Get rune pages for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetRunePages() instead.")]
        public Collection<RunePage> GetRunePagesV12()
        {
            var json = requester.CreateRequest(string.Format(RootV12Url, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetRunePagesAsync() instead.")]
        public async Task<Collection<RunePage>> GetRunePagesV12Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV12Url, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get rune pages for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetRunePages() instead.")]
        public Collection<RunePage> GetRunePagesV11()
        {
            var json = requester.CreateRequest(string.Format(RootV11Url, region)
                + string.Format(RunesUrl, Id));
            return new Collection<RunePage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of rune pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetRunePagesAsync() instead.")]
        public async Task<Collection<RunePage>> GetRunePagesV11Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV11Url, region)
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
            var parsed = JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString();
            return new Collection<MasteryPage>(parsed, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        public async Task<Collection<MasteryPage>> GetMasteryPagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region)
                + string.Format(MasteriesUrl, Id));
            var parsed = JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString();
            return new Collection<MasteryPage>(parsed, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetMasteryPages() instead.")]
        public Collection<MasteryPage> GetMasteryPagesV12()
        {
            var json = requester.CreateRequest(string.Format(RootV12Url, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetMasteryPagesAsync() instead.")]
        public async Task<Collection<MasteryPage>> GetMasteryPagesV12Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV12Url, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPage>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetMasteryPages() instead.")]
        public Collection<MasteryPageV11> GetMasteryPagesV11()
        {
            var json = requester.CreateRequest(string.Format(RootV11Url, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPageV11>(json, requester, region, "pages");
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of mastery pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetMasteryPagesAsync() instead.")]
        public async Task<Collection<MasteryPageV11>> GetMasteryPagesV11Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV11Url, region)
                + string.Format(MasteriesUrl, Id));
            return new Collection<MasteryPageV11>(json, requester, region, "pages");
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
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of 10 games.</returns>
        [Obsolete("The game api v1.2 is deprecated, please use GetRecentGames() instead.")]
        public Collection<GameV12> GetRecentGamesV12()
        {
            var json = requester.CreateRequest(string.Format(GameV12RootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<GameV12>(json, requester, region, "games");
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of 10 games.</returns>
        [Obsolete("The game api v1.1 is deprecated, please use GetRecentGamesAsync() instead.")]
        public async Task<Collection<GameV12>> GetRecentGamesV12Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameV12RootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<GameV12>(json, requester, region, "games");
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>Collection of 10 games.</returns>
        [Obsolete("The game api v1.1 is deprecated, please use GetRecentGames() instead.")]
        public Collection<GameV11> GetRecentGamesV11()
        {
            var json = requester.CreateRequest(string.Format(GameV11RootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<GameV11>(json, requester, region, "games");
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>Collection of 10 games.</returns>
        [Obsolete("The game api v1.1 is deprecated, please use GetRecentGamesAsync() instead.")]
        public async Task<Collection<GameV11>> GetRecentGamesV11Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameV11RootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return new Collection<GameV11>(json, requester, region, "games");
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        public List<League> GetLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<List<League>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        public async Task<List<League>> GetLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<List<League>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        [Obsolete("The league api v2.2 is deprecated, please use GetLeagues() instead.")]
        public Collection<LeagueV22> GetLeaguesV22()
        {
            var json = requester.CreateRequest(string.Format(LeagueV22RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<LeagueV22>(json, requester, region);
        }        

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        [Obsolete("The league api v2.1 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<Collection<LeagueV22>> GetLeaguesV22Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueV22RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<LeagueV22>(json, requester, region);
        }
        
        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        [Obsolete("The league api v2.1 is deprecated, please use GetLeagues() instead.")]
        public Collection<LeagueV21> GetLeaguesV21()
        {
            var json = requester.CreateRequest(string.Format(LeagueV21RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<LeagueV21>(json, requester, region);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>Collection of leagues.</returns>
        [Obsolete("The league api v2.1 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<Collection<LeagueV21>> GetLeaguesV21Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueV21RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return new Collection<LeagueV21>(json, requester, region);
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
        /// Get player stats summaries for this summoner synchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of player stats summaries.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsSummaries() instead.")]
        public Collection<PlayerStatsSummaryV11> GetStatsSummariesV11(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsV11RootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<PlayerStatsSummaryV11>(json, requester, region, "playerStatSummaries");
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of player stats summaries.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsSummariesAsync() instead.")]
        public async Task<Collection<PlayerStatsSummaryV11>> GetStatsSummariesV11Async(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsV11RootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<PlayerStatsSummaryV11>(json, requester, region, "playerStatSummaries");
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

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of champions stats.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsRanked() instead.")]
        public Collection<ChampionStatsV11> GetStatsRankedV11(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsV11RootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<ChampionStatsV11>(json, requester, region, "champions");
        }

        /// <summary>
        /// Get ranked stats for this summoner asynchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>Collection of champions stats.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsRankedAsync() instead.")]
        public async Task<Collection<ChampionStatsV11>> GetStatsRankedV11Async(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsV11RootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            return new Collection<ChampionStatsV11>(json, requester, region, "champions");
        }

        /// <summary>
        /// Get team information for this summoner synchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public List<Team> GetTeams()
        {
            var json = requester.CreateRequest(string.Format(TeamRootUrl, region)
                + string.Format(TeamBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<List<Team>>(json);
        }

        /// <summary>
        /// Get team information for this summoner asynchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public async Task<List<Team>> GetTeamsAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(TeamRootUrl, region)
                + string.Format(TeamBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<List<Team>>(json);
        }

        /// <summary>
        /// Get team information for this summoner synchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        [Obsolete("The team api v2.1 is deprecated, please use GetTeam() instead.")]
        public List<TeamV21> GetTeamsV21()
        {
            var json = requester.CreateRequest(string.Format(TeamV21RootUrl, region)
                + string.Format(TeamBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<List<TeamV21>>(json);
        }

        /// <summary>
        /// Get team information for this summoner asynchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        [Obsolete("The team api v2.1 is deprecated, please use GetTeamAsync() instead.")]
        public async Task<List<TeamV21>> GetTeamsV21Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(TeamV21RootUrl, region)
                + string.Format(TeamBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<List<TeamV21>>(json);
        }
    }
}
