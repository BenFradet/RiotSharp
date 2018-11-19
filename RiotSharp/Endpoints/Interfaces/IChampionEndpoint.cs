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
        /// Get the list of free champions by region asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champion rotation.</param>
        /// <returns>An object containing id's of champions in rotation as well as max new player level.</returns>
        Task<ChampionRotation> GetChampionRotationAsync(Region region);
    }
}
