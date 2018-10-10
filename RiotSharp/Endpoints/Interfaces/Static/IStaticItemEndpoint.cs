using RiotSharp.Endpoints.StaticDataEndpoint.Item;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
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