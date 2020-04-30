using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.TftLeagueEndpoint
{
    public class TftLeagueEndpoint : ITftLeagueEndpoint
    {
        private const string TftLeagueRootUrl = "/tft/league/v1";
        private const string TftGrandmasterLeague = "/grandmaster";
        private const string TftChallengerLeague = "/challenger";
        private const string TftMasterLeague = "/master";
        private const string TftLeagueEntriesBySummoner = "/entries/by-summoner/{0}";
        private const string TftLeagueEntriesByTierDivision = "/{0}/{1}";
        private const string TftLeagueEntriesByLeagueId = "/leagues/{0}";
        private readonly IRateLimitedRequester _requester;

        public TftLeagueEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<TftLeague> GetTftGrandmasterLeagueAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(
                TftLeagueRootUrl + TftGrandmasterLeague, region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TftLeague>(json);
        }

        /// <inheritdoc />
        public async Task<TftLeague> GetTftChallengerLeagueAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(
                TftLeagueRootUrl + TftChallengerLeague, region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TftLeague>(json);
        }

        /// <inheritdoc />
        public async Task<TftLeague> GetTftMasterLeagueAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(
               TftLeagueRootUrl + TftMasterLeague, region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TftLeague>(json);
        }

        /// <inheritdoc />
        public async Task<List<TftLeagueEntry>> GetTftLeagueEntriesBySummonerAsync(Region region, string encryptedSummonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                TftLeagueRootUrl + string.Format(TftLeagueEntriesBySummoner, encryptedSummonerId), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<TftLeagueEntry>>(json);
        }

        /// <inheritdoc />
        public async Task<TftLeague> GetTftLeagueByIdAsync(Region region, string leagueId)
        {
            var json = await _requester.CreateGetRequestAsync(
                TftLeagueRootUrl + string.Format(TftLeagueEntriesByLeagueId, leagueId), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TftLeague>(json);
        }

        /// <inheritdoc />
        public async Task<List<TftLeagueEntry>> GetTftLeagueByTierDivisionAsync(Region region, LeagueEndpoint.Enums.Tier tier, 
            LeagueEndpoint.Enums.Division division)
        {
            var json = await _requester.CreateGetRequestAsync(
                string.Format(TftLeagueRootUrl + TftLeagueEntriesByTierDivision, tier, division), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<TftLeagueEntry>>(json);
        }
    }
}
