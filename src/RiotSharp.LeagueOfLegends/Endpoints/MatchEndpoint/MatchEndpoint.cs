using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint.Models;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint
{
    public class MatchEndpoint : RateLimitedEndpointBase, IMatchEndpoint
    {
        private const string MatchRootUrl = "/lol/match/v5/matches";
        private const string MatchListUrl = MatchRootUrl + "/by-puuid/{0}/ids";
        private const string MatchReplaysUrl = MatchRootUrl + "/by-puuid/{0}/replays";
        private const string MatchSpecificUrl = MatchRootUrl + "/{0}";
        private const string MatchTimelineUrl = MatchRootUrl + "/{0}/timeline";

        public MatchEndpoint(IRateLimitedRequester requester) : base(requester)
        {
        }

        public async Task<List<string>?> GetMatchListAsync(Region region, string puuid, MatchListRequestParameters? queryParams)
        {
            var requestUrl = string.Format(MatchListUrl, puuid);
            var queryParameters = queryParams?.ToQueryParameters() ?? new List<string>();
            return await GetContentAsync<List<string>>(region, requestUrl, queryParameters).ConfigureAwait(false);
        }

        public async Task<Replay?> GetReplaysByPuuidAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(MatchReplaysUrl, puuid);

            return await GetContentAsync<Replay>(region, requestUrl).ConfigureAwait(false);
        }

        public async Task<Match?> GetMatchAsync(Region region, string matchId)
        {
            var requestUrl = string.Format(MatchSpecificUrl, matchId);

            return await GetContentAsync<Match>(region, requestUrl).ConfigureAwait(false);
        }

        /// <summary>
        /// Please note that the documentation is very bad and is missing a lot of information about the match-v5 endpoint.
        /// So there are properties missing...
        /// </summary>
        /// <param name="region"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<MatchTimeline?> GetMatchTimelineAsync(Region region, string matchId)
        {
            var requestUrl = string.Format(MatchTimelineUrl, matchId);

            return await GetContentAsync<MatchTimeline>(region, requestUrl).ConfigureAwait(false);
        }

    }
}