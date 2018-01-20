using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Masteries Endpoint.
    /// </summary>
    public interface IMasteriesEndpoint
    {
        /// <summary>
        /// Get mastery pages for a summoner id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerId">A summoner id for which you wish to retrieve the masteries.</param>
        /// <returns>A list of mastery pages for the summoner.</returns>
        Task<List<MasteryPage>> GetMasteryPagesAsync(Region region, long summonerId);
    }
}
