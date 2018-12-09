using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ChampionMasteryEndpoint
{
    class ChampionMasteryEndpoint : IChampionMasteryEndpoint
    {
        private const string ChampionMasteryRootUrl = "/lol/champion-mastery/v4";
        private const string ChampionMasteriesBySummonerUrl = "/champion-masteries/by-summoner/{0}";
        private const string ChampionMasteryBySummonerUrl = "/champion-masteries/by-summoner/{0}/by-champion/{1}";
        private const string ChampionMasteryTotalScoreBySummonerUrl = "/scores/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public ChampionMasteryEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, string summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChampionMastery>(json);
        }

        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, string summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<ChampionMastery>>(json);
        }

        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, string summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<int>(json);
        }
    }
}
