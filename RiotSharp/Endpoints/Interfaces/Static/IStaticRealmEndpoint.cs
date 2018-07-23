using RiotSharp.Endpoints.StaticDataEndpoint.Realm;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticRealmEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Retrieve realm data asynchronously.
        /// </summary>
        /// <param name="region">Region corresponding to data to retrieve.</param>
        /// <returns>A realm object containing the requested information.</returns>
        Task<RealmStatic> GetAllAsync(Region region);
    }
}