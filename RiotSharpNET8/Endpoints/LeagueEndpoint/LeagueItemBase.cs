using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// A League item
    /// </summary>
    public class LeagueItem
    {
        /// <summary>
        /// The rank of the participant in a league.
        /// </summary>
        [JsonPropertyName("rank")]
        public string Rank { get; set; }

        /// <summary>
        /// Specifies if the participant is fresh blood.
        /// </summary>
        [JsonPropertyName("freshBlood")]
        public bool FreshBlood { get; set; }

        /// <summary>
        /// Specifies if the participant is on a hot streak.
        /// </summary>
        [JsonPropertyName("hotStreak")]
        public bool HotStreak { get; set; }

        /// <summary>
        /// Specifies if the participant is inactive.
        /// </summary>
        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }

        /// <summary>
        /// Specifies if the participant is a veteran.
        /// </summary>
        [JsonPropertyName("veteran")]
        public bool Veteran { get; set; }

        /// <summary>
        /// The league points of the participant.
        /// </summary>
        [JsonPropertyName("leaguePoints")]
        public int LeaguePoints { get; set; }

        /// <summary>
        /// The number of losses for the participant.
        /// </summary>
        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Mini series data for the participant. Only present if the participant is currently in a mini series.
        /// </summary>
        [JsonPropertyName("miniSeries")]
        public MiniSeries MiniSeries { get; set; }

        /// <summary>
        /// The name of the the summoner represented by this entry.
        /// </summary>
        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// The encrypted id of the the summoner represented by this entry.
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// The number of wins for the participant.
        /// </summary>
        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }
}
