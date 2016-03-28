using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    ///     Class representing a tournament for the Tournament API.
    /// </summary>
    public class Tournament
    {
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
        public string CreateTournamentCode(int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata)
        {
            return TournamentRiotApi.GetInstance()
                .CreateTournamentCode(Id, teamSize, allowedSummonerIds, spectatorType, pickType, mapType, metadata);
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
        public async Task<string> CreateTournamentCodeAsync(int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata)
        {
            return await TournamentRiotApi.GetInstance()
                .CreateTournamentCodeAsync(Id, teamSize, allowedSummonerIds, spectatorType, pickType, mapType, metadata);
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
        public List<string> CreateTournamentCodes(int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1)
        {
            return TournamentRiotApi.GetInstance()
                .CreateTournamentCodes(Id, teamSize, spectatorType, pickType, mapType, metadata, count);
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
        public async Task<List<string>> CreateTournamentCodesAsync(int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1)
        {
            return await TournamentRiotApi.GetInstance()
                .CreateTournamentCodesAsync(Id, teamSize, spectatorType, pickType, mapType, metadata, count);
        }
    }
}
