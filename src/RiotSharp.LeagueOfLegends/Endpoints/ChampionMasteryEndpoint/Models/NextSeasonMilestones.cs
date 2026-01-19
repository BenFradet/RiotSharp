using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint.Models
{
	public class NextSeasonMilestones
	{
        /// <summary>
        /// Some weirdly formed object that may look like this:
        /// "requireGradeCounts": {
        ///     "A-": 1
        /// }
        /// Could in the future be handled better. But for now, it's an object because docs say so.
        /// </summary>
        [JsonPropertyName("requireGradeCounts")]
		public required object RequireGradeCounts { get; set; }

		/// <summary>
		/// Reward marks.
		/// </summary>
		[JsonPropertyName("rewardMarks")]
		public required int RewardMarks { get; set; }

		/// <summary>
		/// Bonus.
		/// </summary>
		[JsonPropertyName("bonus")]
		public required bool Bonus { get; set; }

		/// <summary>
		/// Reward configuration.
		/// </summary>
		[JsonPropertyName("rewardConfig")]
		public RewardConfig? RewardConfig { get; set; }
	}
}