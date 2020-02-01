using Newtonsoft.Json;
using RiotSharp.Endpoints.LoREndpoint.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.LoREndpoint
{
    /// <summary>
    /// Implementation of the <see cref="ILoRRankedEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.LoREndpoint.Interfaces.ILoRRankedEndpoint" />
    public class LoRRankedEndpoint : ILoRRankedEndpoint
    {
        private const string LeaderboardRootUrl = "/lor/ranked/v1";
        private const string LeaderboardListUrl = "/leaderboards";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoRRankedEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public LoRRankedEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<LoRLeaderboard> GetLoRRankedLeaderboardsAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(LeaderboardRootUrl + LeaderboardListUrl,
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LoRLeaderboard>(json);
        }
    }
}
