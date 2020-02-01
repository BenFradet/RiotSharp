using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.MatchEndpoint;
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
    /// Implementation of <see cref="ITFTMatchEndpoint"/>
    /// </summary>
    public class TFTMatchEndpoint : ITFTMatchEndpoint
    {
        private const string TftMatchRootUrl = "/tft/match/v1";
        private const string TftMatchesByPuuidUrl = "/matches/by-puuid/{0}/ids";
        private const string TftMatchByMatchIdUrl = "/matches/{0}";
        private const string MatchCache = "match-{0}_{1}";
        private const string MatchTimeLineCacheKey = "match-timeline-{0}_{1}";
        private static readonly TimeSpan MatchTtl = TimeSpan.FromDays(60);

        private readonly IRateLimitedRequester _requester;
        private readonly ICache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="TFTMatchEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public TFTMatchEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task<Match> GetTftMatchByMatchIdAsync(Region region, string matchId)
        {
            var matchInCache = _cache.Get<string, Match>(string.Format(MatchCache, region, matchId));
            if (matchInCache != null)
            {
                return matchInCache;
            }
            var json = await _requester.CreateGetRequestAsync(TftMatchRootUrl + string.Format(TftMatchByMatchIdUrl, matchId),
                region).ConfigureAwait(false);
            var match = JsonConvert.DeserializeObject<Match>(json);
            _cache.Add(string.Format(MatchCache, region, matchId), match, MatchTtl);
            return match;
        }

        /// <inheritdoc />
        public async Task<List<string>> GetTftMatchListByPuuidAsync(Region region, string puuid)
        {
            var json = await _requester.CreateGetRequestAsync(TftMatchRootUrl + string.Format(TftMatchesByPuuidUrl, puuid),
                region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}
