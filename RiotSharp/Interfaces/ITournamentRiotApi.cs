using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.TournamentEndpoint;
using RiotSharp.Endpoints.TournamentEndpoint.Enums;
using RiotSharp.Misc;

namespace RiotSharp.Interfaces
{
    /// <summary>
    /// Entry point for the tournament API.
    /// </summary>
    public interface ITournamentRiotApi
    {
        /// <summary>
        ///     Creates a tournament provider and returns its object.
        /// </summary>
        /// <param name="region">The region in which the provider will be running tournaments.</param>
        /// <param name="url">
        ///     The provider's callback URL to which tournament game results in this region should be posted. The URL
        ///     must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use
        ///     port 80, https URLs must use port 443).
        /// </param>
        /// <returns>The ID of the provider.</returns>
        Task<int> CreateProviderAsync(Region region, string url);

        /// <summary>
        ///     Creates a tournament and returns its object.
        /// </summary>
        /// <param name="providerId">The provider ID to specify the regional registered provider data to associate this tournament.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>The ID of the tournament.</returns>
        Task<int> CreateTournamentAsync(int providerId, string name);

        /// <summary>
        ///     Create multiple tournament codes for the given tournament id.
        /// </summary>
        /// <param name="tournamentId">The tournament ID</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="allowedParticipantIds">List of id's for allowed participants. Defaults to null</param>
        /// <param name="metadata">
        ///     Optional string that may contain any data in any format, if specified at all. Used to denote any
        ///     custom information about the game.
        /// </param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <returns>A list of tournament codes in string format.</returns>
        Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int count, int teamSize,
            TournamentSpectatorType spectatorType, TournamentPickType pickType,
            TournamentMapType mapType, List<long> allowedParticipantIds = null, string metadata = "");

        /// <summary>
        ///     Returns the details of a certain tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code in string format.</param>
        /// <returns>TournamentCodeDetail object with details of the tournament code.</returns>
        Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode);
        
        /// <summary>
        ///     Gets a list of lobby events by tournament code.
        /// </summary>
        /// <param name="tournamentCode">A tournament code in string format.</param>
        /// <returns>List of TournamentLobbyEvents.</returns>
        Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode);

        /// <summary>
        ///     Update the pick type, map, spectator type, or allowed summoners for a code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update</param>
        /// <param name="allowedSummonerIds">List of summoner id's.</param>
        /// <param name="spectatorType">The spectator type.</param>
        /// <param name="pickType">The pick type.</param>
        /// <param name="mapType">The map type.</param>
        /// /// <returns>Success value.</returns>
        Task<bool> UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType);
        
        /// <summary>
        ///     Retrieve match by match ID and tournament code.
        /// </summary>
        /// <param name="region">The region of the match.</param>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code of the match.</param>
        /// <param name="includeTimeline">Flag indicating whether or not to include match timeline data.</param>
        /// <returns>MatchDetail object.</returns>
        Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode,
            bool includeTimeline);

        /// <summary>
        ///     Retrieve match IDs by tournament code.
        /// </summary>
        /// <param name="region">The region of the match.</param>
        /// <param name="tournamentCode">The tournament code of the match.</param>
        /// <returns>The match id of the match played with the tournament code entered.</returns>
        Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode);
    }
}
