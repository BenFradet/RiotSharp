using RiotSharp.Endpoints.AccountEndpoint;
using RiotSharp.Endpoints.AccountEndpoint.Enums;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Account Endpoint.
    /// </summary>
    public interface IAccountEndpoint
    {
        /// <summary>
        /// Get account by puuid.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a account. (Legal values: Americas, Asia, Europe)</param>
        /// <param name="puuid">PUUID of the account you're looking for.</param>
        /// <returns>An Account.</returns>
        Task<Account> GetAccountByPuuidAsync(Region region, string puuid);

        /// <summary>
        /// Get account by riot id.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a account. (Legal values: Americas, Asia, Europe)</param>
        /// <param name="gameName">GameName of the account you're looking for.</param>
        /// <param name="tagLine">TagLine of the account you're looking for.</param>
        /// <returns>An Account.</returns>
        Task<Account> GetAccountByRiotIdAsync(Region region, string gameName, string tagLine);

        /// <summary>
        /// Get active shard for a player.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a active shard. (Legal values: Americas, Asia, Europe)</param>
        /// <param name="game">The game.</param>
        /// <param name="puuid">PUUID of the active shard you're looking for.</param>
        /// <returns>An Active Shard.</returns>
        Task<ActiveShardDto> GetActiveShardByPuuidAsync(Region region, Game game, string puuid);
    }
}