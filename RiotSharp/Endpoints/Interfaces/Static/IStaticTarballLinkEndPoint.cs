using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticTarballLinkEndPoint : IStaticEndpoint
    {
        /// <summary>
        /// Get the link for a tarball
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <returns>A string containing the URL for the tarball file.</returns>
        string Get(string version, bool useHttps = true);
    }
}