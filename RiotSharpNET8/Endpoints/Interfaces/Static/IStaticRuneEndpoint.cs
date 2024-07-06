using RiotSharpNET8.Endpoints.StaticDataEndpoint.Rune;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The static Rune Endpoint
    /// </summary>
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
