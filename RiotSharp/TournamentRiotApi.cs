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
    public class TournamentRiotApi : ITournamentRiotApi
    {
        #region Private Fields

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

        #endregion

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
    
        public TournamentProvider CreateProvider(Region region, string url)
        {
            var body = new Dictionary<string, object> { { "url", url }, { "region", region.ToString().ToUpper() } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateProviderUrl, Region.global,
                JsonConvert.SerializeObject(body));

            // Json is an int directly
            var provider = new TournamentProvider { Id = int.Parse(json) };

            return provider;
        }
     
        public async Task<TournamentProvider> CreateProviderAsync(Region region, string url)
        {
            var body = new Dictionary<string, object> { { "url", url }, { "region", region.ToString().ToUpper() } };
            var json =
                await
                    requester.CreatePostRequestAsync(TournamentRootUrl + CreateProviderUrl, Region.global,
                        JsonConvert.SerializeObject(body));

            return new TournamentProvider { Id = int.Parse(json) };
        }
    
        public Tournament CreateTournament(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateTournamentUrl, Region.global,
                JsonConvert.SerializeObject(body));

            // Json is an int directly
            var tournament = new Tournament { Id = int.Parse(json) };

            return tournament;
        }
     
        public async Task<Tournament> CreateTournamentAsync(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json =
                await
                    requester.CreatePostRequestAsync(TournamentRootUrl + CreateTournamentUrl, Region.global,
                        JsonConvert.SerializeObject(body));

            return new Tournament { Id = int.Parse(json) };
        }
      
        public string CreateTournamentCode(int tournamentId, int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata)
        {
            ValidateTeamSize(teamSize);
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
       
        public async Task<string> CreateTournamentCodeAsync(int tournamentId, int teamSize,
            List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType,
            TournamentMapType mapType, string metadata)
        {
            ValidateTeamSize(teamSize);
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

        public List<string> CreateTournamentCodes(int tournamentId, int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1)
        {
            ValidateTeamSize(teamSize);
            ValidateTournamentCodeCount(count);
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

            // Json is a list of strings
            var tournamentCodes = JsonConvert.DeserializeObject<List<string>>(json);

            return tournamentCodes;
        }

        public async Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int teamSize,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata, int count = 1)
        {
            ValidateTeamSize(teamSize);
            ValidateTournamentCodeCount(count);
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

        public TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode)
        {
            var json = requester.CreateGetRequest(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode),
                Region.global);
            var tournamentCodeDetails = JsonConvert.DeserializeObject<TournamentCodeDetail>(json);

            return tournamentCodeDetails;
        }

        public async Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode),
                        Region.global);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TournamentCodeDetail>(json));
        }

        public List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode)
        {
            var json = requester.CreateGetRequest(TournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode),
                Region.global);
            var lobbyEventsDTO = JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json);

            return lobbyEventsDTO["eventList"];
        }

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
  
        public long GetTournamentMatchId(Region region, string tournamentCode)
        {
            var json =
                requester.CreateGetRequest(
                    string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode), region);

            var matchIds = JsonConvert.DeserializeObject<List<long>>(json);

            return matchIds.FirstOrDefault();
        }

        public async Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode)
        {
            var json =
                await
                    requester.CreateGetRequestAsync(
                        string.Format(MatchRootUrl, region) + string.Format(GetMatchIdUrl, tournamentCode), region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<long>>(json).FirstOrDefault());
        }

        public bool UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            var body = BuildTournamentUpdateBody(allowedSummonerIds, spectatorType, pickType, mapType);

            return requester.CreatePutRequest(TournamentRootUrl + string.Format(PutCodeUrl, tournamentCode), Region.global,
                JsonConvert.SerializeObject(body));
        }
       
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
    }
}
