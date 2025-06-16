using System.Threading.Tasks;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Summoner Endpoint.
    /// </summary>
    public interface ISummonerEndpoint
    {
        /// <summary>
        /// Get a summoner by summoner id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetSummonerBySummonerIdAsync(Region region, string summonerId);

        /// <summary>
        /// Get a summoner by account id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">Account id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetSummonerByAccountIdAsync(Region region, string accountId);

        /// <summary>
        /// Get a summoner by name asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetSummonerByNameAsync(Region region, string summonerName);

        /// <summary>
        /// Get a summoner by puuid asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="puuid">PUUID of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetSummonerByPuuidAsync(Region region, string puuid);
    }
}
