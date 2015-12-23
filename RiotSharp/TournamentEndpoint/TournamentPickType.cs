using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    ///     Pick type of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof (TournamentPickTypeConverter))]
    public enum TournamentPickType
    {
        BlindPick,
        DraftMode,
        AllRandom,
        TournamentDraft
    }
}