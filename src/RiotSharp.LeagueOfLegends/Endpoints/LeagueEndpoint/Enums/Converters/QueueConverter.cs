using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters
{
	public class QueueConverter : JsonConverter<Queue>
	{
		public override Queue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var value = reader.GetString();
			switch (value)
			{
				case "RANKED_SOLO_5x5":
					return Queue.RankedSolo5x5;
				case "RANKED_TEAM_3x3":
					return Queue.RankedTeam3x3;
				case "RANKED_TEAM_5x5":
					return Queue.RankedTeam5x5;
				case "TEAM_BUILDER_DRAFT_RANKED_5x5":
					return Queue.TeamBuilderDraftRanked5x5;
				case "TEAM_BUILDER_DRAFT_UNRANKED_5x5":
					return Queue.TeamBuilderDraftUnranked5x5;
				case "RANKED_FLEX_SR":
					return Queue.RankedFlexSR;
				case "RANKED_FLEX_TT":
					return Queue.RankedFlexTT;
				case "TEAM_BUILDER_RANKED_SOLO":
					return Queue.TeamBuilderRankedSolo;
				case "RANKED_PREMADE_3x3":
					return Queue.RankedPremade3x3;
				case "RANKED_PREMADE_5x5":
					return Queue.RankedPremade5x5;
			}
			// No null value returnable
			return Queue.RankedSolo5x5;
		}

		public override void Write(Utf8JsonWriter writer, Queue value, JsonSerializerOptions options)
		{
			string stringValue = value switch
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
				_ => "RANKED_SOLO_5x5"
			};
			writer.WriteStringValue(stringValue);
		}

	}
}
