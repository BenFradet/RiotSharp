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
    class MatchEndpoint : IMatchEndpoint
    {
        private const string MatchRootUrl = "/lol/match/v3/matches";
        private const string MatchListRootUrl = "/lol/match/v3/matchlists";
        private const string TimelinesRootUrl = "/lol/match/v3/timelines";
        private const string MatchIdsByTournamentCodeUrl = "/by-tournament-code/{0}/ids";
        private const string MatchByIdUrl = "/{0}";
        private const string MatchByIdAndTournamentCodeUrl = "/{0}/by-tournament-code/{1}";
        private const string MatchListByAccountIdUrl = "/by-account/{0}";
        private const string TimelineByMatchIdUrl = "/by-match/{0}";
        private const string MatchCache = "match-{0}_{1}";
        private const string MatchTimeLineCacheKey = "match-timeline-{0}_{1}";
        private static readonly TimeSpan MatchTtl = TimeSpan.FromDays(60);

        private readonly IRateLimitedRequester _requester;
        private readonly ICache _cache;

        public MatchEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        public async Task<List<long>> GetMatchIdsByTournamentCodeAsync(Region region, string tournamentCode)
        {
            var json = await _requester.CreateGetRequestAsync(MatchRootUrl +
                                                             string.Format(MatchIdsByTournamentCodeUrl, tournamentCode),
                region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<long>>(json);
        }

        public async Task<Match> GetMatchAsync(Region region, long matchId)
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

        public async Task<MatchList> GetMatchListAsync(Region region, long accountId, List<int> championIds = null, List<int> queues = null, List<Season> seasons = null,
            DateTime? beginTime = null, DateTime? endTime = null, long? beginIndex = null, long? endIndex = null)
        {
            var addedArguments = CreateArgumentsListForMatchListRequest(championIds, queues, seasons, beginTime,
                endTime, beginIndex, endIndex);

            var json = await _requester.CreateGetRequestAsync(MatchListRootUrl + string.Format(MatchListByAccountIdUrl, accountId),
                region, addedArguments).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MatchList>(json);
        }

        public async Task<MatchTimeline> GetMatchTimelineAsync(Region region, long matchId)
        {
            var cacheKey = string.Format(MatchTimeLineCacheKey, region, matchId);
            var matchTimeline = _cache.Get<string, MatchTimeline>(cacheKey);
            if (matchTimeline != null)
            {
                return matchTimeline;
            }
            var json = await _requester.CreateGetRequestAsync(TimelinesRootUrl +
                                                  string.Format(TimelineByMatchIdUrl, matchId), region).ConfigureAwait(false);
            matchTimeline = JsonConvert.DeserializeObject<MatchTimeline>(json);
            _cache.Add(cacheKey, matchTimeline, MatchTtl);
            return matchTimeline;
        }

        #region Helper

        private List<string> CreateArgumentsListForMatchListRequest(
            List<int> championIds = null,
            List<int> queues = null,
            List<Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null)
        {
            var addedArguments = new List<string>();
            if (beginIndex != null)
            {
                addedArguments.Add($"beginIndex={beginIndex}");
            }
            if (endIndex != null)
            {
                addedArguments.Add($"endIndex={endIndex}");
            }
            if (beginTime != null)
            {
                addedArguments.Add($"beginTime={beginTime.Value.ToLong()}");
            }
            if (endTime != null)
            {
                addedArguments.Add($"endTime={endTime.Value.ToLong()}");
            }
            if (championIds != null)
            {
                foreach (var championId in championIds)
                {
                    addedArguments.Add($"champion={championId}");
                }
            }
            if (queues != null)
            {
                foreach (var queue in queues)
                {
                    addedArguments.Add($"queue={queue}");
                }
            }
            if (seasons != null)
            {
                foreach (var season in seasons)
                {
                    addedArguments.Add($"season={(int)season}");
                }
            }
            return addedArguments;
        }

        #endregion
    }
}
