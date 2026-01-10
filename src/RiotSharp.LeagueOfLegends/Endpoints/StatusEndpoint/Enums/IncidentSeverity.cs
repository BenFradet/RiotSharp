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
    /// Enum representing incident severity levels
    /// </summary>
    [JsonConverter(typeof(IncidentSeverityConverter))]
    public enum IncidentSeverity
    {
        /// <summary>
        /// Informational severity
        /// </summary>
        Info,

        /// <summary>
        /// Warning severity
        /// </summary>
        Warning,

        /// <summary>
        /// Critical severity
        /// </summary>
        Critical
    }

    static class IncidentSeverityExtension
    {
        public static string ToCustomString(this IncidentSeverity severity)
        {
            switch (severity)
            {
                case IncidentSeverity.Info:
                    return "info";
                case IncidentSeverity.Warning:
                    return "warning";
                case IncidentSeverity.Critical:
                    return "critical";
                default:
                    return string.Empty;
            }
        }
    }
}
