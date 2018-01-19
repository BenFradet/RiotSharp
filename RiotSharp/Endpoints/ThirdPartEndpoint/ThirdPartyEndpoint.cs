using System.Threading.Tasks;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ThirdPartEndpoint
{
    public class ThirdPartyEndpoint : IThirdPartEndpoint
    {
        private const string ThirdPartyRootUrl = "/lol/platform/v3/third-party-code";
        private const string ThirdPartyBySummonerUrl = "/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public ThirdPartyEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }


        public string GetThirdPartyCodeBySummonerId(Region region, long summonerId)
        {
            return _requester.CreateGetRequest(ThirdPartyRootUrl + 
                string.Format(ThirdPartyBySummonerUrl, summonerId),
                region);
        }

        public async Task<string> GetThirdPartyCodeBySummonerIdAsync(Region region, long summonerId)
        {
            return await _requester.CreateGetRequestAsync(
                string.Format(ThirdPartyRootUrl + ThirdPartyBySummonerUrl, summonerId),region);
        }
    }
}