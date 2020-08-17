using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    /// Represents one of the participating players in the game. <seealso cref="ActivePlayer.ActivePlayer"/>
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="Player"/> class.
        /// </summary>
        internal Player() { }

        /// <summary>
        /// Gets or sets the name of the champion.
        /// </summary>
        [JsonProperty("championName")]
        public string ChampionName { get; set; }
        
        /// <summary>
        /// Gets or sets the raw champion name.
        /// </summary>
        [JsonProperty("rawChampionName")]
        public string RawChampionName { get; set; }

        /// <summary>
        /// Indicates, whether this player is a bot.
        /// </summary>
        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        /// <summary>
        /// Indicates, whether this player is dead.
        /// </summary>
        [JsonProperty("isDead")]
        public bool IsDead { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="PlayerItem"/>.
        /// </summary>
        [JsonProperty("items")]
        public List<PlayerItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PositionType"/>.
        /// </summary>
        [JsonProperty("position")]
        public PositionType Position { get; set; }

        /// <summary>
        /// Gets or sets the respawn timer.
        /// </summary>
        [JsonProperty("respawnTimer")]
        public double RespawnTimer { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PlayerMainRunes"/>.
        /// </summary>
        [JsonProperty("runes")]
        public PlayerMainRunes Runes { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PlayerScores"/>.
        /// </summary>
        [JsonProperty("scores")]
        public PlayerScores Scores { get; set; }

        /// <summary>
        /// Gets or sets the skin id.
        /// </summary>
        [JsonProperty("skinID")]
        public int SkinId { get; set; }

        /// <summary>
        /// Gets or sets the summoner name.
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PlayerSummonerSpellList"/>.
        /// </summary>
        [JsonProperty("summonerSpells")]
        public PlayerSummonerSpellList SummonerSpells { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TeamType"/>.
        /// </summary>
        [JsonProperty("team")]
        public TeamType Team { get; set; }
    }
}