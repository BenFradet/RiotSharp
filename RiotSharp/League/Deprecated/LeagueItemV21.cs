using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Team or summoner in a league (League API).
    /// </summary>
    [Obsolete("The league api v2.1 is deprecated, please use LeagueItem instead.")]
    public class LeagueItemV21
    {
        internal LeagueItemV21() { }

        /// <summary>
        /// Has this summoner just entered the league?
        /// </summary>
        [JsonProperty("isFreshBlood")]
        public bool IsFreshBlood { get; set; }

        /// <summary>
        /// Is this summoner on a hot streak?
        /// </summary>
        [JsonProperty("isHotStreak")]
        public bool IsHotStreak { get; set; }

        /// <summary>
        /// Is this summoner inactive?
        /// </summary>
        [JsonProperty("isInactive")]
        public bool IsInactive { get; set; }

        /// <summary>
        /// Has this summoner spent a long time in this league?
        /// </summary>
        [JsonProperty("isVeteran")]
        public bool IsVeteran { get; set; }

        /// <summary>
        /// Date this summoner last played.
        /// </summary>
        [JsonProperty("lastPlayed")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastPlayed { get; set; }

        /// <summary>
        /// League name.
        /// </summary>
        [JsonProperty("leagueName")]
        public string LeagueName { get; set; }

        /// <summary>
        /// League points.
        /// </summary>
        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }

        /// <summary>
        /// Number of losses.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Mini series.
        /// </summary>
        [JsonProperty("miniSeries")]
        public MiniSeries MiniSeries { get; set; }

        /// <summary>
        /// Player or team id.
        /// </summary>
        [JsonProperty("playerOrTeamId")]
        public string PlayerOrTeamId { get; set; }

        /// <summary>
        /// Player or team name.
        /// </summary>
        [JsonProperty("playerOrTeamName")]
        public string PlayerOrTeamName { get; set; }

        /// <summary>
        /// Queue type.
        /// </summary>
        [JsonProperty("queueType")]
        [JsonConverter(typeof(QueueConverter))]
        public Queue QueueType { get; set; }

        /// <summary>
        /// Rank of the league.
        /// </summary>
        [JsonProperty("rank")]
        public string Rank { get; set; }

        /// <summary>
        /// Tier of the league.
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierConverter))]
        public Tier Tier { get; set; }

        /// <summary>
        /// Time until decay.
        /// </summary>
        [JsonProperty("timeUntilDecay")]
        [JsonConverter(typeof(TimeSpanConverterFromMS))]
        public TimeSpan TimeUntilDecay { get; set; }

        /// <summary>
        /// Number of wins.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
