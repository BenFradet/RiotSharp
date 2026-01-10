using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Models;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint
{
    public class ChallengesEndpoint : RateLimitedEndpointBase, IChallengesEndpoint
    {
        private const string ChallengesRootUrl = "/lol/challenges/v1";
        private const string ChallengesAllConfigurations = ChallengesRootUrl + "/challenges/config";
        private const string ChallengesAllPercentiles = ChallengesRootUrl + "/challenges/percentiles";
        private const string ChallengesSpecifigChallengeConfig = ChallengesRootUrl + "/challenges/{0}/config";
        private const string ChallengesSpecificChallengeLeaderboard = ChallengesRootUrl + "/challenges/{0}/leaderboards/by-level/{1}";
        private const string ChallengesSpecificChallengePercentile = ChallengesRootUrl + "/challenges/{0}/percentiles";
        private const string ChallengesPlayerInfo = ChallengesRootUrl + "/player-data/{puuid}";

        public ChallengesEndpoint(IRateLimitedRequester requester) : base(requester)
        {
        }

        public async Task<List<ChallengeConfigInfo>?> GetChallengeConfigInfoAsync(Region region)
        {
            return await GetContentAsync<List<ChallengeConfigInfo>>(region, ChallengesAllConfigurations).ConfigureAwait(false);
        }

        public async Task<Dictionary<long, Dictionary<Level, double>>?> GetChallengesPercentilesAsync(Region region)
        {
            return await GetContentAsync<Dictionary<long, Dictionary<Level, double>>>(region, ChallengesAllPercentiles).ConfigureAwait(false);
        }

        public async Task<ChallengeConfigInfo?> GetChallengeConfigByIdAsync(Region region, long challengeId)
        {
            var requestUrl = string.Format(ChallengesSpecifigChallengeConfig, challengeId);

            return await GetContentAsync<ChallengeConfigInfo>(region, requestUrl).ConfigureAwait(false);
        }

        public async Task<List<ApexPlayerInfo>?> GetChallengeLeaderboardAsync(Region region, long challengeId, Level level, int limit = 10)
        {
            var requestUrl = string.Format(ChallengesSpecificChallengeLeaderboard, challengeId, level.ToCustomString());
            var queryParameters = new List<string> { $"limit={limit}" };
            return await GetContentAsync<List<ApexPlayerInfo>>(region, requestUrl, queryParameters).ConfigureAwait(false);
        }

        public async Task<Dictionary<Level, double>?> GetChallengePercentiles(Region region, long challengeId)
        {
            var requestUrl = string.Format(ChallengesSpecificChallengePercentile, challengeId);

            return await GetContentAsync<Dictionary<Level, double>>(region, requestUrl).ConfigureAwait(false);
        }

        public async Task<PlayerInfo?> GetChallengePlayerInfoAsync(Region region, string puuid)
        {
            var requestUrl = ChallengesPlayerInfo.Replace("{puuid}", puuid);

            return await GetContentAsync<PlayerInfo>(region, requestUrl).ConfigureAwait(false);
        }
    }
}
