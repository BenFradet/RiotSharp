using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ClientEndpoint;
using RiotSharp.Endpoints.ClientEndpoint.ActivePlayer;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;

namespace RiotSharp.Endpoints.Interfaces.Client
{
    /// <summary>
    /// Represents the local client's API endpoint.
    /// </summary>
    public interface IClientEndpoint
    {
        /// <summary>
        /// Retrieves the <see cref="ActivePlayer"/> asynchronously.
        /// </summary>
        /// <returns>The <see cref="ActivePlayer"/>.</returns>
        Task<ActivePlayer> GetActivePlayerAsync();

        /// <summary>
        /// Retrieves the summoner name of the <see cref="ActivePlayer"/> asynchronously.
        /// </summary>
        /// <returns>The summoner name of the <see cref="ActivePlayer"/>.</returns>
        Task<string> GetActivePlayerSummonerNameAsync();

        /// <summary>
        /// Retrieves the <see cref="ActivePlayerFullRunes"/> of the <see cref="ActivePlayer"/> asynchronously.
        /// </summary>
        /// <returns>The <see cref="ActivePlayerFullRunes"/> of the <see cref="ActivePlayer"/>.</returns>
        Task<ActivePlayerFullRunes> GetActivePlayerRunesAsync();

        /// <summary>
        /// Retrieves the <see cref="ActivePlayerAbilities"/> of the <see cref="ActivePlayer"/> asynchronously.
        /// </summary>
        /// <returns>The <see cref="ActivePlayerAbilities"/> of the <see cref="ActivePlayer"/>.</returns>
        Task<ActivePlayerAbilities> GetActivePlayerAbilitiesAsync();
        
        /// <summary>
        /// Retrieves a list of all <see cref="Player"/> participating in the current game (including the <see cref="ActivePlayer"/>) asynchronously.
        /// </summary>
        /// <returns>A list of <see cref="Player"/>.</returns>
        Task<List<Player>> GetPlayerListAsync();

        /// <summary>
        /// Retrieves a list of <see cref="PlayerItem"/> for the <see cref="Player"/> with the given <paramref name="summonerName"/> asynchronously.
        /// </summary>
        /// <param name="summonerName">The summoner name of the <see cref="Player"/> for which to get the items for.</param>
        /// <returns>A list of <see cref="PlayerItem"/> that are owned by the <see cref="Player"/> with the given <paramref name="summonerName"/>.</returns>
        Task<List<PlayerItem>> GetPlayerItemsAsync(string summonerName);

        /// <summary>
        /// Retrieves the <see cref="PlayerMainRunes"/> for the <see cref="Player"/> with the given <paramref name="summonerName"/> asynchronously.
        /// </summary>
        /// <param name="summonerName">The summoner name of the <see cref="Player"/> for which to get the runes for.</param>
        /// <returns>The <see cref="PlayerMainRunes"/> that are used by the <see cref="Player"/> with the given <paramref name="summonerName"/>.</returns>
        Task<PlayerMainRunes> GetPlayerMainRunesAsync(string summonerName);

        /// <summary>
        /// Retrieves the <see cref="PlayerSummonerSpellList"/> for the <see cref="Player"/> with the given <paramref name="summonerName"/> asynchronously.
        /// </summary>
        /// <param name="summonerName">The summoner name of the <see cref="Player"/> for which to get the summoner spells for.</param>
        /// <returns>The <see cref="PlayerSummonerSpellList"/> that is used by the <see cref="Player"/> with the given <paramref name="summonerName"/>.</returns>
        Task<PlayerSummonerSpellList> GetPlayerSummonerSpellsAsync(string summonerName);

        /// <summary>
        /// Retrieves the <see cref="PlayerScores"/> for the <see cref="Player"/> with the given <paramref name="summonerName"/> asynchronously.
        /// </summary>
        /// <param name="summonerName">The summoner name of the <see cref="Player"/> for which to get the scores for.</param>
        /// <returns>The <see cref="PlayerScores"/> of the <see cref="Player"/> with the given <paramref name="summonerName"/>.</returns>
        Task<PlayerScores> GetPlayerScoresAsync(string summonerName);

        /// <summary>
        /// Retrieves the <see cref="GameEventList"/> asynchronously.
        /// </summary>
        /// <returns>The <see cref="GameEventList"/>.</returns>
        Task<GameEventList> GetGameEventListAsync();

        /// <summary>
        /// Retrieves the <see cref="GameStats"/> asynchronously.
        /// </summary>
        /// <returns>The <see cref="GameStats"/>.</returns>
        Task<GameStats> GetGameStatsAsync();
    }
}