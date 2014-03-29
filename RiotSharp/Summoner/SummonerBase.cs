using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace RiotSharp
{
    /// <summary>
    /// Class representing the name and id of a Summoner in the API.
    /// </summary>
    [Serializable]
    public class SummonerBase
    {
        private const string RootV12Url = "/api/lol/{0}/v1.2/summoner";
        private const string RootUrl = "/api/lol/{0}/v1.3/summoner";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string GameV12RootUrl = "/api/lol/{0}/v1.2/game";
        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueV21RootUrl = "/api/{0}/v2.1/league";
        private const string LeagueV22RootUrl = "/api/lol/{0}/v2.2/league";
        private const string LeagueRootUrl = "/api/lol/{0}/v2.3/league";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";
        private const string LeagueBySummonerEntryUrl = "/entry";

        private const string StatsRootUrl = "/api/lol/{0}/v1.2/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        private const string TeamV21RootUrl = "/api/{0}/v2.1/team";
        private const string TeamRootUrl = "/api/lol/{0}/v2.2/team";
        private const string TeamBySummonerUrl = "/by-summoner/{0}";

        [field: NonSerialized]
        private RateLimitedRequester requester;
        public Region Region { get; set; }

        internal SummonerBase()
        {
            requester = RateLimitedRequester.Instance;
        }

        internal SummonerBase(string id, string name, RateLimitedRequester requester, Region region)
        {
            Console.WriteLine("summoner base not default constructor");
            this.requester = requester;
            Region = region;
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
            var json = requester.CreateRequest(string.Format(RootUrl, Region) + string.Format(RunesUrl, Id));
            return JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        public async Task<List<RunePage>> GetRunePagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, Region) + string.Format(RunesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<Dictionary<string, RunePages>>(json))
                .Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        public List<MasteryPage> GetMasteryPages()
        {
            var json = requester.CreateRequest(string.Format(RootUrl, Region) + string.Format(MasteriesUrl, Id));
            return JsonConvert.DeserializeObject<Dictionary<long, MasteryPages>>(json).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        public async Task<List<MasteryPage>> GetMasteryPagesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(RootUrl, Region) + string.Format(MasteriesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<Dictionary<long, MasteryPages>>(json))
                .Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public List<Game> GetRecentGames()
        {
            var json = requester.CreateRequest(string.Format(GameRootUrl, Region) + string.Format(RecentGamesUrl, Id));
            return JsonConvert.DeserializeObject<RecentGames>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public async Task<List<Game>> GetRecentGamesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(GameRootUrl, Region) 
                + string.Format(RecentGamesUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RecentGames>(json)).Games;
        }

        /// <summary>
        /// Retrieve the league items for this specific summoner and not the entire league.
        /// </summary>
        /// <returns>A list of league items for each league the summoner is in.</returns>
        public List<LeagueItem> GetLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, Region)
                + string.Format(LeagueBySummonerUrl, Id) + LeagueBySummonerEntryUrl);
            return JsonConvert.DeserializeObject<List<LeagueItem>>(json);
        }

        /// <summary>
        /// Retrieve the league items for this specific summoner and not the entire league asynchronously.
        /// </summary>
        /// <returns>A list of league items for each league the summoner is in.</returns>
        public async Task<List<LeagueItem>> GetLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, Region)
                + string.Format(LeagueBySummonerUrl, Id) + LeagueBySummonerEntryUrl);
            return await JsonConvert.DeserializeObjectAsync<List<LeagueItem>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>List of leagues.</returns>
        public List<League> GetEntireLeagues()
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, Region)
                + string.Format(LeagueBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<List<League>>(json);
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams asynchronously.
        /// </summary>
        /// <returns>List of leagues.</returns>
        public async Task<List<League>> GetEntireLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, Region)
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
            var json = requester.CreateRequest(string.Format(LeagueV22RootUrl, Region) 
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
            var json = await requester.CreateRequestAsync(string.Format(LeagueV22RootUrl, Region)
                + string.Format(LeagueBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<Dictionary<string, LeagueV22>>(json);
        }

        /// <summary>
        /// Get player stats summaries for this summoner synchronously, for the current season. One summary is returned per queue type.
        /// </summary>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries()
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, Region) + string.Format(StatsSummaryUrl, Id));
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }
        
        /// <summary>
        /// Get player stats summaries for this summoner synchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, Region) + string.Format(StatsSummaryUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }
        
        /// <summary>
        /// Get player stats summaries for this summoner asynchronously, for the current season. One summary is returned per queue type.
        /// </summary>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, Region)
                + string.Format(StatsSummaryUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<PlayerStatsSummaryList>(json)).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, Region)
                + string.Format(StatsSummaryUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await JsonConvert.DeserializeObjectAsync<PlayerStatsSummaryList>(json)).PlayerStatSummaries;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously, for the current season. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <returns>A list of champions stats.</returns>
        public List<ChampionStats> GetStatsRanked()
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, Region) + string.Format(StatsRankedUrl, Id));
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        public List<ChampionStats> GetStatsRanked(Season season)
        {
            var json = requester.CreateRequest(string.Format(StatsRootUrl, Region) + string.Format(StatsRankedUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner asynchronously, for the current season. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <returns>A list of champions stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, Region)
                + string.Format(StatsRankedUrl, Id));
            return (await JsonConvert.DeserializeObjectAsync<RankedStats>(json)).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner asynchronously. Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(Season season)
        {
            var json = await requester.CreateRequestAsync(string.Format(StatsRootUrl, Region) 
                + string.Format(StatsRankedUrl, Id)
                , new List<string>() { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await JsonConvert.DeserializeObjectAsync<RankedStats>(json)).ChampionStats;
        }

        /// <summary>
        /// Get team information for this summoner synchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public List<Team> GetTeams()
        {
            var json = requester.CreateRequest(string.Format(TeamRootUrl, Region) + string.Format(TeamBySummonerUrl, Id));
            return JsonConvert.DeserializeObject<List<Team>>(json);
        }

        /// <summary>
        /// Get team information for this summoner asynchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public async Task<List<Team>> GetTeamsAsync()
        {
            var json = await requester.CreateRequestAsync(string.Format(TeamRootUrl, Region)
                + string.Format(TeamBySummonerUrl, Id));
            return await JsonConvert.DeserializeObjectAsync<List<Team>>(json);
        }        
    }
}
