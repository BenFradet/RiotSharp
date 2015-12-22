using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.MatchEndpoint;
using RiotSharp.TournamentEndpoint;
using Newtonsoft.Json;

namespace RiotSharp
{
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

        private RateLimitedRequester requester;

        private static TournamentRiotApi instance;
        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static TournamentRiotApi GetInstance(string apiKey, int rateLimitPer10s = 10, int rateLimitPer10m = 500)
        {
            if (instance == null || 
                Requesters.TournamentRequester == null ||
                apiKey != Requesters.TournamentRequester.ApiKey ||
                rateLimitPer10s != Requesters.TournamentRequester.RateLimitPer10S ||
                rateLimitPer10m != Requesters.TournamentRequester.RateLimitPer10M)
            {
                instance = new TournamentRiotApi(apiKey, rateLimitPer10s, rateLimitPer10m);
            }
            return instance;
        }

        private TournamentRiotApi(string apiKey, int rateLimitPer10s, int rateLimitPer10m)
        {
            Requesters.TournamentRequester = new RateLimitedRequester(apiKey, rateLimitPer10s, rateLimitPer10m);
            requester = Requesters.TournamentRequester;
        }

        public TournamentProvider CreateProvider(Region region, string url)
        {
            var body = new Dictionary<string, object> { { "url", url }, { "region", region.ToString().ToUpper() } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateProviderUrl, Region.global, JsonConvert.SerializeObject(body));

            // json is an int directly
            var obj = new TournamentProvider { Id = int.Parse(json) };

            return obj;
        }

        public async Task<TournamentProvider> CreateProviderAsync(Region region, string url)
        {
            var body = new Dictionary<string, object> { { "url", url }, { "region", region.ToString().ToUpper() } };
            var json = await requester.CreatePostRequestAsync(TournamentRootUrl + CreateProviderUrl, Region.global, JsonConvert.SerializeObject(body));

            // json is an int directly
            var obj = new TournamentProvider { Id = int.Parse(json) };

            return await Task.Factory.StartNew(() => obj);
        }

        public Tournament CreateTournament(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateTournamentUrl, Region.global, JsonConvert.SerializeObject(body));

            // json is an int directly
            var obj = new Tournament { Id = int.Parse(json) };

            return obj;
        }

        public async Task<Tournament> CreateTournamentAsync(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json = await requester.CreatePostRequestAsync(TournamentRootUrl + CreateTournamentUrl, Region.global, JsonConvert.SerializeObject(body));

            // json is an int directly
            var obj = new Tournament { Id = int.Parse(json) };

            return await Task.Factory.StartNew(() => obj);
        }

        public string CreateTournamentCode(int tournamentId, int teamSize, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData)
        {
            var body = new Dictionary<string, object> { { "teamSize", teamSize }, { "allowedSummonerIds", allowedSummonerIds },{ "spectatorType", spectatorType }, { "pickType", pickType }, { "mapType", mapType }, { "metadata", metaData } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateCodeUrl, Region.global, JsonConvert.SerializeObject(body), new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", 1) });

            // json is a list of strings
            var obj = JsonConvert.DeserializeObject<List<string>>(json);

            return obj[0];
        }

        public async Task<string> CreateTournamentCodeAsync(int tournamentId, int teamSize, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData)
        {
            var body = new Dictionary<string, object> { { "teamSize", teamSize }, { "allowedSummonerIds", allowedSummonerIds }, { "spectatorType", spectatorType }, { "pickType", pickType }, { "mapType", mapType }, { "metadata", metaData } };
            var json = await requester.CreatePostRequestAsync(TournamentRootUrl + CreateCodeUrl, Region.global, JsonConvert.SerializeObject(body), new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", 1) });

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(json)[0]);
        }

        public List<string> CreateTournamentCodes(int tournamentId, int teamSize, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData, int count = 1)
        {
            var body = new Dictionary<string, object> { { "teamSize", teamSize }, { "spectatorType", spectatorType }, { "pickType", pickType }, { "mapType", mapType }, { "metadata", metaData } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateCodeUrl, Region.global, JsonConvert.SerializeObject(body), new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", count) });

            // json is a list of strings
            var obj = JsonConvert.DeserializeObject<List<string>>(json);

            return obj;
        }

        public async Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int teamSize, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData, int count = 1)
        {
            var body = new Dictionary<string, object> { { "teamSize", teamSize }, { "spectatorType", spectatorType }, { "pickType", pickType }, { "mapType", mapType }, { "metadata", metaData } };
            var json = await requester.CreatePostRequestAsync(TournamentRootUrl + CreateCodeUrl, Region.global, JsonConvert.SerializeObject(body), new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", count) });

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(json));
        }

        public TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode)
        {
            var json = requester.CreateRequest(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode), Region.global);
            var obj = JsonConvert.DeserializeObject<TournamentCodeDetail>(json);

            return obj;
        }

        public async Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode)
        {
            var json = await requester.CreateRequestAsync(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode), Region.global);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TournamentCodeDetail>(json));
        }

        public List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode)
        {
            var json = requester.CreateRequest(TournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode), Region.global);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json);

            return obj["eventList"];
        }

        public async Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode)
        {
            var json = await requester.CreateRequestAsync(TournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode), Region.global);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json)["eventList"]);
        }

        public MatchDetail GetTournamentMatch(Region region, long matchId, string tournamentCode, bool includeTimeline)
        {
            var json = requester.CreateRequest(TournamentRootUrl + string.Format(GetMatchDetailUrl, matchId), Region.global, new List<string> { string.Format("tournamentCode={0}", tournamentCode), string.Format("includeTimeline={0}", includeTimeline) });

            var obj = JsonConvert.DeserializeObject<MatchDetail>(json);

            return obj;
        }

        public async Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode, bool includeTimeline)
        {
            var json = await requester.CreateRequestAsync(TournamentRootUrl + string.Format(GetMatchDetailUrl, matchId), Region.global, new List<string> { string.Format("tournamentCode={0}", tournamentCode), string.Format("includeTimeline={0}", includeTimeline) });

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchDetail>(json));
        }

        public long GetTournamentMatchId(Region region, string tournamentCode)
        {
            var json = requester.CreateRequest(TournamentRootUrl + string.Format(GetMatchIdUrl, tournamentCode), Region.global);

            var obj = JsonConvert.DeserializeObject<List<long>>(json);

            return obj[0];
        }

        public async Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode)
        {
            var json = await requester.CreateRequestAsync(TournamentRootUrl + string.Format(GetMatchIdUrl, tournamentCode), Region.global);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<long>>(json)[0]);
        }

        public void UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds, TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
        {
            var body = BuildTournamentUpdateBody(allowedSummonerIds, spectatorType, pickType, mapType);

            requester.CreatePutRequest(TournamentRootUrl + string.Format(PutCodeUrl, tournamentCode), Region.global, JsonConvert.SerializeObject(body));
        }

        public async void UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType)
        {
            var body = BuildTournamentUpdateBody(allowedSummonerIds, spectatorType, pickType, mapType);

            await Task.Factory.StartNew(() => requester.CreatePutRequestAsync(TournamentRootUrl + string.Format(PutCodeUrl, tournamentCode), Region.global, JsonConvert.SerializeObject(body)));
        }

        private Dictionary<string, object> BuildTournamentUpdateBody(List<long> allowedSummonerIds, TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType)
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
