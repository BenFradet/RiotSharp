using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ClientEndpoint;
using RiotSharp.Endpoints.ClientEndpoint.ActivePlayer;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;

namespace RiotSharp.Endpoints.Interfaces.Client
{
    public interface IClientEndpoint
    {
        Task<ActivePlayer> GetActivePlayerAsync();

        Task<string> GetActivePlayerSummonerNameAsync();

        Task<ActivePlayerFullRunes> GetActivePlayerRunesAsync();

        Task<ActivePlayerAbilities> GetActivePlayerAbilitiesAsync();
        
        Task<List<Player>> GetPlayerListAsync();

        Task<List<PlayerItem>> GetPlayerItemsAsync(string summonerName);

        Task<PlayerMainRunes> GetPlayerMainRunesAsync(string summonerName);

        Task<PlayerSummonerSpellList> GetPlayerSummonerSpellsAsync(string summonerName);

        Task<PlayerScores> GetPlayerScoresAsync(string summonerName);

        Task<GameEventList> GetGameEventListAsync();

        Task<GameStats> GetGameStatsAsync();
    }
}