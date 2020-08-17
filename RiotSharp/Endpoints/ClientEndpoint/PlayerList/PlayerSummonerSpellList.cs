using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    /// Represents the list of used <see cref="PlayerSummonerSpell"/> of a <see cref="Player"/>.
    /// </summary>
    public class PlayerSummonerSpellList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSummonerSpellList"/> class.
        /// </summary>
        internal PlayerSummonerSpellList() { }

        /// <summary>
        /// Gets or sets the first used <see cref="PlayerSummonerSpell"/>.
        /// </summary>
        [JsonProperty("summonerSpellOne")]
        public PlayerSummonerSpell One { get; set; }

        /// <summary>
        /// Gets or sets the second used <see cref="PlayerSummonerSpell"/>.
        /// </summary>
        [JsonProperty("summonerSpellTwo")]
        public PlayerSummonerSpell Two { get; set; }
    }
}