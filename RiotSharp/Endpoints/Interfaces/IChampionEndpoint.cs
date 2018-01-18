using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Champion Endpoint.
    /// </summary>
    public interface IChampionEndpoint
    {
        /// <summary>
        /// Get the list of champions by region asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <param name="freeToPlay">If set to true will return only free to play champions.</param>
        /// <returns>A list of champions.</returns>
        Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false);

        /// <summary>
        /// Get a champion from its id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a champion.</param>
        /// <param name="championId">Id of the champion you're looking for.</param>
        /// <returns>A champion.</returns>
        Task<Champion> GetChampionAsync(Region region, int championId);
    }
}
