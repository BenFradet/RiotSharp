using Newtonsoft.Json;
using RiotSharp.MatchEndpoint;
using RiotSharp.TournamentEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RiotSharp.Misc;
using RiotSharp.TournamentEndpoint.Enums;
using RiotSharp.Http.Interfaces;
using RiotSharp.Http;
using RiotSharp.Interfaces;

namespace RiotSharp
{
    public class TournamentRiotApi : ITournamentRiotApi
    {
        #region Private Fields

        private const string TournamentStubUrl = "/lol/tournament-stub/v3";
        private const string TournamentUrl = "/lol/tournament/v3";
        private const string CreateCodesUrl = "/codes";
        private const string GetCodesUrl = "/codes/{0}";
        private const string PutCodeUrl = "/codes/{0}";
        private const string LobbyEventUrl = "/lol/tournament/v3/lobby-events/by-code/{0}";
        private const string CreateProviderUrl = "/providers";
        private const string CreateTournamentUrl = "/tournaments";

        private const string MatchRootUrl = "/api/lol/{0}/v2.2/match";
        private const string GetMatchIdUrl = "/by-tournament/{0}/ids";
        private const string GetMatchDetailUrl = "/for-tournament/{0}";

        private static TournamentRiotApi instance;
        private static string instanceApiKey;
        private static IDictionary<TimeSpan, int> instanceRateLimits;

        private readonly IRequester requester;
        private string tournamentRootUrl;

        #endregion

        private TournamentRiotApi(string apiKey, IDictionary<TimeSpan, int> rateLimits, bool useStub = false)
        {
            SetTournamentRootUrl(useStub);

            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var requestCreator = new RequestCreator(apiKey, serializer);
            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();
            var client = new RequestClient(httpClient, failedRequestHandler);
            var basicRequester = new Requester(client, requestCreator, deserializer);
            var rateLimitProvider = new RateLimitProvider(rateLimits);

            requester = new RateLimitedRequester(basicRequester, rateLimitProvider);
            Requesters.TournamentApiRequester = (RateLimitedRequester)requester;
        }

        /// <summary>
        /// Default constructor for dependency injection
        /// </summary>
        /// <param name="useStub">
        /// If true, the tournament stub will be used for requests. 
        /// Useful for testing purposes.
        /// </param>
        public TournamentRiotApi(IRequester rateLimitedRequester, bool useStub = false)
        {
            if (rateLimitedRequester == null)
                throw new ArgumentNullException(nameof(rateLimitedRequester));
            requester = rateLimitedRequester;
            SetTournamentRootUrl(useStub);
        }

