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
            var json = requester.CreateRequest(TournamentRootUrl + CreateProviderUrl, Region.global);

            // json is an int directly
            var obj = new TournamentProvider { Id = int.Parse(json) };

            return obj;
        }

        public Task<TournamentProvider> CreateProviderAsync(Region region, string url)
        {
            throw new NotImplementedException();
        }

        public Tournament CreateTournament(int providerId, string name)
        {
            var body = new Dictionary<string, object> { { "name", name }, { "providerId", providerId } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateTournamentUrl, Region.global, JsonConvert.SerializeObject(body));

            // json is an int directly
            var obj = new Tournament { Id = int.Parse(json) };

            return obj;
        }

        public Task<Tournament> CreateTournamentAsync(int providerId, string name)
        {
            throw new NotImplementedException();
        }

        public string CreateTournamentCode(int tournamentId, int teamSize, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData)
        {
            var body = new Dictionary<string, object> { { "teamSize", teamSize }, { "allowedSummonerIds", allowedSummonerIds },{ "spectatorType", spectatorType }, { "pickType", pickType }, { "mapType", mapType }, { "metadata", metaData } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateCodeUrl, Region.global, JsonConvert.SerializeObject(body), new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", 1) });

            // json is a list of strings
            var obj = JsonConvert.DeserializeObject<List<string>>(json);

            return obj[0];
        }

        public Task<string> CreateTournamentCodeAsync(int tournamentId, int teamSize, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData)
        {
            throw new NotImplementedException();
        }

        public List<string> CreateTournamentCodes(int tournamentId, int teamSize, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData, int count = 1)
        {
            var body = new Dictionary<string, object> { { "teamSize", teamSize }, { "spectatorType", spectatorType }, { "pickType", pickType }, { "mapType", mapType }, { "metadata", metaData } };
            var json = requester.CreatePostRequest(TournamentRootUrl + CreateCodeUrl, Region.global, JsonConvert.SerializeObject(body), new List<string> { string.Format("tournamentId={0}", tournamentId), string.Format("count={0}", count) });

            // json is a list of strings
            var obj = JsonConvert.DeserializeObject<List<string>>(json);

            return obj;
        }

        public Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int teamSize, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData, int count = 1)
        {
            throw new NotImplementedException();
        }

        public TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode)
        {
            var json = requester.CreateRequest(TournamentRootUrl + string.Format(GetCodeUrl, tournamentCode), Region.global);
            var obj = JsonConvert.DeserializeObject<TournamentCodeDetail>(json);

            return obj;
        }

        public Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode)
        {
            throw new NotImplementedException();
        }

        public List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode)
        {
            var json = requester.CreateRequest(TournamentRootUrl + string.Format(LobbyEventUrl, tournamentCode), Region.global);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, List<TournamentLobbyEvent>>>(json);

            return obj["eventList"];
        }

        public Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode)
        {
            throw new NotImplementedException();
        }

        public MatchDetail GetTournamentMatch(Region region, long matchId, string tournamentCode, bool includeTimeline)
        {
            throw new NotImplementedException();
        }

        public Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode, bool includeTimeline)
        {
            throw new NotImplementedException();
        }

        public long GetTournamentMatchId(Region region, string tournamentCode)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType)
        {
            throw new NotImplementedException();
        }

        public void UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType)
        {
            throw new NotImplementedException();
        }
    }
}
