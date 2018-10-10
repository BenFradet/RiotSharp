using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item
{
    class ItemsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var items = new Dictionary<int, ItemStatic>();
            var itemTokens = JToken.Load(reader);
            foreach(var itemToken in itemTokens.Children())
            {
                var item = itemToken.First.ToObject<ItemStatic>();
                item.Id = Convert.ToInt32(((JProperty)itemToken).Name);
                items.Add(item.Id, item);
            } 
            return items;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}