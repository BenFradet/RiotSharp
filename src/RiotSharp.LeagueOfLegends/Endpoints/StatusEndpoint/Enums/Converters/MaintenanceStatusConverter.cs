using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums.Converters
{
    public class MaintenanceStatusConverter : JsonConverter<MaintenanceStatus>
    {
        public override MaintenanceStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParseMaintenanceStatus(value);
        }

        public override void Write(Utf8JsonWriter writer, MaintenanceStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }

        private static MaintenanceStatus ParseMaintenanceStatus(string? value)
        {
            return value switch
            {
                "scheduled" => MaintenanceStatus.Scheduled,
                "in_progress" => MaintenanceStatus.InProgress,
                "complete" => MaintenanceStatus.Complete,
                _ => MaintenanceStatus.Scheduled
            };
        }
    }
}
