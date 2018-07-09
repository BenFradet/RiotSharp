using RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings;
using RiotSharp.Misc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticLanguageEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get languages asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <returns>A list of languages.</returns>
        Task<List<Language>> GetLanguagesAsync();

        /// <summary>
        /// Retrieve language strings asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Version of the dragon API.</param>
        /// <returns>A object containing the language strings.</returns>
        Task<LanguageStringsStatic> GetLanguageStringsAsync(string version, Language language = Language.en_US);
    }
}