using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a CurrentGameParticipant in the API.
    /// </summary>
    public class CurrentGameParticipant
    {
        /// <summary>
        /// Flag indicating whether or not this participant is a bot
        /// </summary>
        [JsonProperty("bot")]
        public bool Bot { get; set; }

        /// <summary>
        /// The ID of the champion played by this participant
        /// </summary>
        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// The ID of the profile icon used by this participant
        /// </summary>
        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }

        /// <summary>
        /// The ID of the first summoner spell used by this participant
        /// </summary>
        [JsonProperty("spell1Id")]
        public long SummonerSpell1 { get; set; }

        /// <summary>
        /// The ID of the second summoner spell used by this participant
        /// </summary>
        [JsonProperty("spell2Id")]
        public long SummonerSpell2 { get; set; }

        /// <summary>
        /// The encrypted summoner ID of this participant
        /// </summary>
        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// The summoner name of this participant
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// The team ID of this participant, indicating the participant's team
        /// </summary>
        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        /// <summary>
        /// List of Game Customizations
        /// </summary>
        [JsonProperty("gameCustomizationObjects")]
        public List<GameCustomizationObject> GameCustomizationObjects { get; set; }

        /// <summary>
        /// Perks/Runes Reforged Information
        /// </summary>
        [JsonProperty("perks")]
        public Perks Perks { get; set; }
    }
}
