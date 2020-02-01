using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.TFTEndpoint.Interfaces
{
    /// <summary>
    /// The TFT Summoner Endpoint.
    /// </summary>
    public interface ITFTSummonerEndpoint
    {
        /// <summary>
        /// Get a summoner by account id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">Account id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetTFTSummonerByAccountIDAsync(Region region, string accountId);

        /// <summary>
        /// Get a summoner by name asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetTFTSummonerByNameAsync(Region region, string summonerName);

        /// <summary>
        /// Get a summoner by puuid asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="puuid">PUUID of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetTFTSummonerByAccountPuuidAsync(Region region, string puuid);

        /// <summary>
        /// Get a summoner by summoner id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<Summoner> GetTFTSummonerBySummonerIdAsync(Region region, string summonerId);
    }
}
