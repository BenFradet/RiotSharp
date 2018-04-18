using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticTarballLinkEndPoint : IStaticEndpoint
    {
        /// <summary>
        /// Get the link for a tarball
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A string containing the URL for the tarball file.</returns>
        Task<string> GetTarballLinksAsync(Region region, string version = null);
    }
}