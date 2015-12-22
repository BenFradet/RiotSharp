using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    [JsonConverter(typeof(TournamentSpectatorTypeConverter))]
    /// <summary>
    /// Spectator type of the game (Tournament API).
    /// </summary>
    public enum TournamentSpectatorType
    {
        None,
        LobbyOnly,
        All
    }
}
