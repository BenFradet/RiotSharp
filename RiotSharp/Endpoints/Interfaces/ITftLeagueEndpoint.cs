using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Endpoints.TftLeagueEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces
{
    public interface ITftLeagueEndpoint
    {
        /// <summary>
        /// Get the TFT grandmaster league
        /// </summary>
        /// <param name="region">Participants server region</param>
        /// <returns><see cref="LeagueEntry"> class</returns>
        Task<TftLeague> GetTftGrandmasterLeagueAsync(Region region);

        /// <summary>
        /// Get the TFT challenger league
        /// </summary>
        /// <param name="region">Participants server region</param>
        /// <returns><see cref="League"> class</returns>
        Task<TftLeague> GetTftChallengerLeagueAsync(Region region);

        /// <summary>
        /// Get the TFT master league
        /// </summary>
        /// <param name="region">Participants server region</param>
        /// <returns><see cref="League"> class</returns>
        Task<TftLeague> GetTftMasterLeagueAsync(Region region);

        /// <summary>
        /// Gets a list of TFT league entries
        /// </summary>
        /// <param name="region">Summoners server region</param>
        /// <param name="encryptedSummonerId">Summoners encrypted id</param>
        /// <returns>List of <see cref="LeagueEntry"> class</returns>
        Task<List<TftLeagueEntry>> GetTftLeagueEntriesBySummonerAsync(Region region, string encryptedSummonerId);

        /// <summary>
        /// Gets a list of league entries for a given tier/division
        /// </summary>
        /// <param name="region">Participants server region</param>
        /// <param name="tier">Tier to get league entries from</param>
        /// <param name="division">Tier division to get league entries from</param>
        /// <returns>List of <see cref="LeagueEntry"> class</returns>
        Task<List<TftLeagueEntry>> GetTftLeagueByTierDivisionAsync(Region region, LeagueEndpoint.Enums.Tier tier, LeagueEndpoint.Enums.Division division);

        /// <summary>
        /// Gets the TFT league by league uuid
        /// </summary>
        /// <param name="region">Participants server region</param>
        /// <param name="leagueId">UUID of the league</param>
        /// <returns><see cref="League"> object/returns>
        Task<TftLeague> GetTftLeagueByIdAsync(Region region, string leagueId);
    }
}
