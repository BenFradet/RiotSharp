using Newtonsoft.Json;

namespace RiotSharp.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// Team or summoner in a league (League API).
    /// </summary>
    public class LeaguePosition
    {
        internal LeaguePosition()
        {
        }

        /// <summary>
        /// The name of the league of the participant.
        /// Only when it's called from the GetLeaguePositions()
        /// </summary>
        [JsonProperty("leagueName")]
        public string LeagueName { get; set; }

        /// <summary>
        /// The queue type of the league.
        /// Only for the GetLeaguePositions() -> don't exist when it's an entry from a League
        /// as there is already the Queue property in this case.
        /// </summary>
        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        /// <summary>
        /// The rank of the participant in a league.
        /// </summary>
        [JsonProperty("rank")]
        public string Rank { get; set; }

        ///<summary>
        /// The league tier of the participant.
        /// Only when it's called from the GetLeaguePositions()
        /// </summary>
        [JsonProperty("tier")]
        public string Tier { get; set; }

        /// <summary>
        /// Specifies if the participant is fresh blood.
        /// </summary>
        [JsonProperty("freshBlood")]
        public bool FreshBlood { get; set; }

        /// <summary>
        /// Specifies if the participant is on a hot streak.
        /// </summary>
        [JsonProperty("hotStreak")]
        public bool HotStreak { get; set; }

        /// <summary>
        /// Specifies if the participant is inactive.
        /// </summary>
        [JsonProperty("inactive")]
        public bool Inactive { get; set; }

        /// <summary>
        /// Specifies if the participant is a veteran.
        /// </summary>
        [JsonProperty("veteran")]
        public bool Veteran { get; set; }

        /// <summary>
        /// The league points of the participant.
        /// </summary>
        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }

        /// <summary>
        /// The number of losses for the participant.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Mini series data for the participant. Only present if the participant is currently in a mini series.
        /// </summary>
        [JsonProperty("miniSeries")]
        public MiniSeries MiniSeries { get; set; }

        /// <summary>
        /// The ID of the participant (i.e., summoner or team) represented by this entry.
        /// </summary>
        [JsonProperty("playerOrTeamId")]
        public string PlayerOrTeamId { get; set; }

        /// <summary>
        /// The name of the the participant (i.e., summoner or team) represented by this entry.
        /// </summary>
        [JsonProperty("playerOrTeamName")]
        public string PlayerOrTeamName { get; set; }

        /// <summary>
        /// The number of wins for the participant.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
