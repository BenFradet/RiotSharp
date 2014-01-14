using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class TeamMemberInfo : Thing
    {
        public TeamMemberInfo() { }

        public TeamMemberInfo(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("inviteDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime InviteDate { get; set; }

        [JsonProperty("joinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime JoinDate { get; set; }

        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
