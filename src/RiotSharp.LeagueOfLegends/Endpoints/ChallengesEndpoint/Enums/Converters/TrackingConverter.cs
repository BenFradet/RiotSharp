using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums.Converters
{
    public class TrackingConverter : JsonConverter<Tracking>
    {
        public override Tracking Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            switch (value)
            {
                case "LIFETIME":
                    return Tracking.Lifetime;
                case "SEASON":
                    return Tracking.Season;
            }

            // Default to Lifetime if unknown value
            return Tracking.Lifetime;
        }

        public override void Write(Utf8JsonWriter writer, Tracking value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }
    }
}
