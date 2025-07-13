using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums
{
	[JsonConverter(typeof(QueueConverter))]
	public enum Queue
	{
		/// <summary>
		/// Solo queue 5 vs 5
		/// </summary>
		RankedSolo5x5, // = "RANKED_SOLO_5x5";

		/// <summary>
		/// Team 3 vs 3
		/// </summary>
		RankedTeam3x3, // = "RANKED_TEAM_3x3";

		/// <summary>
		/// Team 5 vs 5
		/// </summary>
		RankedTeam5x5, // = "RANKED_TEAM_5x5";

		/// <summary>
		/// Team 5 v 5 - Dynamic Queue - Ranked
		/// </summary>
		TeamBuilderDraftRanked5x5, // = "TEAM_BUIDER_DRAFT_RANKED_5x5";

		/// <summary>
		/// Team 5 v 5 - Dynamic Queue - Unranked
		/// </summary>
		TeamBuilderDraftUnranked5x5, // = "TEAM_BUILDER_DRAFT_UNRANKED_5x5";

		/// <summary>
		/// New Summoner's Rift ranked games
		/// </summary>
		RankedFlexSR, // = "RANKED_FLEX_SR";

		/// <summary>
		/// New Twisted Treeline ranked games
		/// </summary>
		RankedFlexTT, // = "RANKED_FLEX_TT";

		/// <summary>
		/// Ranked Solo games from current season that use Team Builder matchmaking
		/// </summary>
		TeamBuilderRankedSolo, // = "TEAM_BUILDER_RANKED_SOLO";

		/// <summary>
		/// Used for both historical Ranked Premade 3v3 games
		/// </summary>
		RankedPremade3x3, // = "RANKED_PREMADE_3x3";

		/// <summary>
		/// Ranked Premade 5v5 games
		/// </summary>
		RankedPremade5x5, // = "RANKED_PREMADE_5x5";
		
		/// <summary>
		/// Darkstar games
		/// </summary>
		Darkstar // = "DARKSTAR_3x3";
	}

	public static class QueueExtensions
	{
		public static string ToApiString(this Queue queue)
		{
			return queue switch
			{
				Queue.RankedSolo5x5 => "RANKED_SOLO_5x5",
				Queue.RankedTeam3x3 => "RANKED_TEAM_3x3",
				Queue.RankedTeam5x5 => "RANKED_TEAM_5x5",
				Queue.TeamBuilderDraftRanked5x5 => "TEAM_BUILDER_DRAFT_RANKED_5x5",
				Queue.TeamBuilderDraftUnranked5x5 => "TEAM_BUILDER_DRAFT_UNRANKED_5x5",
				Queue.RankedFlexSR => "RANKED_FLEX_SR",
				Queue.RankedFlexTT => "RANKED_FLEX_TT",
				Queue.TeamBuilderRankedSolo => "TEAM_BUILDER_RANKED_SOLO",
				Queue.RankedPremade3x3 => "RANKED_PREMADE_3x3",
				Queue.RankedPremade5x5 => "RANKED_PREMADE_5x5",
				Queue.Darkstar => "DARKSTAR_3x3",
				_ => throw new ArgumentOutOfRangeException(nameof(queue), queue, null)
			};
		}
	}
}
