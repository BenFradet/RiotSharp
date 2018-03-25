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
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A list of objects representing maps.</returns>
        Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = null);
    }
}