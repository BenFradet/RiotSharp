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
        private const string ChampionMasteryRootUrl = "/lol/champion-mastery/v3";
        private const string ChampionMasteriesBySummonerUrl = "/champion-masteries/by-summoner/{0}";
        private const string ChampionMasteryBySummonerUrl = "/champion-masteries/by-summoner/{0}/by-champion/{1}";
        private const string ChampionMasteryTotalScoreBySummonerUrl = "/scores/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public ChampionMasteryEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public ChampionMastery GetChampionMastery(Region region, long summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = _requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return JsonConvert.DeserializeObject<ChampionMastery>(json);
        }

        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, long summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ChampionMastery>(json));
        }

        public List<ChampionMastery> GetChampionMasteries(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = _requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return JsonConvert.DeserializeObject<List<ChampionMastery>>(json);
        }

        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ChampionMastery>>(json)));
        }

        public int GetTotalChampionMasteryScore(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = _requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return JsonConvert.DeserializeObject<int>(json);
        }

        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, long summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = _requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<int>(json));
        }
    }
}
