using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item.Cache
{
    class ItemListStaticWrapper
    {
        [JsonProperty]
        public ItemListStatic ItemListStatic { get; private set; }
        public Language Language { get; private set; }
        public ItemData ItemData { get; private set; }

        public ItemListStaticWrapper(ItemListStatic items, Language language, ItemData itemData)
        {
            ItemListStatic = items;
            Language = language;
            ItemData = itemData;
        }
    }
}
