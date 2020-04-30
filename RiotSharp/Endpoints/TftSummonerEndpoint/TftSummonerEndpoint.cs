using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.TftSummonerEndpoint
{
    class TftSummonerEndpoint : ITftSummonerEndpoint
    {
        private const string TftSummonerRootUrl = "/tft/summoner/v1/summoners";
        private const string TftSummonerByAccountIdUrl = "/by-account/{0}";
        private const string TftSummonerBySummonerIdUrl = "/{0}";
        private const string TftSummonerByNameUrl = "/by-name/{0}";
        private const string TftSummonerByPuuid = "/by-puuid/{0}";
        private const string TftSummonerCache = "tft-summoner-{0}_{1}";
        private static readonly TimeSpan TftSummonerTtl = TimeSpan.FromDays(30);

        private readonly IRateLimitedRequester _requester;
        private readonly ICache _cache;
        public TftSummonerEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task<TftSummoner> GetTftSummonerByAccountIdAsync(Region region, string accountId)
        {
            var summonerInCache = _cache.Get<string, TftSummoner>(string.Format(TftSummonerCache, region, accountId));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }

            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(TftSummonerRootUrl + TftSummonerByAccountIdUrl, accountId), region).ConfigureAwait(false);
            var summoner = JsonConvert.DeserializeObject<TftSummoner>(jsonResponse);

            if (summoner != null)
            {
                summoner.Region = region;
            }

            _cache.Add(string.Format(TftSummonerCache, region, accountId), summoner, TftSummonerTtl);
            return summoner;
        }

        /// <inheritdoc />
        public async Task<TftSummoner> GetTftSummonerByNameAsync(Region region, string summonerName)
        {
            var summonerInCache = _cache.Get<string, TftSummoner>(string.Format(TftSummonerCache, region, summonerName));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }

            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(TftSummonerRootUrl + TftSummonerByNameUrl, summonerName), region).ConfigureAwait(false);

            var summoner = JsonConvert.DeserializeObject<TftSummoner>(jsonResponse);

            if (summoner != null)
            {
                summoner.Region = region;
            }
            _cache.Add(string.Format(TftSummonerCache, region, summonerName), summoner, TftSummonerTtl);
            return summoner;
        }

        /// <inheritdoc />
        public async Task<TftSummoner> GetTftSummonerByPuuidAsync(Region region, string puuid)
        {
            var summonerInCache = _cache.Get<string, TftSummoner>(string.Format(TftSummonerCache, region, puuid));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }

            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(TftSummonerRootUrl + TftSummonerByPuuid, puuid), region).ConfigureAwait(false);

            var summoner = JsonConvert.DeserializeObject<TftSummoner>(jsonResponse);

            if (summoner != null)
            {
                summoner.Region = region;
            }
            _cache.Add(string.Format(TftSummonerCache, region, puuid), summoner, TftSummonerTtl);
            return summoner;
        }

        /// <inheritdoc />
        public async Task<TftSummoner> GetTftSummonerBySummonerIdAsync(Region region, string summonerId)
        {
            var summonerInCache = _cache.Get<string, TftSummoner>(string.Format(TftSummonerCache, region, summonerId));
            if (summonerInCache != null)
            {
                return summonerInCache;
            }

            var jsonResponse = await _requester.CreateGetRequestAsync(
                string.Format(TftSummonerRootUrl + TftSummonerBySummonerIdUrl, summonerId), region).ConfigureAwait(false);

            var summoner = JsonConvert.DeserializeObject<TftSummoner>(jsonResponse);

            if (summoner != null)
            {
                summoner.Region = region;
            }
            _cache.Add(string.Format(TftSummonerCache, region, summonerId), summoner, TftSummonerTtl);
            return summoner;
        }
    }
}
