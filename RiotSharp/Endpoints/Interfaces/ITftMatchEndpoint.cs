using RiotSharp.Endpoints.TftMatchEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces
{
    public interface ITftMatchEndpoint
    {
        /// <summary>
        /// Gets a list of match ids by puuid
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="puuid"></param>
        /// <returns>A list of strings</returns>
        Task<List<string>> GetTftMatchIdsByPuuidAsync(Region region, string puuid, int count = 20);

        /// <summary>
        /// Get a match by id
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="matchId">The match id for the match wanting to be retrieved</param>
        /// <returns><see cref="Match"> object </returns>
        Task<TftMatch> GetTftMatchByIdAsync(Region region, string matchId);
    }
}
