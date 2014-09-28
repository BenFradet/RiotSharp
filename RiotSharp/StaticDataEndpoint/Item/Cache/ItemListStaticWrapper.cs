// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemListStaticWrapper.cs" company="">
//
// </copyright>
// <summary>
//   The item list static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The item list static wrapper.
    /// </summary>
    class ItemListStaticWrapper
    {
        /// <summary>
        /// Gets the item list static.
        /// </summary>
        public ItemListStatic ItemListStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the item data.
        /// </summary>
        public ItemData ItemData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemListStaticWrapper"/> class.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="itemData">
        /// The item data.
        /// </param>
        public ItemListStaticWrapper(ItemListStatic items, Language language, ItemData itemData)
        {
            ItemListStatic = items;
            Language = language;
            ItemData = itemData;
        }
    }
}
