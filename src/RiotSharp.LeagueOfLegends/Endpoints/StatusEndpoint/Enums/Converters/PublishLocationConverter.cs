using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums.Converters
{
    public class PublishLocationConverter : JsonConverter<PublishLocation>
    {
        public override PublishLocation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParsePublishLocation(value);
        }

        public override void Write(Utf8JsonWriter writer, PublishLocation value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }

        private static PublishLocation ParsePublishLocation(string? value)
        {
            return value switch
            {
                "riotclient" => PublishLocation.RiotClient,
                "riotstatus" => PublishLocation.RiotStatus,
                "game" => PublishLocation.Game,
                _ => PublishLocation.RiotClient
            };
        }
    }
}
