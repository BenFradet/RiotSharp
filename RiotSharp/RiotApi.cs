using Newtonsoft.Json;
using RiotSharp.ChampionEndpoint;
using RiotSharp.ChampionMasteryEndpoint;
using RiotSharp.CurrentGameEndpoint;
using RiotSharp.FeaturedGamesEndpoint;
using RiotSharp.GameEndpoint;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp.MatchListEndpoint;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;

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

        private const string NamesUrl = "/{0}/name";
        private const string MasteriesUrl = "/lol/platform/v3/masteries/by-summoner/{0}";

        private const string RunesRootUrl = "/api/lol/{0}/v1.4/summoner";
        private const string RunesUrl = "/{0}/runes";

        private const string ChampionsUrl = "/lol/platform/v3/champions";

        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueRootUrl = "/api/lol/{0}/v2.5/league";
        private const string LeagueChallengerUrl = "/challenger";
        private const string LeagueMasterUrl = "/master";

        private const string LeagueBySummonerUrl = "/by-summoner/{0}";
        private const string LeagueEntryUrl = "/entry";

        private const string MatchRootUrl = "/api/lol/{0}/v2.2/match";
        private const string MatchListRootUrl = "/api/lol/{0}/v2.2/matchlist/by-summoner";

        private const string CurrentGameRootUrl = "/observer-mode/rest/consumer/getSpectatorGameInfo/{0}";

        private const string FeaturedGamesRootUrl = "/observer-mode/rest/featured";

        private const string IdUrl = "/{0}";

        private const string ChampionMasteryRootUrl = "/lol/champion-mastery/v3";
        private const string ChampionMasteriesBySummonerUrl = "/champion-masteries/by-summoner/{0}";
        private const string ChampionMasteryBySummonerUrl = "/champion-masteries/by-summoner/{0}/by-champion/{1}";
        private const string ChampionMasteryTotalScoreBySummonerUrl = "/scores/by-summoner/{0}";

        // Used in call which have a maximum number of items you can retrieve in a single call
        private const int MaxNrSummoners = 40;
        private const int MaxNrMasteryPages = 40;
        private const int MaxNrRunePages = 40;
        private const int MaxNrLeagues = 10;
        private const int MaxNrEntireLeagues = 10;

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
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region, usePlatforms: true);
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
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region, usePlatforms: true);
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
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region, usePlatforms: true);
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
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region, usePlatforms: true);
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
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region, usePlatforms: true);
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
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region, usePlatforms: true);
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
            var json = requester.CreateGetRequest(ChampionsUrl, region,
                new List<string> { string.Format("freeToPlay={0}", freeToPlay ? "true" : "false") }, usePlatforms: true);
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }
       
        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            var json = await requester.CreateGetRequestAsync(ChampionsUrl, region,
                new List<string> { string.Format("freeToPlay={0}", freeToPlay ? "true" : "false") }, usePlatforms: true);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionList>(json))).Champions;
        }
       
        public Champion GetChampion(Region region, int championId)
        {
            var json = requester.CreateGetRequest(
                ChampionsUrl + string.Format(IdUrl, championId), region, usePlatforms: true);
            return JsonConvert.DeserializeObject<Champion>(json);
        }
 
        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var json = await requester.CreateGetRequestAsync(
                ChampionsUrl + string.Format(IdUrl, championId),
                region, usePlatforms: true);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Champion>(json));
        }
        #endregion

        #region Masteries
        public List<MasteryPage> GetMasteryPages(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(string.Format(MasteriesUrl, summonerId), region,
                usePlatforms: true);

            var masteries = JsonConvert.DeserializeObject<MasteryPages>(json);
            return masteries.Pages;
        }
 
        public async Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(string.Format(MasteriesUrl, summonerId), region, 
                usePlatforms: true);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MasteryPages>(json).Pages);
        }
        #endregion

        #region Runes
        public Dictionary<long, List<RunePage>> GetRunePages(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<RunePage>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrRunePages))
            {
                var json = requester.CreateGetRequest(
                    string.Format(RunesRootUrl,
                        region.ToString()) + string.Format(RunesUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = ConstructRuneDict(JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }
   
        public async Task<Dictionary<long, List<RunePage>>> GetRunePagesAsync(Region region, List<long> summonerIds)
        {
            var tasks = MakeGroups(summonerIds, MaxNrRunePages).Select(
                grp => requester.CreateGetRequestAsync(
                    string.Format(RunesRootUrl, region.ToString()) +
                    string.Format(RunesUrl, Util.BuildIdsString(grp)), region
                    ).ContinueWith(
                        json => ConstructRuneDict(
                            JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json.Result))
                    )
                ).ToList();

            await Task.WhenAll(tasks);
            return tasks.SelectMany(task => task.Result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
        #endregion

        #region League
        public Dictionary<long, List<League>> GetLeagues(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<League>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrLeagues))
            {
                var json = requester.CreateGetRequest(
                    string.Format(LeagueRootUrl, region.ToString()) +
                        string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)) + LeagueEntryUrl,
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }
 
        public async Task<Dictionary<long, List<League>>> GetLeaguesAsync(Region region, List<long> summonerIds)
        {
            var tasks = MakeGroups(summonerIds, MaxNrLeagues).Select(
                grp => requester.CreateGetRequestAsync(
                    string.Format(LeagueRootUrl, region.ToString()) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)) + LeagueEntryUrl, region
                    ).ContinueWith(
                        json => JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json.Result)
                    )
                ).ToList();

            await Task.WhenAll(tasks);
            return tasks.SelectMany(task => task.Result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    
        public Dictionary<long, List<League>> GetEntireLeagues(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<League>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrEntireLeagues))
            {
                var json = requester.CreateGetRequest(
                    string.Format(LeagueRootUrl,
                        region.ToString()) + string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }
    
        public async Task<Dictionary<long, List<League>>> GetEntireLeaguesAsync(Region region,
            List<long> summonerIds)
        {
            var tasks = MakeGroups(summonerIds, MaxNrEntireLeagues).Select(
                   grp => requester.CreateGetRequestAsync(
                       string.Format(LeagueRootUrl, region.ToString()) +
                       string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)), region
                       ).ContinueWith(
                           json => JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json.Result)
                       )
                   ).ToList();

            await Task.WhenAll(tasks);
            return tasks.SelectMany(task => task.Result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
        
        public League GetChallengerLeague(Region region, string queue)
        {
            var json = requester.CreateGetRequest(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueChallengerUrl,
                region,
                new List<string> { string.Format("type={0}", queue) });
            return JsonConvert.DeserializeObject<League>(json);
        }
      
        public async Task<League> GetChallengerLeagueAsync(Region region, string queue)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueChallengerUrl,
                region,
                new List<string> { string.Format("type={0}", queue) });
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }
  
        public League GetMasterLeague(Region region, string queue)
        {
            var json = requester.CreateGetRequest(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueMasterUrl,
                region,
                new List<string> { string.Format("type={0}", queue) });
            return JsonConvert.DeserializeObject<League>(json);
        }
    
        public async Task<League> GetMasterLeagueAsync(Region region, string queue)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueMasterUrl,
                region,
                new List<string> { string.Format("type={0}", queue) });
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }
        
        public MatchDetail GetMatch(Region region, long matchId, bool includeTimeline = false)
        {
            var json = requester.CreateGetRequest(
                string.Format(MatchRootUrl, region.ToString()) + string.Format(IdUrl, matchId),
                region,
                includeTimeline
                    ? new List<string> { string.Format("includeTimeline={0}", includeTimeline.ToString().ToLower() ) }
                    : null);
            return JsonConvert.DeserializeObject<MatchDetail>(json);
        }
        #endregion

        #region Match
        public async Task<MatchDetail> GetMatchAsync(Region region, long matchId, bool includeTimeline = false)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(MatchRootUrl, region.ToString()) + string.Format(IdUrl, matchId),
                region,
                includeTimeline
                    ? new List<string> { string.Format("includeTimeline={0}", includeTimeline) }
                    : null);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MatchDetail>(json));
        }
    
        public MatchList GetMatchList(Region region, long summonerId,
            List<long> championIds = null, List<string> rankedQueues = null,
            List<MatchEndpoint.Enums.Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null,
            int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string> {
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

            var json = requester.CreateGetRequest(
                string.Format(MatchListRootUrl, region.ToString()) + string.Format(IdUrl, summonerId),
                region,
                addedArguments);
            return JsonConvert.DeserializeObject<MatchList>(json);
        }
      
        public async Task<MatchList> GetMatchListAsync(Region region, long summonerId,
            List<long> championIds = null, List<string> rankedQueues = null,
            List<MatchEndpoint.Enums.Season> seasons = null, DateTime? beginTime = null,
            DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string> {
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

            var json = await requester.CreateGetRequestAsync(
                string.Format(MatchListRootUrl, region.ToString()) + string.Format(IdUrl, summonerId),
                region,
                addedArguments);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchList>(json));
        }

        public List<Game> GetRecentGames(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId),
                region);
            return JsonConvert.DeserializeObject<RecentGames>(json).Games;
        }
     
        public async Task<List<Game>> GetRecentGamesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId),
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RecentGames>(json))).Games;
        }
        #endregion    

        #region Spectator
        public CurrentGame GetCurrentGame(Platform platform, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(CurrentGameRootUrl, platform.ToString()) + string.Format(IdUrl, summonerId),
                platform.ConvertToRegion());
            return JsonConvert.DeserializeObject<CurrentGame>(json);
        }
     
        public async Task<CurrentGame> GetCurrentGameAsync(Platform platform, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(CurrentGameRootUrl, platform.ToString()) + string.Format(IdUrl, summonerId),
                platform.ConvertToRegion());
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CurrentGame>(json)));
        }
      
        public FeaturedGames GetFeaturedGames(Region region)
        {
            var json = requester.CreateGetRequest(
                FeaturedGamesRootUrl,
                region);
            return JsonConvert.DeserializeObject<FeaturedGames>(json);
        }
      
        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var json = await requester.CreateGetRequestAsync(
                FeaturedGamesRootUrl,
                region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FeaturedGames>(json)));
        }
        #endregion

        #region Champion Mastery
        public ChampionMastery GetChampionMastery(Region region, long summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region, usePlatforms: true);
            return JsonConvert.DeserializeObject<ChampionMastery>(json);
        }

        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, long summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = await requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl,
                region, usePlatforms: true);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ChampionMastery>(json)));
        }

        public List<ChampionMastery> GetChampionMasteries(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region, usePlatforms: true);
            return JsonConvert.DeserializeObject<List<ChampionMastery>>(json);
        }
       
        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = await requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, 
                region, usePlatforms: true);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ChampionMastery>>(json)));
        }    

        public int GetTotalChampionMasteryScore(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region, usePlatforms: true);
            return JsonConvert.DeserializeObject<int>(json);
        }
      
        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region, usePlatforms: true);
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
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        #endregion
#pragma warning restore
    }
}
