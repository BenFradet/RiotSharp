using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// Implementation of <see cref="ILeagueEndpoint"/>
    /// </summary>
    public class LeagueEndpoint : ILeagueEndpoint
    {
        private const string LeagueRootUrl = "/lol/league/v4";
        private const string LeagueChallengerUrl = "/challengerleagues/by-queue/{0}";
        private const string LeagueMasterUrl = "/masterleagues/by-queue/{0}";
        private const string LeaguePositionBySummonerUrl = "/positions/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public LeagueEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<List<LeaguePosition>> GetLeaguePositionsAsync(Region region, string summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeaguePositionBySummonerUrl, summonerId), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<LeaguePosition>>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetChallengerLeagueAsync(Region region, string queue)
        {
            var json = await _requester.CreateGetRequestAsync(LeagueRootUrl + string.Format(LeagueChallengerUrl, queue),
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetMasterLeagueAsync(Region region, string queue)
        {
            var json = await _requester.CreateGetRequestAsync(LeagueRootUrl + string.Format(LeagueMasterUrl, queue),
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<League>(json);
        }
    }
}
