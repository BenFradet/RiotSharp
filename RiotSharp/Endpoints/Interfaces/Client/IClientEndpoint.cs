using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ClientEndpoint;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;

namespace RiotSharp.Endpoints.Interfaces.Client
{
    public interface IClientEndpoint
    {
        Task<List<Player>> GetPlayerListAsync();

        Task<List<PlayerItem>> GetPlayerItemsAsync(string summonerName);

        Task<PlayerMainRunes> GetPlayerMainRunesAsync(string summonerName);

        Task<PlayerSummonerSpellList> GetPlayerSummonerSpellsAsync(string summonerName);

        Task<PlayerScores> GetPlayerScoresAsync(string summonerName);

        Task<GameEventList> GetGameEventListAsync();

        Task<GameStats> GetGameStatsAsync();

        Task<string> GetActivePlayerSummonerNameAsync();
    }
}