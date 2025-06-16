using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a CurrentGameParticipant in the API.
    /// </summary>
    public class CurrentGameParticipant
    {
        /// <summary>
        /// Flag indicating whether or not this participant is a bot
        /// </summary>
        [JsonPropertyName("bot")]
        public bool Bot { get; set; }

        /// <summary>
        /// The ID of the champion played by this participant
        /// </summary>
        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// The ID of the profile icon used by this participant
        /// </summary>
        [JsonPropertyName("profileIconId")]
        public long ProfileIconId { get; set; }

        /// <summary>
        /// The ID of the first summoner spell used by this participant
        /// </summary>
        [JsonPropertyName("spell1Id")]
        public long SummonerSpell1 { get; set; }

        /// <summary>
        /// The ID of the second summoner spell used by this participant
        /// </summary>
        [JsonPropertyName("spell2Id")]
        public long SummonerSpell2 { get; set; }

        /// <summary>
        /// The encrypted summoner ID of this participant
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// The summoner name of this participant
        /// </summary>
        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// The team ID of this participant, indicating the participant's team
        /// </summary>
        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }

        /// <summary>
        /// List of Game Customizations
        /// </summary>
        [JsonPropertyName("gameCustomizationObjects")]
        public List<GameCustomizationObject> GameCustomizationObjects { get; set; }

        /// <summary>
        /// Perks/Runes Reforged Information
        /// </summary>
        [JsonPropertyName("perks")]
        public Perks Perks { get; set; }
    }
}
