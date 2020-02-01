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
        /// Get the matches' ID of the specified tournament asynchronously.
        /// </summary>
        /// <param name="region">Region in which the tournament took place.</param>
        /// <param name="tournamentCode">The tournament ID to be retrieved.</param>
        /// <returns>A list containing the matches' ID.</returns>
        Task<List<long>> GetMatchIdsByTournamentCodeAsync(Region region, string tournamentCode);

        /// <summary>
        /// Get match information about a specific match asynchronously.
        /// </summary>
        /// <param name="region">Region in which the match took place.</param>
        /// <param name="matchId">The match ID to be retrieved.</param>
        /// <returns>A match object containing information about the match.</returns>
        Task<Match> GetMatchAsync(Region region, long matchId);

        /// <summary>
        /// Get the list of matches of a specific summoner asynchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="accountId">Account ID for which you want to retrieve the match list.</param>
        /// <param name="championIds">List of champion IDS to use for fetching games.</param>
        /// <param name="queues">List of queue types to use for fetching games.</param>
        /// <param name="seasons">List of seasons for which to filter the match list by.</param>
        /// <param name="beginTime">The earliest date you wish to get matches from.</param>
        /// <param name="endTime">The latest date you wish to get matches from.</param>
        /// <param name="beginIndex">The begin index to use for fetching matches.</param>
        /// <param name="endIndex">The end index to use for fetching matches.</param>
        /// <returns>A list of Match references object.</returns>
        Task<MatchList> GetMatchListAsync(Region region, string accountId,
            List<int> championIds = null,
            List<int> queues = null,
            List<MatchEndpoint.Enums.Season> seasons = null,
            DateTime? beginTime = null,
            DateTime? endTime = null,
            long? beginIndex = null,
            long? endIndex = null);

        /// <summary>
        /// Get match timeline by match ID asynchronously. 
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="matchId">The match ID of the timeline to be retrieved.</param>
        Task<MatchTimeline> GetMatchTimelineAsync(Region region, long matchId);
    }
}
