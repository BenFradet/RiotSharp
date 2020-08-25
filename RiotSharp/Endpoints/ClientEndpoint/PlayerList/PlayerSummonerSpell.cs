using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    ///     Represents a summoner spell used by a <see cref="Player" />.
    /// </summary>
    public class PlayerSummonerSpell
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerSummonerSpell" /> class.
        /// </summary>
        internal PlayerSummonerSpell() { }

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the raw display name.
        /// </summary>
        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the raw description.
        /// </summary>
        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}