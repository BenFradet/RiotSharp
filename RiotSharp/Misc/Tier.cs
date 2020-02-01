using Newtonsoft.Json;
using RiotSharp.Misc.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Misc
{
    /// <summary>
    /// Tier of the league (League API).
    /// </summary>
    [JsonConverter(typeof(TierConverter))]
    public enum Tier
    {
        /// <summary>
        /// Master tier.
        /// </summary>
        Master,

        /// <summary>
        /// Challenger tier.
        /// </summary>
        Challenger,

        /// <summary>
        /// Diamon tier.
        /// </summary>
        Diamond,

        /// <summary>
        /// Platinum tier.
        /// </summary>
        Platinum,

        /// <summary>
        /// Gold tier.
        /// </summary>
        Gold,

        /// <summary>
        /// Silver tier.
        /// </summary>
        Silver,

        /// <summary>
        /// Bronze tier.
        /// </summary>
        Bronze,

        /// <summary>
        /// Iron tier.
        /// </summary>
        Iron,

        /// <summary>
        /// Unranked.
        /// </summary>
        Unranked
    }
}
