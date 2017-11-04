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
using System.Threading.Tasks;
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

        private const string LeagueRootUrl = "/lol/league/v3";
        private const string LeagueChallengerUrl = "/challengerleagues/by-queue/{0}";
        private const string LeagueMasterUrl = "/masterleagues/by-queue/{0}";
        private const string LeagueBySummonerUrl = "/leagues/by-summoner/{0}";
        private const string LeaguePositionBySummonerUrl = "/positions/by-summoner/{0}";

        private const string MatchRootUrl = "/lol/match/v3/matches";
        private const string MatchListRootUrl = "/lol/match/v3/matchlists";
        private const string TimelinesRootUrl = "/lol/match/v3/timelines";
        private const string MatchIdsByTournamentCodeUrl = "/by-tournament-code/{0}/ids";
        private const string MatchByIdUrl = "/{0}";
        private const string MatchByIdAndTournamentCodeUrl = "/{0}/by-tournament-code/{1}";
        private const string MatchListByAccountIdUrl = "/by-account/{0}";
        private const string MatchListByAccountIdRecentUrl = "/by-account/{0}/recent";
        private const string TimelineByMatchIdUrl = "/by-match/{0}";


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

        private readonly IRateLimitedRequester requester;

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
            if (instance == null || Requesters.RiotApiRequester == null ||
                apiKey != Requesters.RiotApiRequester.ApiKey ||
                !rateLimits.Equals(Requesters.RiotApiRequester.RateLimits))
            {
                instance = new RiotApi(apiKey, rateLimits);
            }
            return instance;
        }

        private RiotApi(string apiKey, IDictionary<TimeSpan, int> rateLimits)
        {
            Requesters.RiotApiRequester = new RateLimitedRequester(apiKey, rateLimits);
            requester = Requesters.RiotApiRequester;
        }

        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="rateLimitedRequester"></param>
        public RiotApi(IRateLimitedRequester rateLimitedRequester)
        {
            if (rateLimitedRequester == null)
                throw new ArgumentNullException(nameof(rateLimitedRequester));
            requester = rateLimitedRequester;
        }

