using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class ParticipantPerksStatPerks
    {
        internal ParticipantPerksStatPerks() { }

        /// <summary>
        /// Perk Id of the defense stat perk.
        /// </summary>
        [JsonPropertyName("defense")]
        public int Defense { get; set; }

        /// <summary>
        /// Perk Id of the flex stat perk.
        /// </summary>
        [JsonPropertyName("flex")]
        public int Flex { get; set; }

        /// <summary>
        /// Perk Id of the offense stat perk.
        /// </summary>
        [JsonPropertyName("offense")]
        public int Offense { get; set; }
    }
}
