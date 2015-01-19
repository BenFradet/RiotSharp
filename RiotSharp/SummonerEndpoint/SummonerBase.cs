using Newtonsoft.Json;
using RiotSharp.GameEndpoint;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using RiotSharp.StatsEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// Class representing the name and id of a Summoner in the API.
    /// </summary>
    [Serializable]
    public class SummonerBase
    {
        private const string RootUrl = "/api/lol/{0}/v1.4/summoner";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueRootUrl = "/api/lol/{0}/v2.5/league";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";
        private const string LeagueBySummonerEntryUrl = "/entry";

        private const string StatsRootUrl = "/api/lol/{0}/v1.3/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        private const string TeamRootUrl = "/api/lol/{0}/v2.4/team";
        private const string TeamBySummonerUrl = "/by-summoner/{0}";

        private const string MatchHistoryRootUrl = "/api/lol/{0}/v2.2/matchhistory";
        private const string IdUrl = "/{0}";

        [field: NonSerialized]
        private RateLimitedRequester requester;
        public Region Region { get; set; }

        internal SummonerBase()
        {
            requester = RateLimitedRequester.Instance;
        }

        //summoner base not default constructor
        internal SummonerBase(string id, string name, RateLimitedRequester requester, Region region)
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
            var json = requester.CreateRequest(string.Format(RootUrl, Region) + string.Format(RunesUrl, Id), Region);
            return JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get rune pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of rune pages.</returns>
        public async Task<List<RunePage>> GetRunePagesAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(RootUrl, Region) + string.Format(RunesUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json))).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner synchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        public List<MasteryPage> GetMasteryPages()
        {
            var json = requester.CreateRequest(
                string.Format(RootUrl, Region) + string.Format(MasteriesUrl, Id),
                Region);
            return JsonConvert.DeserializeObject<Dictionary<long, MasteryPages>>(json)
                .Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get mastery pages for this summoner asynchronously.
        /// </summary>
        /// <returns>A list of mastery pages.</returns>
        public async Task<List<MasteryPage>> GetMasteryPagesAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(RootUrl, Region) + string.Format(MasteriesUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, MasteryPages>>(json))).Values.FirstOrDefault().Pages;
        }

        /// <summary>
        /// Get the 10 most recent games for this summoner synchronously.
        /// </summary>
        /// <returns>A list of the 10 most recent games.</returns>
        public List<Game> GetRecentGames()
        {
            var json = requester.CreateRequest(
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
            var json = await requester.CreateRequestAsync(
                string.Format(GameRootUrl, Region) + string.Format(RecentGamesUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RecentGames>(json))).Games;
        }

        /// <summary>
        /// Retrieve the league items for this specific summoner and not the entire league.
        /// </summary>
        /// <returns>A list of league items for each league the summoner is in.</returns>
        public List<League> GetLeagues()
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, Region) + string.Format(LeagueBySummonerUrl, Id) +
                    LeagueBySummonerEntryUrl,
                Region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json)[Id];
        }

        /// <summary>
        /// Retrieve the league items for this specific summoner and not the entire league asynchronously.
        /// </summary>
        /// <returns>A list of league items for each league the summoner is in.</returns>
        public async Task<List<League>> GetLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, Region) + string.Format(LeagueBySummonerUrl, Id) +
                    LeagueBySummonerEntryUrl,
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json)))[Id];
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's teams synchronously.
        /// </summary>
        /// <returns>List of leagues.</returns>
        public List<League> GetEntireLeagues()
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, Region) + string.Format(LeagueBySummonerUrl, Id),
                Region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json)[Id];
        }

        /// <summary>
        /// Retrieves leagues data for this summoner, including leagues for all of this summoner's
        /// teams asynchronously.
        /// </summary>
        /// <returns>List of leagues.</returns>
        public async Task<List<League>> GetEntireLeaguesAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, Region) + string.Format(LeagueBySummonerUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json)))[Id];
        }
        
        /// <summary>
        /// Get player stats summaries for this summoner synchronously, for the current season.
        /// One summary is returned per queue type.
        /// </summary>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries()
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, Region) + string.Format(StatsSummaryUrl, Id),
                Region);
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner synchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries(StatsEndpoint.Season season)
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, Region) + string.Format(StatsSummaryUrl, Id),
                Region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously, for the current season.
        /// One summary is returned per queue type.
        /// </summary>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, Region) + string.Format(StatsSummaryUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json))).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats summaries for this summoner asynchronously. One summary is returned per queue type.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(StatsEndpoint.Season season)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, Region) + string.Format(StatsSummaryUrl, Id),
                Region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json))).PlayerStatSummaries;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously, for the current season.
        /// Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <returns>A list of champions stats.</returns>
        public List<ChampionStats> GetStatsRanked()
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, Region) + string.Format(StatsRankedUrl, Id),
                Region);
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner synchronously.
        /// Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        public List<ChampionStats> GetStatsRanked(StatsEndpoint.Season season)
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, Region) + string.Format(StatsRankedUrl, Id),
                Region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner asynchronously, for the current season.
        /// Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <returns>A list of champions stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, Region) + string.Format(StatsRankedUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RankedStats>(json))).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats for this summoner asynchronously.
        /// Includes statistics for Twisted Treeline and Summoner's Rift.
        /// </summary>
        /// <param name="season">Season for which you want the stats.</param>
        /// <returns>A list of champions stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(StatsEndpoint.Season season)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, Region) + string.Format(StatsRankedUrl, Id),
                Region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RankedStats>(json))).ChampionStats;
        }

        /// <summary>
        /// Get team information for this summoner synchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public List<TeamEndpoint.Team> GetTeams()
        {
            var json = requester.CreateRequest(
                string.Format(TeamRootUrl, Region) + string.Format(TeamBySummonerUrl, Id),
                Region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<TeamEndpoint.Team>>>(json)[Id];
        }

        /// <summary>
        /// Get team information for this summoner asynchronously.
        /// </summary>
        /// <returns>List of teams.</returns>
        public async Task<List<TeamEndpoint.Team>> GetTeamsAsync()
        {
            var json = await requester.CreateRequestAsync(
                string.Format(TeamRootUrl, Region) + string.Format(TeamBySummonerUrl, Id),
                Region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<TeamEndpoint.Team>>>(json)))[Id];
        }

        /// <summary>
        /// Get the match history of this summoner synchronously.
        /// </summary>
        /// <param name="beginIndex">The begin index to use for fetching games.
        /// The range has to be less than or equal to 15.</param>
        /// <param name="endIndex">The end index to use for fetching games.
        /// The range has to be less than or equal to 15.</param>
        /// <param name="championIds">List of champion IDs to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        /// will be ignored.</param>
        /// <returns>A list of match summaries object.</returns>
        public List<MatchSummary> GetMatchHistory(int beginIndex = 0, int endIndex = 14,
            List<int> championIds = null, List<Queue> rankedQueues = null)
        {
            var addedArguments = new List<string>
            {
                    string.Format("beginIndex={0}", beginIndex),
                    string.Format("endIndex={0}", endIndex),
            };
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }
            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }

            var json = requester.CreateRequest(
                string.Format(MatchHistoryRootUrl, Region.ToString()) + string.Format(IdUrl, Id),
                Region,
                addedArguments);
            return JsonConvert.DeserializeObject<PlayerHistory>(json).Matches;
        }

        /// <summary>
        /// Get the match history of this summoner asynchronously.
        /// </summary>
        /// <param name="beginIndex">The begin index to use for fetching games.
        /// endIndex - beginIndex has to be inferior to 15.</param>
        /// <param name="endIndex">The end index to use for fetching games.
        /// endIndex - beginIndex has to be inferior to 15.</param>
        /// <param name="championIds">List of champion IDs to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        /// will be ignored.</param>
        /// <returns>A list of match summaries object.</returns>
        public async Task<List<MatchSummary>> GetMatchHistoryAsync(int beginIndex = 0, int endIndex = 14,
            List<int> championIds = null, List<Queue> rankedQueues = null)
        {
            var addedArguments = new List<string>
            {
                    string.Format("beginIndex={0}", beginIndex),
                    string.Format("endIndex={0}", endIndex),
            };
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }
            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }

            var json = await requester.CreateRequestAsync(
                string.Format(MatchHistoryRootUrl, Region.ToString()) + string.Format(IdUrl, Id),
                Region,
                addedArguments);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerHistory>(json).Matches);
        }
    }
}
