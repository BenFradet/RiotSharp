namespace RiotSharp.StaticDataEndpoint
{
    class ItemStaticWrapper
    {
        public ItemStatic ItemStatic { get; private set; }
        public Language Language { get; private set; }
        public ItemData ItemData { get; private set; }

        public ItemStaticWrapper(ItemStatic item, Language language, ItemData itemData)
        {
            ItemStatic = item;
            Language = language;
            ItemData = itemData;
        }
    }
}
