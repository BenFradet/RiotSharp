using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.TournamentEndpoint
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LobbyEvent
    {
        PracticeGameCreatedEvent,
        PlayerJoinedGameEvent,
        PlayerSwitchedTeamEvent,
        PlayerQuitGameEvent,
        ChampSelectStartedEvent,
        GameAllocationStartedEvent,
        GameAllocatedToLsmEvent
    }
}