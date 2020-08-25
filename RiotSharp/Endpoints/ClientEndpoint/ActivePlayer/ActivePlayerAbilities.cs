using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    /// <summary>
    ///     Represents all <see cref="ActivePlayerAbility" /> of the <see cref="ActivePlayer" />.
    /// </summary>
    public class ActivePlayerAbilities
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivePlayerAbilities" /> class.
        /// </summary>
        internal ActivePlayerAbilities() { }

        /// <summary>
        ///     Gets or sets the passive <see cref="ActivePlayerAbility" />.
        /// </summary>
        [JsonProperty("passive")]
        public ActivePlayerAbility Passive { get; set; }

        /// <summary>
        ///     Gets or sets the Q <see cref="ActivePlayerAbility" />.
        /// </summary>
        [JsonProperty("Q")]
        public ActivePlayerAbility Q { get; set; }

        /// <summary>
        ///     Gets or sets the W <see cref="ActivePlayerAbility" />.
        /// </summary>
        [JsonProperty("W")]
        public ActivePlayerAbility W { get; set; }

        /// <summary>
        ///     Gets or sets the E <see cref="ActivePlayerAbility" />.
        /// </summary>
        [JsonProperty("E")]
        public ActivePlayerAbility E { get; set; }

        /// <summary>
        ///     Gets or sets the R <see cref="ActivePlayerAbility" />.
        /// </summary>
        [JsonProperty("R")]
        public ActivePlayerAbility R { get; set; }
    }
}