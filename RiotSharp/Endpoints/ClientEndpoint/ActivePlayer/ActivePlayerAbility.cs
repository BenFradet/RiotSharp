using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    /// <summary>
    ///     Represents a specific champion ability of the <see cref="ActivePlayer" />.
    /// </summary>
    public class ActivePlayerAbility
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivePlayerAbility" /> class.
        /// </summary>
        internal ActivePlayerAbility() { }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        [JsonProperty("abilityLevel")]
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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