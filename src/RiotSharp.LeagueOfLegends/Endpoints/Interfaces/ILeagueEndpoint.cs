using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Models;

namespace RiotSharp.LeagueOfLegends.Endpoints.Interfaces
{
    /// <summary>
    /// The League Endpoint.
    /// </summary>
    public interface ILeagueEndpoint
    {
        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league. (Supported: <see cref="Queue.RankedSolo5x5"/>, <see cref="Queue.RankedFlexSR"/>, <see cref="Queue.RankedFlexTT"/>)</param>
        /// <returns>A <see cref="LeagueList" /> which contains all the challengers for this specific region and queue.</returns>
        Task<LeagueList?> GetChallengerLeagueAsync(Region region, Queue queue);
        
        /// <summary>
        /// Get the grandmaster league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="rankedQueue">A ranked queue (Supported: <see cref="Queue.RankedSolo5x5"/>, <see cref="Queue.RankedFlexSR"/>, <see cref="Queue.RankedFlexTT"/>)</param>
        /// <returns>A <see cref="LeagueList" /> which contains all the grandmasters for this specific region and queue.</returns>
        Task<LeagueList?> GetLeagueGrandmastersByQueueAsync(Region region, Queue rankedQueue);

        /// <summary>
        /// Get the master league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a master league.</param>
        /// <param name="queue">Queue in which you wish to look for a master league.  (Supported: <see cref="Queue.RankedSolo5x5"/>, <see cref="Queue.RankedFlexSR"/>, <see cref="Queue.RankedFlexTT"/>)</param>
        /// <returns>A <see cref="LeagueList" /> which contains all the masters for this specific region and queue.</returns>
        Task<LeagueList?> GetMasterLeagueAsync(Region region, Queue queue);

		/// <summary>
		/// Used to retrieve a list of <see cref="LeagueEntry"/> for the given <paramref name="puuid"/>.
		/// </summary>
		/// <param name="region">The region</param>
		/// <param name="puuid">The puuid</param>
		/// <returns>List of matching <see cref="LeagueEntry"/>. Should technically be a Set</returns>
		Task<List<LeagueEntry>?> GetLeagueEntriesByPuuidAsync(Region region, string puuid);

        /// <summary>
        /// Used to retrieve a list of <see cref="LeagueEntry"/> for the given <paramref name="division"/>, <paramref name="tier"/> and <paramref name="rankedQueue"/>.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="division">The division</param>
        /// <param name="tier">The tier (<see cref="Tier.Iron"/> to <see cref="Tier.Diamond"/>)</param>
        /// <param name="rankedQueue">Ranked queue. (Supported: <see cref="Queue.RankedSolo5x5"/>, <see cref="Queue.RankedFlexSR"/>, <see cref="Queue.RankedFlexTT"/>)</param>
        /// <param name="pages">Number of pages to lookup. Default is 1.</param>
        /// <returns>List of matching <see cref="LeagueEntry"/>. Should technically be a Set</returns>
        Task<List<LeagueEntry>?> GetLeagueEntriesAsync(Region region, Division division, Tier tier, Queue rankedQueue, int pages = 1);

        /// <summary>
        /// Used to retrieve information about the provided <paramref name="leagueId"/>.
        /// <para/>
        /// Warning: Consistently looking up league ids that don't exist will result in a blacklist.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="leagueId">The league id</param>
        /// <returns>The <see cref="LeagueList" /> for this specific region and queue.</returns>
        Task<LeagueList?> GetLeagueByLeagueIdAsync(Region region, string leagueId);
    }
}
