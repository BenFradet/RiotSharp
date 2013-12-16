using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class LeagueItem : Thing
    {
        public LeagueItem() { }

        public LeagueItem(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("isFreshBlood")]
        public bool IsFreshBlood { get; set; }
        [JsonProperty("isHotStreak")]
        public bool IsHotStreak { get; set; }
        [JsonProperty("isInactive")]
        public bool IsInactive { get; set; }
        [JsonProperty("isVeteran")]
        public bool IsVeteran { get; set; }
        [JsonProperty("lastPlayed")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastPlayed { get; set; }
        [JsonProperty("leagueName")]
        public String LeagueName { get; set; }
        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("miniSeries")]
        [JsonConverter(typeof(MiniSeriesConverter))]
        public MiniSeries MiniSeries { get; set; }
        [JsonProperty("playerOrTeamId")]
        public String PlayerOrTeamId { get; set; }
        [JsonProperty("playerOrTeamName")]
        public String PlayerOrTeamName { get; set; }
        [JsonProperty("queueType")]
        public String QueueType { get; set; }
        [JsonProperty("rank")]
        public String Rank { get; set; }
        [JsonProperty("tier")]
        public String Tier { get; set; }
        [JsonProperty("timeUntilDecay")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeUntilDecay { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
