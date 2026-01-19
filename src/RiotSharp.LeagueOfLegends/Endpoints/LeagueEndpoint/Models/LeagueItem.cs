using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Models
{
    /// <summary>
    /// A League item
    /// </summary>
    public class LeagueItem
    {
	    /// <summary>
	    /// Specifies if the participant is fresh blood.
	    /// </summary>
	    [JsonPropertyName("freshBlood")]
	    public required bool FreshBlood { get; set; }

	    /// <summary>
	    /// The number of wins for the participant.
	    /// </summary>
	    [JsonPropertyName("wins")]
	    public required int Wins { get; set; }

		/// <summary>
		/// Mini series data for the participant. Only present if the participant is currently in a mini series.
		/// It seems that this isn't returned anymore. Kept for future use or if I missed it.
		/// </summary>
		[JsonPropertyName("miniSeries")]
	    public MiniSeries? MiniSeries { get; set; }

	    /// <summary>
	    /// Specifies if the participant is inactive.
	    /// </summary>
	    [JsonPropertyName("inactive")]
	    public required bool Inactive { get; set; }

	    /// <summary>
	    /// Specifies if the participant is a veteran.
	    /// </summary>
	    [JsonPropertyName("veteran")]
	    public required bool Veteran { get; set; }
          
	    /// <summary>
	    /// Specifies if the participant is on a hot streak.
	    /// </summary>
	    [JsonPropertyName("hotStreak")]
	    public required bool HotStreak { get; set; }

	    /// <summary>
	    /// The rank of the participant in a league.
	    /// Pretty sure it is the same as division.
	    /// </summary>
	    [JsonPropertyName("rank")]
	    public required Division Rank { get; set; }

	    /// <summary>
        /// The league points of the participant.
        /// </summary>
        [JsonPropertyName("leaguePoints")]
        public required int LeaguePoints { get; set; }

        /// <summary>
        /// The number of losses for the participant.
        /// </summary>
        [JsonPropertyName("losses")]
        public required int Losses { get; set; }

        /// <summary>
        /// The encrypted id of the the summoner represented by this entry.
        /// </summary>
        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }
    }
}
