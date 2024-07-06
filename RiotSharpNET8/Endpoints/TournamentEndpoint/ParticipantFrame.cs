using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Class representing a particular frame for a participant during a match (Match API).
    /// </summary>
    public class ParticipantFrame
    {
        /// <summary>
        /// Participant's current gold.
        /// </summary>
        [JsonPropertyName("currentGold")]
        public int CurrentGold { get; set; }

        /// <summary>
        /// Number of jungle minions killed by participant.
        /// </summary>
        [JsonPropertyName("jungleMinionsKilled")]
        public int JungleMinionsKilled { get; set; }

        /// <summary>
        /// Participant's current level.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// Number of minions killed by participant.
        /// </summary>
        [JsonPropertyName("minionsKilled")]
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Participant's position.
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Participant's total gold.
        /// </summary>
        [JsonPropertyName("totalGold")]
        public int TotalGold { get; set; }

        /// <summary>
        /// Experience earned by participant.
        /// </summary>
        [JsonPropertyName("xp")]
        public int XP { get; set; }
    }
}
