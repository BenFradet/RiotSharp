using Newtonsoft.Json;
using RiotSharp.MatchEndpoint;
using RiotSharp.TournamentEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharp
{
    /// <summary>
    /// Entry point for the tournament API.
    /// </summary>
    public class TournamentRiotApi : ITournamentRiotApi
    {
        private const string TournamentRootUrl = "/tournament/public/v1";
        private const string CreateCodeUrl = "/code";
        private const string GetCodeUrl = "/code/{0}";
        private const string PutCodeUrl = "/code/{0}";
        private const string LobbyEventUrl = "/lobby/events/by-code/{0}";
        private const string CreateProviderUrl = "/provider";
        private const string CreateTournamentUrl = "/tournament";

        private const string MatchRootUrl = "/api/lol/{0}/v2.2/match";
        private const string GetMatchIdUrl = "/by-tournament/{0}/ids";
        private const string GetMatchDetailUrl = "/for-tournament/{0}";

        private static TournamentRiotApi instance;

        private readonly RateLimitedRequester requester;

        private TournamentRiotApi(string apiKey, int rateLimitPer10s, int rateLimitPer10m)
        {
            Requesters.TournamentApiRequester = new RateLimitedRequester(apiKey, rateLimitPer10s, rateLimitPer10m);
            requester = Requesters.TournamentApiRequester;
        }

        /// <summary>
        ///     Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static TournamentRiotApi GetInstance(string apiKey, int rateLimitPer10s = 10, int rateLimitPer10m = 500)
        {
            if (instance == null ||
                Requesters.TournamentApiRequester == null ||
                apiKey != Requesters.TournamentApiRequester.ApiKey ||
                rateLimitPer10s != Requesters.TournamentApiRequester.RateLimitPer10S ||
                rateLimitPer10m != Requesters.TournamentApiRequester.RateLimitPer10M)
            {
                instance = new TournamentRiotApi(apiKey, rateLimitPer10s, rateLimitPer10m);
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
                    "Use the overloaded method GetInstance(apikey, rateLimitPer10s, rateLimitPer10m) " +
                    "anywhere in your code before calling any tournament API method.");
            }
            return instance;
        }

        /// <summary>
        ///     Creates a tournament provider and returns its ID.
        /// </summary>
        /// <param name="region">The region in which the provider will be running tournaments.</param>
        /// <param name="url">
        ///     The provider's callback URL to which tournament game results in this region should be posted. The URL
        ///     must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use
        ///     port 80, https URLs must use port 443).
        /// </param>
        /// <returns>The ID of the provider.</returns>
        public TournamentProvider CreateProvider(Region region, string url)
        {
            var body = new Dictionary<string, object> { { "url", url }, { "region", region.ToString().ToUpper() } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateProviderUrl, Region.global,
                JsonConvert.SerializeObject(body));

            // json is an int directly
            var provider = new TournamentProvider { Id = int.Parse(json) };

            return provider;
        }

        /// <summary>
        ///     Creates a tournament provider and returns its object.
        /// </summary>
        /// <param name="region">The region in which the provider will be running tournaments.</param>
        /// <param name="url">
        ///     The provider's callback URL to which tournament game results in this region should be posted. The URL
        ///     must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use
        ///     port 80, https URLs must use port 443).
        /// </param>
        /// <returns>The ID of the provider.</returns>
        public async Task<TournamentProvider> CreateProviderAsync(Region region, string url)
        {
            var body = new Dictionary<string, object> { { "url", url }, { "region", region.ToString().ToUpper() } };
            var json =
                await
                    requester.CreatePostRequestAsync(TournamentRootUrl + CreateProviderUrl, Region.global,
                        JsonConvert.SerializeObject(body));

            return new TournamentProvider { Id = int.Parse(json) };
        }

        /// <summary>
        ///     Creates a tournament and returns its object.
        /// </summary>
        /// <param name="providerId">The provider ID to specify the regional registered provider data to associate this tournament.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>The ID of the tournament.</returns>
        public Tournament CreateTournament(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateTournamentUrl, Region.global,
                JsonConvert.SerializeObject(body));

            // json is an int directly
            var tournament = new Tournament { Id = int.Parse(json) };

            return tournament;
        }

        /// <summary>
        ///     Creates a tournament and returns its object.
        /// </summary>
        /// <param name="providerId">The provider ID to specify the regional registered provider data to associate this tournament.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>The ID of the tournament.</returns>
        public async Task<Tournament> CreateTournamentAsync(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json =
                await
                    requester.CreatePostRequestAsync(TournamentRootUrl + CreateTournamentUrl, Region.global,
                        JsonConvert.SerializeObject(body));

            return new Tournament { Id = int.Parse(json) };
        }

        /// <summary>
        ///     Create a tournament code for the given tournament id.
        /// </summary>
        /// <param name="tournamentId">The tournament ID</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="allowedSummonerIds">
        ///     Optional list of participants in order to validate the players eligible to join the
        ///     lobby. NOTE: We currently do not enforce participants at the team level, but rather the aggregate of teamOne and
        ///     teamTwo. We may add the ability to enforce at the team level in the future.
        /// </param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="metadata">
        ///     Optional string that may contain any data in any format, if specified at all. Used to denote any
        ///     custom information about the game.
        /// </param>
        /// <returns>The tournament code in string format.</returns>
        public string CreateTournamentCode(int tournamentId, int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata)
        {
            var body = new Dictionary<string, object>
            {
                {"teamSize", teamSize},
                {"allowedSummonerIds", new Dictionary<string, object> {{"participants", allowedSummonerIds}}},
                {"spectatorType", spectatorType},
                {"pickType", pickType},
                {"mapType", mapType},
                {"metadata", metadata}
            };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateCodeUrl, Region.global,
                JsonConvert.SerializeObject(body),
                new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", 1) });

            // json is a list of strings
            var tournamentCodes = JsonConvert.DeserializeObject<List<string>>(json);

            return tournamentCodes.FirstOrDefault();
        }

        /// <summary>
        ///     Create a tournament code for the given tournament id.
        /// </summary>
        /// <param name="tournamentId">The tournament ID</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="allowedSummonerIds">
        ///     Optional list of participants in order to validate the players eligible to join the
        ///     lobby. NOTE: We currently do not enforce participants at the team level, but rather the aggregate of teamOne and
        ///     teamTwo. We may add the ability to enforce at the team level in the future.
        /// </param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="metadata">
        ///     Optional string that may contain any data in any format, if specified at all. Used to denote any
        ///     custom information about the game.
        /// </param>
        /// <returns>The tournament code in string format.</returns>
        public async Task<string> CreateTournamentCodeAsync(int tournamentId, int teamSize,
            List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType,
            TournamentMapType mapType, string metadata)
        {
            var body = new Dictionary<string, object>
            {
                {"teamSize", teamSize},
                {"allowedSummonerIds", new Dictionary<string, object> {{"participants", allowedSummonerIds}}},
                {"spectatorType", spectatorType},
                {"pickType", pickType},
                {"mapType", mapType},
                {"metadata", metadata}
            };
            var json =
                await
                    requester.CreatePostRequestAsync(TournamentRootUrl + CreateCodeUrl, Region.global,
                        JsonConvert.SerializeObject(body),
                        new List<string>
                        {
                            string.Format("tournamentId={0}", tournamentId),
                            string.Format("count={0}", 1)
                        });

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(json).FirstOrDefault());
        }

        /// <summary>
        ///     Create multiple tournament codes for the given tournament id.
        /// </summary>
        /// <param name="tournamentId">The tournament ID</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="metadata">
        ///     Optional string that may contain any data in any format, if specified at all. Used to denote any
        ///     custom information about the game.
        /// </param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <returns>A list of tournament codes in string format.</returns>
        public List<string> CreateTournamentCodes(int tournamentId, int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1)
        {
            var body = new Dictionary<string, object>
            {
                {"teamSize", teamSize},
                {"spectatorType", spectatorType},
                {"pickType", pickType},
                {"mapType", mapType},
                {"metadata", metadata}
            };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateCodeUrl, Region.global,
                JsonConvert.SerializeObject(body),
                new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", count) });

            // json is a list of strings
            var tournamentCodes = JsonConvert.DeserializeObject<List<string>>(json);

            return tournamentCodes;
        }

        /// <summary>
        ///     Create multiple tournament codes for the given tournament id.
        /// </summary>
        /// <param name="tournamentId">The tournament ID</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="metadata">
        ///     Optional string that may contain any data in any format, if specified at all. Used to denote any
        ///     custom information about the game.
        /// </param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <returns>A list of tournament codes in string format.</returns>
        public async Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int teamSize,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata, int count = 1)
        {
            var body = new Dictionary<string, object>
            {
                {"teamSize", teamSize},
                {"spectatorType", spectatorType},
                {"pickType", pickType},
                {"mapType", mapType},
                {"metadata", metadata}
            };
            var json =
                await
                    requester.CreatePostRequestAsync(TournamentRootUrl + CreateCodeUrl, Region.global,
                        JsonConvert.SerializeObject(body),
                        new List<string>
                        {
                            string.Format("tournamentId={0}", tournamentId),
                            string.Format("count={0}", count)
                        });

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(json));
        }

        /// <summary>
        ///     Returns the details of a certain tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code in string format.</param>
        /// <returns>TournamentCodeDetail object with details of the tournament code.</returns>
        public TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode)
        {
            var json = requester.CreateGetRequest(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode),
                Region.global);
            var tournamentCodeDetails = JsonConvert.DeserializeObject<TournamentCodeDetail>(json);

            return tournamentCodeDetails;
        }

        /// <summary>
        ///     Returns the details of a certain tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code in string format.</param>
        /// <returns>TournamentCodeDetail object with details of the tournament code.</returns>
        public async Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode),
                        Region.global);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TournamentCodeDetail>(json));
        }

        /// <summary>
        ///     Gets a list of lobby events by tournament code.
        /// </summary>
        /// <param name="tournamentCode">A tournament code in string format.</param>
        /// <returns>List of TournamentLobbyEvents.</returns>
        public List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode)
        {
            var json = requester.CreateGetRequest(TournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode),
                Region.global);
            var lobbyEventsDTO = JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json);

            return lobbyEventsDTO["eventList"];
        }

        /// <summary>
        ///     Gets a list of lobby events by tournament code.
        /// </summary>
        /// <param name="tournamentCode">A tournament code in string format.</param>
        /// <returns>List of TournamentLobbyEvents.</returns>
        public async Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(TournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode),
                        Region.global);

            return
                await
                    Task.Factory.StartNew(() =>
                        JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json)["eventList"]
                    );
        }

        /// <summary>
        ///     Retrieve match by match ID and tournament code.
        /// </summary>
        /// <param name="region">The region of the match.</param>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code of the match.</param>
        /// <param name="includeTimeline">Flag indicating whether or not to include match timeline data.</param>
        /// <returns>MatchDetail object.</returns>
        public MatchDetail GetTournamentMatch(Region region, long matchId, string tournamentCode, bool includeTimeline)
        {
            var json =
                requester.CreateGetRequest(
                    string.Format(MatchRootUrl, region) + string.Format(GetMatchDetailUrl, matchId), region,
                    new List<string>
                    {
                        string.Format("tournamentCode={0}", tournamentCode),
                        string.Format("includeTimeline={0}", includeTimeline)
                    });

            var matchDetail = JsonConvert.DeserializeObject<MatchDetail>(json);

            return matchDetail;
        }

        /// <summary>
        ///     Retrieve match by match ID and tournament code.
        /// </summary>
        /// <param name="region">The region of the match.</param>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code of the match.</param>
        /// <param name="includeTimeline">Flag indicating whether or not to include match timeline data.</param>
        /// <returns>MatchDetail object.</returns>
        public async Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode,
            bool includeTimeline)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(
                        string.Format(MatchRootUrl, region) + string.Format(GetMatchDetailUrl, matchId), region,
                        new List<string>
                        {
                            string.Format("tournamentCode={0}", tournamentCode),
                            string.Format("includeTimeline={0}", includeTimeline)
                        });

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchDetail>(json));
        }

        /// <summary>
        ///     Retrieve match IDs by tournament code.
        /// </summary>
        /// <param name="region">The region of the match.</param>
        /// <param name="tournamentCode">The tournament code of the match.</param>
        /// <returns>The match id of the match played with the tournament code entered.</returns>
        public long GetTournamentMatchId(Region region, string tournamentCode)
        {
            var json =
                requester.CreateGetRequest(
                    string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode), region);

            var matchIds = JsonConvert.DeserializeObject<List<long>>(json);

            return matchIds.FirstOrDefault();
        }

        /// <summary>
        ///     Retrieve match IDs by tournament code.
        /// </summary>
        /// <param name="region">The region of the match.</param>
        /// <param name="tournamentCode">The tournament code of the match.</param>
        /// <returns>The match id of the match played with the tournament code entered.</returns>
        public async Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(
                        string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode), region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<long>>(json).FirstOrDefault());
        }

        /// <summary>
        ///     Update the pick type, map, spectator type, or allowed summoners for a code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update</param>
        /// <param name="allowedSummonerIds">List of summoner id's.</param>
        /// <param name="spectatorType">The spectator type.</param>
        /// <param name="pickType">The pick type.</param>
        /// <param name="mapType">The map type.</param>
        /// <returns>Success value.</returns>
        public bool UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            var body = BuildTournamentUpdateBody(allowedSummonerIds, spectatorType, pickType, mapType);

            return requester.CreatePutRequest(TournamentRootUrl + string.Format(PutCodeUrl, tournamentCode), Region.global,
                JsonConvert.SerializeObject(body));
        }

        /// <summary>
        ///     Update the pick type, map, spectator type, or allowed summoners for a code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update</param>
        /// <param name="allowedSummonerIds">List of summoner id's.</param>
        /// <param name="spectatorType">The spectator type.</param>
        /// <param name="pickType">The pick type.</param>
        /// <param name="mapType">The map type.</param>
        /// /// <returns>Success value.</returns>
        public async Task<bool> UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            var body = BuildTournamentUpdateBody(allowedSummonerIds, spectatorType, pickType, mapType);

            return await requester.CreatePutRequestAsync(TournamentRootUrl + string.Format(PutCodeUrl, tournamentCode),
                Region.global, JsonConvert.SerializeObject(body));
        }

        private Dictionary<string, object> BuildTournamentUpdateBody(List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            var body = new Dictionary<string, object>();
            if (allowedSummonerIds != null)
                body.Add("allowedSummonerIds", string.Join(",", allowedSummonerIds));
            if (spectatorType != null)
                body.Add("spectatorType", spectatorType);
            if (pickType != null)
                body.Add("pickType", pickType);
            if (mapType != null)
                body.Add("mapType", mapType);

            return body;
        }
    }
}
