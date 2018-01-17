using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Endpoints.ChampionMasteryEndpoint;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Endpoints.MasteriesEndpoint;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Endpoints.RunesEndpoint;
using RiotSharp.Endpoints.SpectatorEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;

namespace RiotSharp
{
    /// <summary>
    /// Implementation of IRiotApi
    /// </summary>
    public class RiotApi : IRiotApi
    {
        #region Private Fields

        private const string MatchCache = "match-{0}_{1}";
        private const string SummonerCache = "summoner-{0}_{1}";

        private static readonly TimeSpan SummonerTtl = TimeSpan.FromDays(30);
        private static readonly TimeSpan MatchTtl = TimeSpan.FromDays(60);

        private static RiotApi _instance;

        private ICache _cache;

        public ISummonerEndpoint Summoner { get; }

        public IChampionEndpoint Champion { get; }

        public IMasteriesEndpoint Masteries { get; }

        public IRunesEndpoint Runes { get; }

        public ILeagueEndpoint League { get; }

        public IMatchEndpoint Match { get; }

        public ISpectatorEndpoint Spectator { get; }

        public IChampionMasteryEndpoint ChampionMastery { get; }

        #endregion

        /// <summary>
        /// Gets the instance of RiotApi, with development rate limits by default.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer1s">The 1 second rate limit for your api key. 20 by default.</param>
        /// <param name="rateLimitPer2m">The 2 minute rate limit for your api key. 100 by default.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetDevelopmentInstance(string apiKey, int rateLimitPer1s = 20, int rateLimitPer2m = 100, ICache cache = null)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = rateLimitPer1s,
                [TimeSpan.FromMinutes(2)] = rateLimitPer2m
            }, cache ?? new PassThroughCache());
        }

        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, int rateLimitPer10s, int rateLimitPer10m, ICache cache = null)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(10)] = rateLimitPer10m,
                [TimeSpan.FromSeconds(10)] = rateLimitPer10s
            }, cache ?? new PassThroughCache());
        }

        /// <summary>
        /// Gets the instance of RiotApi, allowing custom rate limits.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimits">A dictionary of rate limits where the key is the time span and the value
        /// is the number of requests allowed per that time span.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, IDictionary<TimeSpan, int> rateLimits, ICache cache)
        {
            if (_instance == null || Requesters.RiotApiRequester == null ||
                apiKey != Requesters.RiotApiRequester.ApiKey ||
                !rateLimits.Equals(Requesters.RiotApiRequester.RateLimits))
            {
                _instance = new RiotApi(apiKey, rateLimits);
            }
            return _instance;
        }

        private RiotApi(string apiKey, IDictionary<TimeSpan, int> rateLimits)
        {
            Requesters.RiotApiRequester = new RateLimitedRequester(apiKey, rateLimits);
            var requester = Requesters.RiotApiRequester;
            Summoner = new SummonerEndpoint(requester);
            Champion = new ChampionEndpoint(requester);
            Masteries = new MasteriesEndpoint(requester);
            Runes = new RunesEndpoint(requester);
            League = new LeagueEndpoint(requester);
            Match = new MatchEndpoint(requester);
            Spectator = new SpectatorEndpoint(requester);
            ChampionMastery = new ChampionMasteryEndpoint(requester);
        }

        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="rateLimitedRequester"></param>
        public RiotApi(IRateLimitedRequester rateLimitedRequester)
        {
            if (rateLimitedRequester == null)
            {
                throw new ArgumentNullException(nameof(rateLimitedRequester));
            }
           Summoner = new SummonerEndpoint(rateLimitedRequester);
           Champion = new ChampionEndpoint(rateLimitedRequester);
           Masteries = new MasteriesEndpoint(rateLimitedRequester);
           Runes = new RunesEndpoint(rateLimitedRequester);
           League = new LeagueEndpoint(rateLimitedRequester);
           Match = new MatchEndpoint(rateLimitedRequester);
           Spectator = new SpectatorEndpoint(rateLimitedRequester);
           ChampionMastery = new ChampionMasteryEndpoint(rateLimitedRequester);
            
        }

