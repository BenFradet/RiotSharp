using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    /// Represents a rune used by a <see cref="Player"/>.
    /// </summary>
    public class PlayerRune
    {
        /// <summary>
        /// Initializes a new instance if the <see cref="PlayerRune"/> class.
        /// </summary>
        internal PlayerRune() { }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the raw display name.
        /// </summary>
        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the raw description.
        /// </summary>
        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}