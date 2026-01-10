using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums.Converters
{
    public class PlatformConverter : JsonConverter<Platform>
    {
        public override Platform Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParsePlatform(value);
        }

        public override void Write(Utf8JsonWriter writer, Platform value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }

        private static Platform ParsePlatform(string? value)
        {
            return value switch
            {
                "windows" => Platform.Windows,
                "macos" => Platform.MacOS,
                "android" => Platform.Android,
                "ios" => Platform.iOS,
                "ps4" => Platform.PS4,
                "xbone" => Platform.XboxOne,
                "switch" => Platform.Switch,
                _ => Platform.Windows
            };
        }
    }
}
