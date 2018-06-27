using System;
using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class MatchReference
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
        public Lane Lane { get; set; }

        /// <summary>
        /// The match ID relating to the match.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonProperty("platformId")]
        [JsonConverter(typeof(PlatformConverter))]
        public Platform PlatformID { get; set; }

        /// <summary>
        /// Match queue type.
        /// </summary>
        [JsonProperty("queue")]
        public int Queue { get; set; }

        /// <summary>
        /// The region match was played in.
        /// </summary>
        [JsonProperty("region")]
        public Region Region { get; set; }

        /// <summary>
        /// Participant's role.
        /// </summary>
        [JsonProperty("role")]
        public Role Role { get; set; }

        /// <summary>
        /// Season match was played.
        /// </summary>
        [JsonProperty("season")]
        public Season Season { get; set; }

        /// <summary>
        /// The date/time of which the game lobby was created.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime Timestamp { get; set; }
    }
}
