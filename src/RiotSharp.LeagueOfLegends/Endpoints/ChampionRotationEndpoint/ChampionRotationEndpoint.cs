using System;
using System.Text.Json;
using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChampionRotationEndpoint
{
    /// <summary>
    /// Implementation of the IChampionEndpoint interface.
    /// </summary>
    /// <seealso cref="IChampionRotationEndpoint" />
    public class ChampionRotationEndpoint : RateLimitedEndpointBase, IChampionRotationEndpoint
    {
        private const string Url = "/lol/platform/v3/champion-rotations";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionRotationEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The rate limited requester.</param>
        public ChampionRotationEndpoint(IRateLimitedRequester requester) : base(requester)
        { }

        /// <inheritdoc />
        public async Task<ChampionRotation?> GetChampionRotationAsync(Region region)
        {
	        return await GetContentAsync<ChampionRotation>(region, Url).ConfigureAwait(false);
        }
    }
}
