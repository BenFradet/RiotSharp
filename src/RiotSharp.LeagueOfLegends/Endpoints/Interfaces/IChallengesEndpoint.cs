using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiotSharp.Core.Misc;
using System.Threading.Tasks;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.Interfaces
{
    public interface IChallengesEndpoint
    {
        Task<List<ChallengeConfigInfo>?> GetChallengeConfigInfoAsync(Region region);

        // The api is wrong here, it returns Map[Long, Map[Level, Double]] and not the documented Map[Long, Map[Integer, Map[Level, Double]]]
        Task<Dictionary<long, Dictionary<Level, double>>?> GetChallengesPercentilesAsync(Region region);

        Task<ChallengeConfigInfo?> GetChallengeConfigByIdAsync(Region region, long challengeId);

        Task<List<ApexPlayerInfo>?> GetChallengeLeaderboardAsync(Region region, long challengeId, Level level, int limit = 10);

        Task<Dictionary<Level, double>?> GetChallengePercentiles(Region region, long challengeId);

        Task<PlayerInfo?> GetChallengePlayerInfoAsync(Region region, string puuid);
    }
}
