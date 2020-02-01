using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.LoREndpoint.Interfaces
{
    /// <summary>
    /// The LoR Ranked Leaderboards endpoint
    /// </summary>
    public interface ILoRRankedEndpoint
    {
        /// <summary>
        /// Get the leaderboards list from Legends of Runnetera asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a challenger league.</param>
        /// <returns>A <see cref="LoRLeaderboard" /> which contains top players for this specific region</returns>
        Task<LoRLeaderboard> GetLoRRankedLeaderboardsAsync(Region region);

    }
}
