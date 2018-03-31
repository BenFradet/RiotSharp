using RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticReforgedRuneEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a reforged rune asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="reforgedRuneId">Id of the reforged rune to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A summoner spell.</returns>
        Task<ReforgedRuneStatic> GetReforgedRuneAsync(Region region, int reforgedRuneId, Language language = Language.en_US, string version = null);

        /// <summary>
        /// Get a list of all reforged runes asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A summoner spell.</returns>
        Task<List<ReforgedRuneStatic>> GetReforgedRunesAsync(Region region, Language language = Language.en_US, string version = null);

        /// <summary>
        /// Get a reforged rune path asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="reforgedRunePathId">Id of the reforged rune path to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A summoner spell.</returns>
        Task<ReforgedRunePathStatic> GetReforgedRunePathAsync(Region region, int reforgedRunePathId,
            Language language = Language.en_US, string version = null);

        /// <summary>
        /// Get a list of all reforged rune paths asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A summoner spell.</returns>
        Task<List<ReforgedRunePathStatic>> GetReforgedRunePathsAsync(Region region, Language language = Language.en_US, string version = null);
    }
}
