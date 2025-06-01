using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.ThirdPartyEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IThirdPartyEndpoint"/>
    /// </summary>
    /// <seealso cref="IThirdPartyEndpoint" />
    public class ThirdPartyEndpoint : IThirdPartyEndpoint
    {
        private const string ThirdPartyRootUrl = "/lol/platform/v4/third-party-code";
        private const string ThirdPartyBySummonerUrl = "/by-summoner/{0}";

        private readonly IRiotRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdPartyEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The riotRequester.</param>
        public ThirdPartyEndpoint(IRiotRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<string> GetThirdPartyCodeBySummonerIdAsync(Region region, string summonerId)
        {
            var response = await _requester
                .CreateGetRequestAsync(string.Format(ThirdPartyRootUrl + ThirdPartyBySummonerUrl, summonerId), region)
                .ConfigureAwait(false);
            return response.Substring(1, response.Length - 2);
        }
    }
}
