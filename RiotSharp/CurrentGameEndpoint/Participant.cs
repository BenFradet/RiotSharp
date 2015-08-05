using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.CurrentGameEndpoint
{
    /// <summary>
    /// Class representing a Participant in the API.
    /// </summary>
    public class Participant
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
        /// The masteries used by this participant
        /// </summary>
        [JsonProperty("masteries")]
        public List<Mastery> Masteries { get; set; }

        /// <summary>
        /// The ID of the profile icon used by this participant
        /// </summary>
        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }

        /// <summary>
        /// The runes used by this participant
        /// </summary>
        [JsonProperty("runes")]
        public List<Rune> Runes { get; set; }

        /// <summary>
        /// The ID of the first summoner spell used by this participant
        /// </summary>
        [JsonProperty("spell1Id")]
        public long SummonuerSpell1 { get; set; }

        /// <summary>
        /// The ID of the second summoner spell used by this participant
        /// </summary>
        [JsonProperty("spell2Id")]
        public long SummonerSpell2 { get; set; }

        /// <summary>
        /// The summoner ID of this participant
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

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
    }
}
