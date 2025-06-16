using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The static Version Endpoint
    /// </summary>
    public interface IStaticVersionEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Gets a list of all versions
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetAllAsync();
    }
}
