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
    /// Enum representing maintenance status values
    /// </summary>
    [JsonConverter(typeof(MaintenanceStatusConverter))]
    public enum MaintenanceStatus
    {
        /// <summary>
        /// Maintenance is scheduled
        /// </summary>
        Scheduled,

        /// <summary>
        /// Maintenance is in progress
        /// </summary>
        InProgress,

        /// <summary>
        /// Maintenance is complete
        /// </summary>
        Complete
    }

    static class MaintenanceStatusExtension
    {
        public static string ToCustomString(this MaintenanceStatus status)
        {
            switch (status)
            {
                case MaintenanceStatus.Scheduled:
                    return "scheduled";
                case MaintenanceStatus.InProgress:
                    return "in_progress";
                case MaintenanceStatus.Complete:
                    return "complete";
                default:
                    return string.Empty;
            }
        }
    }
}
