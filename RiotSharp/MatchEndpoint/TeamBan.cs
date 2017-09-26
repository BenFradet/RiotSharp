using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.MatchEndpoint
{
    public class TeamBan
    {
        internal TeamBan() { }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }
    }
}
