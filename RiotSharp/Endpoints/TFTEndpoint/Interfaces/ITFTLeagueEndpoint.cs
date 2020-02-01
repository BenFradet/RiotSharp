using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.TFTEndpoint.Interfaces
{
    public interface ITFTLeagueEndpoint
    {
        /// <summary>
        /// Get the challenger tft league asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a tft challenger league.</param>
        /// <returns>A <see cref="League" /> which contains all the tft challengers for this specific region.</returns>
        Task<League> GetTFTChallengerLeagueAsync(Region region);

        /// <summary>
        /// Used to retrieve a list of <see cref="LeagueEntry"/> for the given <paramref name="encryptedSummonerId"/>.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="encryptedSummonerId">The encrypted summoner id</param>
        Task<List<LeagueEntry>> GetTFTLeagueEntriesBySummonerIdAsync(Region region, string encryptedSummonerId);

        /// <summary>
        /// Used to retrieve a list of TFT <see cref="LeagueEntry"/> for the given <paramref name="division"/>, <paramref name="tier"/>.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="division">The division</param>
        /// <param name="tier">The tier (<see cref="Enums.Tier.Iron"/> to <see cref="Enums.Tier.Diamond"/>)</param>
        /// <returns>List of matching <see cref="LeagueEntry"/>s</returns>
        Task<List<LeagueEntry>> GetTFTLeagueEntriesByTierAndDivisionAsync(Region region, Tier tier, Division division, int page = 1);

        /// <summary>
        /// Get the grandmaster tft league asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a tft grandmaster league.</param>
        /// <returns>A <see cref="League" /> which contains all the tft grandmasters for this specific region.</returns>
        Task<League> GetTFTGrandmasterLeagueAsync(Region region);

        /// <summary>
        /// Used to retrieve information about the provided <paramref name="leagueId"/>.
        /// <para/>
        /// Warning: Consistently looking up league ids that don't exist will result in a blacklist.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="leagueId">The league id</param>
        /// <returns>The <see cref="League" /> for this specific region and queue.</returns>
        Task<League> GetTFTLeaguesByLeagueIdAsync(Region region, string leagueId);

        /// <summary>
        /// Get the master tft league asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a tft master league.</param>
        /// <returns>A <see cref="League" /> which contains all the tft masters for this specific region.</returns>
        Task<League> GetTFTMasterLeagueAsync(Region region);
    }
}
