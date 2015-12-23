using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    ///     Spectator type of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof (TournamentSpectatorTypeConverter))]
    public enum TournamentSpectatorType
    {
        None,
        LobbyOnly,
        All
    }
}