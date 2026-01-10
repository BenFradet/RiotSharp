using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums.Converters
{
    public class StateConverter : JsonConverter<State>
    {
        public override State Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            switch (value)
            {
                case "DISABLED":
                    return State.Disabled;
                case "HIDDEN":
                    return State.Hidden;
                case "ENABLED":
                    return State.Enabled;
                case "ARCHIVED":
                    return State.Archived;
            }

            // Again, cant return null here
            return State.Disabled;
        }

        public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }
    }
}
