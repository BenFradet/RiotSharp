using RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The static Mastery Endpoint
    /// </summary>
    public interface IStaticMasteryEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all masteries asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An MasteryListStatic object containing all masteries.</returns>
        Task<MasteryListStatic> GetAllAsync(string version, Language language = Language.en_US);
    }
}
