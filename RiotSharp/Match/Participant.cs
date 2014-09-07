using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a participant in a match (Match API).
    /// </summary>
    public class Participant
    {
        internal Participant() { }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// First summoner spell ID.
        /// </summary>
        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }

        /// <summary>
        /// Second summoner spell ID.
        /// </summary>
        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        /// <summary>
        /// Participant statistics.
        /// </summary>
        [JsonProperty("stats")]
        public ParticipantStats Stats { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Timeline data.
        /// </summary>
        [JsonProperty("timeline")]
        public ParticipantTimeline Timeline { get; set; }
    }
}
