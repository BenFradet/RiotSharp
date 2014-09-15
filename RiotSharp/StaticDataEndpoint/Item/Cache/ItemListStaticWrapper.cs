namespace RiotSharp.StaticDataEndpoint
{
    class ItemListStaticWrapper
    {
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
