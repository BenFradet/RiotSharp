using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints
{
    public class MasteriesEndpointImp : IMasteriesEndpoint
    {
        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string MasteriesUrl = "/masteries/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public MasteriesEndpointImp(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public List<MasteryPage> GetMasteryPages(Region region, long summonerId)
        {
            var json = _requester.CreateGetRequest(PlatformRootUrl + string.Format(MasteriesUrl, summonerId), region);

            var masteries = JsonConvert.DeserializeObject<MasteryPages>(json);
            return masteries.Pages;
        }

        public async Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + string.Format(MasteriesUrl, summonerId),
                region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MasteryPages>(json).Pages);
        }
    }
}
