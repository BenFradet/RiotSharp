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
    public class SummonerBase
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
        private const string LeagueBySummonerEntryUrl = "/entry";

        private const string StatsV11RootUrl = "/api/lol/{0}/v1.1/stats";
        private const string StatsRootUrl = "/api/lol/{0}/v1.2/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        private const string TeamRootUrl = "/api/lol/{0}/v2.2/team";
        private const string TeamBySummonerUrl = "/by-summoner/{0}";

        private RateLimitedRequester requester;
        private Region region;

        internal SummonerBase()
        {
            requester = RateLimitedRequester.Instance;
            region = Region.euw;
        }

        internal SummonerBase(string id, string name, RateLimitedRequester requester, Region region)
        {
            this.requester = requester;
            this.region = region;
            this.Name = name;
            this.Id = long.Parse(id);
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
        /// <returns>A list of rune pages.</returns>
        public List<RunePage> GetRunePages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, region) + string.Format(RunesUrl, Id));
            return JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        public async Task<List<RunePage>> GetRunePagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region) + string.Format(RunesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<Dictionary<string, RunePages>>(json))
                .Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetRunePages() instead.")]
        public List<RunePage> GetRunePagesV12()
        {
            var json = requester.CreateRequest(string.Format(RootV12Url, region) + string.Format(RunesUrl, Id));
            return JsonConvert.DeserializeObject<RunePages>(json).Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetRunePagesAsync() instead.")]
        public async Task<List<RunePage>> GetRunePagesV12Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV12Url, region) + string.Format(RunesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RunePages>(json)).Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetRunePages() instead.")]
        public List<RunePage> GetRunePagesV11()
        {
            var json = requester.CreateRequest(string.Format(RootV11Url, region) + string.Format(RunesUrl, Id));
            return JsonConvert.DeserializeObject<RunePages>(json).Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetRunePagesAsync() instead.")]
        public async Task<List<RunePage>> GetRunePagesV11Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV11Url, region) + string.Format(RunesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RunePages>(json)).Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        public List<MasteryPage> GetMasteryPages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, region) + string.Format(MasteriesUrl, Id));
            return JsonConvert.DeserializeObject<Dictionary<long, MasteryPages>>(json).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        public async Task<List<MasteryPage>> GetMasteryPagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, region) + string.Format(MasteriesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<Dictionary<long, MasteryPages>>(json))
                .Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetMasteryPages() instead.")]
        public List<MasteryPage> GetMasteryPagesV12()
        {
            var json = requester.CreateRequest(string.Format(RootV12Url, region) + string.Format(MasteriesUrl, Id));
            return JsonConvert.DeserializeObject<MasteryPages>(json).Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetMasteryPagesAsync() instead.")]
        public async Task<List<MasteryPage>> GetMasteryPagesV12Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV12Url, region) 
                + string.Format(MasteriesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<MasteryPages>(json)).Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetMasteryPages() instead.")]
        public List<MasteryPageV11> GetMasteryPagesV11()
        {
            var json = requester.CreateRequest(string.Format(RootV11Url, region) + string.Format(MasteriesUrl, Id));
            return JsonConvert.DeserializeObject<MasteryPagesV11>(json).Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetMasteryPagesAsync() instead.")]
        public async Task<List<MasteryPageV11>> GetMasteryPagesV11Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootV11Url, region)
                + string.Format(MasteriesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<MasteryPagesV11>(json)).Pages;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public List<Game> GetRecentGames()
        {
            var json = requester.CreateRequest(string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, Id));
            return JsonConvert.DeserializeObject<RecentGames>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public async Task<List<Game>> GetRecentGamesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameRootUrl, region) 
                + string.Format(RecentGamesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RecentGames>(json)).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        [Obsolete("The game api v1.2 is deprecated, please use GetRecentGames() instead.")]
        public List<GameV12> GetRecentGamesV12()
        {
            var json = requester.CreateRequest(string.Format(GameV12RootUrl, region) + string.Format(RecentGamesUrl, Id));
            return JsonConvert.DeserializeObject<RecentGamesV12>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        [Obsolete("The game api v1.1 is deprecated, please use GetRecentGamesAsync() instead.")]
        public async Task<List<GameV12>> GetRecentGamesV12Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameV12RootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RecentGamesV12>(json)).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        [Obsolete("The game api v1.1 is deprecated, please use GetRecentGames() instead.")]
        public List<GameV11> GetRecentGamesV11()
        {
            var json = requester.CreateRequest(string.Format(GameV11RootUrl, region) + string.Format(RecentGamesUrl, Id));
            return JsonConvert.DeserializeObject<RecentGamesV11>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        [Obsolete("The game api v1.1 is deprecated, please use GetRecentGamesAsync() instead.")]
        public async Task<List<GameV11>> GetRecentGamesV11Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameV11RootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RecentGamesV11>(json)).Games;
        }

        /// <summary>
        /// Retrieve the league items for this specific summoner and not the entire league.
        /// </summary>
        /// <returns>A list of league items for each league the summoner is in.</returns>
        public List<LeagueItem> GetLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id) + LeagueBySummonerEntryUrl);
            return JsonConvert.DeserializeObject<List<LeagueItem>>(json);
        }

        /// <summary>
        /// Retrieve the league items for this specific summoner and not the entire league asynchronously.
        /// </summary>
        /// <returns>A list of league items for each league the summoner is in.</returns>
        public async Task<List<LeagueItem>> GetLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id) + LeagueBySummonerEntryUrl);
            return await JsonConvert.DeserializeObjectAsync<List<LeagueItem>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>List of leagues.</returns>
        public List<League> GetEntireLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<List<League>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>List of leagues.</returns>
        public async Task<List<League>> GetEntireLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<List<League>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>A map of leagues indexed by thei id.</returns>
        [Obsolete("The league api v2.2 is deprecated, please use GetLeagues() instead.")]
        public Dictionary<string, LeagueV22> GetEntireLeaguesV22()
        {
            var json = requester.CreateRequest(string.Format(LeagueV22RootUrl, region) 
                + string.Format(LeagueBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<Dictionary<string, LeagueV22>>(json);
        }        

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>A map of leagues indexed by their id.</returns>
        [Obsolete("The league api v2.1 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<Dictionary<string, LeagueV22>> GetEntireLeaguesV22Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueV22RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<Dictionary<string, LeagueV22>>(json);
        }
        
        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>A map of leagues indexed by their id.</returns>
        [Obsolete("The league api v2.1 is deprecated, please use GetLeagues() instead.")]
        public Dictionary<string, LeagueV21> GetEntireLeaguesV21()
        {
            var json = requester.CreateRequest(string.Format(LeagueV21RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<Dictionary<string, LeagueV21>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>A map of leagues indexed by their id.</returns>
        [Obsolete("The league api v2.1 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<Dictionary<string, LeagueV21>> GetEntireLeaguesV21Async()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueV21RootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<Dictionary<string, LeagueV21>>(json);
        }

        /// <summary>
        /// Get player stats summaries for this summoner synchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, region)
                + string.Format(StatsSummaryUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await JsonConvert.DeserializeObjectAsync<PlayerStatsSummaryList>(json)).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner synchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsSummaries() instead.")]
        public List<PlayerStatsSummaryV11> GetStatsSummariesV11(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsV11RootUrl, region) + string.Format(StatsSummaryUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<PlayerStatsSummaryListV11>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsSummariesAsync() instead.")]
        public async Task<List<PlayerStatsSummaryV11>> GetStatsSummariesV11Async(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsV11RootUrl, region)
                + string.Format(StatsSummaryUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await JsonConvert.DeserializeObjectAsync<PlayerStatsSummaryListV11>(json)).PlayerStatSummaries;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        public List<ChampionStats> GetStatsRanked(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, region) 
                + string.Format(StatsRankedUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await JsonConvert.DeserializeObjectAsync<RankedStats>(json)).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsRanked() instead.")]
        public List<ChampionStatsV11> GetStatsRankedV11(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsV11RootUrl, region) + string.Format(StatsRankedUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<RankedStatsV11>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner asynchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        [Obsolete("The stats api v1.1 is deprecated, please use GetStatsRankedAsync() instead.")]
        public async Task<List<ChampionStatsV11>> GetStatsRankedV11Async(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsV11RootUrl, region)
                + string.Format(StatsRankedUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await JsonConvert.DeserializeObjectAsync<RankedStatsV11>(json)).ChampionStats;
        }

        /// <summary>
        /// Get team information for this summoner synchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public List<Team> GetTeams()
        {
            var json = requester.CreateRequest(string.Format(TeamRootUrl, region) + string.Format(TeamBySummonerUrl, Id));
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
    }
}
