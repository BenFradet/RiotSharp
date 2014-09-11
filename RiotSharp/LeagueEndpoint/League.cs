using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.LeagueEndpoint
{
    /// <summary>
    /// Class representing a League in the API.
    /// </summary>
    [Serializable]
    public class League
    {
        internal League() { }

        /// <summary>
        /// The requested league entries.
        /// </summary>
        [JsonProperty("entries")]
        public List<LeagueEntry> Entries { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the relevant participant that is a member of this league (i.e., a requested summoner ID,
        /// a requested team ID, or the ID of a team to which one of the requested summoners belongs).
        /// Only present when full league is requested so that participant's entry can be identified.
        /// Not present when individual entry is requested.
        /// </summary>
        [JsonProperty("participantId")]
        public string ParticipantId { get; set; }

        /// <summary>
        /// League queue (eg: RankedSolo5x5).
        /// </summary>
        [JsonProperty("queue")]
        [JsonConverter(typeof(QueueConverter))]
        public Queue Queue { get; set; }

        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierConverter))]
        public Tier Tier { get; set; }
    }
}
