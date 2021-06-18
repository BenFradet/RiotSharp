using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Match Endpoint.
    /// </summary>
    public interface IMatchEndpoint
    {
        /// <summary>
        /// Get match information about a specific match asynchronously.
        /// </summary>
        /// <param name="region">Region in which the match took place. (Europe, Asia, America)</param>
        /// <param name="matchId">The match ID to be retrieved.</param>
        /// <returns>A match object containing information about the match.</returns>
        Task<Match> GetMatchAsync(Region region, string matchId);

        /// <summary>
        /// Get the list of matches of a specific summoner asynchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="puuidId">PuuID for which you want to retrieve the match list.</param>
        /// <param name="start">The begin index to use for fetching matches.</param>
        /// <param name="count">The amount of matches to fetch.</param>
        /// <returns>A list of MatchIds.</returns>
        Task<List<string>> GetMatchListAsync(Region region, string puuidId,
            long? start = null,
            long? count = null);

        /// <summary>
        /// Get match timeline by match ID asynchronously. 
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="matchId">The match ID of the timeline to be retrieved.</param>
        Task<MatchTimeline> GetMatchTimelineAsync(Region region, string matchId);
    }
}
