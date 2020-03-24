using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// The League Endpoint.
    /// </summary>
    public interface ILeagueEndpoint
    {
        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league. (Supported: <see cref="Misc.Queue.RankedSolo5x5"/>, <see cref="Misc.Queue.RankedFlexSR"/>, <see cref="Misc.Queue.RankedFlexTT"/>)</param>
        /// <returns>A <see cref="League" /> which contains all the challengers for this specific region and queue.</returns>
        Task<League> GetChallengerLeagueAsync(Region region, string queue);

        /// <summary>
        /// Get the master league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"><see cref="Region"/> in which you wish to look for a master league.</param>
        /// <param name="queue">Queue in which you wish to look for a master league.  (Supported: <see cref="Misc.Queue.RankedSolo5x5"/>, <see cref="Misc.Queue.RankedFlexSR"/>, <see cref="Misc.Queue.RankedFlexTT"/>)</param>
        /// <returns>A <see cref="League" /> which contains all the masters for this specific region and queue.</returns>
        Task<League> GetMasterLeagueAsync(Region region, string queue);

        /// <summary>
        /// Used to retrieve a list of <see cref="LeagueEntry"/> for the given <paramref name="division"/>, <paramref name="tier"/> and <paramref name="rankedQueue"/>.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="division">The division</param>
        /// <param name="tier">The tier (<see cref="Endpoints.LeagueEndpoint.Enums.Tier.Iron"/> to <see cref="Endpoints.LeagueEndpoint.Enums.Tier.Diamond"/>)</param>
        /// <param name="rankedQueue">Ranked queue. (Supported: <see cref="Misc.Queue.RankedSolo5x5"/>, <see cref="Misc.Queue.RankedFlexSR"/>, <see cref="Misc.Queue.RankedFlexTT"/>)</param>
        /// <param name="page"></param>
        /// <returns>List of matching <see cref="LeagueEntry"/>s</returns>
        Task<List<LeagueEntry>> GetLeagueEntriesAsync(Region region, LeagueEndpoint.Enums.Division division, LeagueEndpoint.Enums.Tier tier, string rankedQueue, int page = 1);

        /// <summary>
        /// Used to retrieve a list of <see cref="LeagueEntry"/> for the given <paramref name="encryptedSummonerId"/>.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="encryptedSummonerId">The encrypted summoner id</param>
        Task<List<LeagueEntry>> GetLeagueEntriesBySummonerAsync(Region region, string encryptedSummonerId);

        /// <summary>
        /// Used to retrieve information about the provided <paramref name="leagueId"/>.
        /// <para/>
        /// Warning: Consistently looking up league ids that don't exist will result in a blacklist.
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="leagueId">The league id</param>
        /// <returns>The <see cref="League" /> for this specific region and queue.</returns>
        Task<League> GetLeagueByIdAsync(Region region, string leagueId);

        /// <summary>
        /// Get the grandmaster league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="rankedQueue">A ranked queue (Supported: <see cref="Misc.Queue.RankedSolo5x5"/>, <see cref="Misc.Queue.RankedFlexSR"/>, <see cref="Misc.Queue.RankedFlexTT"/>)</param>
        /// <returns>A <see cref="League" /> which contains all the grandmasters for this specific region and queue.</returns>
        Task<League> GetLeagueGrandmastersByQueueAsync(Region region, string rankedQueue);
    }
}
