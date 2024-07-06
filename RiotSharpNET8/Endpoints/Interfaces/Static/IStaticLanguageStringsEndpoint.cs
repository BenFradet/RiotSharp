using RiotSharpNET8.Endpoints.StaticDataEndpoint.LanguageStrings;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.Interfaces.Static
{
    /// <summary>
    /// Interface for the static language endpoint
    /// </summary>
    /// <seealso cref="IStaticEndpoint" />
    public interface IStaticLanguageEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get languages asynchronously.
        /// </summary>
        /// <returns>
        /// A list of languages.
        /// </returns>
        Task<List<Language>> GetLanguagesAsync();

        /// <summary>
        /// Retrieve language strings asynchronously.
        /// </summary>
        /// <param name="version">Version of the dragon API.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>
        /// A object containing the language strings.
        /// </returns>
        Task<LanguageStringsStatic> GetLanguageStringsAsync(string version, Language language = Language.en_US);
    }
}