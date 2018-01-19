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
            var response =  _requester
                .CreateGetRequest(ThirdPartyRootUrl + string.Format(ThirdPartyBySummonerUrl, summonerId), region);
            return response.Substring(1, response.Length - 2);
        }

        public async Task<string> GetThirdPartyCodeBySummonerIdAsync(Region region, long summonerId)
        {
            var response = await _requester
                .CreateGetRequestAsync(string.Format(ThirdPartyRootUrl + ThirdPartyBySummonerUrl, summonerId), region)
                .ConfigureAwait(false);
            return response.Substring(1, response.Length - 2);
        }
    }
}
