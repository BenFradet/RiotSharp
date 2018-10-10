using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.SummonerEndpoint
{
    /// <summary>
    /// Implementation of <see cref="ISummonerEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.ISummonerEndpoint" />
    public class SummonerEndpoint : ISummonerEndpoint
    {
        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByAccountIdUrl = "/by-account/{0}";
        private const string SummonerByNameUrl = "/by-name/{0}";
        private const string SummonerBySummonerIdUrl = "/{0}";
        private const string SummonerCache = "summoner-{0}_{1}";
        private static readonly TimeSpan SummonerTtl = TimeSpan.FromDays(30);

        private readonly IRateLimitedRequester _requester;
        private readonly ICache _cache;

        /// <inheritdoc />
        public SummonerEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task<Summoner> GetSummonerBySummonerIdAsync(Region region, long summonerId)
        {
            var summonerInCache = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, summonerId));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }
            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId), region).ConfigureAwait(false);
            var summoner = JsonConvert.DeserializeObject<Summoner>(jsonResponse);
            if (summoner != null)
            {
                summoner.Region = region;
            }
            _cache.Add(string.Format(SummonerCache, region, summonerId), summoner, SummonerTtl);
            return summoner;
        }

        /// <inheritdoc />
        public async Task<Summoner> GetSummonerByAccountIdAsync(Region region, long accountId)
        {
            var summonerInCache = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, accountId));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }
            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId), region).ConfigureAwait(false);
            var summoner = JsonConvert.DeserializeObject<Summoner>(jsonResponse);
            if (summoner != null)
            {
                summoner.Region = region;
            }
            _cache.Add(string.Format(SummonerCache, region, accountId), summoner, SummonerTtl);
            return summoner;
        }

        /// <inheritdoc />
        public async Task<Summoner> GetSummonerByNameAsync(Region region, string summonerName)
        {
            var summonerInCache = _cache.Get<string, Summoner>(string.Format(SummonerCache, region, summonerName));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }
            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName), region).ConfigureAwait(false);
            var summoner = JsonConvert.DeserializeObject<Summoner>(jsonResponse);
            if (summoner != null)
            {
                summoner.Region = region;
            }
            _cache.Add(string.Format(SummonerCache, region, summonerName), summoner, SummonerTtl);
            return summoner;
        }
    }
}
