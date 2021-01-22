using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class TeamBan
    {
        internal TeamBan() { }

        /// <summary>
        /// The primary key.
        /// </summary>
        public int TeamBanId { get; set; }

        /// <summary>
        /// The pick turn where the champion has been banned.
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
        /// <summary>
        /// ID of the banned champion.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
    }
}
