using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums
{
    /// <summary>
    /// Enum representing publish locations for status updates
    /// </summary>
    [JsonConverter(typeof(PublishLocationConverter))]
    public enum PublishLocation
    {
        /// <summary>
        /// Riot Client
        /// </summary>
        RiotClient,

        /// <summary>
        /// Riot Status page
        /// </summary>
        RiotStatus,

        /// <summary>
        /// In-game
        /// </summary>
        Game
    }

    static class PublishLocationExtension
    {
        public static string ToCustomString(this PublishLocation location)
        {
            return location switch
            {
                PublishLocation.RiotClient => "riotclient",
                PublishLocation.RiotStatus => "riotstatus",
                PublishLocation.Game => "game",
                _ => string.Empty
            };
        }
    }
}
