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

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionMasteryEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public ChampionMasteryEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        [Obsolete("Endpoints by summonerID are deprecated and will be removed in January/2024. Use the equivalent by PUUID.")]
        public async Task<ChampionMastery> GetChampionMasteryAsync(Region region, string summonerId, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryBySummonerUrl, summonerId, championId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<ChampionMastery>(json);
        }

        /// <inheritdoc />
        public async Task<ChampionMastery> GetChampionMasteryByPuuidAsync(Region region, string puuid, long championId)
        {
            var requestUrl = string.Format(ChampionMasteryByPuuidUrl, puuid, championId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<ChampionMastery>(json);
        }

        /// <inheritdoc />
        [Obsolete("Endpoints by summonerID are deprecated and will be removed in January/2024. Use the equivalent by PUUID.")]
        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Region region, string summonerId)
        {
            var requestUrl = string.Format(ChampionMasteriesBySummonerUrl, summonerId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<List<ChampionMastery>>(json);
        }

        /// <inheritdoc />
        public async Task<List<ChampionMastery>> GetChampionMasteriesByPuuidAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(ChampionMasteriesByPuuidUrl, puuid);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<List<ChampionMastery>>(json);
        }

        /// <inheritdoc />
        public async Task<int> GetTotalChampionMasteryScoreAsync(Region region, string summonerId)
        {
            var requestUrl = string.Format(ChampionMasteryTotalScoreBySummonerUrl, summonerId);

            var json = await _requester.CreateGetRequestAsync(ChampionMasteryRootUrl + requestUrl, region).ConfigureAwait(false);
            return JsonSerializer.Deserialize<int>(json);
        }
    }
}
