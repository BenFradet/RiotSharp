// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemStaticWrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The item static wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The item static wrapper.
    /// </summary>
    class ItemStaticWrapper
    {
        /// <summary>
        /// Gets the item static.
        /// </summary>
        public ItemStatic ItemStatic { get; private set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the item data.
        /// </summary>
        public ItemData ItemData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemStaticWrapper"/> class.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <param name="itemData">
        /// The item data.
        /// </param>
        public ItemStaticWrapper(ItemStatic item, Language language, ItemData itemData)
        {
            ItemStatic = item;
            Language = language;
            ItemData = itemData;
        }
    }
}
