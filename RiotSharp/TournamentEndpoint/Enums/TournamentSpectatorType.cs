using Newtonsoft.Json;
using RiotSharp.TournamentEndpoint.Enums.Converters;

namespace RiotSharp.TournamentEndpoint.Enums
{
    /// <summary>
    ///     Spectator type of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof(TournamentSpectatorTypeConverter))]
    public enum TournamentSpectatorType
    {
        /// <summary>
        /// No spectators allowed.
        /// </summary>
        None,

        /// <summary>
        /// Spectators only allowed in the lobby.
        /// </summary>
        LobbyOnly,

        /// <summary>
        /// Spectators allowed in the lobby and the game itself.
        /// </summary>
        All
    }
}
