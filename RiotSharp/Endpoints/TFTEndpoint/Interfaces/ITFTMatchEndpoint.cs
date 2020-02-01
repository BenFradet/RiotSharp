using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.TFTEndpoint.Interfaces
{
    /// <summary>
    /// The AMERICAS routing value serves NA, BR, LAN, LAS, and OCE. The ASIA routing value serves KR and JP. The EUROPE routing value serves EUNE, EUW, TR, and RU.
    /// </summary>
    public interface ITFTMatchEndpoint
    {
        /// <summary>
        /// Get the list of matches id of a specific summoner asynchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="puuid">Profile UUID for which you want to retrieve the match list.</param>
        /// <returns>A list of Match Ids references object.</returns>
        Task<List<string>> GetTftMatchListByPuuidAsync(Region region, string puuid);

        /// <summary>
        /// Get match information about a specific match asynchronously.
        /// </summary>
        /// <param name="region">Region in which the match took place.</param>
        /// <param name="matchId">The match ID to be retrieved.</param>
        /// <returns>A match object containing information about the match.</returns>
        Task<Match> GetTftMatchByMatchIdAsync(Region region, string matchId);
    }
}
