using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Item.Cache
{
    internal class ItemListStaticWrapper
    {
        [JsonInclude]
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
