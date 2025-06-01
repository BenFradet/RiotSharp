using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharpNET8.Endpoints.GeneralEndpoints.ChampionMasteryEndpoint
{
	public class RewardConfig
	{
		/// <summary>
		/// Reward value.
		/// </summary>
		[JsonPropertyName("rewardValue")]
		public string RewardValue { get; set; }

		/// <summary>
		/// Reward type.
		/// </summary>
		[JsonPropertyName("rewardType")]
		public string RewardType { get; set; }

		/// <summary>
		/// Maximum reward.
		/// </summary>
		[JsonPropertyName("maximumReward")]
		public int MaximumReward { get; set; }
	}
}