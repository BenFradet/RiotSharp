using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    ///     Represents the scores of a <see cref="Player" />.
    /// </summary>
    public class PlayerScores
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerScores" /> class.
        /// </summary>
        internal PlayerScores() { }

        /// <summary>
        ///     Gets or sets the number of assists.
        /// </summary>
        [JsonProperty("assists")]
        public int Assists { get; set; }

        /// <summary>
        ///     Gets or sets the number of killed minions and monsters.
        /// </summary>
        [JsonProperty("creepScore")]
        public int Creeps { get; set; }

        /// <summary>
        ///     Gets or sets the number of deaths.
        /// </summary>
        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        /// <summary>
        ///     Gets or sets the number of champion kills.
        /// </summary>
        [JsonProperty("kills")]
        public int Kills { get; set; }

        /// <summary>
        ///     Gets or sets the vision score.
        /// </summary>
        [JsonProperty("wardScore")]
        public double Vision { get; set; }
    }
}