        /// <summary>
        /// Get the instance of TournamentRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <param name="useStub">
        /// If true, the tournament stub will be used for requests. 
        /// Useful for testing purposes.
        /// </param>
        /// <returns>The instance of TournamentRiotApi.</returns>
        public static TournamentRiotApi GetInstance(string apiKey, int rateLimitPer10s = 10, int rateLimitPer10m = 500,
            bool useStub = false)
        {
            return GetInstance(apiKey, new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(10)] = rateLimitPer10s,
                [TimeSpan.FromMinutes(10)] = rateLimitPer10m
            }, useStub);
        }

        /// <summary>
        /// Get the instance of TournamentRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimits">A dictionary of rate limits where the key is the time span and the value
        /// is the number of requests allowed per that time span. Use null for no limits (default).</param>
        /// <param name="useStub">
        /// If true, the tournament stub will be used for requests. 
        /// Useful for testing purposes.
        /// </param>
        /// <returns>The instance of TournamentRiotApi.</returns>
        public static TournamentRiotApi GetInstance(string apiKey, IDictionary<TimeSpan, int> rateLimits, bool useStub = false)
        {
            if (rateLimits == null)
                rateLimits = new Dictionary<TimeSpan, int>();
            if (instance == null ||
                Requesters.TournamentApiRequester == null ||
                apiKey != instanceApiKey ||
                !rateLimits.Equals(instanceRateLimits))
            {
                instanceApiKey = apiKey;
                instanceRateLimits = rateLimits;
                instance = new TournamentRiotApi(apiKey, rateLimits);
            }
            return instance;
        }

        internal static TournamentRiotApi GetInstance()
        {
            if (instance == null ||
                Requesters.TournamentApiRequester == null)
            {
                throw new NotSupportedException(
                    "Can't get instance of TournamentRiotApi. " +
                    "Use the overloaded method GetInstance(apikey, rateLimits) " +
                    "anywhere in your code before calling any tournament API method.");
            }
            return instance;
        }

        #region Public Methods
      
        public int CreateProvider(Region region, string url)
        {
            var body = new Dictionary<string, object>
            {
                { "url", url },
                { "region", region.ToString().ToUpper() }
            };
            var relativeUrl = tournamentRootUrl + CreateProviderUrl;
            return requester.Post<int>(relativeUrl, Region.global, body);
        }

        public async Task<int> CreateProviderAsync(Region region, string url)
        {
            var body = new Dictionary<string, object>
            {
                { "url", url },
                { "region", region.ToString().ToUpper() }
            };
            var relativeUrl = tournamentRootUrl + CreateProviderUrl;
            return await requester.PostAsync<int>(relativeUrl, Region.global, body);
        }  

        public int CreateTournament(int providerId, string name)
        {
            var body = new Dictionary<string, object>
            {
                { "name", name },
                { "providerId", providerId }
            };
            var relativeUrl = tournamentRootUrl + CreateTournamentUrl;
            return requester.Post<int>(relativeUrl, Region.global, body);
        }

        public async Task<int> CreateTournamentAsync(int providerId, string name)
        {
            var body = new Dictionary<string, object>
            {
                { "name", name },
                { "providerId", providerId }
            };
            var relativeUrl = tournamentRootUrl + CreateTournamentUrl;
            return await requester.PostAsync<int>(relativeUrl, Region.global, body);
        }

        public List<string> CreateTournamentCodes(int tournamentId, int count, int teamSize, TournamentSpectatorType spectatorType, 
            TournamentPickType pickType, TournamentMapType mapType, List<long> allowedParticipantIds = null,
            string metadata = "")
        {
            ValidateTeamSize(teamSize);
            ValidateTournamentCodeCount(count);
            var body = new Dictionary<string, object>
            {
                { "teamSize", teamSize },
                { "allowedSummonerIds", allowedParticipantIds },
                { "spectatorType", spectatorType },
                { "pickType", pickType },
                { "mapType", mapType },
                { "metadata", metadata }
            };

            var arguments = new List<string>
            {
                $"tournamentId={tournamentId}",
                $"count={count}"
            };

            var url = tournamentRootUrl + CreateCodesUrl;
            return requester.Post<List<string>>(url, Region.global, body, arguments);
        }
   
        public async Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int count, int teamSize,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, 
            TournamentMapType mapType, List<long> allowedParticipantIds = null,  string metadata = null)
        {
            ValidateTeamSize(teamSize);
            ValidateTournamentCodeCount(count);
            var body = new Dictionary<string, object>
            {
                { "teamSize", teamSize },
                { "allowedSummonerIds", allowedParticipantIds },
                { "spectatorType", spectatorType },
                { "pickType", pickType },
                { "mapType", mapType },
                { "metadata", metadata }
            };

            var arguments = new List<string>
            {
                $"tournamentId={tournamentId}",
                $"count={count}"
            };

            var url = tournamentRootUrl + CreateCodesUrl;
            return await requester.PostAsync<List<string>>(url, Region.global, body, arguments);
        }    

        public TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode)
        {
            var url = tournamentRootUrl + string.Format(GetCodesUrl, tournamentCode);
            return requester.Get<TournamentCodeDetail>(url, Region.global);
        }

        public async Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode)
        {
            var url = tournamentRootUrl + string.Format(GetCodesUrl, tournamentCode);
            return await requester.GetAsync<TournamentCodeDetail>(url, Region.global);
        }

        public List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode)
        {
            var url = tournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode);
            return requester.Get<Dictionary<string, List<TournamentLobbyEvent>>>(url, Region.global)["eventList"];
        }

        public async Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode)
        {
            var url = tournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode);
            return (await requester.GetAsync<Dictionary<string, List<TournamentLobbyEvent>>>(url, Region.global))["eventList"];
        }
      
        public bool UpdateTournamentCode(string tournamentCode, List<long> allowedParticipantIds = null,
            TournamentSpectatorType? spectatorType = null, TournamentPickType? pickType = null, TournamentMapType? mapType= null)
        {
            var url = tournamentRootUrl + string.Format(PutCodeUrl, tournamentCode);
            var body = BuildTournamentUpdateBody(allowedParticipantIds, spectatorType, pickType, mapType);
            return requester.Put(url, Region.global, body);
        }

        public async Task<bool> UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedParticipantIds = null,
            TournamentSpectatorType? spectatorType = null, TournamentPickType? pickType = null, TournamentMapType? mapType = null)
        {
            var url = tournamentRootUrl + string.Format(PutCodeUrl, tournamentCode);
            var body = BuildTournamentUpdateBody(allowedParticipantIds, spectatorType, pickType, mapType);
            return await requester.PutAsync(url, Region.global, body);
        }

        #endregion

        #region Get Tournament Matches (based on Match endpoint)

        public MatchDetail GetTournamentMatch(Region region, long matchId, string tournamentCode, bool includeTimeline)
        {
            var url = string.Format(MatchRootUrl, region) + string.Format(GetMatchDetailUrl, matchId);
            var arguments = new List<string>
            {
                $"tournamentCode={tournamentCode}",
                $"includeTimeline={includeTimeline}"
            };
            return requester.Get<MatchDetail>(url, region, arguments);
        }

        public async Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode,
            bool includeTimeline)
        {
            var url = string.Format(MatchRootUrl, region) + string.Format(GetMatchDetailUrl, matchId);
            var arguments = new List<string>
            {
                $"tournamentCode={tournamentCode}",
                $"includeTimeline={includeTimeline}"
            };
            return await requester.GetAsync<MatchDetail>(url, region, arguments);
        }

        public long GetTournamentMatchId(Region region, string tournamentCode)
        {
            var url = string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode);
            return requester.Get<List<long>>(url, region).FirstOrDefault();
        }

        public async Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode)
        {
            var url = string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode);
            return (await requester.GetAsync<List<long>>(url, region)).FirstOrDefault();
        }

        #endregion

        #region Private Helpers
        private void SetTournamentRootUrl(bool useStub)
        {
            tournamentRootUrl = useStub ? TournamentStubUrl : TournamentUrl;
        }

        private Dictionary<string, object> BuildTournamentUpdateBody(List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            var body = new Dictionary<string, object>();
            if (allowedSummonerIds != null)
                body.Add("allowedParticipants", string.Join(",", allowedSummonerIds));
            if (spectatorType != null)
                body.Add("spectatorType", spectatorType);
            if (pickType != null)
                body.Add("pickType", pickType);
            if (mapType != null)
                body.Add("mapType", mapType);

            return body;
        }

        private void ValidateTeamSize(int teamSize)
        {
            if (teamSize < 1 || teamSize > 5)
                throw new ArgumentException("Invalid team size. Valid values are 1-5.", nameof(teamSize));
        }

        private void ValidateTournamentCodeCount(int count)
        {
            if (count > 1000)
                throw new ArgumentException("Invalid count. You cannot create more than 1000 codes at once.", nameof(count));
            if (count < 1)
                throw new ArgumentException("Invalid count. The value of count must be greater than 0.", nameof(count));
        }

        #endregion

    }
}
