using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.TournamentEndpoint.Enums.Converters;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint.Enums
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

    public static class TournamentSpectatorTypeExtension
    {
        public static string ToCustomString(this TournamentSpectatorType spectator)
		{
			switch (spectator)
			{
				case TournamentSpectatorType.None:
					return "NONE";
				case TournamentSpectatorType.LobbyOnly:
					return "LOBBYONLY";
				case TournamentSpectatorType.All:
					return "ALL";
				default:
					return string.Empty;
			}
		}
    }
}
