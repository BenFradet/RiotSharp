using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Item;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticItemEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get an item asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="itemId">Id of the item to retrieve.</param>
        /// <param name="itemData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An item.</returns>
        Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.All,
            Language language = Language.en_US);

        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="itemData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An ItemListStatic object containing all items.</returns>
        Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.All,
            Language language = Language.en_US);
    }
}