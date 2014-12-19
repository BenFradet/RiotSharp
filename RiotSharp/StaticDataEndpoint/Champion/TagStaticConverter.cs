using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace RiotSharp.StaticDataEndpoint
{
    class TagStaticConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<string>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue
            , JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Values<string>() == null) return null;
            var list = token.Values<string>();
            var tags = new List<TagStatic>();
            foreach (var str in list)
            {
                switch (str)
                {
                    case "Fighter":
                        tags.Add(TagStatic.Fighter);
                        break;
                    case "Tank":
                        tags.Add(TagStatic.Tank);
                        break;
                    case "Mage":
                        tags.Add(TagStatic.Mage);
                        break;
                    case "Assassin":
                        tags.Add(TagStatic.Assassin);
                        break;
                    case "Support":
                        tags.Add(TagStatic.Support);
                        break;
                    case "Marksman":
                        tags.Add(TagStatic.Marksman);
                        break;
                }
            }
            return tags;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = new List<string>();
            foreach (var tag in (List<TagStatic>)value)
            {
                list.Add(tag.ToString());
            }
            serializer.Serialize(writer, list);
        }
    }
}
