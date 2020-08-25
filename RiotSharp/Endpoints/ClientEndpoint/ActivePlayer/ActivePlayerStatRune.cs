using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    /// <summary>
    ///     Represents a stat rune of the <see cref="ActivePlayer" />.
    /// </summary>
    public class ActivePlayerStatRune
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivePlayerStatRune" /> class.
        /// </summary>
        internal ActivePlayerStatRune() { }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the raw description.
        /// </summary>
        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}