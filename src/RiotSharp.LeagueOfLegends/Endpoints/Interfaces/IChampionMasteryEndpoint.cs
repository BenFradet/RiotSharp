using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint;

namespace RiotSharp.LeagueOfLegends.Endpoints.Interfaces
{
    /// <summary>
    /// The Champion Mastery Endpoint.
    /// </summary>
    public interface IChampionMasteryEndpoint
    {

        /// <summary>
        /// Gets a champion mastery by puuid asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="puuid">Encrypted PUUID for the summoner</param>
        /// <param name="championId">ID of the champion for which to retrieve mastery.</param>
        Task<ChampionMastery?> GetChampionMasteryByPuuidAsync(Region region, string puuid, long championId);

		/// <summary>
		/// Get a player's total accumulated champion mastery score, which is the sum of individual champion mastery levels.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="puuid"></param>
		/// <returns>The total champion mastery score for the player.</returns>
		Task<int> GetTotalChampionMasteryScoreAsync(Region region, string puuid);

		/// <summary>
		/// Get all champion mastery entries sorted by number of champion points descending asynchronously.
		/// </summary>
		/// <param name="region">Region where to retrieve the data.</param>
		/// <param name="puuid">Encrypted PUUID for the summoner</param>
		/// <param name="championId">ID of the champion for which to retrieve mastery.</param>
		Task<List<ChampionMastery>?> GetChampionMasteriesByPuuidAsync(Region region, string puuid);

		/// <summary>
		/// Get a specified number of top champion masteries for a player asynchronously.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="puuid"></param>
		/// <param name="count">Number of champions to get. Default is top 3.</param>
		/// <returns>A list of the top champions based on mastery score.</returns>
		Task<List<ChampionMastery>?> GetTopChampionMasteriesByPuuidAsync(Region region, string puuid, int count = 3);
    }
}
