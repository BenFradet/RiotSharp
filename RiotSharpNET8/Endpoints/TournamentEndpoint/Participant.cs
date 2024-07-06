using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.LeagueEndpoint.Enums;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
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
        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// List of mastery information.
        /// </summary>
        [JsonPropertyName("masteries")]
        public List<Mastery> Masteries { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// List of rune information.
        /// </summary>
        [JsonPropertyName("runes")]
        public List<Rune> Runes { get; set; }

        /// <summary>
        /// First summoner spell ID.
        /// </summary>
        [JsonPropertyName("spell1Id")]
        public int Spell1Id { get; set; }

        /// <summary>
        /// Second summoner spell ID.
        /// </summary>
        [JsonPropertyName("spell2Id")]
        public int Spell2Id { get; set; }

        /// <summary>
        /// Participant statistics.
        /// </summary>
        [JsonPropertyName("stats")]
        public ParticipantStats Stats { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Timeline data.
        /// </summary>
        [JsonPropertyName("timeline")]
        public ParticipantTimeline Timeline { get; set; }
        
        /// <summary>
        /// Highest achieved season tier.
        /// </summary>
        [JsonPropertyName("highestAchievedSeasonTier")]
        public Tier HighestAchievedSeasonTier { get; set; }
    }
}
