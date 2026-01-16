using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.Interfaces
{
    public interface IMatchEndpoint
    {
        Task<List<string>?> GetMatchListAsync(Region region, string puuid, MatchListRequestParameters? queryParams);
        Task<Replay?> GetReplaysByPuuidAsync(Region region, string puuid);
        Task<Match?> GetMatchAsync(Region region, string matchId);
        Task<MatchTimeline?> GetMatchTimelineAsync(Region region, string matchId);
    }
}