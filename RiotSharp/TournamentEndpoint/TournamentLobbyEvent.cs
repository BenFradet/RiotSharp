using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.TournamentEndpoint
{
    public class TournamentLobbyEvent
    {
        internal TournamentLobbyEvent() { }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
