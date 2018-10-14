using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ChampionRotationEndpoint
{
    /// <summary>
    /// Implementation of the IChampionRotationEndpoint interface.
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.IChampionRotationEndpoint" />
    public class ChampionRotationEndpoint : IChampionRotationEndpoint
    {
        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string ChampionsUrl = "/champion-rotations";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionRotationEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public ChampionRotationEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<ChampionRotation> GetChampionRotationAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + ChampionsUrl, region
                ).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChampionRotation>(json);
        }
    }
}
