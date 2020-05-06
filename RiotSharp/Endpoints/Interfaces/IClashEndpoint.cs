using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ClashEndpoint.Models;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Clash Endpoint
    /// </summary>
    public interface IClashEndpoint
    {
        /// <summary>
        /// Gets a list of active Clash players for a given summoner ID.
        /// If a summoner registers for multiple tournaments at the same time (e.g., Saturday and Sunday) then both
        /// registrations would appear in this list.
        /// </summary>
        /// <param name="region">Region in which the clash is taking place</param>
        /// <param name="summonerId">Summoner Id for which you need to retrieve clash player list</param>
        /// <returns>A List of currently active clash players</returns>
        Task<List<ClashPlayer>> GetClashPlayersBySummonerIdAsync(Region region, string summonerId);
    }
}