#pragma warning disable CS1591

        #region Summoner
        public Summoner GetSummonerByAccountId(Region region, long accountId)
        {
            var json = requester.CreateGetRequest(
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region);
            var obj = JsonConvert.DeserializeObject<Summoner>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<Summoner> GetSummonerByAccountIdAsync(Region region, long accountId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Summoner>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public Summoner GetSummonerBySummonerId(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region);
            var obj = JsonConvert.DeserializeObject<Summoner>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<Summoner> GetSummonerBySummonerIdAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Summoner>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public Summoner GetSummonerByName(Region region, string summonerName)
        {
            var json = requester.CreateGetRequest(
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region);
            var obj = JsonConvert.DeserializeObject<Summoner>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<Summoner> GetSummonerByNameAsync(Region region, string summonerName)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Summoner>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }
        #endregion

        #region Champion
        public List<Champion> GetChampions(Region region, bool freeToPlay = false)
        {
            var json = requester.CreateGetRequest(PlatformRootUrl + ChampionsUrl, region,
                new List<string> { $"freeToPlay={freeToPlay.ToString().ToLower()}" });
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }

        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            var json = await requester.CreateGetRequestAsync(PlatformRootUrl + ChampionsUrl, region,
                new List<string> { $"freeToPlay={freeToPlay.ToString().ToLower()}" });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionList>(json))).Champions;
        }

        public Champion GetChampion(Region region, int championId)
        {
            var json = requester.CreateGetRequest(
                PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId), region);
            return JsonConvert.DeserializeObject<Champion>(json);
        }

        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var json = await requester.CreateGetRequestAsync(
                PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId), region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Champion>(json));
        }
        #endregion

        #region Masteries
        public List<MasteryPage> GetMasteryPages(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(PlatformRootUrl + string.Format(MasteriesUrl, summonerId), region);

            var masteries = JsonConvert.DeserializeObject<MasteryPages>(json);
            return masteries.Pages;
        }

        public async Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(PlatformRootUrl + string.Format(MasteriesUrl, summonerId),
                region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MasteryPages>(json).Pages);
        }
        #endregion

        #region Runes
        public List<RunePage> GetRunePages(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(PlatformRootUrl + string.Format(RunesUrl, summonerId), region);

            var runes = JsonConvert.DeserializeObject<RunePages>(json);
            return runes.Pages;
        }

        public async Task<List<RunePage>> GetRunePagesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(PlatformRootUrl + string.Format(RunesUrl, summonerId),
                region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<RunePages>(json).Pages);
        }
        #endregion

        #region League
        public List<League> GetLeagues(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(LeagueRootUrl + string.Format(LeagueBySummonerUrl, summonerId),
                region);
            return JsonConvert.DeserializeObject<List<League>>(json);
        }

        public async Task<List<League>> GetLeaguesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeagueBySummonerUrl, summonerId), region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<League>>(json));
        }

        public List<LeaguePosition> GetLeaguePositions(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId),
                region);

            return JsonConvert.DeserializeObject<List<LeaguePosition>>(json);
        }

        public async Task<List<LeaguePosition>> GetLeaguePositionsAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId), region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<LeaguePosition>>(json));
        }

        public League GetChallengerLeague(Region region, string queue)
        {
            var json = requester.CreateGetRequest(LeagueRootUrl + string.Format(LeagueChallengerUrl, queue), region);
            return JsonConvert.DeserializeObject<League>(json);
        }

        public async Task<League> GetChallengerLeagueAsync(Region region, string queue)
        {
            var json = await requester.CreateGetRequestAsync(LeagueRootUrl + string.Format(LeagueChallengerUrl, queue),
                region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }

        public League GetMasterLeague(Region region, string queue)
        {
            var json = requester.CreateGetRequest(LeagueRootUrl + string.Format(LeagueMasterUrl, queue), region);
            return JsonConvert.DeserializeObject<League>(json);
        }

        public async Task<League> GetMasterLeagueAsync(Region region, string queue)
        {
            var json = await requester.CreateGetRequestAsync(LeagueRootUrl + string.Format(LeagueMasterUrl, queue),
                region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }
        #endregion

        #region Match
        public List<long> GetMatchIdsByTournamentCode(Region region, string tournamentCode)
        {
            var json = requester.CreateGetRequest(MatchRootUrl +
                                                  string.Format(MatchIdsByTournamentCodeUrl, tournamentCode), region);

            return JsonConvert.DeserializeObject<List<long>>(json);
        }

        public async Task<List<long>> GetMatchIdsByTournamentCodeAsync(Region region, string tournamentCode)
        {
            var json = await requester.CreateGetRequestAsync(MatchRootUrl +
                                                             string.Format(MatchIdsByTournamentCodeUrl, tournamentCode),
                region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<long>>(json));
        }

        public Match GetMatch(Region region, long matchId)
        {
            var json = requester.CreateGetRequest(MatchRootUrl +
                                                  string.Format(MatchByIdUrl, matchId), region);
            return JsonConvert.DeserializeObject<Match>(json);
        }

        public async Task<Match> GetMatchAsync(Region region, long matchId)
        {
            var json = requester.CreateGetRequest(MatchRootUrl +
                                                  string.Format(MatchByIdUrl, matchId), region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Match>(json));
        }

        public MatchList GetMatchList(Region region, long accountId,
            List<int> championIds = null,
            List<int> queues = null,
            List<MatchEndpoint.Enums.Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null)
        {
            var addedArguments = CreateArgumentsListForMatchListRequest(championIds, queues, seasons, beginTime,
                endTime, beginIndex, endIndex);

            var json = requester.CreateGetRequest(MatchListRootUrl + string.Format(MatchListByAccountIdUrl, accountId),
                region, addedArguments);
            return JsonConvert.DeserializeObject<MatchList>(json);
        }

        public async Task<MatchList> GetMatchListAsync(Region region, long accountId,
            List<int> championIds = null,
            List<int> queues = null,
            List<MatchEndpoint.Enums.Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null)
        {
            var addedArguments = CreateArgumentsListForMatchListRequest(championIds, queues, seasons, beginTime,
                endTime, beginIndex, endIndex);

            var json = requester.CreateGetRequest(MatchListRootUrl + string.Format(MatchListByAccountIdUrl, accountId),
                region, addedArguments);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchList>(json));
        }

        public List<MatchReference> GetRecentMatches(Region region, long accountId)
        {
            var json = requester.CreateGetRequest(
                MatchListRootUrl + string.Format(MatchListByAccountIdRecentUrl, accountId),
                region);
            return JsonConvert.DeserializeObject<MatchList>(json).Matches;
        }

        public async Task<List<MatchReference>> GetRecentMatchesAsync(Region region, long accountId)
        {
            var json = await requester.CreateGetRequestAsync(
                MatchListRootUrl + string.Format(MatchListByAccountIdRecentUrl, accountId),
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MatchList>(json))).Matches;
        }
        #endregion

        #region Spectator
        public CurrentGame GetCurrentGame(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId), region);
            return JsonConvert.DeserializeObject<CurrentGame>(json);
        }
        
        public async Task<CurrentGame> GetCurrentGameAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId), region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CurrentGame>(json)));
        }

        public FeaturedGames GetFeaturedGames(Region region)
        {
            var json = requester.CreateGetRequest(SpectatorRootUrl + FeaturedGamesUrl, region);
            return JsonConvert.DeserializeObject<FeaturedGames>(json);
        }

        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var json = await requester.CreateGetRequestAsync(SpectatorRootUrl + FeaturedGamesUrl, region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FeaturedGames>(json)));
        }
        #endregion

        #region Champion Mastery
        public ChampionMastery GetChampionMastery(Region region, long summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return JsonConvert.DeserializeObject<ChampionMastery>(json);
        }

        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, long summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = await requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ChampionMastery>(json)));
        }

        public List<ChampionMastery> GetChampionMasteries(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return JsonConvert.DeserializeObject<List<ChampionMastery>>(json);
        }

        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = await requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ChampionMastery>>(json)));
        }

        public int GetTotalChampionMasteryScore(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return JsonConvert.DeserializeObject<int>(json);
        }

        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<int>(json)));
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
        
        private List<string> CreateArgumentsListForMatchListRequest(
            List<int> championIds = null,
            List<int> queues = null,
            List<MatchEndpoint.Enums.Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null)
        {
            var addedArguments = new List<string>();
            if (beginIndex != null)
            {
                addedArguments.Add($"beginIndex={beginIndex}");
            }
            if (endIndex != null)
            {
                addedArguments.Add($"endIndex={endIndex}");
            }
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
                foreach (var championId in championIds)
                {
                    addedArguments.Add($"champion={championId}");
                }
            }
            if (queues != null)
            {
                foreach (var queue in queues)
                {
                    addedArguments.Add($"queue={queue}");
                }
            }
            if (seasons != null)
            {
                foreach (var season in seasons)
                {
                    addedArguments.Add($"season={(int) season}");
                }
            }
            return addedArguments;
        }
        #endregion

#pragma warning restore
    }
}
