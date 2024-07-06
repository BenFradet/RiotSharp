using RiotSharpNET8.Endpoints.StaticDataEndpoint.Item;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The Static Item Endpoint
    /// </summary>
    public interface IStaticItemEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An ItemListStatic object containing all items.</returns>
        Task<ItemListStatic> GetAllAsync(string version, Language language = Language.en_US);
    }
}
