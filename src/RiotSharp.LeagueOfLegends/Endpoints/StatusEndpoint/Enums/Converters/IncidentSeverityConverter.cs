using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums.Converters
{
    public class IncidentSeverityConverter : JsonConverter<IncidentSeverity>
    {
        public override IncidentSeverity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParseIncidentSeverity(value);
        }

        public override void Write(Utf8JsonWriter writer, IncidentSeverity value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }
        private static IncidentSeverity ParseIncidentSeverity(string? value)
        {
            return value switch
            {
                "info" => IncidentSeverity.Info,
                "warning" => IncidentSeverity.Warning,
                "critical" => IncidentSeverity.Critical,
                _ => IncidentSeverity.Info
            };
        }
    }
}
