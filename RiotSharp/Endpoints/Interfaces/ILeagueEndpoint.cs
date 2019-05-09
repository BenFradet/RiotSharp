using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The League Endpoint.
    /// </summary>
    public interface ILeagueEndpoint
    {
        /// <summary>
        /// Get all the league entries.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for the league entries of the league.</param>
        /// <param name="queue">The queue name e.g. "RANKED_SOLO_5x5"</param>
        /// <param name="division">The division number e.g. 'IV'</param>
        /// <param name="tier">The tier name e.g. "DIAMOND"</param>
        /// <returns><see cref="LeaguePosition" /> of the summoner in the leagues.</returns>
        Task<List<LeaguePosition>> GetLeagueEntriesAsync(Region region, string queue, string tier, string division);

        /// <summary>
        /// Get league entries in all queues for a given summoner ID.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for the league entries of the summoner.</param>
        /// <param name="summonerId">The summoner id.</param>
        /// <returns><see cref="LeaguePosition" /> of the summoner in the leagues.</returns>
        Task<List<LeaguePosition>> GetLeagueEntriesBySummonerIdAsync(Region region, string summonerId);

        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league.</param>
        /// <returns>A <see cref="League" /> which contains all the challengers for this specific region and queue.</returns>
        Task<League> GetChallengerLeagueAsync(Region region, string queue);

        /// <summary>
        /// Get the master league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a master league.</param>
        /// <param name="queue">Queue in which you wish to look for a master league.</param>
        /// <returns>A <see cref="League" /> which contains all the masters for this specific region and queue.</returns>
        Task<League> GetMasterLeagueAsync(Region region, string queue);

        /// <summary>
        /// Get the grandmaster league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a grand master league.</param>
        /// <param name="queue">Queue in which you wish to look for a grand master league.</param>
        /// <returns>A <see cref="League" /> which contains all the grand masters for this specific region and queue.</returns>
        Task<League> GetGrandMasterLeagueAsync(Region region, string queue);
    }
}
