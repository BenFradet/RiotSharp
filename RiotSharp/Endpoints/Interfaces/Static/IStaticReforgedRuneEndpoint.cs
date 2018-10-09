using RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune;
using RiotSharp.Misc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
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
