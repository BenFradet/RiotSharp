using RiotSharp.Endpoints.StaticDataEndpoint.Map;
using RiotSharp.Misc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticMapEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get maps asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A list of objects representing maps.</returns>
        Task<List<MapStatic>> GetAllAsync(string version, Language language = Language.en_US);
    }
}