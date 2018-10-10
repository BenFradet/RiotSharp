using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticVersionEndpoint : IStaticEndpoint
    {
        Task<List<string>> GetAllAsync();
    }
}
