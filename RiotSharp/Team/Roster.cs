using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Roster : Thing
    {
        public Roster() { }

        public Roster(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("memberList")]
        public List<TeamMemberInfo> MemberList { get; set; }

        [JsonProperty("ownerId")]
        public long OwnerId { get; set; }
    }
}
