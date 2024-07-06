using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.TournamentEndpoint.Enums.Converters;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint.Enums
{
    /// <summary>
    ///     Mode of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof(TournamentMapTypeConverter))]
    public enum TournamentMapType
    {
        /// <summary>
        /// Summoner's Rift map.
        /// </summary>
        SummonersRift,

        /// <summary>
        /// Twisted Treeline map.
        /// </summary>
        TwistedTreeline,

        /// <summary>
        /// Crystal Scar (Dominion) map.
        /// </summary>
        CrystalScar,

        /// <summary>
        /// Howling Abyss (ARAM) map.
        /// </summary>
        HowlingAbyss
    }
    public static class TournamentMapTypeExtension
	{
		public static string ToCustomString(this TournamentMapType map)
		{
			switch (map)
			{
				case TournamentMapType.SummonersRift:
					return "SUMMONERS_RIFT";
				case TournamentMapType.TwistedTreeline:
					return "TWISTED_TREELINE";
				case TournamentMapType.CrystalScar:
					return "CRYSTAL_SCAR";
				case TournamentMapType.HowlingAbyss:
					return "HOWLING_ABYSS";
				default:
					return string.Empty;
			}
		}
	}
}
