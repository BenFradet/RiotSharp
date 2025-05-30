using System.Text.Json;
using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.ChampionMasteryEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IChampionMasteryEndpoint"/>
    /// </summary>
    public class ChampionMasteryEndpoint : IChampionMasteryEndpoint
    {
        private const string ChampionMasteryRootUrl = "/lol/champion-mastery/v4";
        private const string ChampionMasteriesBySummonerUrl = "/champion-masteries/by-summoner/{0}";
        private const string ChampionMasteryBySummonerUrl = "/champion-masteries/by-summoner/{0}/by-champion/{1}";
        private const string ChampionMasteryTotalScoreBySummonerUrl = "/scores/by-summoner/{0}";
        private const string ChampionMasteryByPuuidUrl = "/champion-masteries/by-puuid/{0}/by-champion/{1}";
        private const string ChampionMasteriesByPuuidUrl = "/champion-masteries/by-puuid/{0}";

        //private readonly IRiotRateLimitedRequester _requester;

        private readonly IRateLimitedRequester _requester;

		/// <summary>
		/// Initializes a new instance of the <see cref="ChampionMasteryEndpoint"/> class.
		/// </summary>
		/// <param name="requester">The rate limited requester.</param>
		public ChampionMasteryEndpoint(IRateLimitedRequester requester)
		{
			_requester = requester;
		}

		//TODO: Explore the possibility of making a util method that handles asking for permits for the method limiter and the application limiter.


		/// <inheritdoc />
		public async Task<ChampionMastery> GetChampionMasteryByPuuidAsync(Region region, string puuid, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryByPuuidUrl, puuid, championId);

            var request = _requester.CreateGetRequest(region, requestUrl, null);

            var response = await _requester.SendMessageAsync(request, region).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<ChampionMastery>(json);
        }

        /// <inheritdoc />
        public async Task<List<ChampionMastery>> GetChampionMasteriesByPuuidAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(ChampionMasteriesByPuuidUrl, puuid);

            var request = _requester.CreateGetRequest(region, requestUrl, null);

			var response = await _requester.SendMessageAsync(request, region).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			//var json = await _requester.CreateGetRequest(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
			return JsonSerializer.Deserialize<List<ChampionMastery>>(json); //TODO: Fix this null shit
        }

        /// <inheritdoc />
        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, puuid);

            var request = _requester.CreateGetRequest(region, requestUrl, null);

            var response = await _requester.SendMessageAsync(request, region).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<int>(json);
        }

        #region obsolete

        /// <inheritdoc />
        [Obsolete("SummonerID is no longer in service. Use puuid!")]
        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, string summonerId, long championId)
        {
	        var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

	        var request = _requester.CreateGetRequest(region, requestUrl, null);

	        var response = await _requester.SendMessageAsync(request, region).ConfigureAwait(false);

	        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

	        return JsonSerializer.Deserialize<ChampionMastery>(json);
        }
        
        /// <inheritdoc />
        [Obsolete("SummonerID is no longer in service. Use puuid!")]
        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, string summonerId)
        {
	        var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

	        var request = _requester.CreateGetRequest(region, requestUrl, null);

	        var response = await _requester.SendMessageAsync(request, region).ConfigureAwait(false);

	        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

	        return JsonSerializer.Deserialize<List<ChampionMastery>>(json);
        }
        
        #endregion obsolete
    }
}
