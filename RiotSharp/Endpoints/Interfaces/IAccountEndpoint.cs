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
        /// <param name="region">Region in which you wish to look for a account.</param>
        /// <param name="puuid">PUUID of the account you're looking for.</param>
        /// <returns>An Account.</returns>
        Task<Account> GetAccountByPuuindAsync(Region region, string puuid);

        /// <summary>
        /// Get account by riot id.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a account.</param>
        /// <param name="gameName">GameName of the account you're looking for.</param>
        /// <param name="tagLine">TagLine of the account you're looking for.</param>
        /// <returns>An Account.</returns>
        Task<Account> GetAccountRiotIdAsync(Region region, string gameName, string tagLine);

        /// <summary>
        /// Get active shard for a player.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a active shard.</param>
        /// <param name="game"></param>
        /// <param name="puuid">PUUID of the active shard you're looking for.</param>
        /// <returns>An Active Shard.</returns>
        Task<ActiveShardDto> GetActiveShardByPuuindAsync(Region region, Game game, string puuid);
    }
}