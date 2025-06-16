using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.TournamentEndpoint.Enums.Converters;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint.Enums
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

    public static class TournamentPickTypeExtension
	{
		public static string ToCustomString(this TournamentPickType pick)
		{
			switch (pick)
			{
				case TournamentPickType.BlindPick:
					return "BLIND_PICK";
				case TournamentPickType.DraftMode:
					return "DRAFT_MODE";
				case TournamentPickType.AllRandom:
					return "ALL_RANDOM";
				case TournamentPickType.TournamentDraft:
					return "TOURNAMENT_DRAFT";
				default:
					return string.Empty;
			}
		}
	}
}
