using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.MatchEndpoint
{
    class MatchReference
    {
        /// <summary>
        /// The ID of the champion played during the match.
        /// </summary>
        [JsonProperty("champion")]
        public long ChampionID { get; set; }

        /// <summary>
        /// Participant's lane.
        /// </summary>
        [JsonProperty("lane")]
        [JsonConverter(typeof(LaneConverter))]
        public Lane Lane { get; set; }

        /// <summary>
        /// The match ID relating to the match.
        /// </summary>
        [JsonProperty("matchId")]
        public long MatchID { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonProperty("platformId")]
        public string PlatformID { get; set; }

        /// <summary>
        /// Match queue type.
        /// </summary>
        [JsonProperty("queueType")]
        [JsonConverter(typeof(QueueTypeConverter))]
        public QueueType QueueType { get; set; }

        /// <summary>
        /// Participant's role.
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(RoleConverter))]
        public Role Role { get; set; }

        /// <summary>
        /// Season match was played.
        /// </summary>
        [JsonProperty("season")]
        [JsonConverter(typeof(SeasonConverter))]
        public Season Season { get; set; }

    }
}
