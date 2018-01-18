using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ChampionEndpoint
{
    public class ChampionEndpoint : IChampionEndpoint
    {
        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string ChampionsUrl = "/champions";
        private const string IdUrl = "/{0}";

        private readonly IRateLimitedRequester _requester;
        
        public ChampionEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public List<Champion> GetChampions(Region region, bool freeToPlay = false)
        {
            var json = _requester.CreateGetRequest(PlatformRootUrl + ChampionsUrl, region,
                new List<string> { $"freeToPlay={freeToPlay.ToString().ToLower()}" });
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }

        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + ChampionsUrl, region,
                new List<string> { $"freeToPlay={freeToPlay.ToString().ToLower()}" });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionList>(json))).Champions;
        }

        public Champion GetChampion(Region region, int championId)
        {
            var json = _requester.CreateGetRequest(
                PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId), region);
            return JsonConvert.DeserializeObject<Champion>(json);
        }

        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var json = await _requester.CreateGetRequestAsync(
                PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId), region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Champion>(json));
        }
    }
}
