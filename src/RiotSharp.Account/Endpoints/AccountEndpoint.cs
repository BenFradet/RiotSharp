using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;

namespace RiotSharp.Account.Endpoints
{
	/// <summary>
	/// Implementation of <see cref="IAccountEndpoint"/>
	/// </summary>
	public class AccountEndpoint : RateLimitedEndpointBase, IAccountEndpoint
	{
		private const string AccountRootUrl = "/riot/account/v1";
		private const string ByPuuid = "/accounts/by-puuid/{0}";
		private const string ByRiotId = "/accounts/by-riot-id/{0}/{1}";
		private const string ActiveRegion = "/active-shards/by-game/{0}/by-puuid/{1}";
		private const string ActiveShard = "/active-shards/by-game/{0}/by-puuid/{1}";
		private const string ByAccessToken = "/accounts/me";

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountEndpoint"/> class.
		/// </summary>
		/// <param name="requester">The rate limited riotRequester.</param>
		public AccountEndpoint(IRateLimitedRequester requester) : base(requester)
		{}

		/// <inheritdoc/>
		public async Task<Account?> GetAccountByPuuidAsync(Region region, string puuid)
		{
			var requestUrl = string.Format(AccountRootUrl + ByPuuid, puuid);

			return await GetContentAsync<Account>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<Account?> GetAccountByRiotIdAsync(Region region, string gameName, string tagLine)
		{
			var requestUrl = string.Format(AccountRootUrl + ByRiotId, gameName, tagLine);

			return await GetContentAsync<Account>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<ActiveShardDto?> GetActiveShardByPuuidAsync(Region region, string puuid, Game game)
		{
			var requestUrl = string.Format(AccountRootUrl + ActiveShard, game.ToString().ToLower(), puuid);
			
			return await GetContentAsync<ActiveShardDto>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<ActiveRegion?> GetActiveRegionByPuuidAsync(Region region, string puuid, Game game)
		{
			var requestUrl = string.Format(AccountRootUrl + ActiveRegion, game.ToString().ToLower(), puuid);

			return await GetContentAsync<ActiveRegion>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		/// Uses the authorization header to get the account associated with the access token.
		/// This is not yet supported so it throws a NotImplementedException.
		public async Task<Account?> GetAccountByAccessToken(Region region, string authorization)
		{
			throw new NotImplementedException();
		}
	}
}
