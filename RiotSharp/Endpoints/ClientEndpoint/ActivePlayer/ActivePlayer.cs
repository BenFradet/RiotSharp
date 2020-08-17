using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    /// <summary>
    /// Represents the active player.
    /// </summary>
    public class ActivePlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivePlayer"/> class.
        /// </summary>
        internal ActivePlayer() { }

        /// <summary>
        /// Gets or sets the <see cref="ActivePlayerAbilities"/>.
        /// </summary>
        [JsonProperty("abilities")]
        public ActivePlayerAbilities Abilities { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActivePlayerChampionStats"/>.
        /// </summary>
        [JsonProperty("championStats")]
        public ActivePlayerChampionStats ChampionStats { get; set; }

        /// <summary>
        /// Gets or sets the current gold.
        /// </summary>
        [JsonProperty("currentGold")]
        public double CurrentGold { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActivePlayerFullRunes"/>.
        /// </summary>
        [JsonProperty("fullRunes")]
        public ActivePlayerFullRunes Runes { get; set; }

        /// <summary>
        /// Gets or sets the champion level.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the summoner name.
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
}