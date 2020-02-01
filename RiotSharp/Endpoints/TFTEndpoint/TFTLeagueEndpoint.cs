using Newtonsoft.Json;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Endpoints.TFTEndpoint.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.TFTEndpoint
{
    /// <summary>
    /// Implementation of <see cref="ITFTLeagueEndpoint"/>
    /// </summary>
    public class TFTLeagueEndpoint : ITFTLeagueEndpoint
    {
        private const string TftLeagueRootUrl = "/tft/league/v1";
        private const string TftLeagueChallengerUrl = "/challenger";
        private const string TftLeagueMasterUrl = "/master";
        private const string TftLeagueEntriesBySummonerUrl = "/entries/by-summoner/{0}";
        private const string TftLeagueGrandmastersUrl = "/grandmaster";
        private const string TftLeagueEntriesByDivTierUrl = "/entries/{0}/{1}";
        private const string TftLeagueLeagueByIdUrl = "/leagues/{0}";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="TFTLeagueEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public TFTLeagueEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<League> GetTFTChallengerLeagueAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(TftLeagueRootUrl + TftLeagueChallengerUrl,
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetTFTGrandmasterLeagueAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(TftLeagueRootUrl + TftLeagueGrandmastersUrl,
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <inheritdoc />
        public async Task<List<LeagueEntry>> GetTFTLeagueEntriesBySummonerIdAsync(Region region, string encryptedSummonerId)
        {
            var json = await _requester.CreateGetRequestAsync(TftLeagueRootUrl + string.Format(TftLeagueEntriesBySummonerUrl, encryptedSummonerId),
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<LeagueEntry>>(json);
        }

        /// <inheritdoc />
        public async Task<List<LeagueEntry>> GetTFTLeagueEntriesByTierAndDivisionAsync(Region region, Tier tier, Division division, int page = 1)
        {
            var json = await _requester.CreateGetRequestAsync(TftLeagueRootUrl
                + string.Format(TftLeagueEntriesByDivTierUrl, tier.ToString().ToUpperInvariant(), division.ToString().ToUpperInvariant()),
                region,
                new List<string> { page.ToString() }).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<LeagueEntry>>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetTFTLeaguesByLeagueIdAsync(Region region, string leagueId)
        {
            var json = await _requester.CreateGetRequestAsync(TftLeagueRootUrl + string.Format(TftLeagueLeagueByIdUrl, leagueId),
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <inheritdoc />
        public async Task<League> GetTFTMasterLeagueAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(TftLeagueRootUrl + TftLeagueMasterUrl,
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<League>(json);
        }
    }
}
