using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.ActivePlayer;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;
using RiotSharp.Endpoints.Interfaces.Client;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Endpoints.ClientEndpoint
{
    /// <inheritdoc cref="IClientEndpoint"/>
    public class ClientEndpoint : IClientEndpoint
    {
        private const string PrivateCertificateThumbprint = "8259aafd8f71a809d2b154dd1cdb492981e448bd";

        private const string Host = "127.0.0.1:2999";
        private const string ClientDataRootUrl = "/liveclientdata";
        private const string GameDataUrl = "/allgamedata";
        private const string ActivePlayerUrl = "/activeplayer";
        private const string ActivePlayerSummonerNameUrl = "/activeplayername";
        private const string ActivePlayerAbilitiesUrl = "/activeplayerabilities";
        private const string ActivePlayerRunesUrl = "/activeplayerrunes";
        private const string PlayerListUrl = "/playerlist";
        private const string PlayerItemsBySummonerNameUrl = "/playeritems?summonername={0}";
        private const string PlayerMainRunesBySummonerNameUrl = "/playermainrunes?summonername={0}";
        private const string PlayerSummonerSpellsBySummonerNameUrl = "/playersummonerspells?summonername={0}";
        private const string PlayerScoresBySummonerNameUrl = "/playerscores?summonername={0}";
        private const string GameEventListUrl = "/eventdata";
        private const string GameStatsUrl = "/gamestats";

        private static ClientEndpoint _instance;
        
        /// <summary>
        /// Gets the singleton instance of the <see cref="ClientEndpoint"/> class.
        /// </summary>
        /// <returns>The singleton instance of the <see cref="ClientEndpoint"/> class.</returns>
        public static IClientEndpoint GetInstance()
        {
            if (Requesters.ClientApiRequester == null)
            {
                var clientHandler = new HttpClientHandler
                                    {
                                        ServerCertificateCustomValidationCallback =
                                            delegate(HttpRequestMessage message, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors errors)
                                            {
                                                if (errors == SslPolicyErrors.None)
                                                {
                                                    return true;
                                                }

                                                if (certificate?.Thumbprint?.Equals(PrivateCertificateThumbprint, StringComparison.OrdinalIgnoreCase) == true)
                                                {
                                                    return true;
                                                }

                                                return false;
                                            }
                                    };
                Requesters.ClientApiRequester = new Requester(clientHandler);
            }

            return _instance ?? (_instance = new ClientEndpoint(Requesters.ClientApiRequester));
        }

        private readonly IRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The <see cref="IRequester"/> to use for API requests.</param>
        internal ClientEndpoint(IRequester requester)
        {
            _requester = requester ?? throw new ArgumentNullException(nameof(requester));
        }

        /// <inheritdoc/>
        public async Task<GameData> GetGameDataAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{GameDataUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<GameData>(json);
        }

        /// <inheritdoc/>
        public async Task<ActivePlayer.ActivePlayer> GetActivePlayerAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{ActivePlayerUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ActivePlayer.ActivePlayer>(json);
        }

        /// <inheritdoc/>
        public async Task<string> GetActivePlayerSummonerNameAsync()
        {
            return await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{ActivePlayerSummonerNameUrl}").ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<ActivePlayerAbilities> GetActivePlayerAbilitiesAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{ActivePlayerAbilitiesUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ActivePlayerAbilities>(json);
        }

        /// <inheritdoc/>
        public async Task<ActivePlayerFullRunes> GetActivePlayerRunesAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{ActivePlayerRunesUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ActivePlayerFullRunes>(json);
        }

        /// <inheritdoc/>
        public async Task<List<Player>> GetPlayerListAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{PlayerListUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Player>>(json);
        }

        /// <inheritdoc/>
        public async Task<List<PlayerItem>> GetPlayerItemsAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerItemsBySummonerNameUrl}", summonerName))
                                       .ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<PlayerItem>>(json);
        }

        /// <inheritdoc/>
        public async Task<PlayerMainRunes> GetPlayerMainRunesAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerMainRunesBySummonerNameUrl}", summonerName))
                                       .ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerMainRunes>(json);
        }

        /// <inheritdoc/>
        public async Task<PlayerSummonerSpellList> GetPlayerSummonerSpellsAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerSummonerSpellsBySummonerNameUrl}", summonerName))
                                       .ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerSummonerSpellList>(json);
        }

        /// <inheritdoc/>
        public async Task<PlayerScores> GetPlayerScoresAsync(string summonerName)
        {
            var json = await _requester.CreateGetRequestAsync(Host, string.Format($"{ClientDataRootUrl}{PlayerScoresBySummonerNameUrl}", summonerName))
                                       .ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerScores>(json);
        }

        /// <inheritdoc/>
        public async Task<GameEventList> GetGameEventListAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{GameEventListUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<GameEventList>(json);
        }

        /// <inheritdoc/>
        public async Task<GameStats> GetGameStatsAsync()
        {
            var json = await _requester.CreateGetRequestAsync(Host, $"{ClientDataRootUrl}{GameStatsUrl}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<GameStats>(json);
        }
    }
}