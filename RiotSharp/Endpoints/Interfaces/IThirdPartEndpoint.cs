using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Third Party Endpoint.
    /// </summary>
    public interface IThirdPartEndpoint
    {
        /// <summary>
        /// Get a thrid party code by summoner id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A string.</returns>
        string GetThirdPartyCodeBySummonerId(Region region, long summonerId);

        /// <summary>
        /// Get a thrid party code by summoner id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A string.</returns>
        Task<string> GetThirdPartyCodeBySummonerIdAsync(Region region, long summonerId);
    }
}
