using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.SpectatorEndpoint
{
    public class SpectatorEndpoint : ISpectatorEndpoint
    {
        private const string SpectatorRootUrl = "/lol/spectator/v3";
        private const string CurrentGameUrl = "/active-games/by-summoner/{0}";
        private const string FeaturedGamesUrl = "/featured-games";

        private readonly IRateLimitedRequester _requester;

        public SpectatorEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public async Task<CurrentGame> GetCurrentGameAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                SpectatorRootUrl + string.Format(CurrentGameUrl, summonerId), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CurrentGame>(json);
        }

        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(SpectatorRootUrl + FeaturedGamesUrl, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<FeaturedGames>(json);
        }
    }
}
