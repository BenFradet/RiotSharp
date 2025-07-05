
using RiotSharp.Core.Misc;

namespace RiotSharp.Account.Endpoints
{
	/// <summary>
	/// This interface defines the methods for the Account endpoint.
	/// It is used to interact with account-related data in the Riot API.
	/// </summary>
	public interface IAccountEndpoint
	{
		/// <summary>
		/// Get account by puuid.
		/// </summary>
		/// <param name="region">Region in which you wish to look for a account. (Legal values: Americas, Asia, Europe, Esports)(using esports will target the esports endpoint!)</param>
		/// <param name="puuid">PUUID of the account you're looking for.</param>
		/// <returns>An Account.</returns>
		Task<Account?> GetAccountByPuuidAsync(Region region, string puuid);

		/// <summary>
		/// Get account by riot id.
		/// </summary>
		/// <param name="region">Region in which you wish to look for a account. (Legal values: Americas, Asia, Europe, Esports)(using esports will target the esports endpoint!)</param>
		/// <param name="gameName">GameName of the account you're looking for.</param>
		/// <param name="tagLine">TagLine of the account you're looking for.</param>
		/// <returns>An Account.</returns>
		Task<Account?> GetAccountByRiotIdAsync(Region region, string gameName, string tagLine);

		/// <summary>
		/// Get active shard for a player. Used for Legends of Runeterra and Valorant.
		/// </summary>
		/// <param name="region">Region in which you wish to look for a active shard. (Legal values: Americas, Asia, Europe)</param>
		/// <param name="game">The game.</param>
		/// <param name="puuid">PUUID of the active shard you're looking for.</param>
		/// <returns>An Active Shard.</returns>
		Task<ActiveShardDto?> GetActiveShardByPuuidAsync(Region region, string puuid, Game game);

		/// <summary>
		/// Get active region for a player. Used for League of Legends and Teamfight Tactics.
		/// </summary>
		/// <param name="region">Region in which you wish to look for a active shard. (Legal values: Americas, Asia, Europe)</param>
		/// <param name="game">The game.</param>
		/// <param name="puuid">PUUID of the active shard you're looking for.</param>
		/// <returns>An Active Shard.</returns>
		Task<ActiveRegion?> GetActiveRegionByPuuidAsync(Region region, string puuid, Game game);

		/// <summary>
		/// Get account by access token.
		/// </summary>
		/// <param name="region">Region in which you wish to look for a account. (Legal values: Americas, Asia, Europe, Esports)</param>
		/// <param name="authorization">Authorization token.</param>
		/// <returns>The account that the token is bound to.</returns>
		Task<Account?> GetAccountByAccessTokenAsync(Region region, string authorization);
	}
}
