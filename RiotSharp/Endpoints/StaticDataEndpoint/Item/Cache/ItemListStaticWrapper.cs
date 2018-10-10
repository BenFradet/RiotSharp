using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item.Cache
{
    internal class ItemListStaticWrapper
    {
        [JsonProperty]
        public ItemListStatic ItemListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public ItemListStaticWrapper(ItemListStatic items, Language language, string version)
        {
            ItemListStatic = items;
            Language = language;
            Version = version;
        }
    }
}
