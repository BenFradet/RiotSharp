using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ClashEndpoint.Models;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The Clash Endpoint
    /// </summary>
    public interface IClashEndpoint
    {
        /// <summary>
        /// Gets a list of active Clash players for a given summoner ID.
        /// If a summoner registers for multiple tournaments at the same time (e.g., Saturday and Sunday) then both
        /// registrations would appear in this list.
        /// </summary>
        /// <param name="region">Region in which the clash is taking place</param>
        /// <param name="summonerId">Summoner Id for which you need to retrieve clash player list</param>
        /// <returns>A List of currently active clash players</returns>
        Task<List<ClashPlayer>> GetClashPlayersBySummonerIdAsync(Region region, string summonerId);

        
        /// <summary>
        /// Gets Clash Team By Team Id
        /// Returned Object also contains info about all team players
        /// </summary>
        /// <param name="region">Region in which team is registered on clash</param>
        /// <param name="teamId">Clash team id</param>
        /// <returns>Returns Clash Team model object containing all team info</returns>
        Task<ClashTeam> GetClashTeamByTeamIdAsync(Region region, string teamId);
        
        /// <summary>
        /// Returns a list of active and upcoming tournaments in specified region.
        /// </summary>
        /// <param name="region">Region in which the tournaments are held</param>
        /// <returns>Return a list of tournament entity models</returns>
        Task<List<ClashTournament>> GetClashTournamentListAsync(Region region);
        
        /// <summary>
        /// Returns a active or upcoming tournament for specified team.
        /// </summary>
        /// <param name="region">Region in which the tournament is held</param>
        /// <param name="teamId">Team Id for which the tournament entity is fetched</param>
        /// <returns>Return a tournament entity model</returns>
        Task<ClashTournament> GetClashTournamentByTeamAsync(Region region, string teamId);
        
        /// <summary>
        /// Returns a active or upcoming tournament by its Id.
        /// </summary>
        /// <param name="region">Region in which the tournament is held</param>
        /// <param name="tournamentId">tournament id</param>
        /// <returns>Return a tournament entity model</returns>
        Task<ClashTournament> GetClashTournamentByIdAsync(Region region, int tournamentId);
    }
}