using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.AccountEndpoint;
using RiotSharpNET8.Endpoints.ChampionEndpoint;
using RiotSharpNET8.Endpoints.ChampionMasteryEndpoint;
using RiotSharpNET8.Endpoints.ClashEndpoint;
using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.LeagueEndpoint;
using RiotSharpNET8.Endpoints.MatchEndpoint;
using RiotSharpNET8.Endpoints.SpectatorEndpoint;
using RiotSharpNET8.Endpoints.StaticDataEndpoint;
using RiotSharpNET8.Endpoints.StatusEndpoint;
using RiotSharpNET8.Endpoints.SummonerEndpoint;
using RiotSharpNET8.Endpoints.ThirdPartyEndpoint;
using RiotSharpNET8.Http;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Interfaces;

namespace RiotSharpNET8
{
    /// <summary>
    /// Implementation of <see cref="IRiotApi"/>
    /// </summary>
    /// <seealso cref="IRiotApi" />
    public class RiotApi : IRiotApi
    {
        #region Private Fields
        private static RiotApi _instance;

        private readonly ICache _cache;
        #endregion

        #region Endpoints

        /// <inheritdoc />
        public IAccountEndpoint Account { get; }

        /// <inheritdoc />
        public ISummonerEndpoint Summoner { get; }

        /// <inheritdoc />
        public IChampionEndpoint Champion { get; }

        /// <inheritdoc />
        public ILeagueEndpoint League { get; }

        /// <inheritdoc />
        public IMatchEndpoint Match { get; }

        /// <inheritdoc />
        public ISpectatorEndpoint Spectator { get; }

        /// <inheritdoc />
        public IChampionMasteryEndpoint ChampionMastery { get; }

        /// <inheritdoc />
        public IThirdPartyEndpoint ThirdParty { get; }

        /// <inheritdoc />
        public IDataDragonEndpoints DataDragon { get; }
        
        ///<inheritdoc cref="Clash"/>
        public IClashEndpoint Clash { get; }

        /// <inheritdoc />
        public IStatusEndpoint Status { get; }

        #endregion

        /// <summary>
        /// Gets the instance of RiotApi, with development rate limits by default.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer1s">The 1 second rate limit for your api key. 20 by default.</param>
        /// <param name="rateLimitPer2m">The 2 minute rate limit for your api key. 100 by default.</param>
        /// <param name="cache">The cache. PassThroughCache is default.</param>
        /// <returns>
        /// The instance of RiotApi.
        /// </returns>
        public static RiotApi GetDevelopmentInstance(string apiKey, int rateLimitPer1s = 20, int rateLimitPer2m = 100, ICache? cache = null)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = rateLimitPer1s,
                [TimeSpan.FromMinutes(2)] = rateLimitPer2m
            }, cache ?? new PassThroughCache());
        }

        /// <summary>
        /// Get the instance of a production RiotApi with custom rate limits.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <param name="cache">The cache. PassThroughCache is default.</param>
        /// <returns>
        /// The instance of RiotApi.
        /// </returns>
        public static RiotApi GetInstance(string apiKey, int rateLimitPer10s, int rateLimitPer10m, ICache? cache = null)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(10)] = rateLimitPer10m,
                [TimeSpan.FromSeconds(10)] = rateLimitPer10s
            }, cache ?? new PassThroughCache());
        }

        /// <summary>
        /// Gets the instance of RiotApi, allowing custom rate limits.
        /// It essentially constructs a new instance of RiotApi if the api key or rate limits have changed.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimits">A dictionary of rate limits where the key is the time span and the value
        /// is the number of requests allowed per that time span.</param>
        /// <param name="cache">The cache.</param>
        /// <returns>
        /// The instance of RiotApi.
        /// </returns>
        private static RiotApi GetInstance(string apiKey, IDictionary<TimeSpan, int> rateLimits, ICache cache)
        {
            if (_instance == null || Requesters.RiotApiRequester == null ||
                apiKey != Requesters.RiotApiRequester.ApiKey ||
                !rateLimits.Equals(Requesters.RiotApiRequester.RateLimits))
            {
                _instance = new RiotApi(apiKey, rateLimits, cache);
            }
            return _instance;
        }

        private RiotApi(string apiKey, IDictionary<TimeSpan, int> rateLimits, ICache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            Requesters.RiotApiRequester = new RateLimitedRequester(apiKey, rateLimits);
            Requesters.StaticApiRequester = new Requester(apiKey);
            var requester = Requesters.RiotApiRequester;

            Account = new AccountEndpoint(requester);
            Summoner = new SummonerEndpoint(requester, _cache);
            Champion = new ChampionEndpoint(requester);
            League = new LeagueEndpoint(requester);
            Match = new MatchEndpoint(requester, _cache);
            Spectator = new SpectatorEndpoint(requester);
            ChampionMastery = new ChampionMasteryEndpoint(requester);
            ThirdParty = new ThirdPartyEndpoint(requester);

            DataDragon = new DataDragonEndpoints(Requesters.StaticApiRequester, _cache);
            Status = new StatusEndpoint(Requesters.StaticApiRequester);
            
            Clash = new ClashEndpoint(requester, _cache);
        }

        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="rateLimitedRequester">Rate limited requester for all endpoints except the static endpoint.</param>
        /// <param name="requester">Requester for static endpoints.</param>
        /// <param name="staticEndpointProvider">The static endpoint provider.</param>
        /// <param name="cache">The cache. PassThroughCache is default.</param>
        /// <exception cref="ArgumentNullException">
        /// rateLimitedRequester
        /// or
        /// staticEndpointProvider
        /// </exception>
        public RiotApi(IRateLimitedRequester rateLimitedRequester, IRequester requester, IStaticEndpointProvider staticEndpointProvider,
            ICache? cache = null)
        {
            if(rateLimitedRequester == null)
                throw new ArgumentNullException(nameof(rateLimitedRequester));
            if (staticEndpointProvider == null)
                throw new ArgumentNullException(nameof(staticEndpointProvider));

            _cache = cache ?? new PassThroughCache();

            Account = new AccountEndpoint(rateLimitedRequester);
            Summoner = new SummonerEndpoint(rateLimitedRequester, _cache);
            Champion = new ChampionEndpoint(rateLimitedRequester);
            League = new LeagueEndpoint(rateLimitedRequester);
            Match = new MatchEndpoint(rateLimitedRequester, _cache);
            Spectator = new SpectatorEndpoint(rateLimitedRequester);
            ChampionMastery = new ChampionMasteryEndpoint(rateLimitedRequester);
            ThirdParty = new ThirdPartyEndpoint(rateLimitedRequester);

            DataDragon = new DataDragonEndpoints(staticEndpointProvider);
            Status = new StatusEndpoint(requester);
            
            Clash = new ClashEndpoint(rateLimitedRequester, _cache);
        }
    }
}
