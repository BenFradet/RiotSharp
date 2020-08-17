using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;

namespace RiotSharp.Endpoints.ClientEndpoint
{
    /// <summary>
    /// Represents all data about the currently played game.
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameData"/> class.
        /// </summary>
        internal GameData() { }

        /// <summary>
        /// Gets or sets the <see cref="RiotSharp.Endpoints.ClientEndpoint.ActivePlayer.ActivePlayer"/>.
        /// </summary>
        [JsonProperty("activePlayer")]
        public ActivePlayer.ActivePlayer ActivePlayer { get; set; }

        /// <summary>
        /// Gets or sets the list of participating <see cref="Player"/> (including the <see cref="ActivePlayer"/>).
        /// </summary>
        [JsonProperty("allPlayers")]
        public List<Player> Players { get; set; }

        /// <summary>
        /// Gets or the see <see cref="GameEventList"/>.
        /// </summary>
        [JsonProperty("events")]
        public GameEventList EventList { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="GameStats"/>.
        /// </summary>
        [JsonProperty("gameData")]
        public GameStats Stats { get; set; }
    }
}