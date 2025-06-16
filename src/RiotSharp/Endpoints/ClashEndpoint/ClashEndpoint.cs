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
        private const string ClashRootUrl = "/lol/clash/v1";
        private const string ClashPlayersBySummonerId = "/players/by-summoner/{0}";
        private const string ClashTeamById = "/teams/{0}";
        private const string ClashTournaments = "/tournaments";
        private const string ClashTournamentByTeam = "/tournaments/by-team/{0}";
        private const string ClashTournamentById = "/tournaments/{0}";

        private const string ClashPlayerCacheKey = "clash-player-{0}_{1}";
        private const string ClashTeamCacheKey = "clash-team-{0}_{1}";
        private const string ClashTournamentListCacheKey = "clash-tournaments-{0}";
        private const string ClashTournamentByTeamCacheKey = "clash-tournament-by-team-{0}-{1}";
        private const string ClashTournamentByIdCacheKey = "clash-tournament-by-id-{0}-{1}";
        
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
            var cacheKey = string.Format(ClashPlayerCacheKey, region, summonerId);
            var cachePLayerList = _cache.Get<string, List<ClashPlayer>>(cacheKey);

            if (cachePLayerList != null)
            {
                return cachePLayerList;
            }
            
            var json = await _requester
                .CreateGetRequestAsync(ClashRootUrl + string.Format(ClashPlayersBySummonerId, summonerId), region)
                .ConfigureAwait(false);
            
            var clashPlayers = JsonConvert.DeserializeObject<List<ClashPlayer>>(json);
            _cache.Add(cacheKey, clashPlayers, ClashPlayersTtl);

            return clashPlayers;
        }

        
        /// <inheritdoc />
        public async Task<ClashTeam> GetClashTeamByTeamIdAsync(Region region, string teamId)
        {
            var cacheKey = string.Format(ClashTeamCacheKey, region, teamId);
            var cacheTeam = _cache.Get<string, ClashTeam>(cacheKey);

            if (cacheTeam != null)
            {
                return cacheTeam;
            }

            var json = await _requester.CreateGetRequestAsync(ClashRootUrl + string.Format(ClashTeamById, teamId), region)
                .ConfigureAwait(false);

            var clashTeam = JsonConvert.DeserializeObject<ClashTeam>(json);
            _cache.Add(cacheKey, clashTeam, ClashPlayersTtl);

            return clashTeam;
        }
        
        /// <inheritdoc />
        public async Task<List<ClashTournament>> GetClashTournamentListAsync(Region region)
        {
            var cacheKey = string.Format(ClashTournamentListCacheKey, region);
            var cacheTournamentList = _cache.Get<string, List<ClashTournament>>(cacheKey);

            if (cacheTournamentList != null)
            {
                return cacheTournamentList;
            }

            var json = await _requester.CreateGetRequestAsync(ClashRootUrl + ClashTournaments, region)
                .ConfigureAwait(false);

            var tournaments = JsonConvert.DeserializeObject<List<ClashTournament>>(json);
            _cache.Add(cacheKey, tournaments, ClashPlayersTtl);

            return tournaments;
        }
        
        /// <inheritdoc />
        public async Task<ClashTournament> GetClashTournamentByTeamAsync(Region region, string teamId)
        {
            var cacheKey = string.Format(ClashTournamentByTeamCacheKey, region, teamId);
            var cacheTournament = _cache.Get<string, ClashTournament>(cacheKey);

            if (cacheTournament != null)
            {
                return cacheTournament;
            }

            var json = await _requester.CreateGetRequestAsync(ClashRootUrl + string.Format(ClashTournamentByTeam, teamId), region)
                .ConfigureAwait(false);

            var tournament = JsonConvert.DeserializeObject<ClashTournament>(json);
            _cache.Add(cacheKey, tournament, ClashPlayersTtl);

            return tournament;
        }

        public async Task<ClashTournament> GetClashTournamentByIdAsync(Region region, int tournamentId)
        {
            var cacheKey = string.Format(ClashTournamentByIdCacheKey, region, tournamentId);
            var cacheTournament = _cache.Get<string, ClashTournament>(cacheKey);

            if (cacheTournament != null)
            {
                return cacheTournament;
            }

            var json = await _requester.CreateGetRequestAsync(ClashRootUrl + string.Format(ClashTournamentById, tournamentId), region)
                .ConfigureAwait(false);

            var tournament = JsonConvert.DeserializeObject<ClashTournament>(json);
            _cache.Add(cacheKey, tournament, ClashPlayersTtl);

            return tournament;
        }
    }
}