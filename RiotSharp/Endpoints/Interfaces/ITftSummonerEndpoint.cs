using RiotSharp.Endpoints.TftSummonerEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// Tft Summoner Endpoint.
    /// </summary>
    public interface ITftSummonerEndpoint
    {
        /// <summary>
        /// Get a Teamfight Tactics summoner by account id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">Account id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<TftSummoner> GetTftSummonerByAccountIdAsync(Region region, string accountId);

        /// <summary>
        /// Get a Teamfight Tactics summoner by name asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<TftSummoner> GetTftSummonerByNameAsync(Region region, string summonerName);

        /// <summary>
        /// Get a Teamfight Tactics summoner by puuid asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="puuid">PUUID of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<TftSummoner> GetTftSummonerByPuuidAsync(Region region, string summonerName);

        /// <summary>
        /// Get a Teamfight Tactics summoner by summoner id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<TftSummoner> GetTftSummonerBySummonerIdAsync(Region region, string summonerId);
    }
}
