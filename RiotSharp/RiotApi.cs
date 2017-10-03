using Newtonsoft.Json;
using RiotSharp.ChampionEndpoint;
using RiotSharp.ChampionMasteryEndpoint;
using RiotSharp.GameEndpoint;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using RiotSharp.RunesEndpoint;
using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RiotSharp.MatchListEndpoint;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;
using RiotSharp.SpectatorEndpoint;

namespace RiotSharp
{
    /// <summary>
    /// Implementation of IRiotApi
    /// </summary>
    public class RiotApi : IRiotApi
    {
        #region Private Fields
        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByAccountIdUrl = "/by-account/{0}";
        private const string SummonerByNameUrl = "/by-name/{0}";
        private const string SummonerBySummonerIdUrl = "/{0}";

        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string MasteriesUrl = "/masteries/by-summoner/{0}";
        private const string RunesUrl = "/runes/by-summoner/{0}";
        private const string ChampionsUrl = "/champions";

        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueRootUrl = "/lol/league/v3";
        private const string LeagueChallengerUrl = "/challengerleagues/by-queue/{0}";
        private const string LeagueMasterUrl = "/masterleagues/by-queue/{0}";
        private const string LeagueBySummonerUrl = "/leagues/by-summoner/{0}";
        private const string LeaguePositionBySummonerUrl = "/positions/by-summoner/{0}";

        private const string MatchRootUrl = "/api/lol/{0}/v2.2/match";
        private const string MatchListRootUrl = "/api/lol/{0}/v2.2/matchlist/by-summoner";

        private const string SpectatorRootUrl = "/lol/spectator/v3";
        private const string CurrentGameUrl = "/active-games/by-summoner/{0}";
        private const string FeaturedGamesUrl = "/featured-games";

        private const string IdUrl = "/{0}";

        private const string ChampionMasteryRootUrl = "/lol/champion-mastery/v3";
        private const string ChampionMasteriesBySummonerUrl = "/champion-masteries/by-summoner/{0}";
        private const string ChampionMasteryBySummonerUrl = "/champion-masteries/by-summoner/{0}/by-champion/{1}";
        private const string ChampionMasteryTotalScoreBySummonerUrl = "/scores/by-summoner/{0}";

        // Used in call which have a maximum number of items you can retrieve in a single call
        private const int MaxNrSummoners = 40;
        private const int MaxNrMasteryPages = 40;

        private readonly IRequester requester;

        private static RiotApi instance;
        #endregion

        /// <summary>
        /// Gets the instance of RiotApi, with development rate limits by default.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer1s">The 1 second rate limit for your api key. 20 by default.</param>
        /// <param name="rateLimitPer2m">The 2 minute rate limit for your api key. 100 by default.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetDevelopmentInstance(string apiKey, int rateLimitPer1s = 20, int rateLimitPer2m = 100)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = rateLimitPer1s,
                [TimeSpan.FromMinutes(2)] = rateLimitPer2m
            });
        }

        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, int rateLimitPer10s, int rateLimitPer10m)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(10)] = rateLimitPer10m,
                [TimeSpan.FromSeconds(10)] = rateLimitPer10s
            });
        }

        /// <summary>
        /// Gets the instance of RiotApi, allowing custom rate limits.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimits">A dictionary of rate limits where the key is the time span and the value
        /// is the number of requests allowed per that time span.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, IDictionary<TimeSpan, int> rateLimits)
        {
            /* todo is this logic required?
            if (instance == null || Requesters.RiotApiRequester == null ||
                apiKey != Requesters.RiotApiRequester.ApiKey ||
                !rateLimits.Equals(Requesters.RiotApiRequester.RateLimits))
            {
                instance = new RiotApi(apiKey, rateLimits);
            } */
            return instance ?? (instance = new RiotApi(apiKey, rateLimits));
        }

        private RiotApi(string apiKey, IDictionary<TimeSpan, int> rateLimits)
        {
            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var requestCreator = new RequestCreator(apiKey, serializer);
            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();
            var client = new RequestClient(httpClient, failedRequestHandler);
            var basicRequester = new Requester(client, requestCreator, deserializer);
            var rateLimitProvider = new RateLimitProvider(rateLimits);

            requester = new RateLimitedRequester(basicRequester, rateLimitProvider);

            Requesters.RiotApiRequester = (RateLimitedRequester) requester;
        }

        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="requester"></param>
        public RiotApi(IRequester requester)
        {
            this.requester = requester ?? throw new ArgumentNullException(nameof(requester));
        }

