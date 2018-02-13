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
        /// <param name="version">Version of the dragon API.</param>
        /// <returns>A list of objects representing maps.</returns>
        Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "");
    }
}