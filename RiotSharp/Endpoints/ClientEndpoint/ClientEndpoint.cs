using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;
using RiotSharp.Endpoints.Interfaces.Client;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Endpoints.ClientEndpoint
{
    public class ClientEndpoint : IClientEndpoint
    {
        private const string Host = "127.0.0.1:2999";
        private const string ClientDataRootUrl = "/liveclientdata";
        private const string PlayerListUrl = "/playerlist";
        private const string PlayerItemsBySummonerNameUrl = "/playeritems?summonername={0}";
        private const string PlayerMainRunesBySummonerNameUrl = "/playermainrunes?summonername={0}";
        private const string PlayerSummonerSpellsBySummonerNameUrl = "/playersummonerspells?summonername={0}";
        private const string PlayerScoresBySummonerNameUrl = "/playerscores?summonername={0}";
        private const string GameEventListUrl = "/eventdata";
        private const string GameStatsUrl = "/gamestats";
        private const string ActivePlayerSummonerNameUrl = "/activeplayername";

        private static ClientEndpoint _instance;

        public static IClientEndpoint GetInstance()
        {
            return _instance ?? (_instance = new ClientEndpoint(Requesters.ClientApiRequester ?? (Requesters.ClientApiRequester = new Requester())));
        }

        private readonly IRequester _requester;

        internal ClientEndpoint(IRequester requester)
        {
            _requester = requester ?? throw new ArgumentNullException(nameof(requester));
        }

        public async Task<List<Player>> GetPlayerListAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{PlayerListUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Player>>(json);
        }

        public async Task<List<PlayerItem>> GetPlayerItemsAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerItemsBySummonerNameUrl}", summonerName)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<PlayerItem>>(json);
        }

        public async Task<PlayerMainRunes> GetPlayerMainRunesAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerMainRunesBySummonerNameUrl}", summonerName)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerMainRunes>(json);
        }

        public async Task<PlayerSummonerSpellList> GetPlayerSummonerSpellsAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerSummonerSpellsBySummonerNameUrl}", summonerName)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerSummonerSpellList>(json);
        }

        public async Task<PlayerScores> GetPlayerScoresAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerScoresBySummonerNameUrl}", summonerName)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerScores>(json);
        }

        public async Task<GameEventList> GetGameEventListAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{GameEventListUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<GameEventList>(json);
        }

        public async Task<GameStats> GetGameStatsAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{GameStatsUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<GameStats>(json);
        }

        public async Task<string> GetActivePlayerSummonerNameAsync()
        {
            return await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{ActivePlayerSummonerNameUrl}").ConfigureAwait(false);
        }
    }
}