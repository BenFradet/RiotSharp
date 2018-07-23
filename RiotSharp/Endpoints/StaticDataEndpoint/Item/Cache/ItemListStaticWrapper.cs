using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item.Cache
{
    class ItemListStaticWrapper
    {
        [JsonProperty]
        public ItemListStatic ItemListStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public ItemListStaticWrapper(ItemListStatic items, Language language, string version)
        {
            ItemListStatic = items;
            Language = language;
            Version = version;
        }
    }
}
