using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    /// <summary>
    ///     Represents all runes of the <see cref="ActivePlayer" />.
    /// </summary>
    public class ActivePlayerFullRunes
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivePlayerFullRunes" /> class.
        /// </summary>
        internal ActivePlayerFullRunes() { }

        /// <summary>
        ///     Gets or sets the general list of <see cref="PlayerRune" />.
        /// </summary>
        [JsonProperty("generalRunes")]
        public List<PlayerRune> General { get; set; }

        /// <summary>
        ///     Gets or sets the keystone <see cref="PlayerRune" />.
        /// </summary>
        [JsonProperty("keystone")]
        public PlayerRune Keystone { get; set; }

        /// <summary>
        ///     Gets or sets the primary <see cref="PlayerRuneTree" />.
        /// </summary>
        [JsonProperty("primaryRuneTree")]
        public PlayerRuneTree PrimaryTree { get; set; }

        /// <summary>
        ///     Gets or sets the secondary <see cref="PlayerRuneTree" />.
        /// </summary>
        [JsonProperty("secondaryRuneTree")]
        public PlayerRuneTree SecondaryTree { get; set; }

        /// <summary>
        ///     Gets or sets the list of <see cref="ActivePlayerStatRune" />.
        /// </summary>
        [JsonProperty("statRunes")]
        public List<ActivePlayerStatRune> Stats { get; set; }
    }
}