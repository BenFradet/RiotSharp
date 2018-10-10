namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticTarballLinkEndPoint : IStaticEndpoint
    {
        /// <summary>
        /// Get the link for a tarball
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="useHttps">Enables HTTPS based on the boolean. Default is true.</param>
        /// <returns>
        /// A string containing the URL for the tarball file.
        /// </returns>
        string Get(string version, bool useHttps = true);
    }
}