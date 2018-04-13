using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticTarballLinkEndPoint : IStaticEndpoint
    {
        Task<string> GetTarballLinksAsync(Region region, string version = "");
    }
}