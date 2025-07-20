using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums
{
    /// <summary>
    /// Tier of the league (League API).
    /// </summary>
    [JsonConverter(typeof(TierConverter))]
    public enum Tier
    {
        /// <summary>
        /// Master tier.
        /// </summary>
        Master,

        /// <summary>
        /// Challenger tier.
        /// </summary>
        Challenger,

        /// <summary>
        /// Diamond tier.
        /// </summary>
        Diamond,

        /// <summary>
        /// Platinum tier.
        /// </summary>
        Platinum,

        /// <summary>
        /// Gold tier.
        /// </summary>
        Gold,

        /// <summary>
        /// Silver tier.
        /// </summary>
        Silver,

        /// <summary>
        /// Bronze tier.
        /// </summary>
        Bronze,

        /// <summary>
        /// Iron tier.
        /// </summary>
        Iron,
        
        /// <summary>
        /// Unranked.
        /// </summary>
        Unranked
    }


    public static class TierExtensions
    {
	    public static string ToApiString(this Tier tier)
	    {
		    return tier switch
		    {
			    Tier.Master => "MASTER",
			    Tier.Challenger => "CHALLENGER",
			    Tier.Diamond => "DIAMOND",
			    Tier.Platinum => "PLATINUM",
			    Tier.Gold => "GOLD",
			    Tier.Silver => "SILVER",
			    Tier.Bronze => "BRONZE",
			    Tier.Iron => "IRON",
			    Tier.Unranked => "UNRANKED",
			    _ => throw new ArgumentOutOfRangeException(nameof(tier), tier, null)
		    };
	    }
    }
}
