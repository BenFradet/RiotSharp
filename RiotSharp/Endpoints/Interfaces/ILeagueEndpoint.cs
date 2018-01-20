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
        /// Retrieves the league positions for the specified summoner asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for the league positions of the summoner.</param>
        /// <param name="summonerId">The summoner id.</param>
        /// <returns><see cref="LeaguePosition" /> of the summoner in the leagues.</returns>
        Task<List<LeaguePosition>> GetLeaguePositionsAsync(Region region, long summonerId);

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
    }
}
