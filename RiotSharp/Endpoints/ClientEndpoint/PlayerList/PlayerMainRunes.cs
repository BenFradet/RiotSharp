using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    /// Represents the main runes of a <see cref="Player"/>.
    /// </summary>
    public class PlayerMainRunes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerMainRunes"/> class.
        /// </summary>
        internal PlayerMainRunes() { }

        /// <summary>
        /// Gets or sets the keystone <see cref="PlayerRune"/>.
        /// </summary>
        [JsonProperty("keystone")]
        public PlayerRune Keystone { get; set; }

        /// <summary>
        /// Gets or sets the primary <see cref="PlayerRuneTree"/>.
        /// </summary>
        [JsonProperty("primaryRuneTree")]
        public PlayerRuneTree PrimaryTree { get; set; }

        /// <summary>
        /// Gets or sets the secondary <see cref="PlayerRuneTree"/>.
        /// </summary>
        [JsonProperty("secondaryRuneTree")]
        public PlayerRuneTree SecondaryTree { get; set; }
    }
}