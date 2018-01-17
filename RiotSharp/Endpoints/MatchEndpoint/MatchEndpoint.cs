using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        private const string MatchListByAccountIdRecentUrl = "/by-account/{0}/recent";
        private const string TimelineByMatchIdUrl = "/by-match/{0}";

        private readonly IRateLimitedRequester _requester;

        public MatchEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public List<long> GetMatchIdsByTournamentCode(Region region, string tournamentCode)
        {
            var json = _requester.CreateGetRequest(MatchRootUrl +
                                                  string.Format(MatchIdsByTournamentCodeUrl, tournamentCode), region);

            return JsonConvert.DeserializeObject<List<long>>(json);
        }

        public async Task<List<long>> GetMatchIdsByTournamentCodeAsync(Region region, string tournamentCode)
        {
            var json = await _requester.CreateGetRequestAsync(MatchRootUrl +
                                                             string.Format(MatchIdsByTournamentCodeUrl, tournamentCode),
                region);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<long>>(json));
        }

        public Match GetMatch(Region region, long matchId)
        {
            var json = _requester.CreateGetRequest(MatchRootUrl +
                                                  string.Format(MatchByIdUrl, matchId), region);
            return JsonConvert.DeserializeObject<Match>(json);
        }

        public async Task<Match> GetMatchAsync(Region region, long matchId)
        {
            var json = _requester.CreateGetRequest(MatchRootUrl +
                                                  string.Format(MatchByIdUrl, matchId), region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Match>(json));
        }

        public MatchList GetMatchList(Region region, long accountId, List<int> championIds = null, List<int> queues = null, List<Season> seasons = null,
            DateTime? beginTime = null, DateTime? endTime = null, long? beginIndex = null, long? endIndex = null)
        {
            var addedArguments = CreateArgumentsListForMatchListRequest(championIds, queues, seasons, beginTime,
                endTime, beginIndex, endIndex);

            var json = _requester.CreateGetRequest(MatchListRootUrl + string.Format(MatchListByAccountIdUrl, accountId),
                region, addedArguments);
            return JsonConvert.DeserializeObject<MatchList>(json);
        }

        public async Task<MatchList> GetMatchListAsync(Region region, long accountId, List<int> championIds = null, List<int> queues = null, List<Season> seasons = null,
            DateTime? beginTime = null, DateTime? endTime = null, long? beginIndex = null, long? endIndex = null)
        {
            var addedArguments = CreateArgumentsListForMatchListRequest(championIds, queues, seasons, beginTime,
                endTime, beginIndex, endIndex);

            var json = _requester.CreateGetRequest(MatchListRootUrl + string.Format(MatchListByAccountIdUrl, accountId),
                region, addedArguments);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchList>(json));
        }

        public List<MatchReference> GetRecentMatches(Region region, long summonerId)
        {
            var json = _requester.CreateGetRequest(
                MatchListRootUrl + string.Format(MatchListByAccountIdRecentUrl, summonerId),
                region);
            return JsonConvert.DeserializeObject<MatchList>(json).Matches;
        }

        public async Task<List<MatchReference>> GetRecentMatchesAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(
                MatchListRootUrl + string.Format(MatchListByAccountIdRecentUrl, summonerId),
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MatchList>(json))).Matches;
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
