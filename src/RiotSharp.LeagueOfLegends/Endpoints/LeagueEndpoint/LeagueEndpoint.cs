using System.Text.Json;
using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Models;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// Implementation of <see cref="ILeagueEndpoint"/>
    /// </summary>
    public class LeagueEndpoint : RateLimitedEndpointBase, ILeagueEndpoint
    {
        private const string LeagueRootUrl = "/lol/league/v4";
        private const string LeagueChallengerUrl = LeagueRootUrl + "/challengerleagues/by-queue/{0}";
        private const string LeagueEntriesByPuuidUrl = LeagueRootUrl + "/entries/by-puuid/{0}";
        private const string LeagueEntriesByQueueTierDivisionUrl = LeagueRootUrl +"/entries/{0}/{1}/{2}";
        private const string LeagueGrandmasterUrl = LeagueRootUrl +"/grandmasterleagues/by-queue/{0}";
        private const string LeagueLeagueByLeagueIdUrl = LeagueRootUrl + "/leagues/{0}";
        private const string LeagueMasterUrl = LeagueRootUrl + "/masterleagues/by-queue/{0}";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The riotRequester.</param>
        public LeagueEndpoint(IRateLimitedRequester requester) : base(requester)
		{ }

		/// <inheritdoc/>
		public async Task<LeagueList?> GetChallengerLeagueAsync(Region region, Queue queue)
		{
			var requestUrl = string.Format(LeagueChallengerUrl, queue.ToApiString());

			return await GetContentAsync<LeagueList>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<LeagueList?> GetLeagueGrandmastersByQueueAsync(Region region, Queue rankedQueue)
		{
			var requestUrl = string.Format(LeagueGrandmasterUrl, rankedQueue.ToApiString());

			return await GetContentAsync<LeagueList>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<LeagueList?> GetMasterLeagueAsync(Region region, Queue queue)
		{
			var requestUrl = string.Format(LeagueMasterUrl, queue.ToApiString());

			return await GetContentAsync<LeagueList>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<List<LeagueEntry>?> GetLeagueEntriesByPuuidAsync(Region region, string puuid)
		{
			var requestUrl = string.Format(LeagueEntriesByPuuidUrl, puuid);

			return await GetContentAsync<List<LeagueEntry>>(region, requestUrl).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<List<LeagueEntry>?> GetLeagueEntriesAsync(Region region, Division division, Tier tier, Queue rankedQueue, int pages = 1)
		{
			var requestUrl = string.Format(LeagueEntriesByQueueTierDivisionUrl, rankedQueue.ToApiString(), tier.ToApiString(), division.ToString());
			var queryParameters = new List<string> { $"page={pages}" };
			return await GetContentAsync<List<LeagueEntry>>(region, requestUrl, queryParameters).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<LeagueList?> GetLeagueByLeagueIdAsync(Region region, string leagueId)
		{
			var requestUrl = string.Format(LeagueLeagueByLeagueIdUrl, leagueId);

			return await GetContentAsync<LeagueList>(region, requestUrl).ConfigureAwait(false);
		}
    }
}
