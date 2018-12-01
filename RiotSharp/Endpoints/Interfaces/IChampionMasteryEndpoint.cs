using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ChampionMasteryEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Champion Mastery Endpoint.
    /// </summary>
    public interface IChampionMasteryEndpoint
    {
        /// <summary>
        /// Gets a champion mastery by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <param name="championId">ID of the champion for which to retrieve mastery.</param>
        /// <returns>Champion mastery for summoner ID and champion ID.</returns>
        Task<ChampionMastery> GetChampionMasteryAsync(Region region, string summonerId, long championId);

        /// <summary>
        /// Get all champion mastery entries sorted by number of champion points descending asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>All champions mastery entries for the specified summoner ID.</returns>
        Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, string summonerId);

        /// <summary>
        /// Get a player's total champion mastery score,
        /// which is the sum of individual champion mastery levels, by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>Total champion mastery score for summoner ID.</returns>
        Task<int> GetTotalChampionMasteryScoreAsync(Region region, string summonerId);
    }
}
