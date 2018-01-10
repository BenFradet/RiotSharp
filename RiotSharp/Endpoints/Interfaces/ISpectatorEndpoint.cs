using System.Threading.Tasks;
using RiotSharp.Endpoints.SpectatorEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    public interface ISpectatorEndpoint
    {
        /// <summary>
        /// Gets the current game by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve current game.</param>
        /// <returns>Current game of the summoner.</returns>
        CurrentGame GetCurrentGame(Region region, long summonerId);

        /// <summary>
        /// Gets the current game by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve current game.</param>
        /// <returns>Current game of the summoner.</returns>
        Task<CurrentGame> GetCurrentGameAsync(Region region, long summonerId);

        /// <summary>
        /// Gets the featured games by region synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <returns>Featured games for the region.</returns>
        FeaturedGames GetFeaturedGames(Region region);

        /// <summary>
        /// Gets the featured games by region asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <returns>Featured games for the region.</returns>
        Task<FeaturedGames> GetFeaturedGamesAsync(Region region);
    }
}
