using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Implementation of the <see cref="ISpectatorEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.ISpectatorEndpoint" />
    public class SpectatorEndpoint : ISpectatorEndpoint
    {
        private const string SpectatorRootUrl = "/lol/spectator/v4";
        private const string CurrentGameUrl = "/active-games/by-summoner/{0}";
        private const string FeaturedGamesUrl = "/featured-games";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpectatorEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public SpectatorEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<CurrentGame> GetCurrentGameAsync(Region region, string summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CurrentGame>(json);
        }

        /// <inheritdoc />
        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(SpectatorRootUrl + FeaturedGamesUrl, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<FeaturedGames>(json);
        }
    }
}
