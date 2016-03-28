using Newtonsoft.Json;
using RiotSharp.TournamentEndpoint.Enums.Converters;

namespace RiotSharp.TournamentEndpoint.Enums
{
    /// <summary>
    ///     Pick type of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof(TournamentPickTypeConverter))]
    public enum TournamentPickType
    {
        /// <summary>
        /// Blind pick mode.
        /// </summary>
        BlindPick,

        /// <summary>
        /// Draft pick mode.
        /// </summary>
        DraftMode,

        /// <summary>
        /// All random mode.
        /// </summary>
        AllRandom,

        /// <summary>
        /// Tournament draft mode (adds ability to pause).
        /// </summary>
        TournamentDraft
    }
}
