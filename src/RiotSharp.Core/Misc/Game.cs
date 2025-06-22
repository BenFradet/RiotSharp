using System.Text.Json.Serialization;

namespace RiotSharp.Core.Misc
{
    /// <summary>
    /// The games.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<Game>))]
    public enum Game
    {
        /// <summary>
        /// Legends of Runeterra
        /// </summary>
        LoR,

        /// <summary>
        /// VALORANT
        /// </summary>
        Val,

		/// <summary>
		/// League of Legends
		/// </summary>
		LoL,

		/// <summary>
		/// Teamfight Tactics
		/// </summary>
		Tft
	}
}
