using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.ClashEndpoint.Models;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ClashEndpoint
{
    /// <summary>
    /// The Clash Endpoint
    /// </summary>
    public class ClashEndpoint : IClashEndpoint
    {
        private const string ClashPlayersRootUrl = "/lol/clash/v1/players";
        private const string ClashPlayersBySummonerId = "/by-summoner/{0}";

        private const string ClashPlayerCache = "clash-player-{0}_{1}";
        private static readonly TimeSpan ClashPlayersTtl = TimeSpan.FromDays(5);
            
        
        private readonly IRateLimitedRequester _requester;
        private readonly ICache _cache;
        
        /// <summary>
        /// Creates a Clash Endpoint
        /// </summary>
        /// <param name="requester">The requester interface</param>
        /// <param name="cache">The cache interface</param>
        public ClashEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            _requester = requester;
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task<List<ClashPlayer>> GetClashPlayersBySummonerIdAsync(Region region, string summonerId)
        {
            var cacheKey = string.Format(ClashPlayerCache, region, summonerId);
            var cachePLayerList = _cache.Get<string, List<ClashPlayer>>(cacheKey);

            if (cachePLayerList != null)
            {
                return cachePLayerList;
            }
            
            var json = await _requester
                .CreateGetRequestAsync(ClashPlayersRootUrl + string.Format(ClashPlayersBySummonerId, summonerId), region)
                .ConfigureAwait(false);
            
            var clashPlayers = JsonConvert.DeserializeObject<List<ClashPlayer>>(json);
            _cache.Add(cacheKey, clashPlayers, ClashPlayersTtl);

            return clashPlayers;
        }
    }
}