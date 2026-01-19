using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint.Models
{
	public class RewardConfig
	{
		/// <summary>
		/// Reward value.
		/// </summary>
		[JsonPropertyName("rewardValue")]
		public string? RewardValue { get; set; }

		/// <summary>
		/// Reward type.
		/// </summary>
		[JsonPropertyName("rewardType")]
		public string? RewardType { get; set; }

		/// <summary>
		/// Maximum reward.
		/// </summary>
		[JsonPropertyName("maximumReward")]
		public int? MaximumReward { get; set; }
	}
}