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
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>An item.</returns>
        Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.All,
            Language language = Language.en_US, string version = null);

        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="itemData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>An ItemListStatic object containing all items.</returns>
        Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.All,
            Language language = Language.en_US, string version = null);
    }
}