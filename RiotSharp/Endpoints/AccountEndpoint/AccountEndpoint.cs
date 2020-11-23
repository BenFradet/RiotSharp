using Newtonsoft.Json;
using RiotSharp.Endpoints.AccountEndpoint.Enums;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.AccountEndpoint
{
    /// <summary>
    /// Implementation of the IAccountEndpoint interface.
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.IAccountEndpoint" />
    public class AccountEndpoint : IAccountEndpoint
    {
        private const string AccountRootUrl = "/riot/account/v1";
        private const string ByPuuid = "/accounts/by-puuid/{0}";
        private const string ByRiotId = "/accounts/by-riot-id/{0}/{1}";
        private const string ByGame = "/active-shards/by-game/{0}/by-puuid/{1}";

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public AccountEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<Account> GetAccountByPuuidAsync(Region region, string puuid)
        {
            var json = await _requester.CreateGetRequestAsync(AccountRootUrl + string.Format(ByPuuid, puuid), region
                ).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Account>(json);
        }

        /// <inheritdoc />
        public async Task<Account> GetAccountByRiotIdAsync(Region region, string gameName, string tagLine)
        {
            var json = await _requester.CreateGetRequestAsync(AccountRootUrl + string.Format(ByRiotId, gameName, tagLine), region
                ).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Account>(json);
        }

        /// <inheritdoc />
        public async Task<ActiveShardDto> GetActiveShardByPuuidAsync(Region region, Game game, string puuid)
        {
            var json = await _requester.CreateGetRequestAsync(AccountRootUrl + string.Format(ByGame, game.ToString().ToLower(), puuid), region
                ).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ActiveShardDto>(json);
        }
    }
}