#pragma warning disable CS1591

        #region Summoner
        public Summoner GetSummonerByAccountId(Region region, long accountId)
        {
            var wrapper = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, accountId));
            if (wrapper == null)
            {
                var obj = Summoner.GetSummonerByAccountId(region, accountId);
                _cache.Add(string.Format(SummonerCache, region, accountId), obj, SummonerTtl);
                return obj;
            }
            return wrapper;
        }

        public async Task<Summoner> GetSummonerByAccountIdAsync(Region region, long accountId)
        {
            var wrapper = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, accountId));
            if (wrapper == null)
            {
                var obj = await Summoner.GetSummonerByAccountIdAsync(region, accountId);
                _cache.Add(string.Format(SummonerCache, region, accountId), obj, SummonerTtl);
                return obj;
            }
            return wrapper;
        }

        public Summoner GetSummonerBySummonerId(Region region, long summonerId)
        {
            var wrapper = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, summonerId));
            if (wrapper == null)
            {
                var obj = Summoner.GetSummonerBySummonerId(region, summonerId);
                _cache.Add(string.Format(SummonerCache, region, summonerId), obj, SummonerTtl);
                return obj;
            }
            return wrapper;
        }

        public async Task<Summoner> GetSummonerBySummonerIdAsync(Region region, long summonerId)
        {
            var wrapper = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, summonerId));
            if (wrapper == null)
            {
                var obj = await Summoner.GetSummonerBySummonerIdAsync(region, summonerId);
                _cache.Add(string.Format(SummonerCache, region, summonerId), obj, SummonerTtl);
                return obj;
            }
            return wrapper;
        }

        public Summoner GetSummonerByName(Region region, string summonerName)
        {
            var wrapper = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, summonerName));
            if (wrapper == null)
            {
                var obj = Summoner.GetSummonerByName(region, summonerName);
                _cache.Add(string.Format(SummonerCache, region, summonerName), obj, SummonerTtl);
                return obj;
            }
            return wrapper;
        }

        public async Task<Summoner> GetSummonerByNameAsync(Region region, string summonerName)
        {
            var wrapper = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, summonerName));
            if (wrapper == null)
            {
                var obj = await Summoner.GetSummonerByNameAsync(region, summonerName);
                _cache.Add(string.Format(SummonerCache, region, summonerName), obj, SummonerTtl);
                return obj;
            }
            return wrapper;
        }
        #endregion

        #region Champion
        public List<Champion> GetChampions(Region region, bool freeToPlay = false)
        {
            return Champion.GetChampions(region, freeToPlay);
        }

        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            return await Champion.GetChampionsAsync(region, freeToPlay);
        }

        public Champion GetChampion(Region region, int championId)
        {
            return Champion.GetChampion(region, championId);
        }

        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            return await Champion.GetChampionAsync(region, championId);
        }
        #endregion

        #region Masteries
        public List<MasteryPage> GetMasteryPages(Region region, long summonerId)
        {
            return Masteries.GetMasteryPages(region, summonerId);
        }

        public async Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId)
        {
            return await Masteries.GetMasteryPagesAsync(region, summonerId);
        }
        #endregion

        #region Runes
        public List<RunePage> GetRunePages(Region region, long summonerId)
        {
            return Runes.GetRunePages(region, summonerId);
        }

        public async Task<List<RunePage>> GetRunePagesAsync(Region region, long summonerId)
        {
            return await Runes.GetRunePagesAsync(region, summonerId);
        }
        #endregion

        #region League
        public List<LeaguePosition> GetLeaguePositions(Region region, long summonerId)
        {
            return League.GetLeaguePositions(region, summonerId);
        }

        public async Task<List<LeaguePosition>> GetLeaguePositionsAsync(Region region, long summonerId)
        {
            return await League.GetLeaguePositionsAsync(region, summonerId);
        }

        public League GetChallengerLeague(Region region, string queue)
        {
            return League.GetChallengerLeague(region, queue);
        }

        public async Task<League> GetChallengerLeagueAsync(Region region, string queue)
        {
            return await League.GetChallengerLeagueAsync(region, queue);
        }

        public League GetMasterLeague(Region region, string queue)
        {
            return League.GetMasterLeague(region, queue);
        }

        public async Task<League> GetMasterLeagueAsync(Region region, string queue)
        {
            return await League.GetMasterLeagueAsync(region, queue);
        }
        #endregion

        #region Match
        public List<long> GetMatchIdsByTournamentCode(Region region, string tournamentCode)
        {
            return Match.GetMatchIdsByTournamentCode(region, tournamentCode);
        }

        public async Task<List<long>> GetMatchIdsByTournamentCodeAsync(Region region, string tournamentCode)
        {
            return await Match.GetMatchIdsByTournamentCodeAsync(region, tournamentCode);
        }

        public Match GetMatch(Region region, long matchId)
        {
            var wrapper = _cache.Get<string, Match>(string.Format(MatchCache, region, matchId));
            if (wrapper != null) return wrapper;
            var match = Match.GetMatch(region, matchId);
            _cache.Add(string.Format(MatchCache, region, matchId), match, MatchTtl);
            return match;
        }

        public async Task<Match> GetMatchAsync(Region region, long matchId)
        {
            var wrapper = _cache.Get<string, Match>(string.Format(MatchCache, region, matchId));
            if (wrapper != null) return wrapper;
            var match = await Match.GetMatchAsync(region, matchId);
            _cache.Add(string.Format(MatchCache, region, matchId), match, MatchTtl);
            return match;
        }

        public MatchList GetMatchList(Region region, long accountId,
            List<int> championIds = null,
            List<int> queues = null,
            List<Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null)
        {
            return Match.GetMatchList(region, accountId, championIds, queues, seasons, beginTime, endTime, beginIndex,
                endIndex);
        }

        public async Task<MatchList> GetMatchListAsync(Region region, long accountId,
            List<int> championIds = null,
            List<int> queues = null,
            List<Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null)
        {
            return await Match.GetMatchListAsync(region, accountId, championIds, queues, seasons, beginTime, endTime, beginIndex,
                endIndex);
        }

        public List<MatchReference> GetRecentMatches(Region region, long summonerId)
        {
            return Match.GetRecentMatches(region, summonerId);
        }

        public async Task<List<MatchReference>> GetRecentMatchesAsync(Region region, long summonerId)
        {
            return await Match.GetRecentMatchesAsync(region, summonerId);
        }
        #endregion

        #region Spectator
        public CurrentGame GetCurrentGame(Region region, long summonerId)
        {
            return Spectator.GetCurrentGame(region, summonerId);
        }
        
        public async Task<CurrentGame> GetCurrentGameAsync(Region region, long summonerId)
        {
            return await Spectator.GetCurrentGameAsync(region, summonerId);
        }

        public FeaturedGames GetFeaturedGames(Region region)
        {
            return Spectator.GetFeaturedGames(region);
        }

        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            return await Spectator.GetFeaturedGamesAsync(region);
        }
        #endregion

        #region Champion Mastery
        public ChampionMastery GetChampionMastery(Region region, long summonerId, long championId)
        {
            return ChampionMastery.GetChampionMastery(region, summonerId, championId);
        }

        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, long summonerId, long championId)
        {
            return await ChampionMastery.GetChampionMasteryAsync(region, summonerId, championId);
        }

        public List<ChampionMastery> GetChampionMasteries(Region region, long summonerId)
        {
            return ChampionMastery.GetChampionMasteries(region, summonerId);
        }

        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, long summonerId)
        {
            return await ChampionMastery.GetChampionMasteriesAsync(region, summonerId);
        }

        public int GetTotalChampionMasteryScore(Region region, long summonerId)
        {
            return ChampionMastery.GetTotalChampionMasteryScore(region, summonerId);
        }

        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, long summonerId)
        {
            return await ChampionMastery.GetTotalChampionMasteryScoreAsync(region, summonerId);
        }
        #endregion

#pragma warning restore
    }
}
