using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.LeagueEndpoint
{
    public class LeagueEndpoint : ILeagueEndpoint
    {
        private const string LeagueRootUrl = "/lol/league/v3";
        private const string LeagueChallengerUrl = "/challengerleagues/by-queue/{0}";
        private const string LeagueMasterUrl = "/masterleagues/by-queue/{0}";
        private const string LeaguePositionBySummonerUrl = "/positions/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public LeagueEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public List<LeaguePosition> GetLeaguePositions(Region region, long summonerId)
        {
            var json = _requester.CreateGetRequest(
                LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId),
                region);

            return JsonConvert.DeserializeObject<List<LeaguePosition>>(json);
        }

        public async Task<List<LeaguePosition>> GetLeaguePositionsAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId), region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<LeaguePosition>>(json));
        }

        public League GetChallengerLeague(Region region, string queue)
        {
            var json = _requester.CreateGetRequest(LeagueRootUrl + string.Format(LeagueChallengerUrl, queue), region);
            return JsonConvert.DeserializeObject<League>(json);
        }

        public async Task<League> GetChallengerLeagueAsync(Region region, string queue)
        {
            var json = await _requester.CreateGetRequestAsync(LeagueRootUrl + string.Format(LeagueChallengerUrl, queue),
                region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }

        public League GetMasterLeague(Region region, string queue)
        {
            var json = _requester.CreateGetRequest(LeagueRootUrl + string.Format(LeagueMasterUrl, queue), region);
            return JsonConvert.DeserializeObject<League>(json);
        }

        public async Task<League> GetMasterLeagueAsync(Region region, string queue)
        {
            var json = await _requester.CreateGetRequestAsync(LeagueRootUrl + string.Format(LeagueMasterUrl, queue),
                region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }
    }
}
