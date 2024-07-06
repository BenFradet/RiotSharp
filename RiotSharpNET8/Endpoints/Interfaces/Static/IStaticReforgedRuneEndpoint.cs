using RiotSharpNET8.Endpoints.StaticDataEndpoint.ReforgedRune;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The static Reforged Runes Endpoint
    /// </summary>
    public interface IStaticReforgedRuneEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all reforged runes asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A summoner spell.</returns>
        Task<List<ReforgedRunePathStatic>> GetAllAsync(string version, Language language = Language.en_US);
    }
}
