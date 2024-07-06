using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint.Enums
{
    /// <summary>
    ///     The type of event that was triggered in the lobby (Tournament API).
    /// </summary>
    
    //For some reason these events are PascalCase...
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TournamentEventType
    {
        /// <summary>
        /// Lobby created.
        /// </summary>
        PracticeGameCreatedEvent,

        /// <summary>
        /// Player joins lobby.
        /// </summary>
        PlayerJoinedGameEvent,

        /// <summary>
        /// Player switches teams.
        /// </summary>
        PlayerSwitchedTeamEvent,

        /// <summary>
        /// Player leaves lobby
        /// </summary>
        PlayerQuitGameEvent,

        /// <summary>
        /// Champion selection begins.
        /// </summary>
        ChampSelectStartedEvent,

        /// <summary>
        /// Loading screen begins.
        /// </summary>
        GameAllocationStartedEvent,

        /// <summary>
        /// Game begins.
        /// </summary>
        GameAllocatedToLsmEvent,

        PlayerBannedFromGameEvent,

        OwnerChangedEvent,

        GameDissolvedEvent,
    }
}
