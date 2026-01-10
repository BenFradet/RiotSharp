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
    /// Enum representing gaming platforms
    /// </summary>
    [JsonConverter(typeof(PlatformConverter))]
    public enum Platform
    {
        /// <summary>
        /// Windows PC
        /// </summary>
        Windows,

        /// <summary>
        /// macOS
        /// </summary>
        MacOS,

        /// <summary>
        /// Android
        /// </summary>
        Android,

        /// <summary>
        /// iOS
        /// </summary>
        iOS,

        /// <summary>
        /// PlayStation 4
        /// </summary>
        PS4,

        /// <summary>
        /// Xbox One
        /// </summary>
        XboxOne,

        /// <summary>
        /// Nintendo Switch
        /// </summary>
        Switch
    }

    static class PlatformExtension
    {
        public static string ToCustomString(this Platform platform)
        {
            switch (platform)
            {
                case Platform.Windows:
                    return "windows";
                case Platform.MacOS:
                    return "macos";
                case Platform.Android:
                    return "android";
                case Platform.iOS:
                    return "ios";
                case Platform.PS4:
                    return "ps4";
                case Platform.XboxOne:
                    return "xbone";
                case Platform.Switch:
                    return "switch";
                default:
                    return string.Empty;
            }
        }
    }
}
