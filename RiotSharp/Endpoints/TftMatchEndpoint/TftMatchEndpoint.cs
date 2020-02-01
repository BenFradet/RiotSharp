using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.TftMatchEndpoint;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.TftMatchEndpoint
{
    public class TftMatchEndpoint : ITftMatchEndpoint
    {
        private const string TftMatchRootUrl = "/tft/match/v1/matches";
        private const string TftMatchByPuuidUrl = "/by-puuid/{0}ids?count={1}";
        private const string TftMatchCache = "tft-match-{0}_{1}";
        private const string TftMatchByIdUrl = "/{0}";
        private static readonly TimeSpan TftMatchTtl = TimeSpan.FromDays(60);

        private readonly ICache _cache;
        private readonly IRateLimitedRequester _requester;

        public TftMatchEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task<List<string>> GetTftMatchIdsByPuuidAsync(Region region, string puuid, int count = 20)
        {
            var json = await _requester.CreateGetRequestAsync(
                string.Format(TftMatchRootUrl + TftMatchByPuuidUrl, puuid, count), region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        /// <inheritdoc />
        public async Task<TftMatch> GetTftMatchByIdAsync(Region region, string matchId)
        {
            var cacheKey = string.Format(TftMatchCache, region, matchId);
            var match = _cache.Get<string, TftMatch>(cacheKey);

            if (match != null)
            {
                return match;
            }

            var json = await _requester.CreateGetRequestAsync(
                string.Format(TftMatchRootUrl + TftMatchByIdUrl, matchId), region).ConfigureAwait(false);

            match = JsonConvert.DeserializeObject<TftMatch>(json);

            if (match != null)
            {
                _cache.Add(cacheKey, match, TftMatchTtl);
            }

            return match;

        }
    }
}
