using System.Threading.Tasks;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ThirdPartyEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IThirdPartyEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.IThirdPartyEndpoint" />
    public class ThirdPartyEndpoint : IThirdPartyEndpoint
    {
        private const string ThirdPartyRootUrl = "/lol/platform/v3/third-party-code";
        private const string ThirdPartyBySummonerUrl = "/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdPartyEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public ThirdPartyEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<string> GetThirdPartyCodeBySummonerIdAsync(Region region, long summonerId)
        {
            var response = await _requester
                .CreateGetRequestAsync(string.Format(ThirdPartyRootUrl + ThirdPartyBySummonerUrl, summonerId), region)
                .ConfigureAwait(false);
            return response.Substring(1, response.Length - 2);
        }
    }
}
