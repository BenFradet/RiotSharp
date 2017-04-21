using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    ///     Class representing a tournament for the Tournament API.
    /// </summary>
    [Obsolete]
    public class Tournament
    {
        [Obsolete]
        internal Tournament()
        {
        }

        /// <summary>
        ///     Tournament's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Create a tournament code for the tournament.
        /// </summary>
        /// <param name="teamSize">The team size for the tournament code game.</param>
        /// <param name="allowedSummonerIds">participants</param>
        /// <param name="spectatorType">The spectator mode for the tournament code game.</param>
        /// <param name="pickType">The pick mode for tournament code game.</param>
        /// <param name="mapType">The game map for the tournament code game</param>
        /// <param name="metadata">The metadata for tournament code.</param>
        /// <returns>The tournament code.</returns>
        [Obsolete]
        public string CreateTournamentCodeV1(int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata)
        {
            return TournamentRiotApi.GetInstance()
                .CreateTournamentCodeV1(Id, teamSize, allowedSummonerIds, spectatorType, pickType, mapType, metadata);
        }

        /// <summary>
        ///     Create a tournament code for the tournament asynchronously.
        /// </summary>
        /// <param name="teamSize">The team size for the tournament code game.</param>
        /// <param name="allowedSummonerIds">participants</param>
        /// <param name="spectatorType">The spectator mode for the tournament code game.</param>
        /// <param name="pickType">The pick mode for tournament code game.</param>
        /// <param name="mapType">The game map for the tournament code game</param>
        /// <param name="metadata">The metadata for tournament code.</param>
        /// <returns>The tournament code.</returns>
        [Obsolete]
        public async Task<string> CreateTournamentCodeV1Async(int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata)
        {
            return await TournamentRiotApi.GetInstance()
                .CreateTournamentCodeV1Async(Id, teamSize, allowedSummonerIds, spectatorType, pickType, mapType, metadata);
        }

        /// <summary>
        ///     Create multiple tournament codes for the tournament.
        /// </summary>
        /// <param name="teamSize">The team size for the tournament code game.</param>
        /// <param name="spectatorType">The spectator mode for the tournament code game.</param>
        /// <param name="pickType">The pick mode for tournament code game.</param>
        /// <param name="mapType">The game map for the tournament code game</param>
        /// <param name="metadata">The metadata for tournament code.</param>
        /// <param name="count">The number of codes to be created</param>
        /// <returns>A list of the created tournament codes</returns>
        [Obsolete]
        public List<string> CreateTournamentCodesV1(int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1)
        {
            return TournamentRiotApi.GetInstance()
                .CreateTournamentCodesV1(Id, teamSize, spectatorType, pickType, mapType, metadata, count);
        }

        /// <summary>
        ///     Create multiple tournament codes for the tournament asynchronously.
        /// </summary>
        /// <param name="teamSize">The team size for the tournament code game.</param>
        /// <param name="spectatorType">The spectator mode for the tournament code game.</param>
        /// <param name="pickType">The pick mode for tournament code game.</param>
        /// <param name="mapType">The game map for the tournament code game</param>
        /// <param name="metadata">The metadata for tournament code.</param>
        /// <param name="count">The number of codes to be created</param>
        /// <returns>A list of the created tournament codes</returns>
        [Obsolete]
        public async Task<List<string>> CreateTournamentCodesV1Async(int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1)
        {
            return await TournamentRiotApi.GetInstance()
                .CreateTournamentCodesV1Async(Id, teamSize, spectatorType, pickType, mapType, metadata, count);
        }
    }
}
