using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.MasteriesEndpoint
{
    public class MasteriesEndpoint : IMasteriesEndpoint
    {
        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string MasteriesUrl = "/masteries/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public MasteriesEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public async Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + string.Format(MasteriesUrl, summonerId),
                region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MasteryPages>(json).Pages;
        }
    }
}
