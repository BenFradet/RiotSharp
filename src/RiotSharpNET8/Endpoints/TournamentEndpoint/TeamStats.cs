using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Class representing a team in a match (Match API).
    /// </summary>
    public class TeamStats
    {
        internal TeamStats() { }

        /// <summary>
        /// If game was draft mode, contains banned champion data, otherwise null.
        /// </summary>
        [JsonPropertyName("bans")]
        public List<TeamBan> Bans { get; set; }

        /// <summary>
        /// Number of times the team killed baron.
        /// </summary>
        [JsonPropertyName("baronKills")]
        public int BaronKills { get; set; }

        /// <summary>
        /// If game was a dominion game, specifies the points the team had at game end, otherwise null.
        /// </summary>
        [JsonPropertyName("dominionVictoryScore")]
        public long DominionVictoryScore { get; set; }

        /// <summary>
        /// Number of times the team killed dragon.
        /// </summary>
        [JsonPropertyName("dragonKills")]
        public int DragonKills { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got the first baron kill.
        /// </summary>
        [JsonPropertyName("firstBaron")]
        public bool FirstBaron { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got first blood.
        /// </summary>
        [JsonPropertyName("firstBlood")]
        public bool FirstBlood { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got the first dragon kill.
        /// </summary>
        [JsonPropertyName("firstDragon")]
        public bool FirstDragon { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team destroyed the first inhibitor.
        /// </summary>
        [JsonPropertyName("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team killed the first rift herald.
        /// </summary>
        [JsonPropertyName("firstRiftHerald")]
        public bool FirstRiftHerald { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team destroyed the first tower.
        /// </summary>
        [JsonPropertyName("firstTower")]
        public bool FirstTower { get; set; }

        /// <summary>
        /// Number of inhibitors the team destroyed.
        /// </summary>
        [JsonPropertyName("inhibitorKills")]
        public int InhibitorKills { get; set; }

        /// <summary>
        /// Number of rift heralds killed.
        /// </summary>
        [JsonPropertyName("riftHeraldKills")]
        public int RiftHeraldKills { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Number of towers the team destroyed.
        /// </summary>
        [JsonPropertyName("towerKills")]
        public int TowerKills { get; set; }

        /// <summary>
        /// Number of times the team killed vilemaw (Twisted Treeline epic monster).
        /// </summary>
        [JsonPropertyName("vilemawKills")]
        public int VilemawKills { get; set; }

        /// <summary>
        /// A string indicating whether or not the team won.
        /// </summary>
        [JsonPropertyName("win")]
        public string Win { get; set; }
    }
}
