using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// The match endpoint
    /// </summary>
    public class MatchEndpoint : IMatchEndpoint
    {
        private const string MatchRootUrl = "/lol/match/v5/matches";
        private const string MatchByIdUrl = "/{0}";
        private const string MatchListByPuuIdUrl = "/by-puuid/{0}/ids";
        private const string TimelineByMatchIdUrl = "/{0}/timeline";
        private const string MatchCache = "match-{0}_{1}";
        private const string MatchTimeLineCacheKey = "match-timeline-{0}_{1}";
        private static readonly TimeSpan MatchTtl = TimeSpan.FromDays(60);

        private readonly IRateLimitedRequester _requester;
        private readonly ICache _cache;

        /// <summary>
        /// Creates a new match endpoint
        /// </summary>
        /// <param name="requester">the requester</param>
        /// <param name="cache">the cache</param>
        public MatchEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task<Match> GetMatchAsync(Region region, string matchId)
        {
            var matchInCache = _cache.Get<string, Match>(string.Format(MatchCache, region, matchId));
            if (matchInCache != null)
            {
                return matchInCache;
            }
            var json = await _requester.CreateGetRequestAsync(MatchRootUrl +
                                                  string.Format(MatchByIdUrl, matchId), region).ConfigureAwait(false);
            var match = JsonConvert.DeserializeObject<Match>(json);
            _cache.Add(string.Format(MatchCache, region, matchId), match, MatchTtl);
            return match;
        }

        /// <inheritdoc />
        public async Task<List<string>> GetMatchListAsync(Region region, string puuId,
            long? start = null, long? count = null, long? queue = null, Enums.MatchFilterType? type = null)
        {
            var addedArguments = CreateArgumentsListForMatchListRequest(start, count, queue, type);

            var json = await _requester.CreateGetRequestAsync(MatchRootUrl + string.Format(MatchListByPuuIdUrl, puuId),
                region, addedArguments).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        /// <inheritdoc />
        public async Task<MatchTimeline> GetMatchTimelineAsync(Region region, string matchId)
        {
            var cacheKey = string.Format(MatchTimeLineCacheKey, region, matchId);
            var matchTimeline = _cache.Get<string, MatchTimeline>(cacheKey);
            if (matchTimeline != null)
            {
                return matchTimeline;
            }
            var json = await _requester.CreateGetRequestAsync(MatchRootUrl +
                                                  string.Format(TimelineByMatchIdUrl, matchId), region).ConfigureAwait(false);
            matchTimeline = JsonConvert.DeserializeObject<MatchTimeline>(json);
            _cache.Add(cacheKey, matchTimeline, MatchTtl);
            return matchTimeline;
        }

        #region Helper

        private List<string> CreateArgumentsListForMatchListRequest(
            long? start = null,
            long? count = null,
            long? queue = null,
            Enums.MatchFilterType? type = null)
        {
            var addedArguments = new List<string>();
            if (start.HasValue)
            {
                addedArguments.Add($"start={start.Value}");
            }
            if (count.HasValue)
            {
                addedArguments.Add($"count={count.Value}");
            }
            if (queue.HasValue)
            {
                addedArguments.Add($"queue={queue.Value}");
            }
            if (type.HasValue)
            {
                addedArguments.Add($"type={type.Value.ToCostumString()}");
            }
            return addedArguments;
        }

        #endregion
    }
}
