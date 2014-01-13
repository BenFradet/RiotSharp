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
    /// Class representing a Team in the API.
    /// </summary>
    [Obsolete("The team api v2.1 is deprecated, please use Team instead.")]
    public class TeamV21 : Thing
    {
        public TeamV21(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateDate { get; set; }

        [JsonProperty("lastGameDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastGameDate { get; set; }

        [JsonProperty("lastJoinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastJoinDate { get; set; }

        [JsonProperty("lastJoinedRankedTeamQueueDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastJoinedRankedTeamQueueDate { get; set; }

        [JsonProperty("matchHistory")]
        public List<MatchHistorySummary> MatchHistory { get; set; }

        [JsonProperty("messageOfDay")]
        public MessageOfDay MessageOfDay { get; set; }

        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roster")]
        public Roster Roster { get; set; }

        [JsonProperty("secondLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime SecondLastJoinDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("teamId")]
        public TeamId TeamId { get; set; }

        [JsonProperty("teamStatSummary")]
        public TeamStatSummary TeamStatSummary { get; set; }

        [JsonProperty("thirdLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ThirdLastJoinDate { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
