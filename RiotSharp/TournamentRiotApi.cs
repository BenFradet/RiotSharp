using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.TournamentEndpoint;
using RiotSharp.Endpoints.TournamentEndpoint.Enums;
using RiotSharp.Misc;
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

        private readonly IRateLimitedRequester requester;
        private string tournamentRootUrl;

        #endregion

        private TournamentRiotApi(string apiKey, IDictionary<TimeSpan, int> rateLimits, bool useStub = false)
        {
            Requesters.TournamentApiRequester = new RateLimitedRequester(apiKey, rateLimits);
            requester = Requesters.TournamentApiRequester;
            SetTournamentRootUrl(useStub);
        }

        /// <summary>
        /// Default constructor for dependency injection
        /// </summary>
        /// <param name="useStub">
        /// If true, the tournament stub will be used for requests. 
        /// Useful for testing purposes.
        /// </param>
        public TournamentRiotApi(IRateLimitedRequester rateLimitedRequester, bool useStub = false)
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
                apiKey != Requesters.TournamentApiRequester.ApiKey ||
                !rateLimits.Equals(Requesters.TournamentApiRequester.RateLimits))
            {
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

        public async Task<int> CreateProviderAsync(Region region, string url)
        {
            var body = new Dictionary<string, object>
            {
                { "url", url },
                { "region", region.ToString().ToUpper() }
            };
            var json =
                await
                    requester.CreatePostRequestAsync(tournamentRootUrl + CreateProviderUrl, Region.Americas,
                        JsonConvert.SerializeObject(body)).ConfigureAwait(false);

            return int.Parse(json);
        }

        public async Task<int> CreateTournamentAsync(int providerId, string name)
        {
            var body = new Dictionary<string, object> {
                { "name", name },
                { "providerId", providerId }
            };
            var json =
                await
                    requester.CreatePostRequestAsync(tournamentRootUrl + CreateTournamentUrl, Region.Americas,
                        JsonConvert.SerializeObject(body)).ConfigureAwait(false);

            return int.Parse(json);
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
            var json = await requester.CreatePostRequestAsync(tournamentRootUrl + CreateCodesUrl, Region.Americas,
                JsonConvert.SerializeObject(body, null, 
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }),
                    new List<string>
                    {
                        $"tournamentId={tournamentId}",
                        $"count={count}"
                    }).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        public async Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(tournamentRootUrl + string.Format(GetCodesUrl, tournamentCode),
                        Region.Americas).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TournamentCodeDetail>(json);
        }

        public async Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(tournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode),
                        Region.Americas).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json)["eventList"];
        }

        public Task<bool> UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedParticipantIds = null,
            TournamentSpectatorType? spectatorType = null, TournamentPickType? pickType = null, TournamentMapType? mapType = null)
        {
            var body = BuildTournamentUpdateBody(allowedParticipantIds, spectatorType, pickType, mapType);

            return requester.CreatePutRequestAsync(tournamentRootUrl + string.Format(PutCodeUrl, tournamentCode),
                Region.Americas, JsonConvert.SerializeObject(body));
        }

        #endregion

        #region Get Tournament Matches (based on Match endpoint)

        public async Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode,
            bool includeTimeline)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(
                        string.Format(MatchRootUrl, region) + string.Format(GetMatchDetailUrl, matchId), region,
                        new List<string>
                        {
                            $"tournamentCode={tournamentCode}",
                            $"includeTimeline={includeTimeline}"
                        }).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MatchDetail>(json);
        }

        public async Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(
                        string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<long>>(json).FirstOrDefault();
        }

        #endregion

        #region Private Helpers
        private void SetTournamentRootUrl(bool useStub)
        {
            if (useStub)
                tournamentRootUrl = TournamentStubUrl;
            else
                tournamentRootUrl = TournamentUrl;
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
