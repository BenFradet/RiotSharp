using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.EndpointInterfaces;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IChampionMasteryEndpoint"/>
    /// </summary>
    public class ChampionMasteryEndpoint : RateLimitedEndpointBase, IChampionMasteryEndpoint
    {
        private const string ChampionMasteryTotalScoreByPuuidUrl = "/lol/champion-mastery/v4/scores/by-puuid/{0}";
        private const string ChampionMasteryByPuuidUrl = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{0}/by-champion/{1}";
        private const string ChampionMasteriesByPuuidUrl = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{0}"; // encrypted PUUID
        private const string ChampionMasteryTopUrl = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{0}/top"; // with query parameters for top champion mastery

		/// <summary>
		/// Initializes a new instance of the <see cref="ChampionMasteryEndpoint"/> class.
		/// </summary>
		/// <param name="requester">The rate limited riotRequester.</param>
		public ChampionMasteryEndpoint(IRateLimitedRequester requester) : base(requester)
		{}

		/// <inheritdoc />
		public async Task<ChampionMastery?> GetChampionMasteryByPuuidAsync(Region region, string puuid, long championId)
        {
	        var requestUrl = string.Format(ChampionMasteryByPuuidUrl, puuid, championId);

	        return await GetContentAsync<ChampionMastery>(region, requestUrl).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<ChampionMastery>?> GetChampionMasteriesByPuuidAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(ChampionMasteriesByPuuidUrl, puuid);

            return await GetContentAsync<List<ChampionMastery>>(region, requestUrl).ConfigureAwait(false);
        }

        public Task<List<ChampionMastery>?> GetTopChampionMasteriesByPuuidAsync(Region region, string puuid, int count = 3)
        {
			var requestUrl = string.Format(ChampionMasteryTopUrl, puuid);
			var queryParameters = new List<string> { $"count={count}" };
			return GetContentAsync<List<ChampionMastery>>(region, requestUrl, queryParameters);
		}

        /// <inheritdoc />
        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreByPuuidUrl, puuid);

            return await GetContentAsync<int>(region, requestUrl).ConfigureAwait(false);
		}
    }
}
