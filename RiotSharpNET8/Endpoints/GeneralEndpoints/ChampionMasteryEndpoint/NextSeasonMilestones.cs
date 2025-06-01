using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharpNET8.Endpoints.GeneralEndpoints.ChampionMasteryEndpoint
{
	public class NextSeasonMilestones
	{
		/// <summary>
		/// Some weirdly formed object that may look like this:
		/// "requireGradeCounts": {
		///     "A-": 1
		/// }
		/// </summary>
		[JsonPropertyName("requireGradeCounts")]
		public object RequireGradeCounts { get; set; }

		/// <summary>
		/// Reward marks.
		/// </summary>
		[JsonPropertyName("rewardMarks")]
		public int RewardMarks { get; set; }

		/// <summary>
		/// Bonus.
		/// </summary>
		[JsonPropertyName("bonus")]
		public bool Bonus { get; set; }

		/// <summary>
		/// Reward configuration.
		/// </summary>
		[JsonPropertyName("rewardConfig")]
		public RewardConfig RewardConfig { get; set; }
	}
}