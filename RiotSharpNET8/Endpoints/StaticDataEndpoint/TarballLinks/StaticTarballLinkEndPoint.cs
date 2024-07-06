using RiotSharpNET8.Endpoints.Interfaces.Static;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.TarballLinks
{
    /// <summary>
    /// Implementation of <see cref="IStaticTarballLinkEndPoint"/>
    /// </summary>
    /// <seealso cref="IStaticTarballLinkEndPoint" />
    /// <seealso cref="IStaticEndpoint" />
    public class StaticTarballLinkEndPoint : IStaticTarballLinkEndPoint
    {
        private const string TarballLinkUrl = StaticEndpointBase.Host + "/cdn/dragontail-{0}.tgz";

        /// <inheritdoc />
        public string Get(string version, bool useHttps = true)
        {
            return useHttps ? "https://" : "http://" + string.Format(TarballLinkUrl, version);
        }
    }
}