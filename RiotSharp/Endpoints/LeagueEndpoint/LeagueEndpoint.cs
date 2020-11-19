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
        private const string LeagueEntriesBySummoner = "/entries/by-summoner/{0}";
        private const string LeagueGrandmastersByQueue = "/grandmasterleagues/by-queue/{0}";
        private const string LeagueEntriesByDivTierQueue = "/entries/{0}/{1}/{2}";
        private const string LeagueLeagueById = "/leagues/{0}";

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

        /// <inheritdoc />
        public async Task<List<LeagueEntry>> GetLeagueEntriesBySummonerAsync(Region region, string encryptedSummonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeagueEntriesBySummoner, encryptedSummonerId), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<LeagueEntry>>(json);
        }

        /// <inheritdoc />
        public async Task<List<LeagueEntry>> GetLeagueEntriesAsync(Region region, Enums.Division division, Enums.Tier tier, string rankedQueue, int page = 1)
        {
            var json = await _requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeagueEntriesByDivTierQueue, rankedQueue, tier.ToString().ToUpperInvariant(), division),
                region,
                new List<string> { page.ToString() }).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<LeagueEntry>>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetLeagueGrandmastersByQueueAsync(Region region, string rankedQueue)
        {
            var json = await _requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeagueGrandmastersByQueue, rankedQueue), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetLeagueByIdAsync(Region region, string leagueId)
        {
            var json = await _requester.CreateGetRequestAsync(
                LeagueRootUrl + string.Format(LeagueLeagueById, leagueId), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<League>(json);
        }
    }
}
