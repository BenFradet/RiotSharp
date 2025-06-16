using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Item
{
	class ItemsConverter : JsonConverter<Dictionary<int, ItemStatic>>
	{
        public override Dictionary<int, ItemStatic>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var items = new Dictionary<int, ItemStatic>();
			var itemTokens = JsonDocument.ParseValue(ref reader).RootElement;
			foreach (var itemToken in itemTokens.EnumerateObject())
			{
				var item = JsonSerializer.Deserialize<ItemStatic>(itemToken.Value.GetRawText(), options);
				item.Id = Convert.ToInt32(itemToken.Name);
				items.Add(item.Id, item);
			}
			return items;
		}

		public override void Write(Utf8JsonWriter writer, Dictionary<int, ItemStatic> value, JsonSerializerOptions options)
		{
            writer.WriteStartObject();
            foreach (var item in value) 
            {
				writer.WriteStartObject(item.Key.ToString());
				JsonSerializer.Serialize(writer, item.Value, options);
				writer.WriteEndObject();
			}
            writer.WriteEndObject();
		}
		/*
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
        */

        /*
         "1001": {
               "name": "Boots",
               "description": "<mainText><stats><attention>25</attention> Move Speed</stats></mainText><br>",
               "colloq": ";",
               "plaintext": "Slightly increases Move Speed",
               "into": [
                   "3158",
                   "3006",
                   "3009",
                   "3020",
                   "3047",
                   "3111",
                   "3117"
               ],
               "image": {
                   "full": "1001.png",
                   "sprite": "item0.png",
                   "group": "item",
                   "x": 0,
                   "y": 0,
                   "w": 48,
                   "h": 48
               },
               "gold": {
                   "base": 300,
                   "purchasable": true,
                   "total": 300,
                   "sell": 210
               },
               "tags": [
                   "Boots"
               ],
               "maps": {
                   "11": true,
                   "12": true,
                   "21": true,
                   "22": false
               },
               "stats": {
                   "FlatMovementSpeedMod": 25
               }
           },
           "1004": {
               "name": "Faerie Charm",
               "description": "<mainText><stats><attention>50%</attention> Base Mana Regen</stats></mainText><br>",
               "colloq": ";",
               "plaintext": "Slightly increases Mana Regen",
               "into": [
                   "3114",
                   "4642"
               ],
               "image": {
                   "full": "1004.png",
                   "sprite": "item0.png",
                   "group": "item",
                   "x": 48,
                   "y": 0,
                   "w": 48,
                   "h": 48
               },
               "gold": {
                   "base": 250,
                   "purchasable": true,
                   "total": 250,
                   "sell": 175
               },
               "tags": [
                   "ManaRegen"
               ],
               "maps": {
                   "11": true,
                   "12": true,
                   "21": true,
                   "22": false
               },
               "stats": {}
           }
         */
	}
}