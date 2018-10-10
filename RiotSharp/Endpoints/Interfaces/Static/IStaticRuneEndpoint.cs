using RiotSharp.Endpoints.StaticDataEndpoint.Rune;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticRuneEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all runes asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A RuneListStatic object containing all runes.</returns>
        Task<RuneListStatic> GetAllAsync(string version, Language language = Language.en_US);
    }
}