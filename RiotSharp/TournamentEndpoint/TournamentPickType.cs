using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    [JsonConverter(typeof(TournamentPickTypeConverter))]
    /// <summary>
    /// Pick type of the game (Tournament API).
    /// </summary>
    public enum TournamentPickType
    {
        BlindPick,
        DraftMode,
        AllRandom,
        TournamentDraft
    }
}
