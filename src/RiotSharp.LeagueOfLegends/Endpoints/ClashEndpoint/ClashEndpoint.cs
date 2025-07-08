using System.Text.Json;
using RiotSharp.Core.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Models;
using RiotSharp.LeagueOfLegends.Endpoints.Interfaces;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint
{
    /// <summary>
    /// The Clash Endpoint
    /// </summary>
    public class ClashEndpoint : RateLimitedEndpointBase, IClashEndpoint
    {
        private const string ClashRootUrl = "/lol/clash/v1";
        private const string ClashPlayersByPuuid = ClashRootUrl + "/players/by-puuid/{0}";
        private const string ClashTeamById = ClashRootUrl + "/teams/{0}";
        private const string ClashTournaments = ClashRootUrl + "/tournaments";
        private const string ClashTournamentsByTeam = ClashRootUrl + "/tournaments/by-team/{0}";
        private const string ClashTournamentsById = ClashRootUrl + "/tournaments/{0}";

        /// <summary>
        /// Creates a Clash Endpoint
        /// </summary>
        /// <param name="requester">The rate limited requester</param>
        public ClashEndpoint(IRateLimitedRequester requester) : base(requester)
        {
        }

        /// <inheritdoc />
        public async Task<List<ClashPlayer>?> GetClashPlayersByPuuidAsync(Region region, string puuid)
        {
            var requestUrl = string.Format(ClashPlayersByPuuid, puuid);
             
            return await GetContentAsync<List<ClashPlayer>>(region, requestUrl).ConfigureAwait(false);
        }

        
        /// <inheritdoc />
        public async Task<ClashTeam?> GetClashTeamByTeamIdAsync(Region region, string teamId)
        {
			var requestUrl = string.Format(ClashTeamById, teamId);

			return await GetContentAsync<ClashTeam>(region, requestUrl).ConfigureAwait(false);
		}
        
        /// <inheritdoc />
        public async Task<List<ClashTournament>?> GetClashTournamentListAsync(Region region)
        {
			var requestUrl = ClashTournaments;

			return await GetContentAsync<List<ClashTournament>>(region, requestUrl).ConfigureAwait(false);
		}
        
        /// <inheritdoc />
        public async Task<ClashTournament?> GetClashTournamentByTeamAsync(Region region, string teamId)
        {
			var requestUrl = string.Format(ClashTournamentsByTeam, teamId);

			return await GetContentAsync<ClashTournament>(region, requestUrl).ConfigureAwait(false);
		}

        public async Task<ClashTournament?> GetClashTournamentByIdAsync(Region region, int tournamentId)
        {
			var requestUrl = string.Format(ClashTournamentsById, tournamentId);

			return await GetContentAsync<ClashTournament>(region, requestUrl).ConfigureAwait(false);
		}
    }
}