#pragma warning disable CS1591

        #region Summoner
        public Summoner GetSummonerByAccountId(Region region, long accountId)
        {
            var url = string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId);
            var summoner = requester.Get<Summoner>(url, region);
            return SummonerWithRegion(summoner, region);
        }

        public async Task<Summoner> GetSummonerByAccountIdAsync(Region region, long accountId)
        {
            var url = string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId);
            var summoner = await requester.GetAsync<Summoner>(url, region);
            return SummonerWithRegion(summoner, region);
        }

        public Summoner GetSummonerBySummonerId(Region region, long summonerId)
        {
            var url = string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId);
            var summoner = requester.Get<Summoner>(url, region);
            return SummonerWithRegion(summoner, region);
        }

        public async Task<Summoner> GetSummonerBySummonerIdAsync(Region region, long summonerId)
        {
            var url = string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId);
            var summoner = await requester.GetAsync<Summoner>(url, region);
            return SummonerWithRegion(summoner, region);
        }

        public Summoner GetSummonerByName(Region region, string summonerName)
        {
            var url = string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName);
            var summoner = requester.Get<Summoner>(url, region);
            return SummonerWithRegion(summoner, region);
        }

        public async Task<Summoner> GetSummonerByNameAsync(Region region, string summonerName)
        {
            var url = string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName);
            var summoner = await requester.GetAsync<Summoner>(url, region);
            return SummonerWithRegion(summoner, region);
        }

        public Summoner SummonerWithRegion(Summoner summoner, Region region)
        {
            if (summoner != null)
            {
                summoner.Region = region;
            }
            return summoner;
        }
        #endregion

        #region Champion
        public List<Champion> GetChampions(Region region, bool freeToPlay = false)
        {
            var url = PlatformRootUrl + ChampionsUrl;
            var arguments = new List<string>{$"freeToPlay={freeToPlay.ToString().ToLower()}" };
            return requester.Get<ChampionList>(url, region, arguments).Champions;
        }

        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            var url = PlatformRootUrl + ChampionsUrl;
            var arguments = new List<string> { $"freeToPlay={freeToPlay.ToString().ToLower()}" };
            return (await requester.GetAsync<ChampionList>(url, region, arguments)).Champions;
        }

        public Champion GetChampion(Region region, int championId)
        {
            var url = PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId);
            return requester.Get<Champion>(url, region);
        }

        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var url = PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId);
            return await requester.GetAsync<Champion>(url, region);

        }
        #endregion

        #region Masteries
        public List<MasteryPage> GetMasteryPages(Region region, long summonerId)
        {
            var url = PlatformRootUrl + string.Format(MasteriesUrl, summonerId);
            return requester.Get<MasteryPages>(url, region).Pages;
        }

        public async Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId)
        {
            var url = PlatformRootUrl + string.Format(MasteriesUrl, summonerId);
            return (await requester.GetAsync<MasteryPages>(url, region)).Pages;
        }
        #endregion

        #region Runes
        public List<RunePage> GetRunePages(Region region, long summonerId)
        {
            var url = PlatformRootUrl + string.Format(RunesUrl, summonerId);
            return requester.Get<RunePages>(url, region).Pages;
        }

        public async Task<List<RunePage>> GetRunePagesAsync(Region region, long summonerId)
        {
            var url = PlatformRootUrl + string.Format(RunesUrl, summonerId);
            return (await requester.GetAsync<RunePages>(url, region)).Pages;
        }
        #endregion

        #region League
        public List<League> GetLeagues(Region region, long summonerId)
        {
            var url = LeagueRootUrl + string.Format(LeagueBySummonerUrl, summonerId);
            return requester.Get<List<League>>(url, region);
        }

        public async Task<List<League>> GetLeaguesAsync(Region region, long summonerId)
        {
            var url = LeagueRootUrl + string.Format(LeagueBySummonerUrl, summonerId);
            return await requester.GetAsync<List<League>>(url, region);
        }

        public List<LeaguePosition> GetLeaguePositions(Region region, long summonerId)
        {
            var url = LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId);
            return requester.Get<List<LeaguePosition>>(url, region);
        }

        public async Task<List<LeaguePosition>> GetLeaguePositionsAsync(Region region, long summonerId)
        {
            var url = LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId);
            return await requester.GetAsync<List<LeaguePosition>>(url, region);
        }

        public League GetChallengerLeague(Region region, string queue)
        {
            var url = LeagueRootUrl + string.Format(LeagueChallengerUrl, queue);
            return requester.Get<League>(url, region);
        }

        public async Task<League> GetChallengerLeagueAsync(Region region, string queue)
        {
            var url = LeagueRootUrl + string.Format(LeagueChallengerUrl, queue);
            return await requester.GetAsync<League>(url, region);
        }

        public League GetMasterLeague(Region region, string queue)
        {
            var url = LeagueRootUrl + string.Format(LeagueMasterUrl, queue);
            return requester.Get<League>(url, region);
        }

        public async Task<League> GetMasterLeagueAsync(Region region, string queue)
        {
            var url = LeagueRootUrl + string.Format(LeagueMasterUrl, queue);
            return await requester.GetAsync<League>(url, region);
        }
        #endregion

        #region Match
        public MatchDetail GetMatch(Region region, long matchId, bool includeTimeline = false)
        {
            var url = string.Format(MatchRootUrl, region.ToString()) + string.Format(IdUrl, matchId);
            var arguments = includeTimeline ? new List<string> { "includeTimeline=false" } : new List<string>();
            return requester.Get<MatchDetail>(url, region, arguments);
        }

        public async Task<MatchDetail> GetMatchAsync(Region region, long matchId, bool includeTimeline = false)
        {
            var url = string.Format(MatchRootUrl, region.ToString()) + string.Format(IdUrl, matchId);
            var arguments = includeTimeline ? new List<string> { "includeTimeline=false" } : new List<string>();
            return await requester.GetAsync<MatchDetail>(url, region, arguments);
        }

        public MatchList GetMatchList(Region region, long summonerId,
            List<long> championIds = null, List<string> rankedQueues = null,
            List<MatchEndpoint.Enums.Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null,
            int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string>
            {
                $"beginIndex={beginIndex}",
                $"endIndex={endIndex}",
            };
            if (beginTime != null)
            {
                addedArguments.Add($"beginTime={beginTime.Value.ToLong()}");
            }
            if (endTime != null)
            {
                addedArguments.Add($"endTime={endTime.Value.ToLong()}");
            }
            if (championIds != null)
            {
                addedArguments.Add($"championIds={Util.BuildIdsString(championIds)}");
            }
            if (rankedQueues != null)
            {
                addedArguments.Add($"rankedQueues={Util.BuildQueuesString(rankedQueues)}");
            }
            if (seasons != null)
            {
                addedArguments.Add($"seasons={Util.BuildSeasonString(seasons)}");
            }

            var url = string.Format(MatchListRootUrl, region.ToString()) + string.Format(IdUrl, summonerId);
            return requester.Get<MatchList>(url, region, addedArguments);
        }

        public async Task<MatchList> GetMatchListAsync(Region region, long summonerId,
            List<long> championIds = null, List<string> rankedQueues = null,
            List<MatchEndpoint.Enums.Season> seasons = null, DateTime? beginTime = null,
            DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string>
            {
                string.Format("beginIndex={0}", beginIndex),
                string.Format("endIndex={0}", endIndex),
            };
            if (beginTime != null)
            {
                addedArguments.Add(string.Format("beginTime={0}", beginTime.Value.ToLong()));
            }
            if (endTime != null)
            {
                addedArguments.Add(string.Format("endTime={0}", endTime.Value.ToLong()));
            }
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }
            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }
            if (seasons != null)
            {
                addedArguments.Add(string.Format("seasons={0}", Util.BuildSeasonString(seasons)));
            }

            var url = string.Format(MatchListRootUrl, region.ToString()) + string.Format(IdUrl, summonerId);

            return await requester.GetAsync<MatchList>(url, region, addedArguments);
        }

        public List<Game> GetRecentGames(Region region, long summonerId)
        {
            var url = string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId);
            return requester.Get<RecentGames>(url, region).Games;
        }

        public async Task<List<Game>> GetRecentGamesAsync(Region region, long summonerId)
        {
            var url = string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId);
            return (await requester.GetAsync<RecentGames>(url, region)).Games;
        }
        #endregion

        #region Spectator
        public CurrentGame GetCurrentGame(Region region, long summonerId)
        {
            var url = SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId);
            return requester.Get<CurrentGame>(url, region);
        }

        public async Task<CurrentGame> GetCurrentGameAsync(Region region, long summonerId)
        {
            var url = SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId);
            return await requester.GetAsync<CurrentGame>(url, region);
        }

        public FeaturedGames GetFeaturedGames(Region region)
        {
            var url = SpectatorRootUrl + FeaturedGamesUrl;
            return requester.Get<FeaturedGames>(url, region);
        }

        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var url = SpectatorRootUrl + FeaturedGamesUrl;
            return await requester.GetAsync<FeaturedGames>(url, region);
        }
        #endregion

        #region Champion Mastery
        public ChampionMastery GetChampionMastery(Region region, long summonerId, long championId)
        {
            var url = ChampionMasteryRootUrl + string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);
            return requester.Get<ChampionMastery>(url, region);
        }

        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, long summonerId, long championId)
        {
            var url = ChampionMasteryRootUrl + string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);
            return await requester.GetAsync<ChampionMastery>(url, region);
        }

        public List<ChampionMastery> GetChampionMasteries(Region region, long summonerId)
        {
            var url = ChampionMasteryRootUrl + string.Format(ChampionMasteriesBySummonerUrl, summonerId);
            return requester.Get<List<ChampionMastery>>(url, region);

        }

        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, long summonerId)
        {
            var url = ChampionMasteryRootUrl + string.Format(ChampionMasteriesBySummonerUrl, summonerId);
            return await requester.GetAsync<List<ChampionMastery>>(url, region);
        }

        public int GetTotalChampionMasteryScore(Region region, long summonerId)
        {
            var url = ChampionMasteryRootUrl + string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);
            return requester.Get<int>(url, region);
        }

        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, long summonerId)
        {
            var url = ChampionMasteryRootUrl + string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);
            return await requester.GetAsync<int>(url, region);
        }
        #endregion

        #region Helpers
        private Dictionary<long, List<MasteryPage>> ConstructMasteryDict(Dictionary<string, MasteryPages> dict)
        {
            var returnDict = new Dictionary<long, List<MasteryPage>>();
            foreach (var masteryPage in dict.Values)
            {
                returnDict.Add(masteryPage.SummonerId, masteryPage.Pages);
            }
            return returnDict;
        }

        private Dictionary<long, List<RunePage>> ConstructRuneDict(Dictionary<string, RunePages> dict)
        {
            var returnDict = new Dictionary<long, List<RunePage>>();
            foreach (var runePage in dict.Values)
            {
                returnDict.Add(runePage.SummonerId, runePage.Pages);
            }
            return returnDict;
        }

        private List<List<T>> MakeGroups<T>(List<T> toSplit, int chunkSize)
        {
            return toSplit
                .Distinct()
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        #endregion

#pragma warning restore
    }
}
