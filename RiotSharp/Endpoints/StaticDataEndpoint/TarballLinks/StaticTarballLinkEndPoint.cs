using RiotSharp.Endpoints.Interfaces.Static;

namespace RiotSharp.Endpoints.StaticDataEndpoint.TarballLinks
{
    /// <summary>
    /// Implementation of <see cref="IStaticTarballLinkEndPoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticTarballLinkEndPoint" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticEndpoint" />
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