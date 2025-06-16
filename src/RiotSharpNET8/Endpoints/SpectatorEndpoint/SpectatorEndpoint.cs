using System.Text.Json;
using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Implementation of the <see cref="ISpectatorEndpoint"/>
    /// </summary>
    /// <seealso cref="ISpectatorEndpoint" />
    public class SpectatorEndpoint : ISpectatorEndpoint
    {
        private const string SpectatorRootUrl = "/lol/spectator/v5";
        private const string CurrentGameUrl = "/active-games/by-summoner/{0}";
        private const string FeaturedGamesUrl = "/featured-games";

        private readonly IRiotRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpectatorEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The riotRequester.</param>
        public SpectatorEndpoint(IRiotRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<CurrentGame> GetCurrentGameAsync(Region region, string summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId), region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<CurrentGame>(json); //JsonConvert.DeserializeObject<CurrentGame>(json);
        }

        /// <inheritdoc />
        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(SpectatorRootUrl + FeaturedGamesUrl, region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<FeaturedGames>(json); //JsonConvert.DeserializeObject<FeaturedGames>(json);
        }
    }
}
