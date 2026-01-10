using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums
{
    [JsonConverter(typeof(StateConverter))]
    public enum State
    {
        /// <summary>
        /// Not visible and not calculated
        /// </summary>
        Disabled,

        /// <summary>
        /// Not visible, but calculated
        /// </summary>
        Hidden,

        /// <summary>
        /// Visible and calculated
        /// </summary>
        Enabled,

        /// <summary>
        /// Visible, but not calculated
        /// </summary>
        Archived,
    }

    static class StateExtension
    {
        public static string ToCustomString(this State state)
        {
            switch (state)
            {
                case State.Disabled:
                    return "DISABLED";
                case State.Hidden:
                    return "HIDDEN";
                case State.Enabled:
                    return "ENABLED";
                case State.Archived:
                    return "ARCHIVED";
                default:
                    return string.Empty;
            }
        }
    }
}