using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.RunesEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Runes Endpoint.
    /// </summary>
    public interface IRunesEndpoint
    {
        /// <summary>
        /// Get rune pages for a summoner id asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for rune pages for a summoner</param>
        /// <param name="summonerIds">The summoner id for which you wish to retrieve rune pages.</param>
        /// <returns>A list of <see cref="RunePage"/> for the given summoner.
        /// </returns>
        Task<List<RunePage>> GetRunePagesAsync(Region region, long summonerId);
    }
}
